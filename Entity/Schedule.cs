using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Entity
{
    public class Schedule
    {
        public readonly int id;
        public readonly DateTime dateTime;
        public readonly int filmId;
        public readonly double price;
        public readonly int hallId;
        public Schedule(int id, DateTime dateTime, int filmId, double price, int hallId)
        {
            this.id = id;
            this.dateTime = dateTime;
            this.filmId = filmId;
            this.price = price;
            this.hallId = hallId;
        }
    }
    public class SchedulePresent
    {
        public readonly Schedule owner;
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Hall { get; set; }

        public SchedulePresent(Schedule schedule)
        {
            owner = schedule;
            Date = schedule.dateTime;
            Price = schedule.price;
            Title = DBController.GetFilmTitleById(schedule.filmId);
            Hall = DBController.GetHallNameById(schedule.hallId);
        }

    }
}
