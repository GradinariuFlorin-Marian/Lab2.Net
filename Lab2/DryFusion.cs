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
            }
            else
            {
                computeData(myList, nameValue, scoreValue, 8, 6, 8, 1);
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