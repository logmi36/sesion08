using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s07_02
{
    public class Pila
    {

        public Nodo primero;
        public Point location;
        public Size size;
        public int id;

        public Pila()
        {
            primero = null;
        }

        public void Insertar(Nodo nuevo)
        {
            nuevo.siguiente = primero;
            primero = nuevo;
        }

        public void Listar()
        {
            Nodo actual = new Nodo();
            actual = primero;

            int i = 0;
            if (primero != null)
            {
                while (actual != null)
                {
                    Console.WriteLine("{0}\t:\t{1}", i, actual.image);
                    actual = actual.siguiente;
                    i++;
                }
            }
        }

        public int Largo()
        {
            Nodo actual = new Nodo();
            actual = primero;

            int i = 0;
            if (primero != null)
            {
                while (actual != null)
                {
                    actual = actual.siguiente;
                    i++;
                }
            }
            return i;
        }



        public int Buscar(string tag)
        {

            Nodo actual = new Nodo();
            actual = primero;

            int i = 0;
            if (primero != null)
            {
                while (actual != null)
                {
                    if (actual.image.Tag.ToString() == tag)
                    {
                        i++;
                    }

                    actual = actual.siguiente;
                    
                }

            }

            return i;
        }


        public void Modificar(Image image1, Image image2)
        {
            Nodo actual = new Nodo();
            actual = primero;

            int i = 0;
            if (primero != null)
            {
                while (actual != null)
                {
                    if (actual.image== image1)
                    {
                        Console.WriteLine("{0}\t:\t{1}", i, actual.image);
                        actual.image = image2;
                        Console.WriteLine("{0}\t:\t{1}", i, actual.image);
                        break;
                    }
                    actual = actual.siguiente;
                    i++;
                }

            }
        }


        public void Eliminar(Nodo nodo)
        {
            Nodo actual = new Nodo();
            actual = primero;

            Nodo anterior;
            anterior = null;
            int i = 0;
            if (primero != null)
            {
                while (actual != null)
                {
                    if (actual.id==nodo.id)
                    {
                        Console.WriteLine("{0}\t:\t{1}", i, actual.id);

                        if (actual == primero)
                        {
                            primero = primero.siguiente;
                        }
                        else
                        {
                            anterior.siguiente = actual.siguiente;
                        }

                        break;
                    }
                    anterior = actual;
                    actual = actual.siguiente;
                    i++;

                }

            }
        }
    }
}
