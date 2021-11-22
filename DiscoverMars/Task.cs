using DiscoverMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverMars
{
    public class Task
    {
        FileReader fileReader;
        Plateau plateau;
        Settings taskSettings;

        /// <summary>
        /// Initiliazing Task Setting
        /// </summary>
        public Task()
        {
            fileReader = new FileReader();
            taskSettings = new Settings(fileReader.GetBoardSize(),
                                        fileReader.GetRovers());
            plateau = new Plateau(taskSettings.PlateauSize.X, taskSettings.PlateauSize.Y);
            SetPlateauObjects();

        }

        public static Task CreateTask()
        {
            return new Task();
        }

        private void SetPlateauObjects()
        {
            LocateRoversToPlateau(taskSettings.Rovers);
        }


        /// <summary>
        /// Locating Rovers To Board
        /// </summary>
        /// <param name="roverPoints"></param>
        private void LocateRoversToPlateau(List<Rover> rovers)
        {
            foreach (var rover in rovers)
            {
                plateau.objectsOfPlateau[rover.Location.X,rover.Location.Y] = rover;
            }
        }


        /// <summary>
        /// Game Start
        /// </summary>
        public void StartTask()
        {
            var rovers = taskSettings.Rovers;

            foreach (var rover in rovers)
            {

                var currentRover = plateau.objectsOfPlateau[rover.Location.X, rover.Location.Y] as Rover;

                var moves = currentRover.Moves[0].Split(' ', ',');

                for (int i = 0; i < moves.Length; i++)
                {
                    if (moves[i].ToUpper() == "R")
                    {
                        rover.RotateRight();
                    }
                    if (moves[i].ToUpper() == "L")
                    {
                        currentRover.RotateLeft();
                    }
                    if (moves[i].ToUpper() == "M")
                    {
                        Point oldLocation = currentRover.Location;
                        currentRover.Move();

                        plateau.objectsOfPlateau[currentRover.Location.X, currentRover.Location.Y] = currentRover;

                        Console.WriteLine("Rover Moved from ({0},{1}) to ({2},{3})", oldLocation.X, oldLocation.Y, currentRover.Location.X, currentRover.Location.Y);
                        plateau.objectsOfPlateau[oldLocation.X, oldLocation.Y] = null;

                    }
                }
            }


        }

    }
}
