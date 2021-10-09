using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //First Program
            Console.WriteLine("First program: ");
            string[] lines = System.IO.File.ReadAllLines("/Users/gradinariuflorin-marian/Desktop/weather.dat");
            foreach (string line in lines)
            {
                string[] ln = line.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
                if (ln.Length > 0)
                    Console.WriteLine("\t" + ln[0] + " " + ln[2].Replace("*", ""));
            }

            Console.WriteLine("\nSecond program: ");
            //Second program
            string[] lines2 = System.IO.File.ReadAllLines("/Users/gradinariuflorin-marian/Desktop/football.dat");
            int minscore = Int32.MinValue;
            StringBuilder teamName = new StringBuilder();
            foreach (string line in lines2)
            {
                string[] ln = line.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
                if (ln.Length > 8)
                {
                    if (verifyNumber(ln[6]) && verifyNumber(ln[8]))
                    {
                        int scored = IntegerType.FromString(ln[6]);
                        int against = IntegerType.FromString(ln[8]);
                        if ((scored - against) > minscore)
                        {
                            minscore = scored - against;
                            teamName.Clear();
                            teamName.Append(ln[1]);
                        }
                    }
                }
            }

            Console.WriteLine("\t" + teamName + " " + minscore);
        }

        public static Boolean verifyNumber(String number)
        {
            try
            {
                IntegerType.FromString(number);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}