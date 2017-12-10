using DatabaseModels.Extensions;
using DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            await Database.Entities.UserAnswers.LoadAsync(); 
            _dataGridRating.ItemsSource = Database.Entities.UserAnswers.Local.AsQueryable().GetUserRating();
        }

    }
}
