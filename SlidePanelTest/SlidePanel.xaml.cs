using System;
using System.Windows;
using System.Windows.Markup;

namespace SlidePanelTest
{
    [ContentProperty(nameof(UserContent))]
    public partial class SlidePanel
    {
        private bool _shouldFireDismissedEvent;
        private bool _visible;

        public SlidePanel()
        {
            InitializeComponent();

            VisualStateGroup.CurrentStateChanged += VisualStateGroupOnCurrentStateChanged;
        }

        public event EventHandler Dismissed;

        public bool Visible
        {
            get => _visible;

            set
            {
                if (_visible && !value)
                {
                    _shouldFireDismissedEvent = true;
                }

                VisualStateManager.GoToState(this, value ? "VisibleState" : "HiddenState", true);

                _visible = value;
            }
        }

        public object UserContent
        {
            get => UserContentPresenter.Content;

            set => UserContentPresenter.Content = value;
        }

        public void Hide()
        {
            Visible = false;
        }

        public void Show()
        {
            Visible = true;
        }

        private void Hide(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void VisualStateGroupOnCurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            if (!_shouldFireDismissedEvent)
            {
                return;
            }

            _shouldFireDismissedEvent = false;

            Dismissed?.Invoke(this, new EventArgs());
        }
    }
}
