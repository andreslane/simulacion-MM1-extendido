using ModeloBasico.App.Colas;
using System.Collections.Generic;

namespace ModeloBasico.App.Servidores
{
    public class ServidorDos : Servidor
    {
        protected ServidorDos()
        {
        }

        public ServidorDos(Cola cola, List<Cola> colasPosteriores) : base(cola, colasPosteriores)
        {
        }

        public override int Prioridad => 2; 

        public override string NombreDelEventoDePartida => Comunes.PartidaServidorDos;
    }
}
