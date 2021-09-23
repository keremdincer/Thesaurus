using Core.Entities;
using Core.Interfaces;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastracture.Repositories
{
    public class WordRepository : Repository<Word>, IWordRepository
    {
        public WordRepository(ThesaurusContext context) : base(context) { }

        public IEnumerable<Word> Search(string term)
        {
            return entities.Where(e => e.Text.Contains(term)).AsEnumerable();
        }

        public new Word GetById(int id)
        {
            return entities.Include(e => e.Synonyms).ThenInclude(e => e.ToWord).SingleOrDefault(e => e.Id == id);
        }
    }
}
