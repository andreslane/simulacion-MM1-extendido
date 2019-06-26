using ModeloBasico.GeneradoresAleatorios.NumerosAleatorios;
using System;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorArribosDistribucionExponencial : IGeneradorArribos
    {
        private readonly decimal media;
        private readonly IGeneradorNumerosAleatorios generadorNumerosAleatorios;

        public GeneradorArribosDistribucionExponencial(decimal media, IGeneradorNumerosAleatorios generadorNumerosAleatorios)
        {
            this.media = media;
            this.generadorNumerosAleatorios = generadorNumerosAleatorios;
        }

        public decimal ObtenerProximo()
        {
            var numeroAleatorio = this.generadorNumerosAleatorios.ObtenerProximo();

            // Creo que esta logica solo aplica cuando el generador de numeros aleatorios es Uniforme. Pendiente.
            decimal proximaPartida = (-1) * media * Convert.ToDecimal(Math.Log(Convert.ToDouble(numeroAleatorio)));

            return Math.Round(proximaPartida, 2);
        }
    }
}
