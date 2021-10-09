using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            int mval = Int32.MaxValue;
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                string[] ln = line.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
                if (ln.Length > 0)
                {
                    if (verifyNumber(ln[0]) && verifyNumber(ln[1].Replace("*", "")) &&
                        verifyNumber(ln[2].Replace("*", "")))
                    {
                        int max = IntegerType.FromString(ln[1].Replace("*", ""));
                        int min = IntegerType.FromString(ln[2].Replace("*", ""));
                        if ((max - min) < mval)
                        {
                            sb.Clear();
                            sb.Append(ln[0]);
                            mval = max - min;
                        }
                    }
                }
            }

            Console.WriteLine("\t" + sb + " " + mval);

            Console.WriteLine("\nSecond program: ");
            //Second program
            string[] lines2 = System.IO.File.ReadAllLines("/Users/gradinariuflorin-marian/Desktop/football.dat");
            int minscore = Int32.MaxValue;
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
                        if (Math.Abs(scored - against) < minscore)
                        {
                            minscore = Math.Abs(scored - against);
                            teamName.Clear();
                            teamName.Append(ln[1]);
                        }
                    }
                }
            }

            Console.WriteLine("\t" + teamName + " " + minscore);
            Console.WriteLine("\nDry code 1:");
            new DryFusion("/Users/gradinariuflorin-marian/Desktop/weather.dat", "weather");
            Console.WriteLine("\nDry code 2:");
            new DryFusion("/Users/gradinariuflorin-marian/Desktop/football.dat", "football");
        }

        public static Boolean verifyNumber(String number)
        {
            try
            {
                IntegerType.FromString(number);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}