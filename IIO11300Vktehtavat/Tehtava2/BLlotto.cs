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
        public int[] drawNumbers(int numbers, int max)
        {
            int tempRand;
            int[] lottoArray = new int[numbers];

            for (int i = 0; i < numbers; i++)
            {
                tempRand = rand.Next(1, max + 1);
                if (lottoArray.Contains(tempRand))
                {
                    i--;
                }
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
                    return string.Join(", ", drawNumbers(7, 39));
                case "Viking":
                    return string.Join(", ", drawNumbers(6, 48));
                case "Euro":
                    return string.Join(", ", drawNumbers(5, 50)) + " + " + string.Join(", ", drawNumbers(2, 8));
                default:
                    return "Select game";
            }
        }
    }
}

