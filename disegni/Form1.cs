using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace disegni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public bool disegnaoggetti = true;
        public int x;
        public int y;
        public bool inizio = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void DisegnaCerchio(object sender, PaintEventArgs e)
        {

            if (disegnaoggetti)
            {
                if(inizio == true)
                {
                    inizio = false;

                    x = 50; y = 50;

                    Graphics g = this.panel1.CreateGraphics();
                    Pen cerchio = new Pen(Color.Black, 2);
                    Rectangle rettangolo_cerchio = new Rectangle(x, y, 50, 50);

                    g.DrawEllipse(cerchio, rettangolo_cerchio);
                }
                else
                {
                    x += 50; y += 50;

                    Graphics g = this.panel1.CreateGraphics();
                    Pen cerchio = new Pen(Color.Black, 2);
                    Rectangle rettangolo_cerchio = new Rectangle(x, y, 50, 50);

                    g.DrawEllipse(cerchio, rettangolo_cerchio);
                }
            }
        }

        public void DisegnaLinea(object sender, PaintEventArgs e)
        {
            if (disegnaoggetti)
            {
                if (inizio == true)
                {
                    x = 50; y = 50;

                    Graphics g = this.panel1.CreateGraphics();
                    Pen linea = new Pen(Color.Black, 2);

                    PointF p1 = new PointF(x, y);

                    x += 50; y += 5;

                    PointF p2 = new PointF(x, y);

                    g.DrawLine(linea, p1, p2);
                }
                else
                {
                    x += 50; y += 50;

                    Graphics g = this.panel1.CreateGraphics();
                    Pen linea = new Pen(Color.Black, 2);

                    PointF p1 = new PointF(x, y);

                    x += 50; y += 5;

                    PointF p2 = new PointF(x, y);

                    g.DrawLine(linea, p1, p2);
                }
            }
        }

        public void DisegnaGrafo()
        {
            this.Paint += new PaintEventHandler(DisegnaCerchio); 
            this.Paint += new PaintEventHandler(DisegnaLinea);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string titolo_input = "Numero nodi", frase = "Inserisci il numero di nodi";
            object input_n = Interaction.InputBox(frase, titolo_input);

            int n = int.Parse(input_n.ToString());

            DisegnaGrafo();

            this.Invalidate();

           

        }
    }
}
