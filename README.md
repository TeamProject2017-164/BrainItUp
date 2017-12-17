# BrainItUp
## Пояснительная записка

Интеллектуальная игра Brain It Up. 

## Аннотация

Цель игры отвечать правильно на поставленные вопросы в течение одной минуты. 
На каждый вопрос дается не более 10 секунд. Если результат игры вас устраивает, вы можете поучаствовать 
в рейтинге с другими игроками, сохранив свои результаты под своим псевдонимом.

## Репозиторий

https://github.com/TeamProject2017-164/BrainItUp/

## Authors

* **Кузьмина Любовь** разработка базы данных, тестовых сценариев, интеграция приложения с базой данных 
* **Романова Дарья** разработка программного интерфейса и дизайна
* **Shamazova Leysan** разработка логики приложения

## Список классов
* App - приложение
* MainWindow - основное окно приложения
* StartPage - стартовая страница приложения с логотипом
![Start](https://github.com/TeamProject2017-164/BrainItUp/master/ScreenShoots/Start.png)
* RatingPage - страница с рейтингом игроков
![Rating](https://github.com/TeamProject2017-164/BrainItUp/master/ScreenShoots/Rating.png)
* GamePage - основная игровая страница приложения
![Game](https://github.com/TeamProject2017-164/BrainItUp/master/ScreenShoots/Game.png)
* FinishPage - финальная страница приложения
![Finish](https://github.com/TeamProject2017-164/BrainItUp/master/ScreenShoots/Finish.png)
* BrainItUpMessageBox - класс для вывода однотипных сообщений
* Counter - счетчик правильных и неправильных ответов пользователя
* Database - класс для доступа к базе данных с помощью Entity Framework 
* Pages - класс для доступа к страницам приложения

## Установка

Используйте нижеуказанные шаги, чтобы запустить проект

```
Склонируйте или скачайте репозиторий. Откройте Database проект, найдите и дважды кликните на Database.publish.xml, нажмите кнопку Publish (Публикация). 
```

Если публикация базы данных прошла успешно

```
Откройте проект BrainItUp, установите его, как Startup Project (стартовый проект) и запустите приложение.
```
## Тестовые сценарии

* Запустите приложение, нажмите кнопку Start! Появляется страница с вопросом и четырьмя ответами. 
![Start](https://github.com/TeamProject2017-164/BrainItUp/master/ScreenShoots/Start.png)
* Выберите ответ на вопрос и нажмите соответствующий ему ответ. Появится следующий вопрос.
![Game](https://github.com/TeamProject2017-164/BrainItUp/master/ScreenShoots/Game.png)
* Если не отвечать на вопрос в течение 10 секунд, данный вопрос считается не отвеченным и появится следующий вопрос.
* По истечении 60 секунд, вы будете переброшены на финишную страницу.
* На финишной странице можете сохранить свои результаты для рейтинга, начать игру заново, либо посмотреть рейтинг игроков.
![Finish](https://github.com/TeamProject2017-164/BrainItUp/master/ScreenShoots/Finish.png)
* На странице рейтинга отображается рейтинг других игроков
![Rating](https://github.com/TeamProject2017-164/BrainItUp/master/ScreenShoots/Rating.png)

## Тесты

Откройте Test Explorer (проводник тестов), нажмите Run All (запустить все) и удостоверьтесь, что все тесты зеленые.
В этом случае можно считать, что все работает правильно.

```
        [Fact]
        public void Database_Should_Exists()
        {
            Assert.True(_fixture.BrainItUp.Database.Exists());
        }

		[Fact]
        public async void GetRating_Should_BeOk()
        {
            using (var scope = _fixture.BrainItUp.Database.BeginTransaction())
            {
                //Arrange
                var u1 = new User { NickName = "Ivan" };
                var u2 = new User { NickName = "Hellen" };
                var u3 = new User { NickName = "Paul" };
                var users = new[] { u1, u2, u3 };
                _fixture.BrainItUp.Users.AddRange(users);

                var q1 = new Question { Content = "What?" };
                var q2 = new Question { Content = "Where?" };
                var q3 = new Question { Content = "When?" };
                _fixture.BrainItUp.Questions.AddRange(new[] { q1, q2, q3 });

                await _fixture.BrainItUp.SaveChangesAsync(); 

                var q1a1 = new Answer { Question = q1, Content = "Nothing.", IsCorrect = true };
                var q1a2 = new Answer { Question = q1, Content = "Everything.", IsCorrect = false };
                var q2a1 = new Answer { Question = q2, Content = "Nowhere.", IsCorrect = true };
                var q2a2 = new Answer { Question = q2, Content = "Everywhere.", IsCorrect = false };
                var q3a1 = new Answer { Question = q3, Content = "Then.", IsCorrect = true };
                var q3a2 = new Answer { Question = q3, Content = "Anytime.", IsCorrect = false };
                _fixture.BrainItUp.Answers.AddRange(new[] { q1a1, q1a1, q2a1, q2a2, q3a1, q3a2 });

                await _fixture.BrainItUp.SaveChangesAsync(); 

                var u1q1 = new UserAnswer { User = u1, Answer = q1a1 };
                var u1q2 = new UserAnswer { User = u1, Answer = q2a1 };
                var u1q3 = new UserAnswer { User = u1, Answer = q3a1 };
				ж
                var u2q1 = new UserAnswer { User = u2, Answer = q1a2 };
                var u2q2 = new UserAnswer { User = u2, Answer = q2a2 };
                var u2q3 = new UserAnswer { User = u2, Answer = q3a1 };

                var u3q1 = new UserAnswer { User = u3, Answer = q1a1 };
                var u3q2 = new UserAnswer { User = u3, Answer = q2a2 };
                var u3q3 = new UserAnswer { User = u3, Answer = q3a1 };

                _fixture.BrainItUp.UserAnswers.AddRange(new[] {
                    u1q1, u1q2, u1q3,
                    u2q1, u2q2, u2q3,
                    u3q1, u3q2, u3q3,
                });

                await _fixture.BrainItUp.SaveChangesAsync();

                //Act
                await _fixture.BrainItUp.UserAnswers.LoadAsync();
                var query = _fixture.BrainItUp.UserAnswers
                    .Where(x => x.UserId == u1.UserId || x.UserId == u2.UserId || x.UserId == u3.UserId);

                var result = await query.GetUserRating().ToArrayAsync();

                //Assert
                Assert.Equal(result.FirstOrDefault(x => x.User.UserId == u1.UserId).Rate, 100);
                Assert.Equal(result.FirstOrDefault(x => x.User.UserId == u2.UserId).Rate, 33);
                Assert.Equal(result.FirstOrDefault(x => x.User.UserId == u3.UserId).Rate, 66);

                scope.Rollback();
            }
        }
```

## Acknowledgments

* Высшая Школа Экономики
