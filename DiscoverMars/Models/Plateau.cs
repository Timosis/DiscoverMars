using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverMars.Models
{
    public class Plateau
    {
        public Object[,] objectsOfPlateau;
        public Plateau(int width, int height)
        {
            objectsOfPlateau = new Object[width, height];
        }
    }
}
