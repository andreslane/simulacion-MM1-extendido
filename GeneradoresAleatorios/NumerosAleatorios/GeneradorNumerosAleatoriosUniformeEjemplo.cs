using System;
using System.Collections.Generic;

namespace ModeloBasico.GeneradoresAleatorios.NumerosAleatorios
{
    public class GeneradorNumerosAleatoriosUniformeEjemplo : IGeneradorNumerosAleatorios
    {
        public GeneradorNumerosAleatoriosUniformeEjemplo()
        {
            this.cantidadDeSolicitudes = 0;
            this.numerosAleatoriosEjemplo = new List<decimal> { 0.5121m, 0.8116m, 0.6717m, 0.1901m, 0.5184m, 0.6467m, 0.8954m, 0.3884m, 0.0279m, 0.8365m, 0.3618m, 0.3098m, 0.9208m, 0.7429m, 0.1578m, 0.1917m, 0.8492m, 0.5247m, 0.2871m };
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
