using Conways_Game_Of_Life.Models;
using System;
using System.Text;
using System.Text.Unicode;
using System.Threading;

namespace Conways_Game_Of_Life
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int x = 50, y = 50;
            bool[,] Cells = new bool[x, y];
            bool[,] newCells = new bool[x, y];
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            string output;
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = random.Next(4) == 1;
                }
            }

            do
            {
                output = "";
                sb.Clear();
                for (int i = 0; i < Cells.GetLength(0); i++)
                {
                    for (int j = 0; j < Cells.GetLength(1); j++)
                    {
                        int count = 0;
                        
                        if (j > 0)
                        {
                            //Top
                            if (Cells[i, j - 1])
                            {
                                count++;
                            }
                            if (i > 0)
                            {
                                //topLeft
                                if (Cells[i - 1, j - 1])
                                {
                                    count++;
                                }
                            }
                            if(i<Cells.GetLength(0)-1)
                            {
                                //TopRight
                                if(Cells[i+1, j-1])
                                {
                                    count++;
                                }
                            }

                        }
                        if (i < Cells.GetLength(0)-1)
                        {
                            //Right
                            if (Cells[i + 1, j])
                            {
                                count++;
                            }
                        }
                        if (i > 0)
                        {
                            //Left
                            if (Cells[i - 1, j])
                            {
                                count++;
                            }
                        }
                        if (j < Cells.GetLength(1)-1)
                        {
                            //bottom
                            if (Cells[i, j + 1])
                            {
                                count++;
                            }                           
                            if(i > 0)
                            {
                                //Bottom Left
                                if(Cells[i-1, j+1])
                                {
                                    count++;
                                }
                            }
                            if(i<Cells.GetLength(0) -1)
                            {
                                //Bottom Right
                                if(Cells[i+1,j+1])
                                {
                                    count++;
                                }
                            }
                        }

                        if(Cells[i,j])
                        {
                            if (count == 2 || count == 3)
                            {
                                newCells[i, j] = true;
                            }
                            else
                            {
                                newCells[i, j] = false;
                            }
                        }
                        else
                        {
                            if (count == 3)
                            {
                                newCells[i, j] = true;
                            }
                            else
                            {
                                newCells[i, j] = false;
                            }
                        }

                    }
                }
                Cells = newCells.Clone() as bool[,];
                //newCells = new bool[x, y];
                Console.ResetColor();
                //Console.Clear();
                for (int i = 0; i < newCells.GetLength(0); i++)
                {
                    for (int j = 0; j < newCells.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(0, i);
                        if (newCells[i,j])
                        {
                            sb.Append("\u2588\u2588");
                            //Console.BackgroundColor = ConsoleColor.White;
                            //Console.Write("  ");
                        }
                        else
                        {
                            sb.Append("  ");
                            //Console.BackgroundColor = ConsoleColor.Black;
                            //Console.Write("  ");
                        }

                        
                    }

                    output = sb.ToString();
                    Console.WriteLine(output);
                    sb.Clear();
                }
                System.Threading.Thread.Sleep(5);
            } while (true);
        }
    }
}
