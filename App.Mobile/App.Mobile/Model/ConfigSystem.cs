using System;
using System.Collections.Generic;
using System.Text;

namespace App.Mobile.Model
{
   public static class ConfigSystem
    {
        private static string urlapi = "http://127.0.0.1:5000/api";
        public static string URLAPI
        {
            get { return urlapi; }
        }


        private static string token = null;
        public static string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}
