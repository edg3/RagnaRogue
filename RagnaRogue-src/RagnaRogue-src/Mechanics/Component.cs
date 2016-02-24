using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Mechanics
{
    public class Component
    {
        private string _name = "[Name me]";

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public void SetName(string _name)
        {
            Name = _name;
        }
    }
}
