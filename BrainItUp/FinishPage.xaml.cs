using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для FinishPage.xaml
    /// </summary>
    public partial class FinishPage : Page
    {
        public FinishPage()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Counter counter = new Counter();
            counter.Value = 0;
            Pages.GamePage = new GamePage(counter);
            NavigationService.Navigate(Pages.GamePage);
        }

        private void RaitingButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.RatingPage = new RatingPage();
            NavigationService.Navigate(Pages.RatingPage);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //здесь мы добавляем имя юзера в таблицу и кол-во его баллов
            MessageBox.Show("Your resuts are saved successfully","",MessageBoxButton.OK);
        }
    }
}
