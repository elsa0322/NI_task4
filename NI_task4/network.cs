using System.Collections.Generic;
using System.IO;

namespace NS_4
{
    class network
    {
        public List<List<List<double>>> Neurons;

        public network(string file)
        {
            Neurons = matrix_vector.ReadNetowrk(file);
        }

        public void Serialize(string output)
        {
            FileStream file = new FileStream(output, FileMode.Create);
            StreamWriter write = new StreamWriter(file);
            write.Write("{\"Neurons\":");
            write.Write("[");
            for (int i = 0; i < Neurons.Count; i++)
            {
                if (i != 0)
                    write.Write(",");
                write.Write("[");
                for (int j = 0; j < Neurons[i].Count; j++)
                {
                    if (j != 0)
                        write.Write(",");
                    write.Write("[");
                    for (int k = 0; k < Neurons[i][j].Count; k++)
                    {
                        if (k != 0)
                            write.Write(",");
                        write.Write(Neurons[i][j][k].ToString().Replace(',', '.'));
                    }
                    write.Write("]");
                }
                write.Write("]");
            }
            write.Write("]}");
            write.Close();
            file.Close();
        }
    }
}

