using RagnaRogue.Generation.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using RagnaRogue.Mechanics;
using RagnaRogue.Helpers;

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

            X = width / 2;
            Y = height / 2;

            Position = new Microsoft.Xna.Framework.Point(1, 1);

            CanUseKeyboard = true;
            CanUseMouse = true;

            _player = new PlayerEntity();

            int _x = Dice.Next(width);
            int _y = Dice.Next(height);

            while (_map[_x, _y].BackColor == Color.Black)
            {
                _x = (_x + 1) % width;
                _y = (_y + 1) % height;
            }

            _map[_x, _y].Contains = _player;
            _player.X = _x;
            _player.Y = _y;

            GenerateRender();
        }

        private void MakeMap()
        {
            if (null == _map)
            {
                var stime = DateTime.Now;
                var newData = (new MapGenNormal()).Generate(0);
                _map = newData.Data;
                width = newData.W;
                height = newData.H;
                var etime = DateTime.Now;
                System.Console.WriteLine("Map gen took " + (etime - stime).TotalSeconds.ToString() + " seconds");
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
                        this.CellData[i + 1, j + 1].CharacterIndex = ' ';
                        continue;
                    }
                    
                    this.CellData[i + 1, j + 1].Background = _map[x, y].BackColor;
                    if (_map[x,y].Contains != null)
                    {
                        this.CellData[i + 1, j + 1].Foreground = _map[x, y].Contains.VisualColor;
                        this.CellData[i + 1, j + 1].CharacterIndex = (int)_map[x, y].Contains.VisualCharacter[0];
                    }
                    else
                    {
                        this.CellData[i + 1, j + 1].CharacterIndex = ' ';
                    }
                }
            }
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            int x = X;
            int y = Y;

            if (inputDelay < DateTime.Now)
            {
                if (_player.ProcessKeyboard(_map, _player.X, _player.Y, info))
                {
                    _allTurn = true;

                    X = _player.X; // - (drawable_width / 2);
                    Y = _player.Y; // - (drawable_height / 2);
                }
            }

            if ((x != X) || (y != Y))
            {
                GenerateRender();
            }

            return false; // base.ProcessKeyboard(info);
        }

        PlayerEntity _player;
        private bool _allTurn = false;
        DateTime inputDelay;
        public override void Update()
        {
            if (_allTurn)
            {
                inputDelay = DateTime.Now + TimeSpan.FromMilliseconds(100);
                // TODO: Should turns stay localized?
                for (int i = 0; i < drawable_width; i++)
                {
                    for (int j = 0; j < drawable_height; j++)
                    {
                        int x = (X + i - drawable_width / 2);
                        int y = (Y + j - drawable_height / 2);

                        if ((x < 0) || (y < 0) || (x >= width) || (y >= height))
                        {
                            continue;
                        }

                        if (_map[x, y].Contains != null)
                        {
                            _map[x, y].Contains.Update(_map, x, y);
                        }
                    }
                }

                GenerateRender();

                _allTurn = false;
            }

            base.Update();
        }
    }
}
