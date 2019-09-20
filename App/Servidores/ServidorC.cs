using ModeloBasico.App.Colas;
using System.Collections.Generic;

namespace ModeloBasico.App.Servidores
{
    public class ServidorC : Servidor
    {
        protected ServidorC()
        {
        }

        public ServidorC(Cola cola, List<Cola> colasPosteriores) : base(cola, colasPosteriores)
        {
        }

        public override int Prioridad => 99; // Servidores A B C no usan prioridad.

        public override string NombreDelEventoDePartida => Comunes.PartidaServidorC;
    }
}
