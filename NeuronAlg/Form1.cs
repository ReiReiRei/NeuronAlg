using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuronAlg
{
    public partial class Form1 : Form
    {

        double rate = 0.2;
        int activation = 1500;
        Perceptron perceprton;
        public Form1()
        {
            InitializeComponent();
            perceprton = new Perceptron(50, activation, rate);
        }

        private int[] Normalize(Bitmap img)
        {
            int[] map = new int[img.Size.Height * img.Size.Width];

            for(int i = 0;i<img.Size.Width;i++)
            {
                for(int j=0;j<img.Size.Height;j++)
                {
                    if(img.GetPixel(i,j).B == 0)
                    {
                        map[i * img.Size.Width + j] = 1;
                    }
                    else { map[i * img.Size.Width + j] = 0; }
                       
                }
            }
            return map;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] rec;
            if (tryFileDialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Load(tryFileDialog.FileName);
               rec = perceprton.Recognize(Normalize(new Bitmap(tryFileDialog.FileName)));
              
               textBox1.Text = perceprton.getSymbol(rec);
                
            }
         
                    
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( teachFileDIalog.ShowDialog() == DialogResult.OK )
            {
                foreach(var file in teachFileDIalog.FileNames)
                {
                    perceprton.teach(Normalize( new Bitmap(file )),textBox2.Text);
                }
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            activation = Convert.ToInt32(textBox3.Text);
            perceprton.activation_number = activation;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = activation.ToString();
            textBox4.Text = rate.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            rate = Convert.ToDouble(textBox4.Text);
            perceprton.learning_rate = rate;

        }

      


    }
}
