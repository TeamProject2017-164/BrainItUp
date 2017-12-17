using DatabaseModels.Extensions;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BrainItUp
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class RatingPage : Page
    {
        public RatingPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await Database.Entities.UserAnswers.LoadAsync();
                _dataGridRating.ItemsSource = Database.Entities.
                    UserAnswers.Local.
                    AsQueryable().
                    GetUserRating().
                    OrderByDescending(x=> x.Rate).Take(10);
            }
            catch (Exception ex)
            {
                BrainItUpMessageBox.Error(ex);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.GamePage = new GamePage();
            NavigationService.Navigate(Pages.GamePage);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.StartPage = new StartPage();
            NavigationService.Navigate(Pages.StartPage);
        }
    }
}
