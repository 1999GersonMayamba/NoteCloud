using System;
using System.Collections.Generic;
using System.Text;
using Templete.Data.Model;

namespace Templete.Data.Interface
{
   public interface ICliente
    {
        int Insert(Cliente cliente);
        int Remove(Guid id);
        int Update(Guid id, Cliente cliente);
        List<Cliente> GetAll();
        Cliente Get(Guid id);
        Cliente GetNote(string email);

        Cliente GetClinteByEmail(string email);
    }
}
