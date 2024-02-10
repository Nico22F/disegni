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
        public bool inizio = true;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // struct che contiente tutti i dati

        public struct Struct
        {
            public int x;
            public int y;
            public string nome;
        }

        public int pos = 0;

        Struct[] array = new Struct[24];

        public void DisegnaCerchio(object sender, PaintEventArgs e)
        {
            if (disegnaoggetti)
            {
                
                Graphics g = this.panel1.CreateGraphics();
                Pen cerchio = new Pen(Color.Black, 2);
                Rectangle rettangolo_cerchio = new Rectangle(array[pos].x, array[pos].y, 50, 50);

                g.DrawEllipse(cerchio, rettangolo_cerchio);
            }
        }

        /*
         * 
         * public void DisegnaLinea(object sender, PaintEventArgs e)
        {
            if (disegnaoggetti)
            {
                Graphics g = this.panel1.CreateGraphics();
                Pen linea = new Pen(Color.Black, 2);

                PointF p1 = new PointF(x, y);

                x += 50; y += 5;

                PointF p2 = new PointF(x, y);

                g.DrawLine(linea, p1, p2);
            }
        }*/

        // funzione che disegna il grafo

        public void DisegnaGrafo(int n)
        {
            // disegno i cerchi

            for (int i = 0; i < n; i++)
            {
                pos = i;

                this.Paint += new PaintEventHandler(DisegnaCerchio);
            }

            // disegno le linee
        }

        public void RiempiLettere(int n)
        {
            int ascii_n = 65;

            for (int i = 0; i < n; i++)
            {
                // lettere

                array[i].nome = ((char)ascii_n).ToString();
                ascii_n++;
                pos++;

                // posizioni

                array[i].x = Randomizzare();
                array[i].y = (array[i].x + 20);
            }
        }

        // numeri casuali

        public int Randomizzare()
        {
            int n;
            Random random = new Random();
            return n = random.Next(0,101);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string titolo_input = "Numero nodi", frase = "Inserisci il numero di nodi";
            object input_n = Interaction.InputBox(frase, titolo_input);


            int n = int.Parse(input_n.ToString());

            // riempio l'array con le lettere

            RiempiLettere(n);

            // disegno il grafo

            DisegnaGrafo(n);

            this.Invalidate();

        }
    }
}
