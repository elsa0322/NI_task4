using System;
using System.Collections.Generic;
using System.IO;

namespace NS_4
{
    class matrix_vector
    {
        public static List<List<List<double>>> ReadNetowrk(string input)
        {
            List<List<List<double>>> res = new List<List<List<double>>>();
            FileStream file = new FileStream(input, FileMode.Open);
            StreamReader read = new StreamReader(file);

            while (!read.EndOfStream)
            {
                List<List<double>> matrix = new List<List<double>>();
                string[] line = read.ReadLine().Replace("],", "|").Replace("[", "").Replace("]", "").Split('|');
                foreach (string data in line)
                {
                    string[] tempData = data.Split(',');
                    matrix.Add(new List<double>());
                    foreach (string doub in tempData)
                    {
                        matrix[matrix.Count - 1].Add(Convert.ToDouble(doub.Replace('.', ',')));
                    }
                }
                res.Add(matrix);
            }
            read.Close();
            file.Close();
            return res;
        }

        public static List<Pair> ReadVectors(string input)
        {
            List<Pair> res = new List<Pair>();
            FileStream file = new FileStream(input, FileMode.Open);
            StreamReader read = new StreamReader(file);
            while (!read.EndOfStream)
            {
                string[] temp = read.ReadLine().Split('|');
                string[] tempFirst = temp[0].Split(' ');
                string[] tempSecond = temp[1].Split(' ');

                List<double> f = new List<double>();
                List<double> s = new List<double>();
                for (int i = 0; i < 3; i++)
                {
                    f.Add(Convert.ToDouble(tempFirst[i]));
                    s.Add(Convert.ToDouble(tempSecond[i]));
                }
                res.Add(new Pair(f, s));
            }
            read.Close();
            file.Close();
            return res;
        }

        public static List<double> ReadVector(string input)
        {
            List<double> res = new List<double>();
            FileStream file = new FileStream(input, FileMode.Open);
            StreamReader read = new StreamReader(file);
            string[] temp = read.ReadLine().Split(' ');
            read.Close();
            file.Close();
            foreach (string s in temp)
            {
                res.Add(Convert.ToDouble(s.Replace('.', ',')));
            }
            return res;
        }

        public static void GenVec(int count)
        {
            FileStream file = new FileStream("invecs.txt", FileMode.Create);
            StreamWriter write = new StreamWriter(file);

            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                double x1 = rnd.NextDouble() / 3;
                double x2 = rnd.NextDouble() / 3;
                double x3 = rnd.NextDouble() / 3;
                string s = "";
                s += x1 + " " + x2 + " " + x3 + "|";
                s += x1 * 2 + " " + x2 * 2 + " " + x3 * 2;
                write.WriteLine(s);
            }

            write.Close();
            file.Close();
        }

        public static void Write(string s, string output)
        {
            FileStream file = new FileStream(output, FileMode.Create);
            StreamWriter write = new StreamWriter(file);
            write.Write(s);
            write.Close();
            file.Close();
        }
    }
}

