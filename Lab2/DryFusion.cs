using System;
using System.Collections;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab2
{
    public class DryFusion
    {
        public DryFusion(string fileName, string type)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            ArrayList myList = new ArrayList();
            foreach (string line in lines)
            {
                string[] ln = line.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
                myList.Add(ln);
            }

            if (type.Equals("weather"))
            {
                weatherProgram(myList);
            }
            else
            {
                footballProgram(myList);
            }
        }

        public void weatherProgram(ArrayList weatherList)
        {
            foreach (string[] name in weatherList)
            {
                if (name.Length > 0)
                    Console.WriteLine("\t" + name[0] + " " + name[2].Replace("*", ""));
            }
        }

        public void footballProgram(ArrayList footballList)
        {
            int minscore = Int32.MinValue;
            StringBuilder teamName = new StringBuilder();
            foreach (string[] name in footballList)
            {
                if (name.Length > 8)
                {
                    if (verifyNumber(name[6]) && verifyNumber(name[8]))
                    {
                        int scored = IntegerType.FromString(name[6]);
                        int against = IntegerType.FromString(name[8]);
                        if ((scored - against) > minscore)
                        {
                            minscore = scored - against;
                            teamName.Clear();
                            teamName.Append(name[1]);
                        }
                    }
                }
            }

            Console.WriteLine("\t" + teamName + " " + minscore);
        }

        public Boolean verifyNumber(String number)
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