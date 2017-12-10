using System.Linq;
using Xunit;
using DatabaseModels.Models;
using System.Data.Entity;
using DatabaseModels.Extensions;

namespace BrainItUpTests
{
    [Collection("Database collection")]
    public class DataModelTest
    {
        DatabaseFixture _fixture;
        public DataModelTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
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

        [Fact]
        public void Database_Should_Exists()
        {
            Assert.True(_fixture.BrainItUp.Database.Exists());
        }

        [Fact]
        public void Questions_Should_Exist()
        {
            Assert.True(_fixture.BrainItUp.Questions.Any());
        }

        [Fact]
        public void Answers_Should_Exist()
        {
            Assert.True(_fixture.BrainItUp.Answers.Any());
        }

        [Fact]
        public void Users_Should_Exist()
        {
            Assert.True(_fixture.BrainItUp.Users.Any());
        }

    }
}
