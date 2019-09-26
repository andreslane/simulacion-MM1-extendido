using System.Collections.Generic;
using System.Linq;

namespace ModeloBasico.App
{
    public abstract class Cola
    {
        public Cola(List<string> servidores)
        {
            this.SirveAServidores = servidores;
            this.ColaDeTiemposDeArribo = new List<decimal>();
        }

        // Implemento navegabilidad a través de nombres para evitar bidireccionalidad de la relacion servidor-cola.
        // Un servidor ve una cola.
        public List<string> SirveAServidores { get; private set; }

        public abstract string NombreDelEventoDeArribo { get; }

        public decimal TiempoDelUltimoEvento { get; private set; }

        public int CantidadDeDemorasCompletadas { get; private set; } // Number delayed

        public decimal TotalDemora { get; private set; } // Total delay

        public decimal AreaBajoQ { get; private set; }

        public int CantidadEnCola { get { return this.ColaDeTiemposDeArribo.Count; } }

        public List<decimal> ColaDeTiemposDeArribo { get; private set; } // times of arrival.

        public void AcumularAreaBajoQ(Modelo modelo)
        {
            this.AreaBajoQ = this.AreaBajoQ + this.CantidadEnCola * (modelo.Reloj - this.TiempoDelUltimoEvento);

            this.TiempoDelUltimoEvento = modelo.Reloj;
        }

        public void EstablecerDemoraCompletada()
        {
            this.CantidadDeDemorasCompletadas++;
        }

        public void ComputarDemoraTotal(Modelo modelo)
        {
            // Se acumula el tiempo que estuvo esperando el primero en cola hasta ser atendido.
            this.TotalDemora = this.TotalDemora + modelo.Reloj - this.ColaDeTiemposDeArribo.FirstOrDefault();
        }

        public void AgregarALaColaDeEspera(Modelo modelo)
        {
            this.ColaDeTiemposDeArribo.Add(modelo.Reloj); // FI - Siempre el primero en llegar queda en la 1er posicion.

            //this.ColaDeTiemposDeArribo.Insert(0, modelo.Reloj); // LI - Siempre el ultimo en llegar queda en la 1er posicion.

        }

        public void QuitarUltimoDeLaColaDeEspera()
        {
            this.ColaDeTiemposDeArribo.RemoveAt(0); // FO
        }
    }
}
