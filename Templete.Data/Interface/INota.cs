using System;
using System.Collections.Generic;
using System.Text;
using Templete.Data.Model;

namespace Templete.Data.Interface
{
   public interface INota
    {
        int Insert(Nota nota);
        int Remove(Guid id);
        int Update( Nota nota);
        List<Nota> GetAll();
        Nota Get(Guid id);
        Cliente GetNote(Guid id);

        Nota FindNoteById(Guid id);
    }
}
