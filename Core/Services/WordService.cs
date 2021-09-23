using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class WordService : IWordService
    {
        private IWordRepository wordRepository;
        private IRepository<Synonym> synonymRepository;

        public WordService(IWordRepository wordRepository, IRepository<Synonym> synonymRepository)
        {
            this.wordRepository = wordRepository;
            this.synonymRepository = synonymRepository;
        }

        public void Create(string word, List<string> synonyms)
        {
            if (string.IsNullOrEmpty(word))
                throw new Exception("word cannot be null");

            var keyword = CreateOrGet(word);

            foreach (var s in synonyms)
            {
                var synonym = CreateOrGet(s);

                var relationOne = new Synonym { FromWord = keyword, ToWord = synonym };
                var relationTwo = new Synonym { ToWord = keyword, FromWord = synonym };
                synonymRepository.Create(relationOne);
                synonymRepository.Create(relationTwo);
            }
        }

        public Word CreateOrGet(string word)
        {
            Word keyword;
            var existing = wordRepository.Search(word.ToLower()).ToList();
            if (existing.Count > 0)
                keyword = existing[0];
            else
                keyword = wordRepository.Create(new Word(word.ToLower()));

            return keyword;
        }

        public IEnumerable<Word> GetAll()
        {
            return wordRepository.GetAll();
        }

        public Word GetById(int id)
        {
            return wordRepository.GetById(id);
        }

        public IEnumerable<Word> Search(string term)
        {
            return wordRepository.Search(term);
        }
    }
}
