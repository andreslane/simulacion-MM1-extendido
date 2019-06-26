using System;
using System.Collections.Generic;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorPartidasEjemploLibro : IGeneradorPartidas
    {
        public GeneradorPartidasEjemploLibro()
        {
            this.cantidadDeSolicitudes = 0;
            this.PartidasDelEjemplo = new List<decimal> { 2.0m, 0.7m, 0.2m, 1.1m, 3.7m, 0.6m };
        }

        private int cantidadDeSolicitudes { get; set; }
        private List<decimal> PartidasDelEjemplo { get; set; }

        public decimal ObtenerProxima()
        {
            var numeroAleatorio = this.PartidasDelEjemplo[cantidadDeSolicitudes];

            cantidadDeSolicitudes++;

            return numeroAleatorio;
        }
    }
}
