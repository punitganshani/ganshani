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
using System.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Browser;

namespace LuckyDraw
{
    public partial class CircularMotion : UserControl
    {
        #region Private
        
        //Lists
        private ObservableCollection<TextBox> _namelist = new ObservableCollection<TextBox>();
        private int _maxItems = 36;
        private int _maxRotations = 2;

        //Wheel Parameters
        private RadialPanel _radialpanelxaml;
        private double _wheelradiusfactor = 2.4;
        private int _radialpanelradius;
        private int _listWheelLeft = 50;
        private int _listWheelTop = 75;
        private long _anglesteps = 10;
        private double _animationAngleRotation = 10.0;
        private double _angleFactor = 4.0;
        private double _itemWidth = 100.0;
        private double _itemHeight = 50.0;
        
        //Guide Lines
        private Line _line1 = new Line();
        private Line _line2 = new Line();

        //Mask and winner box
        private Rectangle _rectMask = new Rectangle();
        private TextBox _textWinner = new TextBox();

        //Random numbers        
        private int _randomnumber = 0;
        private int _oldrandomnumber = 0;

        //Animations
        private System.Windows.Threading.DispatcherTimer _rotationTimer = new System.Windows.Threading.DispatcherTimer();
        private System.Windows.Threading.DispatcherTimer _timer2 = new System.Windows.Threading.DispatcherTimer();
        private int _stepMax = 40;
        private int _step10 = 10;
        private double _scale10;
        private double _translateFactor10;
        private int _selectedBox10;
        private double _xIncrement = 0.1;
        private double _yIncrement = 0.1;
        #endregion

        public CircularMotion()
        {
            InitializeComponent();

            //Initialize timers
            _rotationTimer.Interval = new TimeSpan(0, 0, 0, 0, 25); // 100 Milliseconds 
            _rotationTimer.Tick += new EventHandler(Each_Tick);
            _timer2.Interval = new TimeSpan(0, 0, 0, 0, 25); // 100 Milliseconds 
            _timer2.Tick += new EventHandler(Each_Tick2);

            //Add graphic objects
            MainCanvas.Children.Add(_line1);
            MainCanvas.Children.Add(_line2);
            MainCanvas.Children.Add(_rectMask);
            MainCanvas.Children.Add(_textWinner);
        }

        private void LoadData()
        {
            _namelist.Clear();

            int backgroundColorCounter = 0;

            IDataFactory dataFactory = DataFactory.Create<StaticData>();
            List<string> data = dataFactory.GetData();

            if (data.Count > _maxItems)
            {
                // throw exception
                return;
            }

            for (int i = 0; i < _maxItems; i++)
            {
                TextBox textBox = new TextBox();
                if (data.Count < _maxItems && i >= data.Count) // no data available
                    textBox.Text = String.Format("EXTRA{0}", data.Count - i + 1);
                else
                    textBox.Text = data[i];

                textBox.FontSize = 14;
                textBox.Height = textBox.FontSize * 2;
                textBox.Width = textBox.Text.Length * textBox.FontSize;
                textBox.Foreground = new SolidColorBrush(Colors.Black);
                System.Windows.Media.Color[] backgroundColorList = { Colors.Blue, Colors.Red, Colors.Green, Colors.Purple, Colors.Magenta };

                textBox.Background = new SolidColorBrush(backgroundColorList[backgroundColorCounter]);
                backgroundColorCounter++;

                if (backgroundColorCounter == (backgroundColorList.Length))
                    backgroundColorCounter = 0;

                _namelist.Add(textBox);
            }

            DataWheel.ItemsSource = _namelist;

            _itemWidth = _namelist[0].Width + 20;
            _itemHeight = _namelist[0].Height + 10;
        }

        private void Data_Load(object sender, RoutedEventArgs e)
        {
            Load_Wheel_Data();
        }

        //Load wheel with data
        private void Load_Wheel_Data()
        {
            DataWheel_Rotate.Angle = 0;
            _oldrandomnumber = 0;
            LoadData();
            RectMaskCreate();
        }

        //Modify wheel diameter
        private void Modify_Wheel(object sender, RoutedEventArgs e)
        {
            ModifyWheelParameters();
            Load_Wheel_Data();
        }

        //Modify wheel diameter
        private void ModifyWheelParameters()
        {
            DataWheel.ItemsSource = "";
            _radialpanelradius = 250;
            _radialpanelxaml.Radius = _radialpanelradius;
            DataWheel.Height = _radialpanelradius * _wheelradiusfactor;
            DataWheel.Width = _radialpanelradius * _wheelradiusfactor;
            DataWheel_Rotate.CenterX = DataWheel.Width / 2;
            DataWheel_Rotate.CenterY = DataWheel.Height / 2;
            Canvas.SetLeft(DataWheel, _listWheelLeft);
            Canvas.SetTop(DataWheel, _listWheelTop);
            RectMaskCreate();
        }

