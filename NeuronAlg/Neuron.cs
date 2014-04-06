using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronAlg
{
    class Neuron
    {

        private double[] w;
        private int activator_number;
        private string symbol="";

        public Neuron(int image_size, string letter,int activ)
        {
            w = new double[image_size*image_size];
            activator_number = activ;
            symbol = letter;

            initWeights();
        }
        public override string ToString()
        {
            return symbol;
        }


        private void initWeights()
        {
            Random rnd = new Random();
            for (int i = 0; i < w.Length; i++)
            {
                w[i] =  rnd.Next(1, 10);
            }
            System.Threading.Thread.Sleep(10);
        }

        private int activator(double number)
        {
            if (number >= activator_number)
            {
                return 1;
            }
            else { return 0; }
        }

        public int transfer(int[] x)
        {
            return activator(sum(x));
        }


        private double sum(int[] x)
        {
            double ret = 0;
            for (int i = 0; i < w.Length; i++)
            {
                ret =  ret + w[i] * x[i];
            }
            return ret;
        }
        public void changeWeights(double v, int d, int[] x)
        {
            for (int i = 0; i < w.Length; i++)
            {
                w[i] += v * d * x[i];
            }
        }



    }
}
