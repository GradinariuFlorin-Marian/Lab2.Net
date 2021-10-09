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
                computeData(myList, nameValue, scoreValue, 0, 1, 2, 0);
                // weatherProgram(myList, nameValue, scoreValue);
            }
            else
            {
                computeData(myList, nameValue, scoreValue, 8, 6, 8, 1);
                // footballProgram(myList, nameValue, scoreValue);
            }
        }

        public void computeData(ArrayList myList, StringBuilder nameValue, int scoreValue, int line1, int column1,
            int column2, int nameCol)
        {
            foreach (string[] name in myList)
            {
                if (name.Length > line1)
                {
                    if (verifyNumber(name[line1]) && verifyNumber(name[column1].Replace("*", "")) &&
                        verifyNumber(name[column2].Replace("*", "")))
                    {
                        int max = IntegerType.FromString(name[column1].Replace("*", ""));
                        int min = IntegerType.FromString(name[column2].Replace("*", ""));
                        if (Math.Abs(max - min) < scoreValue)
                        {
                            nameValue.Clear();
                            nameValue.Append(name[nameCol]);
                            scoreValue = Math.Abs(max - min);
                        }
                    }
                }
            }

            Console.WriteLine("\t" + nameValue + " " + scoreValue);
        }

        public void weatherProgram(ArrayList myList, StringBuilder nameValue, int scoreValue)
        {
            foreach (string[] name in myList)
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
                            nameValue.Clear();
                            nameValue.Append(name[1]);
                            scoreValue = Math.Abs(scored - against);

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