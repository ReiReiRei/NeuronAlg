using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NeuronAlg
{
    class Perceptron
    {
        private Dictionary<string,Neuron>  neuronesPosition = new Dictionary<string,Neuron>();
        private List<Neuron> neurones = new List<Neuron>();

        private int image_size;
        public double learning_rate
        {
            get;
            set;
        }
        public int activation_number
        {
            get;set;
        }
        public Perceptron(int image, int activationNumber,double rate)
        {
            image_size = image;
            activation_number = activationNumber;
            learning_rate = rate;
            
     
        }





        public int[] Recognize(int[] x)
        {
            int[] y = new int[neurones.Count];
            for (int i = 0; i < neurones.Count;i++ )
            {
                y[i] = neurones[i].transfer(x);
            }

            return y;
        }

        public string getSymbol(int[] y)
        {
            for(int i = 0;i<y.Length;i++)
            {
                if (y[i] == 1) { return neurones[i].ToString(); }
            }
            return "Не опознано";
        }


        public void teach(int[] vector,string symbol)
        {
            
            
            if(!neuronesPosition.ContainsKey(symbol))
            {
                Neuron  newNeuron = new Neuron(image_size,symbol,activation_number);
                neurones.Add(newNeuron);
                neuronesPosition.Add(symbol,newNeuron );            

            }
            int[] truth_vector = makeTruthVector(symbol);
            int d;
            

            int[] t;
            do
            {
                t = Recognize(vector);

                for (int j = 0; j < neurones.Count; j++)
                {
                    d = truth_vector[j] - t[j];

                    neurones[j].changeWeights(learning_rate, d, vector);
                }

            } while (!isSame(t, truth_vector));

        }

        private int[] makeTruthVector(string symbol)
        {
            int[] truthVector = new int[neurones.Count];
            if(!neuronesPosition.ContainsKey(symbol))
            {
                return truthVector;
            }
            truthVector[neurones.IndexOf(neuronesPosition[symbol])] = 1;
            return truthVector;
        }

        private bool isSame(int[] x, int[] y)
        {
            if (x.Length != y.Length) { return false; }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        

        


    }
}
