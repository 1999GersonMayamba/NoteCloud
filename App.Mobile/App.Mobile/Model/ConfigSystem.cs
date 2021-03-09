using System;
using System.Collections.Generic;
using System.Text;

namespace App.Mobile.Model
{
   public static class ConfigSystem
    {
        private static string urlapi = "http://10.0.2.2:5000/api";
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

        private static string _email;
        public static string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private static int _initialpage;
        public static int InitialPage
        {
            get { return _initialpage; }
            set { _initialpage = value; }
        }

        private static int _updateOrInsert;
        public static int UpdateOrDelete
        {
            get { return _initialpage; }
            set { _initialpage = value; }
        }

    }
}
