using DiscoverMars.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverMars
{
    public class FileReader
    {
        string filePath = Path.Combine(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), @"..\..\..\Commands\RoverCommands.txt");

        public string[] SettingsFromFile { get; set; }

        public FileReader()
        {
            SettingsFromFile = File.ReadAllLines(filePath);
        }

        public Point GetBoardSize()
        {
            var plateauSize = SettingsFromFile[0].Split(",");
            int.TryParse(plateauSize[0], out var width);
            int.TryParse(plateauSize[1], out var height);
            Point PlateauPoints = new Point(width, height);
            return PlateauPoints;
        }

        public List<Rover> GetRovers()
        {
            var rovers = new List<Rover>();

            for (int i = 1; i < SettingsFromFile.Length - 1; i += 2)
            {
                var roverLocation = SettingsFromFile[i].Split(' ', ',');
                rovers.Add(new Rover(new Point(int.Parse(roverLocation[0]), int.Parse(roverLocation[1])), roverLocation[2], new string[] { SettingsFromFile[i + 1] }));            
            }
             
            return rovers;
        }
    }
}
