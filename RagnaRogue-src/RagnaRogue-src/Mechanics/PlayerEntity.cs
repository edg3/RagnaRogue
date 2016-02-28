using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RagnaRogue.Generation.Map;
using SadConsole.Input;
using RagnaRogue.Mechanics.Database;

namespace RagnaRogue.Mechanics
{
    public class PlayerEntity : Entity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PlayerEntity() : base("@", Color.White)
        {
            AddComponent(RegistryDatabase.Instance.CloneCreature("p_human_warrior"));
        }

        public bool ProcessKeyboard(CellData[,] _map, int x, int y, KeyboardInfo info)
        {
            bool _pressed = false;
            Point _dir = new Point();

            if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad9))
            {
                _dir.X = 1;
                _dir.Y = -1;
                _pressed = true;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad8))
            {
                _dir.X = 0;
                _dir.Y = -1;
                _pressed = true;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad7))
            {
                _dir.X = -1;
                _dir.Y = -1;
                _pressed = true;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad4))
            {
                _dir.X = -1;
                _dir.Y = 0;
                _pressed = true;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad1))
            {
                _dir.X = -1;
                _dir.Y = 1;
                _pressed = true;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad2))
            {
                _dir.X = 0;
                _dir.Y = 1;
                _pressed = true;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad3))
            {
                _dir.X = 1;
                _dir.Y = 1;
                _pressed = true;
            }
            else if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.NumPad6))
            {
                _dir.X = 1;
                _dir.Y = 0;
                _pressed = true;
            }

            if (_pressed)
            {

                // REF: copy this for open-ness for pathing
                int _x = X + _dir.X;
                int _Y = Y + _dir.Y;

                // TODO: try catch is horror, this is lazy, why do I do this?
                //       probably only triggers on map borders
                try {
                    if (_map[X + _dir.X, Y + _dir.Y].Pathable && (_map[X + _dir.X, Y + _dir.Y].Contains == null))
                    {
                        _map[X + _dir.X, Y + _dir.Y].Contains = this;
                        _map[X, Y].Contains = null;

                        X += _dir.X;
                        Y += _dir.Y;

                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
