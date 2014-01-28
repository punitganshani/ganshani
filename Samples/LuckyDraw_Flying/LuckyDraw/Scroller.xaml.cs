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
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;

namespace LuckyDraw
{
    public partial class Scroller : UserControl
    {
        private int _startCount;
        private const int showMax = 5;
        private List<string> _actualData;
        private ObservableCollection<DisplayDataModel> _displayData;
        private Random _rand;
        private Timer _timerLuckyDraw;
        private int _backgroundColorCounter;

        private bool _calledForWinner;
        private DateTime _clickedAt;
        private int _timerCounter = 40;
        private int _timeBetweenTick = 250;
        private bool _gameOver = false;

        public Scroller()
        {
            InitializeComponent();

            GetActualData();
            _rand = new Random();
            _displayData = new ObservableCollection<DisplayDataModel>();
        }


        private void ChangeData(object state)
        {
            Dispatcher.BeginInvoke(() =>
            {
                if (_startCount + 4 >= _actualData.Count)
                    _startCount = 0;

                _displayData.RemoveAt(0); // remove firstone..

                string newEntry = _actualData.Skip(_startCount).Take(1).First();

                _displayData.Add(new DisplayDataModel
                {
                    Name = newEntry,
                    Background = GetColor(0)
                });

                _startCount += 1;

                this.DataContext = _displayData;

                if (_calledForWinner)
                {
                    TimeSpan span = TimeSpan.FromMilliseconds(_timeBetweenTick * _timerCounter);
                    txtTimer.Text = String.Format("{0:00}:{1:00}", span.Minutes, span.Seconds);
                    txtMessage.Text = "Waiting ....";
                    rectWinner.Visibility = System.Windows.Visibility.Visible;
                    _timerCounter--;
                }

                if (_calledForWinner && _rand.Next(0, 100000) % 2 == 0) // random hide the items for 1 second
                {
                    animateHideItems.Begin();
                }

                if (_timerCounter == 0)
                {
                    _timerLuckyDraw.Change(-1, -1);
                    _timerLuckyDraw.Dispose();

                    DisplayDataModel winner = _displayData[2];
                    txtMessage.Text = winner.Name;
                    _gameOver = true;

                    soundComplete.Play();
                }
            });
        }

        private Brush GetColor(int counter)
        {
            System.Windows.Media.Color[] backgroundColorList = { Colors.Blue, Colors.Red, 
                                                                   Colors.Brown, Colors.Purple, 
                                                                   Colors.Magenta };

            Brush returnValue = new SolidColorBrush(backgroundColorList[_backgroundColorCounter]);
            _backgroundColorCounter++;

            if (_backgroundColorCounter == (backgroundColorList.Length))
                _backgroundColorCounter = 0;

            return returnValue;
        }

        private void GetActualData()
        {
            _actualData = new List<string>();

            DataService.LuckyDrawServiceClient client = new DataService.LuckyDrawServiceClient();
            client.GetNamesCompleted += new EventHandler<DataService.GetNamesCompletedEventArgs>(client_GetNamesCompleted);
            client.GetNamesAsync();
        }

        void client_GetNamesCompleted(object sender, DataService.GetNamesCompletedEventArgs e)
        {
            _actualData = e.Result.Names.OrderBy(x => Guid.NewGuid()).ToList();  // randomize it

            for (int i = 0; i < showMax; i++)
            {
                _displayData.Add(new DisplayDataModel
                {
                    Background = GetColor(i),
                    Name = _actualData[i]
                });
            }

            _startCount = showMax;
            _timerLuckyDraw = new Timer(ChangeData, null, 1000, 1000);

            animateButton.Begin();
            soundTick.Play();
        }

        private void btnGetMeWinner_Click(object sender, RoutedEventArgs e)
        {
            _calledForWinner = true;
            _timerLuckyDraw.Change(_timeBetweenTick, _timeBetweenTick);
            _clickedAt = DateTime.Now;
            //animateOnClick.Begin();
        }

        private void soundTick_MediaEnded(object sender, RoutedEventArgs e)
        {
            soundTick.Play();
        }
    }
}