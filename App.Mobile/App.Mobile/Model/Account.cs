using System;
using System.Collections.Generic;
using System.Text;

namespace App.Mobile.Model
{
   public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirPassword { get; set; }
        public string Token { get; set; }
        public string Grupo { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string DetailMessage { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
