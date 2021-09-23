using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Word : BaseEntity
    {
        public string Text { get; set; }

        public IList<Synonym> Synonyms { get; set; }

        [JsonIgnore]
        public IList<Synonym> FromSynonyms { get; set; }

        public Word(string text)
        {
            Text = text;
        }
    }
}
