using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Entidades
{
    class telefono
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int marca { get; set; }
        public double precio { get; set; }

        public telefono(int codigo, string nombre, int marca, double precio)
        {
            this.codigo = codigo = 0;
            this.nombre = nombre = "";
            this.marca = marca = 0;
            this.precio = precio = 0;
        }

        public telefono()
        {
        }
    }
}
