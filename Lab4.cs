using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double digit = 0;
            double[,] competence = new double[4, 6]
            {
                { 0.31, 0.1, 0.5, 0.08, 0.05, 0},
                { 0.27, 0.2, 0.4, 0.08, 0.04, 0},
                { 0.19, 0.1, 0.5, 0.04, 0.05, 0},
                { 0.76, 0.1, 0.4, 0.1, 0.02, 0}
            };
            int n = 6;
            for (int i = 0; i < 4; i++)
            {
                competence[i, 5] = (competence[i, 0] + competence[i, 1] + competence[i, 2] + competence[i, 3] + competence[i, 4]) / 2;
            }
            Console.WriteLine("Джерела аргументiв");
            Console.WriteLine("   Кз   ТА   Дос   Лiт   Iнт   Кк");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("E" + (i + 1) + " ");
                for (int j = 0; j < 6; j++)
                {
                    if (competence[i, j] >= 0.1 && competence[i, j] <= 0.1)
                    {
                        digit = Math.Round(competence[i, j], 2);
                        Console.Write(digit + "  |");
                    }
                    else
                    {
                        digit = Math.Round(competence[i, j], 2);
                        Console.Write(digit + " |");
                    }
                }
                Console.WriteLine();
            }
            double[,] grades = new double[7, 6];

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 6; ++j)
                {
                    grades[i, j] = random.Next(0, 10);
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    grades[4, i] += (grades[j, i] * competence[j, 5]);
                }
                grades[4, i] = Math.Round((grades[4, i] / 4), 2);
            }
            double[] rank = new double[6];
            for (int i = 0; i < 6; i++)
            {
                rank[i] = grades[4, i];
            }
            Array.Sort(rank);
            Array.Reverse(rank);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (rank[i] == grades[4, j])
                    {
                        grades[5, j] = i + 1;
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                grades[6, i] = 2 * (((n + 1) - grades[5, i]) / (n * (n + 1)));
                grades[6, i] = Math.Round(grades[6, i], 8);
            }
            Console.WriteLine();
            Console.WriteLine("Частковi критерiї");
            Console.WriteLine("   f1 f2 f3 f4 f5 f6 ");
            for (int i = 0; i < 7; i++)
            {
                if (i < 4)
                    Console.Write("E" + (i + 1) + " ");
                if (i == 4)
                    Console.Write("M  ");
                if (i == 5)
                    Console.Write("R  ");
                if (i == 6)
                    Console.Write("l  ");
                for (int j = 0; j < 6; j++)
                {
                    if (grades[i, j] < 10)
                        Console.Write(grades[i, j] + "  ");
                    else
                        Console.Write(grades[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}