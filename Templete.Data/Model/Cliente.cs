using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Templete.Data.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            Nota = new HashSet<Nota>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
    }
}
