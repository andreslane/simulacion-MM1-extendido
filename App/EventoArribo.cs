using ModeloBasico.App.Colas;
using System.Linq;

namespace ModeloBasico.App
{
    public abstract class EventoArribo : IEvento
    {
        public abstract Cola Cola { get; protected set; }

        public void RutinaEvento(Modelo modelo)
        {
            // Figura 1.8 pagina 32.

            this.Cola.AcumularAreaBajoQ(modelo);
            foreach (var servidor in modelo.Servidores)
            {
                servidor.AcumularAreaBajoB(modelo);
            }

            // Refactor
            if (this.Cola.NombreDelEventoDeArribo == Comunes.ArriboColaUno) // Si es "cola inicial".
            {
                modelo.EstablecerProximoEvento(this.Cola.NombreDelEventoDeArribo);
            }
            else
            {
                modelo.QuitarEventoDeConsideracion(this.Cola.NombreDelEventoDeArribo);
            }

            var sevidoresConLosQueTrabajaLaCola = modelo.DeterminarServidoresConLosQueTrabajaUnaCola(this.Cola);

            if (sevidoresConLosQueTrabajaLaCola.All(s => s.ServidorOcupado))
            {
                this.Cola.AgregarALaColaDeEspera(modelo);
            }
            else
            {
                this.Cola.EstablecerDemoraCompletada();

                Servidor servidorLibre = sevidoresConLosQueTrabajaLaCola.OrderBy(s => s.Prioridad).FirstOrDefault(s => !s.ServidorOcupado);
                servidorLibre.EstablecerServidorOcupado();

                modelo.EstablecerProximoEvento(servidorLibre.NombreDelEventoDePartida);
            }
        }
    }
}
