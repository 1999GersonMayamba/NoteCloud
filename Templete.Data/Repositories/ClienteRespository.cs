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


        public ClienteRespository()
        {

        }

        public Cliente GetNote(Guid id)
        {
            using (var DataContext = new NoteCloudContext())
            {

                //Buscar as notas de um determinado cliente
                var Cliente = DataContext.Cliente.Include(a => a.Nota)
                    .Where(p => p.Id == id).First();

                return Cliente;
            }

        }

        public Cliente Get(Guid id)
        {
            using (var DataContext = new NoteCloudContext())
            {
                //Procurar o cliente 
                var SearchClient = DataContext.Cliente.First(c => c.Id == id);
                return SearchClient;
            }
        }

        public List<Cliente> GetAll()
        {
            using (var DataContext = new NoteCloudContext())
            {
                //Trazer todos os clientes
                List<Cliente> ListOfClient = DataContext.Cliente.ToList<Cliente>();
                return ListOfClient;
            }
        }

        public int Insert(Cliente cliente)
        {
            using (var DataContext = new NoteCloudContext())
            {
                DataContext.Cliente.Add(cliente);
                int InsertResult = DataContext.SaveChanges();
                return InsertResult;
            }
        }

        public int Remove(Guid id)
        {
            using (var DataContext = new NoteCloudContext())
            {
                //Buscar o Cliente que se deseja eliminar
                var SearchClient = DataContext.Cliente.First(c => c.Id == id);
                DataContext.Cliente.Remove(SearchClient);
                int InsertResult = DataContext.SaveChanges();//Salvar o Cliente na base de dados
                return InsertResult;
            }
        }

        public int Update(Guid id, Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
