using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Templete.Data.Context;
using Templete.Data.Interface;
using Templete.Data.Model;

namespace Templete.Data.Repositories
{
    public class ClienteRespository : ICliente
    {

        private readonly NoteCloudContext _noteCloudContext;
        public ClienteRespository(NoteCloudContext noteCloudContext)
        {
            this._noteCloudContext = noteCloudContext;
        }

        public Cliente GetNote(string email)
        {
                //Buscar as notas de um determinado cliente
                var Cliente = _noteCloudContext.Cliente.Include(a => a.Nota)
                    .Where(p => p.Email == email).First();

                return Cliente;
        }

        public Cliente Get(Guid id)
        {
            //Procurar o cliente 
            var SearchClient = _noteCloudContext.Cliente.First(c => c.Id == id);
            return SearchClient;
        }

        public List<Cliente> GetAll()
        {
            //Trazer todos os clientes
            List<Cliente> ListOfClient = _noteCloudContext.Cliente.ToList<Cliente>();
            return ListOfClient;
        }

        public int Insert(Cliente cliente)
        {
            _noteCloudContext.Cliente.Add(cliente);
            int InsertResult = _noteCloudContext.SaveChanges();
            return InsertResult;
        }

        public int Remove(Guid id)
        {
            //Buscar o Cliente que se deseja eliminar
            var SearchClient = _noteCloudContext.Cliente.First(c => c.Id == id);
            _noteCloudContext.Cliente.Remove(SearchClient);
            int InsertResult = _noteCloudContext.SaveChanges();//Salvar o Cliente na base de dados
            return InsertResult;
        }

        public int Update(Guid id, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente GetClinteByEmail(string email)
        {
            //Procurar o cliente 
            var SearchClient = _noteCloudContext.Cliente.First(c => c.Email == email);
            return SearchClient;
        }
    }
}
