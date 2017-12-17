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
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage(Counter c)
        {
            InitializeComponent();
            counter = c;
            counter.Value += 1;
            LoadData();
            
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }
        Counter counter;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // тут мы проверяем на ответ на правлильность (информ. про это в БД), если ответ верный (if True), 
            // то мы делаем вот что:
            counter.RightAnswers += 1; //но только если ответ правильный мы это делаем, это надо будет прописать

            // дальше уже просто, для всех случаев, не при условии правильности
            LoadData();
                
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Pages.FinishPage = new FinishPage(counter);
            NavigationService.Navigate(Pages.FinishPage);
        }
        private void LoadData()
        {
            Random rnd = new Random();
            int index = rnd.Next(1, 40); //это индекс вопроса, который будет выводиться пользователю 
                                         //(если индексы,конечно, заданы именно таким образом, то есть с 1, по порядку),
                                         //тут типа рассчитано, что вопросов всего 39, поэтому до 40,
                                         //не знаю уж сколько их там на самом деле

            //здесь надо будет загрузить рандомный вопрос из БД!!!
            QuestionTextBox.Text = /*сюда вставляем строку вопроса*/""; //пока строка пустая, потом удалить и заменить на вопрос 
            //а также варианты ответов 
            AnswerButton1.Content = "";
            AnswerButton2.Content = ""; //тут аналогично, просто в кнопки загрузить варианты ответов
            AnswerButton3.Content = "";
            AnswerButton4.Content = "";
        }
    }
}
