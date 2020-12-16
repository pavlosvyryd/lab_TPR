using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Program
    {
        private static void RelativeMajority(int[] votes, string[,] candidates)
        {
            var na = 0;
            var nb = 0;
            var nc = 0;
            var nd = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Equals(candidates[0, i], "A"))
                    na += votes[i];
                else if (Equals(candidates[0, i], "B"))
                    nb += votes[i];
                else if (Equals(candidates[0, i], "C"))
                    nc += votes[i];
                else
                    nd += votes[i];
            }
            Console.WriteLine("N(A)=" + na + "   N(B)=" + nb + "   N(C)=" + nc + "   N(D)=" + nd);
            var max = Math.Max(Math.Max(na, nb), Math.Max(nc, nd));
            Console.WriteLine();
            if (max == na)
                Console.WriteLine(" А");
            if (max == nb)
                Console.WriteLine(" B");
            if (max == nc)
                Console.WriteLine("C");
            if (max == nd)
                Console.WriteLine(" D");
        }

        private static void AbsoluteMajority(int[] votes, string[,] candidates)
        {
            var na = 0;
            var nb = 0;
            var nc = 0;
            var nd = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Equals(candidates[0, i], "A"))
                    na += votes[i];
                else if (Equals(candidates[0, i], "B"))
                    nb += votes[i];
                else if (Equals(candidates[0, i], "C"))
                    nc += votes[i];
                else
                    nd += votes[i];
            }
            var sum = na + nb + nc + nd;

            if (na > sum / 2 || nb > sum / 2 || nc > sum / 2 || nd > sum / 2)
            {
                RelativeMajority(votes, candidates);
            }
            else
            {
                int[] sortedArray = new int[4] { na, nb, nc, nd };
                Array.Sort(sortedArray);
                Array.Reverse(sortedArray);

                string letter1, letter2;
                if (sortedArray[0] == na)
                    letter1 = "A";
                else if (sortedArray[0] == nb)
                    letter1 = "B";
                else if (sortedArray[0] == nc)
                    letter1 = "C";
                else
                    letter1 = "D";

                if (sortedArray[1] == na)
                    letter2 = "A";
                else if (sortedArray[1] == nb)
                    letter2 = "B";
                else if (sortedArray[1] == nc)
                    letter2 = "C";
                else
                    letter2 = "D";

                string[,] destinationArray = new string[4, 4];
                destinationArray = candidates.Clone() as string[,];

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (!Equals(destinationArray[i, j], letter1) && !Equals(destinationArray[i, j], letter2))
                            destinationArray[i, j] = " ";
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Equals(destinationArray[i, j], " "))
                        {
                            for (int k = i; k < 3; k++)
                            {
                                destinationArray[k, j] = destinationArray[k + 1, j];
                                destinationArray[k + 1, j] = " ";
                            }
                        }
                    }
                }

                Console.WriteLine("Другий тур");
                PrintArray(votes, destinationArray);

                AbsoluteMajority(votes, destinationArray);
            }
        }

        private static void Borde(int[] votes, string[,] candidates)
        {
            var na = 0;
            var nb = 0;
            var nc = 0;
            var nd = 0;
            int[] rankingArray = new int[4] { 3, 2, 1, 0 };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Equals(candidates[i, j], "A"))
                        na += votes[j] * rankingArray[i];
                    else if (Equals(candidates[i, j], "B"))
                        nb += votes[j] * rankingArray[i];
                    else if (Equals(candidates[i, j], "C"))
                        nc += votes[j] * rankingArray[i];
                    else if (Equals(candidates[i, j], "D"))
                        nd += votes[j] * rankingArray[i];
                }
            }
            Console.WriteLine("N(A)=" + na + "   N(B)=" + nb + "   N(C)=" + nc + "   N(D)=" + nd);
            var max = Math.Max(Math.Max(na, nb), Math.Max(nc, nd));
            Console.WriteLine();
            if (max == na)
                Console.WriteLine(" А");
            if (max == nb)
                Console.WriteLine(" B");
            if (max == nc)
                Console.WriteLine(" C");
            if (max == nd)
                Console.WriteLine(" D");
        }

        private static void Condorce(int[] votes, string[,] candidates)
        {
            var count1 = 0;
            var count2 = 0;
            var na = 0;
            var nb = 0;
            var nc = 0;
            var nd = 0;
            var indexA = 0;
            var indexB = 0;

            void CountCondorce(string name1, string name2)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Equals(candidates[j, i], name1))
                            indexA = j;
                        if (Equals(candidates[j, i], name2))
                            indexB = j;
                    }
                    if (indexA < indexB)
                        count1 += votes[i];
                    else
                        count2 += votes[i];
                }
                if (count1 > count2 && Equals(name1, "A"))
                    na++;
                else if (count1 > count2 && Equals(name1, "B"))
                    nb++;
                else if (count1 > count2 && Equals(name1, "C"))
                    nc++;
                else if (count1 > count2 && Equals(name1, "D"))
                    nd++;
                else if (count2 > count1 && Equals(name2, "A"))
                    na++;
                else if (count2 > count1 && Equals(name2, "B"))
                    nb++;
                else if (count2 > count1 && Equals(name2, "C"))
                    nc++;
                else if (count2 > count1 && Equals(name2, "D"))
                    nd++;
                Console.WriteLine(name1 + ":" + name2 + "=" + count1 + ":" + count2);
                count1 = 0;
                count2 = 0;
            }

            CountCondorce("A", "B");
            CountCondorce("A", "C");
            CountCondorce("A", "D");
            CountCondorce("B", "C");
            CountCondorce("B", "D");
            CountCondorce("C", "D");

            Console.WriteLine();
            if (na == 3)
                Console.WriteLine(" А");
            else if (nb == 3)
                Console.WriteLine(" B");
            else if (nc == 3)
                Console.WriteLine(" C");
            else if (nd == 3)
                Console.WriteLine(" D");
            else
                Console.WriteLine("Немає переможця.");
        }

        private static void Conpland(int[] votes, string[,] candidates)
        {
            var count1 = 0;
            var count2 = 0;
            var na = 0;
            var nb = 0;
            var nc = 0;
            var nd = 0;
            var indexA = 0;
            var indexB = 0;
            var result = 0;

            int CountConpland(string name1, string name2)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Equals(candidates[j, i], name1))
                            indexA = j;
                        if (Equals(candidates[j, i], name2))
                            indexB = j;
                    }
                    if (indexA < indexB)
                        count1 += votes[i];
                    else
                        count2 += votes[i];
                }
                if (count1 > count2)
                    result = 1;
                else if (count1 == count2)
                    result = 0;
                else
                    result = -1;
                count1 = 0;
                count2 = 0;
                return result;
            }
            na = CountConpland("A", "B") + CountConpland("A", "C") + CountConpland("A", "D");
            nb = CountConpland("B", "A") + CountConpland("B", "C") + CountConpland("B", "D");
            nc = CountConpland("C", "A") + CountConpland("C", "B") + CountConpland("C", "D");
            nd = CountConpland("D", "A") + CountConpland("D", "B") + CountConpland("D", "C");

            Console.WriteLine("K(A)=" + na + "   K(B)=" + nb + "   K(C)=" + nc + "   K(D)=" + nd);
            var max = Math.Max(Math.Max(na, nb), Math.Max(nc, nd));
            Console.WriteLine();
            if (max == na)
                Console.WriteLine(" А");
            if (max == nb)
                Console.WriteLine(" B");
            if (max == nc)
                Console.WriteLine(" C");
            if (max == nd)
                Console.WriteLine(" D");
        }

        private static void Simpson(int[] votes, string[,] candidates)
        {
            var count1 = 0;
            var result = 0;
            var na = 0;
            var nb = 0;
            var nc = 0;
            var nd = 0;
            var indexA = 0;
            var indexB = 0;

            int CountSimpson(string name1, string name2)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Equals(candidates[j, i], name1))
                            indexA = j;
                        if (Equals(candidates[j, i], name2))
                            indexB = j;
                    }
                    if (indexA < indexB)
                        count1 += votes[i];
                }
                result = count1;
                count1 = 0;
                return result;
            }
            na = Math.Min(Math.Min(CountSimpson("A", "B"), CountSimpson("A", "C")), CountSimpson("A", "D"));
            nb = Math.Min(Math.Min(CountSimpson("B", "A"), CountSimpson("B", "C")), CountSimpson("B", "D"));
            nc = Math.Min(Math.Min(CountSimpson("C", "A"), CountSimpson("C", "B")), CountSimpson("C", "D"));
            nd = Math.Min(Math.Min(CountSimpson("D", "A"), CountSimpson("D", "B")), CountSimpson("D", "C"));

            Console.WriteLine("S(A)=" + na + "   S(B)=" + nb + "   S(C)=" + nc + "   S(D)=" + nd);
            var max = Math.Max(Math.Max(na, nb), Math.Max(nc, nd));
            Console.WriteLine();
            if (max == na)
                Console.WriteLine(" А");
            if (max == nb)
                Console.WriteLine(" B");
            if (max == nc)
                Console.WriteLine(" C");
            if (max == nd)
                Console.WriteLine(" D");
        }
        private static void PrintArray(int[] votes, string[,] array)
        {
            for (int i = 0; i < votes.GetLength(0); i++)
            {
                Console.Write(votes[i] + " ");
            }
            Console.Write("\n");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[] voteArray = new int[4] { 5, 5, 4, 6 };
            string[,] candidatesArray = new string[4, 4]
            {
                {"A", "C", "B", "C"},
                {"B", "A", "C", "B"},
                {"C", "B", "D", "D"},
                {"D", "D", "A", "A"}
            };

            Console.WriteLine("Початкова матриця");
            PrintArray(voteArray, candidatesArray);
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Вiдносна бiльшiсть");
            Console.WriteLine();
            RelativeMajority(voteArray, candidatesArray);
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Абсолютна бiльшiсть");
            Console.WriteLine();
            AbsoluteMajority(voteArray, candidatesArray);
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Борда");
            Console.WriteLine();
            Borde(voteArray, candidatesArray);
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Кондорсе");
            Console.WriteLine();
            Condorce(voteArray, candidatesArray);
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Конпленд");
            Console.WriteLine();
            Conpland(voteArray, candidatesArray);
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.WriteLine("Сiмпсон");
            Console.WriteLine();
            Simpson(voteArray, candidatesArray);
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}