        //Mask to show the item selected, guide lines to debug
        private void RectMaskCreate()
        {
            //rectangle mask to highlight the box area which will be selected.
            _rectMask.Width = _itemWidth;
            _rectMask.Height = _itemHeight;
            _rectMask.Opacity = 0.4;
            SolidColorBrush blueBrush = new SolidColorBrush(Colors.Yellow);
            _rectMask.Fill = blueBrush;
            SolidColorBrush blackBrush = new SolidColorBrush(Colors.Black);
            _rectMask.StrokeThickness = 4;
            _rectMask.Stroke = blackBrush;

            double recttopoffset = _listWheelTop + (DataWheel.Height - _rectMask.Height) / 2;
            double rectleftoffset = _listWheelLeft + DataWheel.Width / 2 + _radialpanelradius - _rectMask.Width / 2;

            Canvas.SetLeft(_rectMask, rectleftoffset);
            Canvas.SetTop(_rectMask, recttopoffset);

            //Vertical and horizontal lines through center of circle, can be removed, for debugging
            _line1.X1 = _listWheelLeft;
            _line1.X2 = _listWheelLeft + DataWheel.Width;
            _line1.Y1 = _line1.Y2 = _listWheelTop + DataWheel.Height / 2;
            _line1.StrokeThickness = 2;

            SolidColorBrush stroke = new SolidColorBrush(Colors.Black);
            _line1.Stroke = stroke;
            _line1.Opacity = 0.1;
            _line2.Stroke = stroke;
            _line2.Opacity = 0.1;
            _line2.X1 = _line2.X2 = _listWheelLeft + DataWheel.Width / 2;
            _line2.Y2 = _listWheelTop;
            _line2.Y1 = _listWheelTop + DataWheel.Height;

            SolidColorBrush colorWinner = new SolidColorBrush(Colors.Transparent);
            _textWinner.Text = "Winner is";
            _textWinner.FontSize = 20;
            _textWinner.Background = colorWinner;
            _textWinner.BorderBrush = colorWinner;
            _textWinner.IsEnabled = false;

            double winnertopoffset = _listWheelTop + (DataWheel.Height / 5.5);
            double winnerleftoffset = _listWheelLeft + DataWheel.Width / 2.5;

            Canvas.SetLeft(_textWinner, winnerleftoffset);
            Canvas.SetTop(_textWinner, winnertopoffset);

            _textWinner.Visibility = Visibility.Collapsed;
        }

        private void RadialPanel1_Loaded(object sender, RoutedEventArgs e)
        {
            _radialpanelxaml = (RadialPanel)sender;

            ModifyWheelParameters();
            Load_Wheel_Data();
        }

        //Spin starts
        private void btnSpin_Click(object sender, RoutedEventArgs e)
        {
            //Bring box to original position from previous win
            ShiftNormal(_oldrandomnumber);
            Random random = new Random();

            _randomnumber = random.Next(0, _maxItems);
            _animationAngleRotation = 360.0 / Convert.ToDouble(_maxItems);
            _anglesteps = Convert.ToInt64((_maxItems * _maxRotations - _randomnumber + _oldrandomnumber) * _angleFactor);

            _anglesteps--;
            DataWheel_Rotate.Angle += _animationAngleRotation / _angleFactor;
            _rotationTimer.Start();
        }

        //rotation timer
        public void Each_Tick(object o, EventArgs sender)
        {
            if (_anglesteps > 0)
            {
                DataWheel_Rotate.Angle += _animationAngleRotation / _angleFactor;
                _anglesteps--;
            }
            else
            {
                _rotationTimer.Stop();
                Winner_Animation();
                _oldrandomnumber = _randomnumber;
            }
        }

        //Animation for winner
        private void Winner_Animation()
        {
            double Scale = 1;
            double translatefactor = -0.5;
            int selectedbox = _randomnumber;
            _textWinner.Visibility = Visibility.Visible;
            Animate(Scale, translatefactor, selectedbox);
        }

        private void Animate(double Scale, double translatefactor, int selectedbox)
        {
            _scale10 = Scale;
            _translateFactor10 = translatefactor;
            _selectedBox10 = selectedbox;
            _xIncrement = _radialpanelradius * 2 * (_translateFactor10 / _stepMax);
            _yIncrement = _radialpanelradius * 1 * (_translateFactor10 / _stepMax);
            _step10 = _stepMax;
            _timer2.Start();
        }

        public void Each_Tick2(object o, EventArgs sender)
        {
            if (_step10 > 0)
            {
                ScaleAnimation(_randomnumber);
                _step10--;
            }
            else
            {
                _timer2.Stop();
            }
        }
        private void ShiftNormal(int boxnumber)
        {
            TransformGroup translateGroup = new TransformGroup();
            ScaleTransform scaleTransform = new ScaleTransform();

            scaleTransform.ScaleX = 1;
            scaleTransform.ScaleY = 1;

            TranslateTransform translateTranform = new TranslateTransform();
            translateTranform.X = 0;
            translateTranform.Y = 0;
            translateGroup.Children.Add(scaleTransform);
            translateGroup.Children.Add(translateTranform);

            _namelist[boxnumber].RenderTransform = translateGroup;

            _textWinner.Visibility = Visibility.Collapsed;
        }
        private void ScaleAnimation(int boxNumber)
        {
            TransformGroup transformGroup = new TransformGroup();
            ScaleTransform scaleTransform = new ScaleTransform();
            PlaneProjection planeProjection = new PlaneProjection();
            scaleTransform.ScaleX = 1 + _scale10 / _step10;
            scaleTransform.ScaleY = 1 + _scale10 / _step10;

            TranslateTransform translateTransform = new TranslateTransform();
            translateTransform.X = _xIncrement * (_stepMax - _step10);
            translateTransform.Y = _yIncrement * (_stepMax - _step10);
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);

            _namelist[boxNumber].RenderTransform = transformGroup;
            _namelist[boxNumber].Projection = planeProjection;
            planeProjection.RotationY = 15 * _step10;
        }
    }
}
