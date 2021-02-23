using System;
using System.Collections.Generic;
using System.Text;

namespace App.Mobile.Model
{
   public static class ConfigSystem
    {
        private static string urlapi = "http://192.168.1.44:84/api";
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
