using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LuckyDraw
{
    public partial class FlyingMotion : UserControl
    {
        IOrderedEnumerable<string> _randomizedData;
        Random _random;
        DispatcherTimer _timer;
        public FlyingMotion()
        {
            InitializeComponent();

            _random = new Random();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += new EventHandler(_timer_Tick);

            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            Color newColor = Color.FromArgb(255, (byte)_random.Next(0, 255), (byte)_random.Next(0, 255), (byte)_random.Next(0, 255));
            pathListBox1.Foreground = new SolidColorBrush(newColor);   
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //IDataFactory dataFactory = DataFactory.Create<StaticData>();
            //List<string> data = dataFactory.GetData();

            DataService.LuckyDrawServiceClient client = new DataService.LuckyDrawServiceClient();
            client.GetNamesCompleted += new EventHandler<DataService.GetNamesCompletedEventArgs>(client_GetNamesCompleted);
            client.GetNamesAsync();
        }

        void client_GetNamesCompleted(object sender, DataService.GetNamesCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
                return;
            }

            _randomizedData = e.Result.Names.OrderBy(x => Guid.NewGuid());
            pathListBox1.ItemsSource = _randomizedData;
            sbAnimateChars.Begin();
        }

        private void btnWinner_Click(object sender, RoutedEventArgs e)
        {
            if (_randomizedData != null)
            {
                sbAnimateChars.Stop();

                pathListBox1.Visibility = System.Windows.Visibility.Collapsed;

                int selectedWinnerIndex = _random.Next(0, _randomizedData.Count());

                string selectedWinner = _randomizedData.Skip(selectedWinnerIndex).First();
                txtWinner.Text = "Winner is " + selectedWinner;
                txtWinner.Opacity = 1.0;

                animateWinner.Begin();

                btnWinner.Visibility = System.Windows.Visibility.Collapsed;

                _timer.Stop();
            }
        }
    }
}
