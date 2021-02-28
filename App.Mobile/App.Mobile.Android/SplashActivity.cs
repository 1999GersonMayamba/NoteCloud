using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace App.Mobile.Droid
{
    [Activity(Label = "NoteCloud", MainLauncher =true, Theme = "@style/Theme.Splash")]
    public class SplashActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                //Ler o token
                ConfigSystem.Token = await SecureStorage.GetAsync("oauth_token");
                //Ler o email
                ConfigSystem.Email = await SecureStorage.GetAsync("email_user");

                if (!string.IsNullOrEmpty(ConfigSystem.Token)) 
                     ConfigSystem.InitialPage = 1;

                StartActivity(typeof(MainActivity));
                // Create your application here
            }
            catch (Exception)
            {
                new  NotImplementedException();
            }
        }
    }
}