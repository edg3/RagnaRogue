using Microsoft.Xna.Framework;
using RagnaRogue.Generation.Map;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RagnaRogue.Mechanics
{
    public class Entity
    {
        public Entity(string vis_char, Color vis_col)
        {
            VisualCharacter = vis_char;
            VisualColor = vis_col;
        }

        public string VisualCharacter { get; set; }
        public Color VisualColor { get; set; }

        private List<Component> _components = new List<Component>();

        public Entity AddComponent(Component _C)
        {
            var count = (from item in _components
                         where item.GetType() == _C.GetType()
                         select item).ToList().Count;
            if (count == 0)
            {
                _components.Add(_C);
            }

            return this;
        }

        public T First<T>()
        {
            var val = (from item in _components
                        where item.GetType() == typeof(T)
                        select item).FirstOrDefault();

            try
            {
                return (T)Convert.ChangeType(val, typeof(T));
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }

        public virtual bool Update(CellData[,] _map, int _x, int _y)
        {
            return false;
        }
    }
}
