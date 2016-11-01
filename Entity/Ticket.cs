using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Entity
{
    public class Ticket
    {
        public readonly int id;
        public readonly int schedule_id;
        public readonly int placeInHall_id;
        public readonly int x;
        public readonly int y;
        public Ticket(int ticket_id, int schedule_id, int placeInHall_id, int x, int y)
        {
            this.id = ticket_id;
            this.schedule_id = schedule_id;
            this.placeInHall_id = placeInHall_id;
            this.x = x;
            this.y = y;
        }
    }
}
