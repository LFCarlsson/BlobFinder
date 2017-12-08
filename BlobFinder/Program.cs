using Disjoint_Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] frame = IOHelper.ReadFrame("frame.txt");
            foreach(var line in frame)
            {
                Console.WriteLine(line);
            }

            int rows = frame.Count();
            int columns = frame[0].Length;
            int[,] labelArray = new int[rows,columns];
            int label = 0;

            var disjointSet = new DisjointSet<int>();
    
            for(int y = 0; y < rows; y++)
            {
                for(int x = 0; x < columns; x++)
                {
                    int labelLeft = x == 0 ? 0 : labelArray[y, x - 1];
                    int labelAbove = y== 0 ? 0 : labelArray[y - 1, x];
                    if(frame[y][x] != '0')
                    {
                    // pixels to left and above is part of blob, must be the same one.
                     if(labelLeft != 0 && labelAbove != 0)
                        {
                            disjointSet.Merge(labelLeft, labelAbove);
                            labelArray[y, x] = Math.Min(labelLeft, labelAbove);
                        }
                     else if(labelLeft != 0)
                        {
                            labelArray[y, x] = labelLeft;
                        }
                     else if(labelAbove != 0)
                        {
                            labelArray[y, x] = labelAbove;
                        }
                     else
                        {
                            labelArray[y, x] = ++label;
                            disjointSet.AddSet(label);
                        }
         
                    }
                }
            }

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {

                    if(labelArray[y,x] != 0)
                    {
                        labelArray[y, x] = disjointSet.FindRepresentant(labelArray[y,x]);
                    }
                }
            }
            Console.WriteLine();

            for (int y = 0; y < rows; y++)
            {
                for(int x = 0; x < columns; x++ )
                {
                    Console.ForegroundColor = (System.ConsoleColor) (labelArray[y, x] % 14);
                    Console.Write('#');
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
