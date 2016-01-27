using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{



    public class BLlotto
    {

        Random rand = new Random();
        public int[] drawArray(int numbers, int max)
        {
            int tempRand;
            int[] lottoArray = new int[numbers];

            for (int i = 0; i < numbers; i++)
            {
                tempRand = rand.Next(1, max + 1);
                lottoArray[i] = tempRand;
            }
            Array.Sort(lottoArray);
            return lottoArray;
        }

        public string draw(string gamename)
        {
            switch (gamename)
            {
                case "Lotto":
                    return "Numerot: " + string.Join(", ", drawArray(7, 39));
                case "Viking Lotto":
                    return "Numerot: " + string.Join(", ", drawArray(6, 48));
                case "Eurojackpot":
                    return "Numerot: " + string.Join(", ", drawArray(5, 50)) + " + " + string.Join(", ", drawArray(2, 8));
                default:
                    return "Select game";
            }
        }
    }
}

