﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteView : ContentPage
    {
        public NoteView()
        {
            InitializeComponent();
        }
    }
}