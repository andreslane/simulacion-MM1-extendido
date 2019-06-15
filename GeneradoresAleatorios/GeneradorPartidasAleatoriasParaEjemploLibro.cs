using System;
using System.Collections.Generic;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorPartidasAleatoriasParaEjemploLibro : IGeneradorPartidas
    {
        public GeneradorPartidasAleatoriasParaEjemploLibro()
        {
            this.cantidadDeSolicitudes = 0;
            this.NumerosAleatoriosADevolver = new List<decimal> { 2.0m, 0.7m, 0.2m, 1.1m, 3.7m, 0.6m };
        }

        private int cantidadDeSolicitudes { get; set; }
        private List<decimal> NumerosAleatoriosADevolver { get; set; }

        public decimal ObtenerProxima()
        {
            var numeroAleatorio = this.NumerosAleatoriosADevolver[cantidadDeSolicitudes];

            cantidadDeSolicitudes++;

            return numeroAleatorio;
        }
    }
}
