using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class CreateWordDto
    {
        public string Word { get; set; }
        public List<string> Synonyms { get; set; }
    }
}
