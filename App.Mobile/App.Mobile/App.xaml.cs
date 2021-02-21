using App.Mobile.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NotesView())
            {
                BarBackgroundColor = Color.FromHex("#023047")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
