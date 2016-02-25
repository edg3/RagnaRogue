using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Generation.Map
{
    public struct CellData
    {
        public string Fore;
        public string Back;
        public Color ForeColor;
        public Color BackColor;
        public int W;
        public int H;
    }

    interface IGenerateMaps
    {
        /// <summary>
        /// Generate maps using a seed
        /// </summary>
        /// <param name="seed">TODO: implement map seeds.</param>
        /// <returns></returns>
        CellData[,] Generate(int seed);
    }
}
