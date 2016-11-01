using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Entity
{
    public class PlaceInHall
    {
        public readonly int placeInHall_id;
        public readonly int hall_id;
        public readonly int coordX;
        public readonly int coordY;
        public PlaceInHall(int placeInHall_id, int hall_id, int coordX, int coordY)
        {
            this.placeInHall_id = placeInHall_id;
            this.hall_id = hall_id;
            this.coordX = coordX;
            this.coordY = coordY;
        }
    }
}
