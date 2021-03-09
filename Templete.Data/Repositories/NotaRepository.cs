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
        private readonly NoteCloudContext _noteCloudContext;
        public NotaRepository(NoteCloudContext noteCloudContext)
        {
            this._noteCloudContext = noteCloudContext;
        }

        public Nota Get(Guid id)
        {
            //Procurar o cliente 
            var SearchNote = _noteCloudContext.Nota.First(c => c.IdCliente == id);
            return SearchNote;
        }

        public Cliente GetNote(Guid id)
        {

            var query = from b in _noteCloudContext.Set<Cliente>()
                        join p in _noteCloudContext.Set<Nota>()
                            on b.Id equals p.IdCliente into grouping
                        select new { b, grouping };

            return query as Cliente;
        }
        public List<Nota> GetAll()
        {

            //Trazer todos os clientes
            List<Nota> ListOfNote = _noteCloudContext.Nota.ToList<Nota>();
            return ListOfNote;
        }

        public int Insert(Nota nota)
        {
            _noteCloudContext.Nota.Add(nota);
            int InsertResult = _noteCloudContext.SaveChanges();
            return InsertResult;
        }

        public int Remove(Guid id)
        {
            //Buscar o Cliente que se deseja eliminar
            var SearchNote = _noteCloudContext.Nota.First(c => c.Id == id);
        _noteCloudContext.Nota.Remove(SearchNote);
            int InsertResult = _noteCloudContext.SaveChanges();//Salvar o Cliente na base de dados
            return InsertResult;
        }

        public int Update(Nota nota)
        {
           _noteCloudContext.Nota.Update(nota);
            var UpdateNote = _noteCloudContext.SaveChanges();
            return UpdateNote;

        }

        public Nota FindNoteById(Guid id)
        {
            var SearchNote = _noteCloudContext.Nota.First(c => c.Id == id);
            return SearchNote;
        }
    }
}
