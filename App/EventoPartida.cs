namespace ModeloBasico.App
{
    internal class EventoPartida : IEvento
    {
        public void RutinaEvento(Modelo modelo)
        {
            // Figura 1.9 pagina 32.

            modelo.AcumularAreaBajoB();

            if (modelo.CantidadEnCola == 0)
            {
                modelo.EstablecerServidorLibre();
                modelo.QuitarPartidasDeConsideracion(); // Fuerza que el proximo evento sea un arribo.
            }
            else
            {
                modelo.ComputarDemoraCompletada();
                modelo.AcumularAreaBajoQ();

                modelo.EstablecerDemoraCompletada();

                modelo.EstablecerProximoEventoPartida();
                modelo.QuitarUltimoDeLaColaDeEspera();
            }
        }
    }
}
