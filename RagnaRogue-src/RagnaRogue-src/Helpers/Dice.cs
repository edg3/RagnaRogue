using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Helpers
{
    public class Dice
    {
        private static Random _rand = new Random();
        public static int Roll(int count, int size)
        {
            int tote = 0;
            for (int i = 0; i < count; i++)
            {
                tote += 1 + _rand.Next(size);
            }

            return tote;
        }

        public static int Next(int max)
        {
            return _rand.Next(max);
        }
    }
}
