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
        public readonly int number;
        public readonly string name;
        public Hall(int id, int number, string name)
        {
            this.id = id;
            this.number = number;
            this.name = name;
        }
        override
        public string ToString()
        {
            return "Зал: " + number + " -" +name;
        }
    }
    
}
