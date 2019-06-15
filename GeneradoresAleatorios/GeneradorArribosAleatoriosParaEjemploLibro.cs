using System;
using System.Collections.Generic;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorArribosAleatoriosParaEjemploLibro : IGeneradorArribos
    {
        public GeneradorArribosAleatoriosParaEjemploLibro()
        {
            this.cantidadDeSolicitudes = 0;
            this.NumerosAleatoriosADevolver = new List<decimal> { 0.4m, 1.2m, 0.5m, 1.7m, 0.2m, 1.6m, 0.2m, 1.4m, 1.9m, };
        }

        private int cantidadDeSolicitudes { get; set; }
        private List<decimal> NumerosAleatoriosADevolver { get; set; }

        public decimal ObtenerProximo()
        {
            var numeroAleatorio = this.NumerosAleatoriosADevolver[cantidadDeSolicitudes];

            cantidadDeSolicitudes++;

            return numeroAleatorio;
        }
    }
}
