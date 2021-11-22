using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverMars.Models
{
    public class Settings
    {
        public Point PlateauSize { get; set; }                
        public List<Rover> Rovers { get; set; }

        public Settings(Point plateauSize, List<Rover> rovers)
        {
            PlateauSize = plateauSize;            
            Rovers = rovers;                        
        }
    }
}
