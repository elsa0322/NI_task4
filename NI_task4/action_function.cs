using System;
using System.Collections.Generic;

namespace NS_4
{
    class action_function
    {
        public static double sigmoidFunction(double z, double c)
        {
            return 1.0 / (1.0 + Math.Exp(-(c * z)));
        }

        public static double hyperbolicTanFunction(double z, double c)
        {
            return Math.Sin(c * z) / Math.Cos(c * z);
        }

        public static double rationalSigmoidFunction(double z, double c)
        {
            return 1.0 / (c + Math.Abs(z)); ;
        }

        public static double sigmoidFunction2(double z, double c)
        {
            double x = sigmoidFunction(z, c);
            return x * (1 - x);
        }

        public static double SquareFunction(List<List<double>> ys, List<List<double>> ds)
        {
            double res = 0;
            if (ys.Count != ds.Count)
                Console.WriteLine("Количество векторов выборки не совпадает с количеством выходных векторов");
            for (int i = 0; i < ys.Count; i++)
            {
                if (ys[i].Count != ds[i].Count)
                    Console.WriteLine("Размер вектора выборки не совпадает с размером выходного вектора");
                for (int j = 0; j < ys[i].Count; j++)
                {
                    res += Math.Pow(ys[i][j] - ds[i][j], 2);
                }
            }

            return res / 2;
        }

        public static int GetMinSquareDifference(List<List<double>> ys, List<List<double>> ds)
        {
            if (ys.Count != ds.Count)
                Console.WriteLine("Количество векторов выборки не совпадает с количеством выходных векторов");

            double minRes = -1;
            int minIdx = 0;
            for (int i = 0; i < ys.Count; i++)
            {
                if (ys[i].Count != ds[i].Count)
                    Console.WriteLine("Размер вектора выборки не совпадает с размером выходного вектора");

                double res = 0;
                for (int j = 0; j < ys[i].Count; j++)
                {
                    res += Math.Pow(ys[i][j] - ds[i][j], 2);
                }
                res /= 2;
                if (minRes < 0 || res < minRes)
                {
                    minRes = res;
                    minIdx = i;
                }
            }

            return minIdx;
        }
    }
}

