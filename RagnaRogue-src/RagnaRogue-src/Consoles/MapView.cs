using RagnaRogue.Generation.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Input;
using Microsoft.Xna.Framework;

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

        int width;
        int height;

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

            this.width = _map[0, 0].W;
            this.height = _map[0, 0].H;

            GenerateRender();

            Position = new Microsoft.Xna.Framework.Point(1, 1);

            CanUseKeyboard = true;
            CanUseMouse = true;
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
            if ((width == 0) || (height == 0)) return;

            for (int i = 0; i < drawable_width; i++)
            {
                for (int j = 0; j < drawable_height; j++)
                {
                    int x = (X + i - drawable_width / 2);
                    int y = (Y + j - drawable_height / 2);
                    if ((x < 0) || (y < 0) || (x >= width) || (y >= height))
                    {
                        this.CellData[i + 1, j + 1].Background = Color.Black;
                        continue;
                    }
                    
                    this.CellData[i + 1, j + 1].Background = _map[x, y].BackColor;
                }
            }
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            int x = X;
            int y = Y;
            if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                Y -= 1;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
            {
                Y += 1;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
            {
                X -= 1;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            {
                X += 1;
            }

            if ((x != X) || (y != Y))
            {
                GenerateRender();
            }

            return false; // base.ProcessKeyboard(info);
        }
    }
}
