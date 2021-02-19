using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Templete.Data.Context;
using Templete.Data.Interface;
using Templete.Data.Model;

namespace Templete.Data.Repositories
{
    public class NotaRepository : INota
    {
        public Nota Get(Guid id)
        {
            using (var DataContext = new NoteCloudContext())
            {
                //Procurar o cliente 
                var SearchNote = DataContext.Nota.First(c => c.IdCliente == id);
                return SearchNote;
            }
        }

        public Cliente GetNote(Guid id)
        {
            using (var DataContext = new NoteCloudContext())
            {
                var query = from b in DataContext.Set<Cliente>()
                            join p in DataContext.Set<Nota>()
                                on b.Id equals p.IdCliente into grouping
                            select new { b, grouping };

                return query as Cliente;
            }

        }
        public List<Nota> GetAll()
        {
            using (var DataContext = new NoteCloudContext())
            {
                //Trazer todos os clientes
                List<Nota> ListOfNote = DataContext.Nota.ToList<Nota>();
                return ListOfNote;
            }
        }

        public int Insert(Nota nota)
        {
            using (var DataContext = new NoteCloudContext())
            {
                DataContext.Nota.Add(nota);
                int InsertResult = DataContext.SaveChanges();
                return InsertResult;
            }
        }

        public int Remove(Guid id)
        {
            using (var DataContext = new NoteCloudContext())
            {
                //Buscar o Cliente que se deseja eliminar
                var SearchNote = DataContext.Cliente.First(c => c.Id == id);
                DataContext.Cliente.Remove(SearchNote);
                int InsertResult = DataContext.SaveChanges();//Salvar o Cliente na base de dados
                return InsertResult;
            }
        }

        public int Update(Guid id, Nota nota)
        {
            throw new NotImplementedException();
        }
    }
}
