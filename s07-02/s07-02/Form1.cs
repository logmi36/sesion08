using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s07_02
{
    public partial class Form1 : Form
    {

        Pen pincel;
        List<Image> images;

        List<Pila> pilas;
        Nodo mNodo;

        public double dis = 0.0;
        public double ang = 0.0;

        private Point MouseDownLocation;
        private Point MouseNewLocation;
        private Point MouseOriginalLocation;
        private Random rnd = new Random();
        private static int n;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Inicializar();
            Dibujar();

        }

        private void Inicializar() {

            pincel = new Pen(Color.FromArgb(139, 51, 51));
            pincel.Width = 1;
            timer1.Interval = 20;

            pilas = new List<Pila>();
            mNodo = new Nodo();

            int x0 = 60;
            int y0 = 60;

            Pila pila;
            for (int i = 0; i < 4; i++)
            {
                
                int x1 = x0 + 160 * i;
                Point location = new Point(x1, y0);
                Size size = new Size(80 , 480);
                
                pila = new Pila();
                pila.id = i;
                pila.location = location;
                pila.size = size;
                pilas.Add(pila);
            }
            

            images = new List<Image>();

            int w = 0;
            
            for (int i = 0; i < 3; i++)
            {
                
                for (int j = 0; j <= 5; j++)
                {
                    Image im = imageList1.Images[i];
                    im.Tag = i;
                    images.Add(im);
                    w = w + 1;
                }

            }

            images = images.OrderBy(_ => rnd.Next()).ToList();

            int k = 0;

            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j <= 5; j++) {

                    int x1 = x0 + 160 * i;
                    int y1 = y0+400 - 80 * j;

                    Nodo nodo = new Nodo();
                    nodo.image = images[k];
                    nodo.id = images[k].GetHashCode();
                    nodo.idImage = images[k].Tag.ToString();
                    nodo.idStack = i;
                    nodo.location = new Point(x1, y1);

                    pilas[i].Insertar(nodo);

                    k = k + 1;

                }

            }

        }

        private void Dibujar() {

            lienzo.Controls.Clear();

            for (int i = 0; i < 4; i++) {

                Nodo actual = new Nodo();
                actual = pilas[i].primero;

                if (pilas[i].primero != null)
                {
                    while (actual != null)
                    {
                        Propiedades(actual);

                        actual = actual.siguiente;
                    }
                }
            }
        }

        private void Propiedades(Nodo nodo) {

            PictureBox picture = new PictureBox();
            lienzo.Controls.Add(picture);
            picture.Size = new Size(80, 80);
            picture.Location = nodo.location;
            picture.Image = nodo.image;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Name ="pic_"+ nodo.id.ToString();
            picture.Tag = nodo.id;


            picture.MouseDown += (s, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    MouseOriginalLocation = nodo.location;
                    mNodo = nodo;

                }
                if (args.Button == MouseButtons.Right)
                {

                }
            };

            picture.MouseMove += (s, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    picture.Left = args.X + picture.Left - MouseDownLocation.X;
                    picture.Top = args.Y + picture.Top - MouseDownLocation.Y;


                }
                if (args.Button == MouseButtons.Right)
                {

                }

            };

            picture.MouseUp += (s, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    MouseNewLocation = lienzo.PointToClient(Cursor.Position);


                    int origen = nodo.idStack;
                    int destino = Region();


                    if (origen != destino)
                    {

                        if (pilas[origen].primero.id == nodo.id)
                        {
                            if (destino != -1)
                            {

                                int l = pilas[destino].Largo();

                                if (l < 6)
                                {
                                    int x = 0;
                                    int y = 0;
                                    if (pilas[destino].primero == null)
                                    {
                                        x = pilas[destino].location.X;
                                        y = pilas[destino].location.Y + pilas[destino].size.Height - 80;
                                    }
                                    else
                                    {
                                        x = pilas[destino].primero.location.X;
                                        y = pilas[destino].primero.location.Y - 80;
                                    }

                                    MouseOriginalLocation = new Point(x, y);

                                    pilas[origen].Eliminar(nodo);

                                    nodo.idStack = destino;
                                    nodo.location = MouseOriginalLocation;

                                    pilas[destino].Insertar(nodo);
                                }

                            }
                        }

                    }


                    Mover();
                    n = 0;
                    timer1.Enabled = true;

                }
                if (args.Button == MouseButtons.Right)
                {

                }
            };


        }


        private int Region() {
            int res = -1;

            int a = MouseNewLocation.X;
            int b = MouseNewLocation.Y;

            for (int i = 0; i < 4; i++)
            {
                int x = pilas[i].location.X;
                int y = pilas[i].location.Y;

                int w = pilas[i].size.Width;
                int h = pilas[i].size.Height;

                if ((x <= a) && (a <= x + w)) {
                    if ((y <= b) && (b <= y + h))
                    {
                        res = i;
                    }
                }
            }

            return res;
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                Inicializar();
                Dibujar();
            }
           
        }



        private void Mover() {


            double x0 = Convert.ToDouble(MouseOriginalLocation.X);
            double y0 = Convert.ToDouble(MouseOriginalLocation.Y);

            double x1 = Convert.ToDouble(MouseNewLocation.X);
            double y1 = Convert.ToDouble(MouseNewLocation.Y);

            double r = -1.0 * ((y1 - y0) / (x1 - x0));

            ang = Math.Atan(r);

            if (x1 < x0)
                ang = ang + Math.PI;

            double w = ang * 180.0 / (Math.PI);

            dis = 1.0* Math.Sqrt(Math.Pow((y1 - y0), 2.0) + Math.Pow((x1 - x0), 2.0)) ;


        }





        

        private void timer1_Tick(object sender, EventArgs e)
        {
            n = n + 1;
            double m = Convert.ToDouble(n);

            double xp = -1.0*m*dis * Math.Cos(ang)/10.0;
            double yp = -1.0*m*dis * Math.Sin(ang)/10.0;

            Size z1 = new Size(Convert.ToInt32(xp), -1 * Convert.ToInt32(yp));

            Point b2 = Point.Add(MouseNewLocation, z1);

            string id = "pic_" + mNodo.id.ToString();
            PictureBox pb =lienzo.Controls[id] as PictureBox; 

            pb.Location = b2;

            if (n == 10) {
                timer1.Enabled = false;
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void lienzo_MouseMove(object sender, MouseEventArgs e)
        {
  
        }

        private void lienzo_Paint(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < 4; i++)
            {
                int x = pilas[i].location.X;
                int y = pilas[i].location.Y;

                int w = pilas[i].size.Width;
                int h = pilas[i].size.Height;

                e.Graphics.DrawRectangle(pincel, x-1, y-1, w+1, h+1);
            }

        }
    }
}
