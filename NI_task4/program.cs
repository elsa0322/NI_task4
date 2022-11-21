using System;
using System.Collections.Generic;
using System.Linq;

namespace NS_4
{
    class program
    {
        static void task4()
        {
            network n = null;
            List<double> v = null;

            n = new network("input.txt");
            v = matrix_vector.ReadVector("input_vector.txt");
            n.Serialize("output.json");

            matrix worker = new matrix(n, 1, v);

            List<double> res = worker.Evaluate();
            string sres = "";
            foreach (double t in res)
            {
                sres += ", " + t.ToString();
            }
            sres = sres.Substring(2);
            Console.WriteLine(sres);
            matrix_vector.Write(sres, "output.txt");

            Console.ReadLine();
        }

        private static void EvaluateStep(network n, List<Pair> vs, List<List<double>> ys, List<List<double>> ss, List<matrix> workers)
        {
            foreach (Pair v in vs)
            {
                matrix worker = new matrix(n, 1, (List<double>)v.First);
                ys.Add(worker.Evaluate());
                ss.Add(worker.ss);
                workers.Add(worker);
            }
        }

        private static void LearnStep(network n, List<List<double>> ys, List<List<double>> ds, List<List<double>> ss, List<matrix> workers, List<List<List<double>>> previousDeltas)
        {
            List<double> delta = new List<double>();
            int minDiffIdx = action_function.GetMinSquareDifference(ys, ds);
            for (int i = 0; i < ys[minDiffIdx].Count; i++)
            {
                delta.Add((ys[minDiffIdx][i] - ds[minDiffIdx][i]) * action_function.sigmoidFunction2(ss[n.Neurons.Count - 1][i], 1));
            }

            for (int k = n.Neurons.Count - 1; k >= 0; k--)
            {
                if (k < n.Neurons.Count - 1)
                {
                    List<double> newDelta = new List<double>();
                    for (int i = 0; i < n.Neurons[k + 1][0].Count; i++)
                    {
                        double sum = 0;
                        for (int j = 0; j < delta.Count; j++)
                        {
                            sum += delta[j] * n.Neurons[k + 1][j][i];
                        }
                        newDelta.Add(sum * action_function.sigmoidFunction2(ss[k][i], 1)
                        );
                    }
                    delta = newDelta;
                }

                double e = 0.5;
                double m = 0.1;
                for (int i = 0; i < n.Neurons[k].Count; i++)
                {
                    for (int j = 0; j < n.Neurons[k][i].Count; j++)
                    {
                        Double wkij = n.Neurons[k][i][j];
                        double wDeltaNew = delta[i] * workers[minDiffIdx].getLayerOutputs(k - 1)[j];
                        double wDeltaPrev = previousDeltas[k][i][j];
                        double wDelta = e * (m * wDeltaPrev + (1 - m) * wDeltaNew);
                        wkij += wDelta;
                        previousDeltas[k][i][j] = wDelta;
                        n.Neurons[k][i][j] = wkij;
                    }
                }


            }
        }

        static void Main(string[] args)
        {
            task4();
        }
    }
}

