using ModeloBasico.GeneradoresAleatorios.NumerosAleatorios;
using System;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorArribosDistribucionExponencial : IGeneradorArribos
    {
        private readonly IGeneradorNumerosAleatorios generadorNumerosAleatorios;

        public GeneradorArribosDistribucionExponencial(IGeneradorNumerosAleatorios generadorNumerosAleatorios)
        {
            this.generadorNumerosAleatorios = generadorNumerosAleatorios;
        }

        public decimal ObtenerProximo(decimal media)
        {
            var numeroAleatorio = this.generadorNumerosAleatorios.ObtenerProximo();

            var log = Convert.ToDecimal(Math.Log(Convert.ToDouble(numeroAleatorio)));
            decimal proximaPartida = (-1) * media * log;

            return Math.Round(proximaPartida, 2);
        }
    }
}
