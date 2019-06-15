using System;

namespace ModeloBasico.GeneradoresAleatorios
{
    public class GeneradorPartidasAleatorias : IGeneradorPartidas
    {
        private readonly Random Random;

        public GeneradorPartidasAleatorias()
        {
            this.Random = new Random();
        }

        public decimal ObtenerProxima()
        {
            return Convert.ToDecimal(this.Random.NextDouble());
        }
    }
}
