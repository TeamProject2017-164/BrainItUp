using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Text.RegularExpressions;

namespace BrainItUp
{
    /// <summary>
    /// Логика взаимодействия для FinishPage.xaml
    /// </summary>
    public partial class FinishPage : Page
    {
        private Counter _counter;
        public FinishPage(Counter c)
        {
            InitializeComponent();
            _counter = c;
            NickNameTextBox.Text = "";
            ResultsTextBox.Text = $"You answered {c.Value} questions and {c.RightAnswers} of them correct!";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Counter counter = new Counter();
            Pages.GamePage = new GamePage();
            NavigationService.Navigate(Pages.GamePage);
        }

        private void RaitingButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.RatingPage = new RatingPage();
            NavigationService.Navigate(Pages.RatingPage);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nickName = NickNameTextBox.Text;
                Regex nickNameRegex = new Regex(@"^[a-zA-ZАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя][a-zA-ZАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0-9]{3,11}$");

                if (nickName == null || !nickNameRegex.IsMatch(nickName))
                {
                    BrainItUpMessageBox.Warning("Bad nick name entered, please use letters and numbers.");
                    return;
                }

                _counter.User.NickName = nickName;
                //здесь мы добавляем имя юзера в таблицу и кол-во его баллов, то есть в БД саму
                Database.Entities.SaveChanges();

                SaveButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                BrainItUpMessageBox.Error(ex);
            }
        }

        private void NickNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NickNameTextBox.Text = "";
        }
    }
}
