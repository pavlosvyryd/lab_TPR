using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] mas = new double[3, 4] {
            {100, 70, 60, 0},
            {80, 90, 70, 0},
            {60, 70, 80, 0}};
            //Критеій Вальда
            for (int i = 0; i < 3; i++)
            {
                mas[i, 3] = Math.Min(Math.Min(mas[i, 0], mas[i, 1]), mas[i, 2]);
            }
            Print("Критерiй Вальда", mas);
            double[] mas1 = new double[3];
            for (int i = 0; i < 3; i++)
            {
                mas1[i] = mas[i, 3];
            }
            double vidp = Math.Max(Math.Max(mas1[0], mas1[1]), mas1[2]);
            Description(vidp);
            //Критерій Севіджа
            double max = 0;
            for (int i = 0; i < 3; i++)
            {
                max = Math.Max(Math.Max(mas[i, 0], mas[i, 1]), mas[i, 2]);
                mas[i, 3] = Math.Max(Math.Max(max - mas[i, 0], max - mas[i, 1]), max - mas[i, 2]);
            }
            Print("Критерiй Севiджа", mas);
            for (int i = 0; i < 3; i++)
            {
                mas1[i] = mas[i, 3];
            }
            vidp = Math.Min(Math.Min(mas1[0], mas1[1]), mas1[2]);
            Description(vidp);
            //Критерій Гурвіца
            double min = 0;
            max = 0;
            double al = 0.5;
            for (int i = 0; i < 3; i++)
            {
                max = Math.Max(Math.Max(mas[i, 0], mas[i, 1]), mas[i, 2]);
                min = Math.Min(Math.Min(mas[i, 0], mas[i, 1]), mas[i, 2]);
                mas[i, 3] = al * max + (1 - al) * min;
            }
            Print("Критерiй Гурвiца", mas);
            for (int i = 0; i < 3; i++)
            {
                mas1[i] = mas[i, 3];
            }
            vidp = Math.Max(Math.Max(mas1[0], mas1[1]), mas1[2]);
            Description(vidp);
            //Критерій Байеса-Лапласа
            var p1 = 0.15;
            var p2 = 0.5;
            var p3 = 0.35;
            for (int i = 0; i < 3; i++)
            {
                mas[i, 3] = p1 * mas[i, 0] + p2 * mas[i, 1] + p3 * mas[i, 2];
            }
            Print("Критерiй Байеса-Лапласа", mas);
            for (int i = 0; i < 3; i++)
            {
                mas1[i] = mas[i, 3];
            }
            vidp = Math.Max(Math.Max(mas1[0], mas1[1]), mas1[2]);
            Description(vidp);
            //Модальний критерій
            min = 0;
            max = 0;
            if (p1 > p2 && p1 > p3)
            {
                for (int i = 0; i < 3; i++)
                {
                    mas[i, 3] = mas[i, 0];
                }
            }
            else if (p2 > p1 && p2 > p3)
            {
                for (int i = 0; i < 3; i++)
                {
                    mas[i, 3] = mas[i, 1];
                }
            }
            else if (p3 > p1 && p3 > p2)
            {
                for (int i = 0; i < 3; i++)
                {
                    mas[i, 3] = mas[i, 2];
                }
            }
            else
                Console.WriteLine("НЕоднозначна вiдповiдь");

            Print("Модальний критерiй", mas);
            for (int i = 0; i < 3; i++)
            {
                mas1[i] = mas[i, 3];
            }
            vidp = Math.Max(Math.Max(mas1[0], mas1[1]), mas1[2]);
            Description(vidp);
            Console.ReadLine();
        }
        private static void Print(string name, double[,] array)
        {
            Console.WriteLine(name);
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Write("x" + (i + 1) + " ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private static void Description(double vidp)
        {
            Console.WriteLine("найкращий:" + vidp);
            Console.WriteLine("_________________________________");
            Console.WriteLine();
        }
    }
}
