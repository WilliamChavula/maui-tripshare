using System;
namespace tripshare.triggers
{
    public class AppThemeStateTrigger : StateTriggerBase
    {
        public static readonly BindableProperty CurrentThemeProperty = BindableProperty.Create(
            nameof(CurrentTheme),
            typeof(AppTheme),
            typeof(AppThemeStateTrigger),
            propertyChanged: OnAppThemeChanged
            );

        public AppThemeStateTrigger()
        {
        }

        public AppTheme CurrentTheme
        {
            get => (AppTheme)GetValue(CurrentThemeProperty);
            set => SetValue(CurrentThemeProperty, value);
        }

        private static void OnAppThemeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AppThemeStateTrigger)bindable).UpdateState();
        }

        void OnAppThemeChanged(object sender, ConnectivityChangedEventArgs e)
        {
            UpdateState();
        }

        void UpdateState()
        {
            var currentTheme = Application.Current.RequestedTheme;

            if (CurrentTheme == AppTheme.Dark)
                SetActive(currentTheme == AppTheme.Dark);
            else
                SetActive(currentTheme == AppTheme.Light);
        }
    }
}

