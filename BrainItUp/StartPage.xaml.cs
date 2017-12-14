using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BrainItUp
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.GamePage = new GamePage();
            NavigationService.Navigate(Pages.GamePage);
            Counter counter = new Counter();
            counter.Value = 0;
            
        }

        private void RatingButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.RatingPage = new RatingPage();
            NavigationService.Navigate(Pages.RatingPage);
        }
    }
}
