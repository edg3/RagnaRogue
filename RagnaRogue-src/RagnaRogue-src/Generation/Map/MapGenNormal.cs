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
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        private int euclid_distance(Point a, Point b)
        {
            return (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        const int point_max = 18;

        public ReturnedCellData Generate(int seed)
        {
            int wide = 100 + Dice.Roll(5, 20); //55 -> 100
            int high = 100 + Dice.Roll(5, 20); // 55 -> 100
            CellData[,] cdata = new CellData[wide, high];

            //Base Simplistic Map Gen
            List<Point> initial = new List<Point>();

            int points = Math.Max(Math.Min(120, (wide * high) / 250), 30);

            System.Console.WriteLine("Map points: " + points.ToString());

            for (int i = 0; i < points; i++)
                initial.Add(new Point(Dice.Next(wide), Dice.Next(high)));

            var dense_points = (from item in initial
                                where (from b in initial
                                       where manhattan_distance(item, b) < 6
                                       select b).ToList().Count > 0
                                select item).ToList();

            List<Point> final_points = new List<Point>();
            int limit = 0;
            foreach (var dense_point in dense_points)
            {
                limit++;
                int size = 7 + Dice.Roll(4, 6);
                Point p = new Point(dense_point.X, dense_point.Y);
                int roll = Dice.Roll(1, 2);
                for (int i = -size/2; i < size/2; i++)
                {
                    for (int j = -size/2; j < size/2; j++)
                    {
                        Point check_point = new Point(p.X + i, p.Y + j);
                        if ((check_point.X < 0) || (check_point.X > wide - 1) || (check_point.Y < 0) || (check_point.Y > high - 1)) continue;

                        if (roll == 1)
                        {
                            if (euclid_distance(check_point, p) < size / 2)
                            {
                                final_points.Add(check_point);
                            }
                        }
                        else
                        {
                            final_points.Add(check_point);
                        }
                    }
                }

                if (limit == point_max) break;
            }

            for (int i = 0; i < Math.Min(dense_points.Count, point_max) - 1; i++)
            {
                Point a = dense_points[i];
                Point b = dense_points[i + 1];

                Point dist = new Point(1, 0);

                //Walk from a to b
                while (dist.X != 0 || dist.Y != 0)
                {
                    dist = a - b;
                
                    Point[] toSort = new Point[4];
                    toSort[0] = new Point(0, -1);
                    toSort[1] = new Point(0, 1);
                    toSort[2] = new Point(-1, 0);
                    toSort[3] = new Point(1, 0);

                    //Cheeky shuffle to simulate a minor random choice, should make the walk less linear / makes multiple things show manhattan distance
                    for (int z = 0; z < 6; z++)
                    {
                        int pza = Dice.Next(3) + 1;
                        var temp = toSort[pza];
                        toSort[pza] = toSort[0];
                        toSort[0] = temp;
                    }

                    for (int outer = 0; outer < 3; outer++)
                    {
                        for (int inner = outer + 1; inner < 4; inner++)
                        {
                            if (manhattan_distance(toSort[outer] + a, b) > manhattan_distance(toSort[inner] + a, b))
                            {
                                var temp = toSort[outer];
                                toSort[outer] = toSort[inner];
                                toSort[inner] = temp;
                            }
                        }
                    }

                    a = a + toSort[0];

                    int size = 2 + Dice.Roll(1, 5);
                    for (int k = -size / 2; k < size / 2; k++)
                    {
                        for (int j = -size / 2; j < size / 2; j++)
                        {
                            Point check_point = new Point((int)(a.X) + k, (int)(a.Y) + j);
                            if ((check_point.X < 0) || (check_point.X > wide - 1) || (check_point.Y < 0) || (check_point.Y > high - 1)) continue;
                    
                            if (euclid_distance(check_point, a) < size / 2)
                            {
                                final_points.Add(check_point);
                            }
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
                        cdata[i, j].Pathable = true;
                    }
                }
            }

            ReturnedCellData adata = new ReturnedCellData();
            adata.Data = cdata;

            adata.W = wide;
            adata.H = high;

            return adata;
        }
    }
}
