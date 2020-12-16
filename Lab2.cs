using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\KN-314\ТПР\Sanya\laba5S.txt";
            double[] doubleArray = ReadFile(path);
            Description(doubleArray);


            Console.ReadLine();
        }

        private static double[] ReadFile(string path)
        {
            List<double> lst = new List<double>();
            double[] doubleArray = new double[14];
            int contor = 0;
            string[] stringArray = System.IO.File.ReadAllLines(path);
            foreach (string example in stringArray)
            {
                lst.Add(Convert.ToDouble(example.Trim()));
                doubleArray[contor] = Convert.ToDouble(example.Trim());
                ++contor;
            }
            return doubleArray;
        }

        private static void Description(double[] doubleArray)
        {
            double[] budget = new double[2] { doubleArray[0], doubleArray[5] };
            double[] probability = new double[8] { doubleArray[2], doubleArray[4], doubleArray[7], doubleArray[9], doubleArray[10], doubleArray[11], doubleArray[12], doubleArray[13] };
            double[] income = new double[2] { doubleArray[1], doubleArray[6] };
            double[] losses = new double[2] { doubleArray[3], doubleArray[8] };
            double[] OGO = new double[4];
            double[] BGE = new double[4] { budget[0], budget[1], budget[0], budget[1] };
            double[] result = new double[4];

            Console.WriteLine("\t\t\t ___________________________________");
            Console.WriteLine("\t\t\t|                                   |");
            Console.WriteLine("\t\t\t|ТАБЛИЦI ВХIДНИХ УМОВ ДЛЯ ВУЗЛIВ 1-4|");
            Console.WriteLine("\t\t\t|___________________________________|");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Вузол 1. Побудова великого заводу негайно.");
            Console.WriteLine();
            Console.WriteLine("            |" + "Великий попит" + "  Низький попит");
            Console.WriteLine("____________ " + "_____________" + "  _____________");
            Console.WriteLine("Дохiд       |      " + income[0] + "           " + losses[0]);
            Console.WriteLine("Ймовiрнiсть |      " + probability[0] + "          " + probability[1]);
            OGO[0] = (probability[0] * income[0] + probability[1] * losses[0]) * 5;
            result[0] = OGO[0] - budget[0];
            Console.WriteLine("__________________________________________");
            Console.WriteLine();

            Console.WriteLine("Вузол 2. Побудова малого заводу негайно.");
            Console.WriteLine();
            Console.WriteLine("            |" + "Великий попит" + "  Низький попит");
            Console.WriteLine("____________ " + "_____________" + "  _____________");
            Console.WriteLine("Дохiд       |      " + income[1] + "           " + losses[1]);
            Console.WriteLine("Ймовiрнiсть |      " + probability[2] + "          " + probability[3]);
            Console.WriteLine();
            OGO[1] = (probability[2] * income[1] + probability[3] * losses[1]) * 5;
            result[1] = OGO[1] - budget[1];
            Console.WriteLine("__________________________________________");
            Console.WriteLine();

            Console.WriteLine("Вузол 3. Побудова великого заводу через 1 рiк. Ймовiрнiсть - " + probability[4]);
            Console.WriteLine();
            Console.WriteLine("            |" + "Великий попит" + "  Низький попит");
            Console.WriteLine("____________ " + "_____________" + "  _____________");
            Console.WriteLine("Дохiд       |      " + income[0] + "           " + losses[0]);
            Console.WriteLine("Ймовiрнiсть |      " + probability[6] + "          " + probability[7]);
            Console.WriteLine();
            OGO[2] = (probability[6] * income[0] + probability[7] * losses[0]) * 4 * probability[4];
            result[2] = OGO[2] - budget[0];
            Console.WriteLine("__________________________________________");
            Console.WriteLine();

            Console.WriteLine("Вузол 4. Побудова малого заводу через 1 рiк. Ймовiрнiсть - " + probability[4]);
            Console.WriteLine();
            Console.WriteLine("            |" + "Великий попит" + "  Низький попит");
            Console.WriteLine("____________ " + "_____________" + "  _____________");
            Console.WriteLine("Дохiд       |      " + income[1] + "           " + losses[1]);
            Console.WriteLine("Ймовiрнiсть |      " + probability[6] + "          " + probability[7]);
            Console.WriteLine();
            OGO[3] = (probability[6] * income[1] + probability[7] * losses[1]) * 4 * probability[4];
            result[3] = OGO[3] - budget[1];
            Console.WriteLine("__________________________________________");
            Console.WriteLine();

            Console.WriteLine("\t\t\t ___________________________________");
            Console.WriteLine("\t\t\t|                                   |");
            Console.WriteLine("\t\t\t|    ТАБЛИЦЯ ОЧIКУВАНИХ ДОХОДIВ     |");
            Console.WriteLine("\t\t\t|___________________________________|");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  {0,-6} {1,5} {2,5} {3,16}", "Вузол", " ОГО", "БГЕ", "  Очiкуванi доходи");
            Console.WriteLine("  {0,-6} {1,5}{2,5} {3,16}", "_____", "______", "___", "  ________________");
            double max = 0;
            double min = result[0];
            int index1 = 0;
            int index2 = 0;
            for (int i = 0; i < 4; i++)
            {
                if (result[i] > max)
                {
                    max = result[i];
                    index1 = i + 1;
                }
                if (result[i] < min)
                {
                    min = result[i];
                    index2 = i + 1;
                }
                Console.WriteLine("  {0,-6} {1,-6}  {2,-5}      {3,-5}", (i + 1), OGO[i], BGE[i], result[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Найефективнiше рiшення - {0} iз доходом ${1} тис.", index1, max);
            Console.WriteLine("Найменш ефективне рiшення - {0} iз збитками ${1} тис.", index2, (min * -1));

        }
    }
}