using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IWordService
    {
        void Create(string word, List<string> synonyms);
        IEnumerable<Word> GetAll();
        IEnumerable<Word> Search(string term);
        Word GetById(int id);
    }
}
