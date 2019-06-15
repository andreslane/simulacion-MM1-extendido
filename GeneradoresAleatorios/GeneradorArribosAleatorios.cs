using System;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorArribosAleatorios : IGeneradorArribos
    {
        private readonly Random Random;

        public GeneradorArribosAleatorios()
        {
            this.Random = new Random();
        }

        public decimal ObtenerProximo()
        {
            return Convert.ToDecimal(this.Random.NextDouble());
        }
    }
}
