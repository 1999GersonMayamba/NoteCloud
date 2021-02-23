using System;
using System.Collections.Generic;
using System.Text;

namespace App.Mobile.Model
{
   public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public virtual ICollection<Note> Nota { get; set; }
    }
}
