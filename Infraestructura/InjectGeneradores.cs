using ModeloBasico.GeneradoresAleatorios;
using ModeloBasico.GeneradoresAleatorios.NumerosAleatorios;

namespace ModeloBasico.Infraestructura
{
    // Esta clase debe instanciarse en un unico lugar de toda la app.
    public class InjectGeneradores
    {

        private IGeneradorArribos generadorArribos;
        public IGeneradorArribos InjectGeneradorDeArribos()
        {
            if (this.generadorArribos == null)
            {
                this.generadorArribos = new GeneradorArribosDistribucionExponencial(0.7m, this.InjectGeneradorNumerosAleatorios());
            }
            return this.generadorArribos;
        }

        private IGeneradorPartidas generadorPartidas;
        public IGeneradorPartidas InjectGeneradorDePartidas()
        {
            if (this.generadorPartidas == null)
            {
                this.generadorPartidas = new GeneradorPartidasDistribucionExponencial(0.66m, this.InjectGeneradorNumerosAleatorios());
            }
            return this.generadorPartidas;
        }

        private IGeneradorNumerosAleatorios generadorNumerosAleatorios;
        public IGeneradorNumerosAleatorios InjectGeneradorNumerosAleatorios()
        {
            if (this.generadorNumerosAleatorios == null)
            {
                this.generadorNumerosAleatorios = new GeneradorNumerosAleatoriosUniformeEjemplo();
            }
            return this.generadorNumerosAleatorios;
        }
    }
}
