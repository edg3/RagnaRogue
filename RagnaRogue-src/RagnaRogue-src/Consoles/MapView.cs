using RagnaRogue.Generation.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Consoles
{
    public class MapView : BorderedConsole
    {
        int drawable_width;
        int drawable_height;
        int center_x;
        int center_y;

        public int X { get; private set; }
        public int Y { get; private set; }

        CellData[,] _map = null;

        public MapView(int width, int height) : base(width, height, "World")
        {
            drawable_width = width - 2;
            drawable_height = height - 2;

            center_x = width / 2;
            center_y = height / 2;

            MakeMap();

            X = _map[0, 0].W / 2;
            Y = _map[0, 0].H / 2;

            GenerateRender();

            Position = new Microsoft.Xna.Framework.Point(1, 1);
        }

        private void MakeMap()
        {
            if (null == _map)
            {
                _map = (new MapGenNormal()).Generate(0);
            }
        }

        public void GenerateRender()
        {
            for (int i = 0; i < drawable_width; i++)
            {
                for (int j = 0; j < drawable_height; j++)
                {
                    this.CellData[i + 1, j + 1].Background = _map[X + i - drawable_width / 2, Y + j - drawable_height / 2].BackColor;
                }
            }
        }
    }
}
