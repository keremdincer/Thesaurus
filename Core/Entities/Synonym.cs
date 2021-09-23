using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Synonym : BaseEntity
    {
        public int FromId { get; set; }
        public Word FromWord { get; set; }

        public int ToId { get; set; }
        public Word ToWord { get; set; }
    }
}
