using DatabaseModels.Models;
using System;
using System.Windows.Threading;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using DatabaseModels.Extensions;

namespace BrainItUp
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private Counter _counter;
        private Question[] _questionsRandomArray;
        private int _currentQuestionIndex;
        private DispatcherTimer _finishTimer;
        private DispatcherTimer _questionTimer;
        private Answer _wrongAnswer;

        public GamePage()
        {
            InitializeComponent();

            QuestionTextBox.Text = "Loading... please wait!";
            AnswerButton1.Content = "";
            AnswerButton2.Content = "";
            AnswerButton3.Content = "";
            AnswerButton4.Content = "";

            _counter = new Counter();
            _currentQuestionIndex = 0;

            _finishTimer = new DispatcherTimer();
            _finishTimer.Tick += new EventHandler(FinishTimer_Tick);
            _finishTimer.Interval = new TimeSpan(0, 1, 0);
            _finishTimer.Start();

            _questionTimer = new DispatcherTimer();
            _questionTimer.Tick += new EventHandler(QuestionTimer_Tick);
            _questionTimer.Interval = new TimeSpan(0, 0, 10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _questionTimer.Stop();

            var buttonClicked = (Button)sender;

            if (buttonClicked == null)
                return;
            
            var answer = (Answer)buttonClicked.Tag;

            if (answer == null)
                return;

            // тут мы проверяем на ответ на правлильность (информ. про это в БД), если ответ верный (if True), 
            // то мы делаем вот что:
            if (answer.IsCorrect)
                _counter.RightAnswers++; //но только если ответ правильный мы это делаем, это надо будет прописать

            // дальше уже просто, для всех случаев, при условии правильности

            var ua = new UserAnswer { User = _counter.User, Answer = answer };

            Database.Entities.UserAnswers.Add(ua);

            LoadNextQuestionData();
        }

        private void ForwardToFinishPage()
        {
            _counter.Value = _currentQuestionIndex;
            _finishTimer.Stop();
            _questionTimer.Stop();
            Pages.FinishPage = new FinishPage(_counter);
            NavigationService.Navigate(Pages.FinishPage);
        }

        private void FinishTimer_Tick(object sender, EventArgs e)
        {
            ForwardToFinishPage();
        }

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            _questionTimer.Stop();

            var ua = new UserAnswer { User = _counter.User, Answer = _wrongAnswer};
            Database.Entities.UserAnswers.Add(ua);

            LoadNextQuestionData();

        }

        private void LoadNextQuestionData()
        {
            _questionTimer.Start();

            if (_currentQuestionIndex == _questionsRandomArray.Length)
            {
                ForwardToFinishPage();
                return;
            }

            var question = _questionsRandomArray[_currentQuestionIndex];

            _currentQuestionIndex++;

            //здесь надо будет загрузить рандомный вопрос из БД!!!
            QuestionTextBox.Text = question.Content;

            //а также варианты ответов 
            //таким образом все ответы выводятся в случайном порядке
            var answersArray = question.Answers.ToArray();

            var randomAnswers = answersArray.RandomizeCollection().ToArray();

            var buttons = new[] { AnswerButton1, AnswerButton2, AnswerButton3, AnswerButton4 };

            _wrongAnswer = null;

            for (var i = 0; i < 4; i++)
            {
                var randomAnswer = randomAnswers[i];
                var button = buttons[i];

                button.Tag = randomAnswer;
                button.Content = randomAnswer.Content;

                if (_wrongAnswer == null && randomAnswer.IsCorrect == false)
                    _wrongAnswer = randomAnswer;
            }

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await Database.Entities.Questions.LoadAsync();

                var questions = Database.Entities.Questions.Local;

                Random rnd = new Random();

                //это случайный индекс вопроса, который будет выводиться пользователю
                //таким образом все вопросы выводятся в случайном порядке

                var questionsArray = questions.ToArray();

                _questionsRandomArray = questionsArray.RandomizeCollection().ToArray();

                LoadNextQuestionData();
            }
            catch (Exception ex)
            {
                BrainItUpMessageBox.Error(ex);
            }
        }
    }
}
