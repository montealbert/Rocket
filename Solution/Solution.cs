using System;
using System.Collections.Generic;
using System.Linq;
namespace Solution
{
    public class SpaceShip
    {
        public long id;
        public long startTime;
        public long endTime;
        public long score;
    }
    public class Solution
    {
        static void Main2()
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            int numberOfShips = int.Parse(Console2.ReadLine());
            List<SpaceShip> spaceships = new List<SpaceShip>();
            for (long i = 0; i < numberOfShips; i++)
            {
                string shipStr = Console2.ReadLine();
                string[] shipData = shipStr.Split(' ');
                SpaceShip ss = new SpaceShip();
                ss.id = long.Parse(shipData[0]);
                ss.startTime = long.Parse(shipData[1]);
                ss.endTime = long.Parse(shipData[2]);
                ss.score = 0;
                spaceships.Add(ss);
            }
            List<SpaceShip> sortedByStartTime = spaceships.OrderBy(s => s.startTime).ToList();
            for (int i = 0; i < numberOfShips; i++)
            {
                for (int j = i + 1; j < numberOfShips; j++)
                {
                    if ((sortedByStartTime[j].startTime > sortedByStartTime[i].startTime) && (sortedByStartTime[j].endTime < sortedByStartTime[i].endTime))
                    {
                        sortedByStartTime[i].score++;
                    }
                }
            }
            List<SpaceShip> sortedByScore = sortedByStartTime.OrderBy(t => t.score).ThenBy(t => t.id).ToList();
            foreach (SpaceShip ss in sortedByScore)
            {
                Console2.WriteLine(ss.id + " " + ss.score);
            }
        }

        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        public static void StartEvents(string inputfile)
        {
            Console2.setCurrentFile(inputfile);
            Main2();
            Console2.CloseCurrentFiles();
        }

    }
}