using System;
using System.Collections.Generic;
using System.Text;

namespace Templete.Identity.Model
{
  public  class RegiterUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
