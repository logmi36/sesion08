using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s07_02
{
    public class Nodo
    {
        public int id { get; set; }
        public Image image { get; set; }
        public Point location { get; set; }
        public int idStack { get; set; }
        public string idImage { get; set; }
        public Nodo siguiente { get; set; }
    }
}
