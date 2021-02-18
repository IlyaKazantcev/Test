using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int equilibrium = 0;
            int a = 0;
            int b = 0;
            var chips = new List<int>();
            int temp;
            string strchips;

            Console.WriteLine("Для начала работы введите количество фишек на каждом месте через запятую, после нажмите Enter" + '\n');

            strchips = Console.ReadLine();
            strchips = strchips.Trim(' ');
            while (a == 0)
            {
                if (strchips.Contains(",") != false)
                {
                    temp = strchips.IndexOf(",");
                    chips.Add(Convert.ToInt32(strchips.Remove(temp)));
                    strchips = strchips.Remove(0, temp + 1);
                }
                else
                {
                    chips.Add(Convert.ToInt32(strchips));
                    break;
                }
            }

            foreach (int i in chips)
            {
                equilibrium += i;
                n++;
            }
            equilibrium /= n;

            int ready, steps;
            steps = 0;
            while (a == 0)
            {
                int min = chips[0];
                int indexmin = 0;
                for (int i = 1; i < chips.Count; i++)
                {
                    if (min > chips[i])
                    {
                        min = chips[i];
                        indexmin = i;
                    }
                }
                temp = 1;
                while (b == 0)
                {
                    try
                    {
                        if (chips[indexmin + temp] > equilibrium)
                        {
                            chips[indexmin + temp]--;
                            chips[indexmin]++;
                            steps += temp;
                            break;
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        if (chips[indexmin + temp - chips.Count] > equilibrium)
                        {
                            chips[indexmin + temp - chips.Count]--;
                            chips[indexmin]++;
                            steps += temp;
                            break;
                        }
                    }
                    try
                    {
                        if (chips[indexmin - temp] > equilibrium)
                        {
                            chips[indexmin - temp]--;
                            chips[indexmin]++;
                            steps += temp;
                            break;
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        if (chips[indexmin - temp + chips.Count] > equilibrium)
                        {
                            chips[indexmin - temp + chips.Count]--;
                            chips[indexmin]++;
                            steps += temp;
                            break;
                        }
                    }
                    temp++;
                }
                ready = 0;
                foreach (int i in chips)
                {
                    if (i == equilibrium)
                    {
                        ready++;
                    }
                }
                if (ready == chips.Count)
                {
                    a = 1;
                    break;
                }
            }
            Console.WriteLine("Итоговое распределение:");
            foreach (int i in chips)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine('\n' + "Количество шагов");
            Console.WriteLine(steps);
            Console.ReadKey();
        }
    }
}
