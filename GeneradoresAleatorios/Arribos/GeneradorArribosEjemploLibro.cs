using System;
using System.Collections.Generic;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorArribosEjemploLibro : IGeneradorArribos
    {
        public GeneradorArribosEjemploLibro()
        {
            this.cantidadDeSolicitudes = 0;
            this.ArribosDelEjemplo = new List<decimal> { 0.4m, 1.2m, 0.5m, 1.7m, 0.2m, 1.6m, 0.2m, 1.4m, 1.9m, };
        }

        private int cantidadDeSolicitudes { get; set; }

        private readonly List<decimal> ArribosDelEjemplo;

        public decimal ObtenerProximo(decimal media)
        {
            var numeroAleatorio = this.ArribosDelEjemplo[cantidadDeSolicitudes];

            cantidadDeSolicitudes++;

            return numeroAleatorio;
        }
    }
}
