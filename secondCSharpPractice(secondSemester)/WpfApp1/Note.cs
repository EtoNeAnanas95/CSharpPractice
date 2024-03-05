using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal struct Note
    {
        public DateOnly datetime = new DateOnly();
        public string name { get; set; }
        public string description { get; set; }

        public Note(DateOnly datetime, string name, string description)
        {
            this.datetime = datetime;
            this.name = name;
            this.description = description;
        }
    }
}
