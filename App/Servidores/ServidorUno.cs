using ModeloBasico.App.Colas;
using System.Collections.Generic;

namespace ModeloBasico.App.Servidores
{
    public class ServidorUno : Servidor
    {
        public ServidorUno(Cola cola, List<Cola> colasPosteriores) : base(cola, colasPosteriores)
        {

        }

        public override int Prioridad => 1;

        public override string NombreDelEventoDePartida => Comunes.PartidaServidorUno;
    }
}
