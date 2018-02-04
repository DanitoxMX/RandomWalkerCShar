using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomWalkerCSharp
{
    public partial class Form1 : Form
    {
        Graphics canvas;  //Creación de nuetro Canvas
        int x, y, direccion, size = 20;

        Random rnd = new Random();  //  Numeros Aleatorios
        SolidBrush stroke = new SolidBrush(Color.White);    //  Brocha Blanca
        SolidBrush strokeRed = new SolidBrush(Color.Red);   //  Bocha Roja es el pivote

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            draw.Stop();    //  Paramos el timer
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            draw.Start();   //Iniciamos el timer
        }

        private void Setup()        //Fución que recoge toda la configuración
        {
            canvas = pb1.CreateGraphics();  //  Aisgnacion del canvas
            x = pb1.Width / 2;
            y = pb1.Height / 2;
        }

        private void draw_Tick(object sender, EventArgs e)
        {
            canvas.FillEllipse(stroke, x-(size/2), y-(size/2), size, size); //  Trazo anterios

            direccion = (int)rnd.Next(4);   //  Generacion de los numeros aleatorios

            switch (direccion)
            {
                case 0: //  Paso al Frente
                    y--;
                    break;
                case 1: //  Paso a la derecha
                    x++;
                    break;
                case 2: //  Paso atras;
                    y++;
                    break;
                case 3: //  Paso a la izquierda
                    x--;
                    break;
            }

            canvas.FillEllipse(strokeRed, x - (size / 2), y - (size / 2), size, size);  //  Dibujamos el pivote
        }
    }
}
