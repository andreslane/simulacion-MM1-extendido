using System;

namespace ModeloBasico.GeneradoresAleatorios.NumerosAleatorios
{
    public class GeneradorNumerosAleatoriosUniforme : IGeneradorNumerosAleatorios
    {
        private readonly Random Random;

        public GeneradorNumerosAleatoriosUniforme()
        {
            this.Random = new Random();
        }

        public decimal ObtenerProximo()
        {
            return Convert.ToDecimal(this.Random.NextDouble());
        }
    }
}
