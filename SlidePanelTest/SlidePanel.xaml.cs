namespace SlidePanelTest
{
    using System;
    using System.Windows;
    using System.Windows.Markup;

    /// <summary>
    /// A panel that slides in from the right. This <see cref="UserControl"/> can be used instead of a modal pop-up dialog.
    /// </summary>
    [ContentProperty("UserContent")]
    public partial class SlidePanel
    {
        private bool _shouldFireDismissedEvent;
        private bool _visible;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlidePanel"/> class. 
        /// </summary>
        public SlidePanel()
        {
            InitializeComponent();

            VisualStateGroup.CurrentStateChanged += VisualStateGroupOnCurrentStateChanged;
        }

        public event EventHandler Dismissed;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SlidePanel"/> should be visible.
        /// </summary>
        public bool Visible
        {
            get
            {
                return _visible;
            }

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

        /// <summary>
        /// Gets or sets the user supplied content of this <see cref="SlidePanel"/>.
        /// </summary>
        public object UserContent
        {
            get
            {
                return UserContentPresenter.Content;
            }

            set
            {
                UserContentPresenter.Content = value;
            }
        }

        /// <summary>
        /// Hides this <see cref="SlidePanel"/>.
        /// </summary>
        public void Hide()
        {
            Visible = false;
        }

        /// <summary>
        /// Shows this <see cref="SlidePanel"/>.
        /// </summary>
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

            var handler = Dismissed;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
