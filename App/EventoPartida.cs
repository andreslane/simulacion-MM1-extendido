using System.Linq;

namespace ModeloBasico.App
{
    public abstract class EventoPartida : IEvento
    {
        public abstract Servidor Servidor { get; protected set; } 

        public void RutinaEvento(Modelo modelo)
        {
            // Figura 1.9 pagina 32.

            this.Servidor.AcumularAreaBajoB(modelo);

            if (this.Servidor.ColaPrevia.CantidadEnCola == 0)
            {
                this.Servidor.EstablecerServidorLibre(); 
                modelo.QuitarEventoDeConsideracion(this.Servidor.NombreDelEventoDePartida); // Fuerza que el proximo evento sea un arribo.
            }
            else
            {
                this.Servidor.ColaPrevia.ComputarDemoraTotal(modelo);
                this.Servidor.ColaPrevia.AcumularAreaBajoQ(modelo);

                this.Servidor.ColaPrevia.EstablecerDemoraCompletada();

                modelo.EstablecerProximoEvento(this.Servidor.NombreDelEventoDePartida);
                this.Servidor.ColaPrevia.QuitarUltimoDeLaColaDeEspera();
            }

            var cola = this.Servidor.DeterminarColaDeProximoEventoArribo(modelo);

            if (cola != null)
            {
                modelo.EstablecerEventoArriboInmediato(cola.NombreDelEventoDeArribo);
            }
        }
    }
}
