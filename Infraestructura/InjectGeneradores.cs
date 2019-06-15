using ModeloBasico.GeneradoresAleatorios;

namespace ModeloBasico.Infraestructura
{
    public static class InjectGeneradores
    {
        public static IGeneradorArribos InjectGeneradorDeArribos()
        {
            return new GeneradorArribosAleatorios();
            //return new GeneradorArribosAleatoriosParaEjemploLibro();
        }

        public static IGeneradorPartidas InjectGeneradorDePartidas()
        {
            return new GeneradorPartidasAleatorias();
            //return new GeneradorPartidasAleatoriasParaEjemploLibro();
        }
    }
}
