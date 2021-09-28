using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;



namespace SCommerce.Main.Controls
{
    public sealed class BadgeAppBarButton : AppBarButton
    {

        private const string STATE_BADGE_HIDDEN = "BadgeHidden";
        private const string STATE_BADGE_VISIBLE = "BadgeVisible";

        public string Badge
        {
            get { return (string)GetValue(BadgeProperty); }
            set { SetValue(BadgeProperty, value); }
        }

        public static readonly DependencyProperty BadgeProperty =
            DependencyProperty.Register("Badge", typeof(string), typeof(BadgeAppBarButton), new PropertyMetadata(string.Empty, OnBadgePropertyChanged));

        private static void OnBadgePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var badge = e.NewValue as string;
            badge = badge == "0" ? "" : badge;

            var state = badge == string.Empty ? STATE_BADGE_HIDDEN : STATE_BADGE_VISIBLE;
            VisualStateManager.GoToState((Control)d, state,false);
        }

        public BadgeAppBarButton()
        {
            this.DefaultStyleKey = typeof(BadgeAppBarButton);
        }
    }
}
