using ModeloBasico.GeneradoresAleatorios.NumerosAleatorios;
using System;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorPartidasDistribucionExponencial : IGeneradorPartidas
    {
        private readonly decimal media;
        private readonly IGeneradorNumerosAleatorios generadorNumerosAleatorios;

        public GeneradorPartidasDistribucionExponencial(decimal media, IGeneradorNumerosAleatorios generadorNumerosAleatorios)
        {
            this.media = media;
            this.generadorNumerosAleatorios = generadorNumerosAleatorios;
        }

        public decimal ObtenerProxima()
        {
            var numeroAleatorio = this.generadorNumerosAleatorios.ObtenerProximo();

            // Creo que esta logica solo aplica cuando el generador de numeros aleatorios es Uniforme. Pendiente.
            decimal proximaPartida = (-1) * media * Convert.ToDecimal(Math.Log(Convert.ToDouble(numeroAleatorio)));

            return Math.Round(proximaPartida, 2);
        }
    }
}
