namespace ModeloBasico.App
{
    internal class EventoArribo : IEvento
    {
        public void RutinaEvento(Modelo modelo)
        {
            // Figura 1.8 pagina 32.

            modelo.AcumularAreaBajoQ();
            modelo.AcumularAreaBajoB();

            modelo.EstablecerProximoEventoArribo();

            if (modelo.ServidorOcupado)
            {
                modelo.AgregarALaColaDeEspera();
            }
            else
            {
                modelo.EstablecerDemoraCompletada();
                modelo.EstablecerServidorOcupado();
                modelo.EstablecerProximoEventoPartida();
            }
        }
    }
}
