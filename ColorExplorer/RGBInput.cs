using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ColorExplorer
{
    public class RGBInput : INotifyPropertyChanged
    {
        public RGBInput(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        private byte red;
        public byte Red
        {
            get => red;
            set
            {
                red = value;
                SetColor();
                OnPropertyChanged();
            }
        }

        private byte green;
        public byte Green
        {
            get => green;
            set
            {
                green = value;
                SetColor();
                OnPropertyChanged();
            }
        }

        private byte blue;
        public byte Blue
        {
            get => blue;
            set
            {
                blue = value;
                SetColor();
                OnPropertyChanged();
            }
        }

        private SolidColorBrush color;
        public SolidColorBrush Color
        {
            get
            {
                if (color == null)
                {
                    color = new SolidColorBrush();
                }

                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged();
            }
        }

        private void SetColor()
        {
            Color.Color = System.Windows.Media.Color.FromRgb(red, green, blue);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
