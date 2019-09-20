using System;
using System.Collections.Generic;

namespace ModeloBasico.GeneradoresAleatorios.NumerosAleatorios
{
    public class GeneradorNumerosAleatoriosUniformeEjemplo : IGeneradorNumerosAleatorios
    {
        public GeneradorNumerosAleatoriosUniformeEjemplo()
        {
            this.cantidadDeSolicitudes = 0;
            this.numerosAleatoriosEjemplo = new List<decimal> { 0.5121m, 0.8116m, 0.6717m, 0.1901m, 0.5184m, 0.6467m, 0.8954m, 0.3884m, 0.0279m, 0.8365m, 0.3618m, 0.3098m, 0.9208m, 0.7429m, 0.1578m, 0.1917m, 0.8492m, 0.5247m, 0.2871m, /**/ 0.6868m, 0.4986m, 0.228m, 0.6902m, 0.744m, 0.0124m, 0.5758m, 0.9469m, 0.4219m, 0.8613m, 0.5959m, 0.766m, 0.8346m, 0.8227m, 0.761m, 0.7286m, 0.8261m, 0.6921m, 0.5789m, 0.6636m, 0.2402m, 0.6597m, 0.4356m, 0.893m, 0.2593m, 0.4507m, 0.891m, 0.5586m, 0.6491m, 0.1376m, 0.0188m, 0.3757m, 0.422m, 0.2396m, 0.3498m, 0.1321m, 0.1106m, 0.7137m, 0.1885m, 0.1200m, 0.2773m };
        }

        private int cantidadDeSolicitudes { get; set; }

        private readonly List<decimal> numerosAleatoriosEjemplo;

        public decimal ObtenerProximo()
        {
            if (cantidadDeSolicitudes >= this.numerosAleatoriosEjemplo.Count)
            {
                throw new InvalidOperationException("No se dispone de más numeros aleatorios segun el ejemplo.");
            }

            var numeroAleatorio = this.numerosAleatoriosEjemplo[this.cantidadDeSolicitudes];

            this.cantidadDeSolicitudes++;

            return numeroAleatorio;
        }
    }
}
