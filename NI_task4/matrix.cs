using System;
using System.Collections.Generic;

namespace NS_4
{
    class matrix
    {
        public List<double> state;
        public network neuralNetwork;
        public action_function activationFunction;
        public int constant;
        public List<double> ss;
        public List<List<double>> layerOutputs;

        public matrix(network neuralNetwork, int constant, List<double> inputVector)
        {
            this.neuralNetwork = neuralNetwork;
            this.state = inputVector;
            this.constant = constant;
            this.ss = new List<double>();
            this.layerOutputs = new List<List<double>>();
            this.layerOutputs.Add(inputVector);
        }


        public List<double> Evaluate()
        {
            int curStateLength;
            foreach (List<List<double>> layer in neuralNetwork.Neurons)
            {
                curStateLength = state.Count;
                List<Double> nextState = new List<double>();
                for (int i = 0; i < layer.Count; i++)
                {
                    if (layer[i].Count != curStateLength)
                    {
                        Console.WriteLine("Длина входа не совпадает с длиной строки матрицы");
                    }
                    double sum = 0;
                    for (int j = 0; j < layer[i].Count; j++)
                    {
                        sum += layer[i][j] * state[j];
                    }
                    ss.Add(sum);
                    nextState.Add(action_function.hyperbolicTanFunction(sum, constant));
                }
                layerOutputs.Add(nextState);
                state = nextState;
            }

            return state;
        }

        public List<Double> getLayerOutputs(int i)
        {
            return layerOutputs[i + 1];
        }
    }
}
