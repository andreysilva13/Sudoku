using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string sudoku =@"1 3 2 5 7 9 4 6 8
                             2 9 8 2 6 1 3 7 5
                             7 5 6 3 8 4 2 1 9
                             6 4 3 1 5 8 7 9 2
                             5 2 1 7 9 3 8 4 6
                             9 8 7 4 2 6 5 3 1
                             2 1 4 9 3 5 6 8 7
                             3 6 5 8 1 7 9 2 4
                             8 7 9 6 4 2 1 5 3";

            int[,] linhasSudoku = new int[9, 9];
            int[,] colunaSudoku = new int[9, 9];
            int[,] zonaSudoku = new int[9, 9];

            using (StringReader sudokuReader = new StringReader(sudoku))
            {

                string line = "";

                for (int x = 0; x < 9; x++)
                {
                    line = sudokuReader.ReadLine();

                    string[] valores = line.Trim().Split();

                    GerarLinha(linhasSudoku, x, valores);

                }
                GerarColuna(linhasSudoku, colunaSudoku);
                GerarBloco(linhasSudoku, zonaSudoku);
            }

            if (TemRepeticao(linhasSudoku))
            {
                Console.WriteLine("NÃO");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (TemRepeticao(colunaSudoku))
            {
                Console.WriteLine("NÃO");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (TemRepeticao(zonaSudoku))
            {
                Console.WriteLine("NÃO");
                Console.ReadLine();
                Environment.Exit(0);
            }

            
            Console.WriteLine("SIM");
            Console.ReadLine();
            

        }

        private static void GerarBloco(int[,] linhasSudoku, int[,] zonaSudoku)
        {
            int l = 0;

            for (int k = 0; k < 9; k++)
            {
                l = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int x = i + k % 3 * 3;
                        int y = j + k / 3 * 3;
                        zonaSudoku[k, l] = linhasSudoku[x, y];
                        l++;
                    }
                }
            }
        }

        private static void GerarColuna(int[,] linhasSudoku, int[,] colunaSudoku)
        {
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    colunaSudoku[a, b] = linhasSudoku[b, a];
                }
            }
        }

        private static void GerarLinha(int[,] linhasSudoku, int x, string[] valores)
        {
            for (int y = 0; y < 9; y++)
            {
                linhasSudoku[x, y] = Convert.ToInt32(valores[y]);
            }
        }

        private static bool TemRepeticao(int[,] arr)
        {
            for (int y = 0; y < 9; y++)
            {
                int[] arr2 = new int[9];
                for (int i = 0; i < 9; i++)
                {
                    arr2[i] = arr[y, i];
                }
                Hashtable table = new Hashtable();
                foreach (int i in arr2)
                {
                    if (table.ContainsKey(i))
                    {
                        return true;
                    }
                    else
                    {
                        table.Add(i, i);
                    }
                }  
            }
            return false;
        }
    }
}
