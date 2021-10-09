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
            int scoreValue = Int32.MaxValue;
            StringBuilder nameValue = new StringBuilder();
            foreach (string line in lines)
            {
                string[] ln = line.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
                myList.Add(ln);
            }

            if (type.Equals("weather"))
            {
                weatherProgram(myList, nameValue, scoreValue);
            }
            else
            {
                footballProgram(myList, nameValue, scoreValue);
            }
        }

        public void weatherProgram(ArrayList weatherList, StringBuilder nameValue, int scoreValue)
        {
            foreach (string[] name in weatherList)
            {
                if (name.Length > 0)
                {
                    if (verifyNumber(name[0]) && verifyNumber(name[1].Replace("*", "")) &&
                        verifyNumber(name[2].Replace("*", "")))
                    {
                        int max = IntegerType.FromString(name[1].Replace("*", ""));
                        int min = IntegerType.FromString(name[2].Replace("*", ""));
                        if ((max - min) < scoreValue)
                        {
                            nameValue.Clear();
                            nameValue.Append(name[0]);
                            scoreValue = max - min;
                        }
                    }
                }
            }

            Console.WriteLine("\t" + nameValue + " " + scoreValue);
        }

        public void footballProgram(ArrayList footballList, StringBuilder nameValue, int scoreValue)
        {
            foreach (string[] name in footballList)
            {
                if (name.Length > 8)
                {
                    if (verifyNumber(name[6]) && verifyNumber(name[8]))
                    {
                        int scored = IntegerType.FromString(name[6]);
                        int against = IntegerType.FromString(name[8]);
                        if (Math.Abs(scored - against) < scoreValue)
                        {
                            scoreValue = Math.Abs(scored - against);
                            nameValue.Clear();
                            nameValue.Append(name[1]);
                        }
                    }
                }
            }

            Console.WriteLine("\t" + nameValue + " " + scoreValue);
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