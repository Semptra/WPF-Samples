using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace ColorExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random((int)DateTime.Now.Ticks);

        private bool isRandomEnabled = false;

        private bool isRedColorIncreasing = false;
        private readonly DispatcherTimer redColorChangeTimer = new DispatcherTimer();

        private bool isGreenColorIncreasing = false;
        private readonly DispatcherTimer greenColorChangeTimer = new DispatcherTimer();

        private bool isBlueColorIncreasing = false;
        private readonly DispatcherTimer blueColorChangeTimer = new DispatcherTimer();

        private readonly ObjectDataProvider rgbProvider;
        private RGBInput RGBInputData => rgbProvider.Data as RGBInput;

        public MainWindow()
        {
            InitializeComponent();

            rgbProvider = TryFindResource("ColorDataSource") as ObjectDataProvider;

            #region Events

            redColorChangeTimer.Tick += (_, __) =>
            {
                if (RGBInputData.Red == byte.MaxValue)
                {
                    isRedColorIncreasing = false;
                }
                else if (RGBInputData.Red == 0)
                {
                    isRedColorIncreasing = true;
                }

                if (isRedColorIncreasing)
                {
                    RGBInputData.Red++;
                }
                else
                {
                    RGBInputData.Red--;
                }
            };

            greenColorChangeTimer.Tick += (_, __) =>
            {
                if (RGBInputData.Green == byte.MaxValue)
                {
                    isGreenColorIncreasing = false;
                }
                else if (RGBInputData.Green == 0)
                {
                    isGreenColorIncreasing = true;
                }

                if (isGreenColorIncreasing)
                {
                    RGBInputData.Green++;
                }
                else
                {
                    RGBInputData.Green--;
                }
            };

            blueColorChangeTimer.Tick += (_, __) =>
            {
                if (RGBInputData.Blue == byte.MaxValue)
                {
                    isBlueColorIncreasing = false;
                }
                else if (RGBInputData.Blue == 0)
                {
                    isBlueColorIncreasing = true;
                }

                if (isBlueColorIncreasing)
                {
                    RGBInputData.Blue++;
                }
                else
                {
                    RGBInputData.Blue--;
                }
            };

            #endregion
        }

        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRandomEnabled)
            {
                redColorChangeTimer.Interval = GetRandomInterval();
                greenColorChangeTimer.Interval = GetRandomInterval();
                blueColorChangeTimer.Interval = GetRandomInterval();

                redColorChangeTimer.Start();
                greenColorChangeTimer.Start();
                blueColorChangeTimer.Start();

                RandomButton.Content = "Stop";
            }
            else
            {
                redColorChangeTimer.Stop();
                greenColorChangeTimer.Stop();
                blueColorChangeTimer.Stop();

                RandomButton.Content = "Start";
            }

            isRandomEnabled = !isRandomEnabled;

            TimeSpan GetRandomInterval(int min = 2, int max = 25) => TimeSpan.FromMilliseconds(random.Next(min, max));
        }
    }
}
