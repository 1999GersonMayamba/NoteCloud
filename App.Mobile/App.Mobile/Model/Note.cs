﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.Mobile.Model
{
  public  class Note
    {
         public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string Titulo { get; set; }
        public string Nota { get; set; }
        public string Data { get; set; }
    }
}
