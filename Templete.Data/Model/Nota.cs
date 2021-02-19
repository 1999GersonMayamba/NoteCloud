using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Templete.Data.Model
{
    public partial class Nota
    {
        public Guid Id { get; set; }
        public Guid? IdCliente { get; set; }
        public string Titulo { get; set; }
        public string Nota1 { get; set; }
        public DateTime? Data { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
