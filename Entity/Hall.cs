using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Entity
{
    public class Hall
    {
        public readonly int id;
        public readonly string name;
        public Hall(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        override
        public string ToString()
        {
            return "Зал: " + id + " -" +name;
        }
    }
    
}
