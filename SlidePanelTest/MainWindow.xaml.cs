namespace SlidePanelTest
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The main window.
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private int _counterValue;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Counter
        {
            get
            {
                return _counterValue;
            }

            set
            {
                _counterValue = value;
                OnPropertyChanged("Counter");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var slidePanel = (SlidePanel)btn.Tag;
            slidePanel.Show();
        }

        private void SlidePanel_OnDismissed(object sender, EventArgs e)
        {
            ++Counter;
        }
    }
}
