using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Helpers
{
    public class RagnaRogueColors
    {
        /// <summary>
        /// Dark grey is for structure
        /// </summary>
        public static Color UIDarkGray = new Color(33, 33, 33);

        /// <summary>
        /// Light blue is for general information
        /// </summary>
        public static Color UILightBlue = new Color(12, 226, 250);

        /// <summary>
        /// Light purple is for important interest information [e.g. item pickups, ammo, casting, etc]
        /// </summary>
        public static Color UILightPurple = new Color(171, 76, 196);

        /// <summary>
        /// Light green is for good happenings [e.g. getting exp, levelling up, etc]
        /// </summary>
        public static Color UILightGreen = new Color(100, 240, 67);

        /// <summary>
        /// Light orange is for important bad interest information [e.g. enemy casting, etc]
        /// </summary>
        public static Color UILightOrange = new Color(233, 127, 11);

        /// <summary>
        /// Red is for bad information [e.g. taking damage, damage to limbs, etc]
        /// </summary>
        public static Color UIRed = new Color(209, 5, 19);
    }
}
