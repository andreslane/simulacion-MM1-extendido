using ModeloBasico.App.Colas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModeloBasico.App
{
    public abstract class Servidor
    {

        protected Servidor() { }

        public Servidor(Cola cola , List<Cola> colasPosteriores)
        {
            this.ColaPrevia = cola;
            this.ColasPosteriores = colasPosteriores;
        }

        public abstract int Prioridad { get; }

        public abstract string NombreDelEventoDePartida { get; }

        public decimal TiempoDelUltimoEvento { get; private set; }

        public decimal AreaBajoB { get; private set; }

        public bool ServidorOcupado { get; private set; }

        public Cola ColaPrevia { get; private set; }

        public List<Cola> ColasPosteriores { get; private set; }

        public void AcumularAreaBajoB(Modelo modelo)
        {
            if (this.ServidorOcupado)
            {
                this.AreaBajoB = this.AreaBajoB + 1 * (modelo.Reloj - this.TiempoDelUltimoEvento);
                // El valor 1 en el producto es teorico, la curva B(t) tendra valor 0 ó 1.
            }

            this.TiempoDelUltimoEvento = modelo.Reloj;
        }

        public void EstablecerServidorOcupado()
        {
            this.ServidorOcupado = true;
        }

        public Cola DeterminarColaDeProximoEventoArribo(Modelo modelo)
        {
            // Busca entre las colas posteriores aquella que tenga un servidor libre.

            foreach (var cola in this.ColasPosteriores)
            {
                var servidoresDeCola = modelo.DeterminarServidoresConLosQueTrabajaUnaCola(cola);

                var servidorLibre = servidoresDeCola.FirstOrDefault(s => !s.ServidorOcupado);
                if (servidorLibre != null)
                {
                    return servidorLibre.ColaPrevia;
                }
            }

            // Si no hay ninguno libre, tomamos la cola de menor logitud.
            return this.ColasPosteriores.OrderBy(c => c.CantidadEnCola).FirstOrDefault();
        }

        public void EstablecerServidorLibre()
        {
            this.ServidorOcupado = false;
        }
    }
}
