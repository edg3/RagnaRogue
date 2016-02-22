using Microsoft.Xna.Framework;
using RagnaRogue.Helpers;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Consoles
{
    class BorderedConsole : SadConsole.Consoles.Console
    {
        public BorderedConsole(int width, int height, string title) : base(width, height)
        {
            SadConsole.Shapes.Box box = SadConsole.Shapes.Box.GetDefaultBox();
            box.Foreground = RagnaRogueColors.UIDarkGray;
            box.Width = width;
            box.Height = height;
            box.Draw(CellData);

            CellData.Print(3, 0, new ColoredString(title, new CellAppearance(RagnaRogueColors.UILightBlue, Color.Black)));
        }
    }
}
