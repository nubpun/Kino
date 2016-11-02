using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Entity
{
    public class Film
    {
        public readonly int id;
        public readonly string title;
        public readonly int lengthInMin;
        public readonly string description;
        public Film(int id, string title, int lengthInMin, string description)
        {
            this.id = id;
            this.title = title;
            this.lengthInMin = lengthInMin;
            this.description = description;
        }
        override
        public string ToString()
        {
            return title + "(" + lengthInMin + " мин)";
        }
    }

    public class FilmsByDate
    {
        public string Title { get; set; }
        public int Count { get; set; }
        public double Amount { get; set; }
        public FilmsByDate(string title, int count, double amount)
        {
            Title = title;
            Count = count;
            Amount = amount;
        }

    }
}