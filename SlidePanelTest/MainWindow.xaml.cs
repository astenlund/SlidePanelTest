using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SlidePanelTest
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private int _counterValue;

        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Counter
        {
            get => _counterValue;

            set
            {
                _counterValue = value;
                OnPropertyChanged(nameof(Counter));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
