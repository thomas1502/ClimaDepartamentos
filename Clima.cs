using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaDepartamentos
{
    class Clima
    {
        string codigo;
        float temperatura;
        DateTime fechaMedicion;

        public string Codigo { get => codigo; set => codigo = value; }
        public float Temperatura { get => temperatura; set => temperatura = value; }
        public DateTime FechaMedicion { get => fechaMedicion; set => fechaMedicion = value; }
    }
}
