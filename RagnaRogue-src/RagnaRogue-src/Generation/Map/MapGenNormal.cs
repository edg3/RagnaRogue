using Microsoft.Xna.Framework;
using RagnaRogue.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Generation.Map
{
    public class MapGenNormal : IGenerateMaps
    {
        private int manhattan_distance(Point a, Point b)
        {
            return (int)Math.Abs(a.X - b.X) + (int)Math.Abs(a.Y - b.Y);
        }

        private int euclid_distance(Point a, Point b)
        {
            return (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public CellData[,] Generate(int seed)
        {
            int wide = 50 + Dice.Roll(5, 10); //55 -> 100
            int high = 50 + Dice.Roll(5, 10); // 55 -> 100
            CellData[,] cdata = new CellData[wide, high];

            //Base Simplistic Map Gen
            List<Point> initial = new List<Point>();

            int points = wide * high / 250;
            for (int i = 0; i < points; i++)
                initial.Add(new Point(Dice.Next(wide), Dice.Next(high)));

            var dense_points = (from item in initial
                                where (from b in initial
                                       where manhattan_distance(item, b) < 6
                                       select b).ToList().Count > 0
                                select item).ToList();

            List<Point> final_points = new List<Point>();
            foreach (var dense_point in dense_points)
            {
                int size = Dice.Roll(3, 6);
                Point p = new Point(dense_point.X, dense_point.Y);
                for (int i = -size/2; i < size/2; i++)
                {
                    for (int j = -size/2; j < size/2; j++)
                    {
                        Point check_point = new Point(p.X + i, p.Y + j);
                        if ((check_point.X < 0) || (check_point.X > wide - 1) || (check_point.Y < 0) || (check_point.Y > high - 1)) continue;

                        if (euclid_distance(check_point, p) < size)
                        {
                            final_points.Add(check_point);
                        }
                    }
                }
            }

            //End Base Simplistic Map Gen

            for (int i = 0; i < wide; i++)
            {
                for (int j = 0; j < high; j++)
                {
                    cdata[i, j] = new CellData();
                    cdata[i, j].Fore = "";
                    cdata[i, j].Back = "";
                    cdata[i, j].ForeColor = Color.White;
                    cdata[i, j].BackColor = Color.Black;

                    var search_count = (from item in final_points
                                        where (item.X == i) && (item.Y == j)
                                        select item).ToList().Count;

                    if (search_count > 0)
                    {
                        cdata[i, j].BackColor = Color.Gray;
                    }
                }
            }

            cdata[0, 0].W = wide;
            cdata[0, 0].H = high;

            return cdata;
        }
    }
}
