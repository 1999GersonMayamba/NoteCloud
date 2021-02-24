using System;
using System.Collections.Generic;
using System.Text;

namespace Templete.Identity.Model
{
  public  class LoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Grupo { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }

        public string Message { get; set; }

        public string DetailMessage { get; set; }
    }
}
