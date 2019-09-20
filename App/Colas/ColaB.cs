using System.Collections.Generic;

namespace ModeloBasico.App.Colas
{
    public class ColaB : Cola
    {
        public ColaB(List<string> servidores) : base(servidores)
        {
        }

        public override string NombreDelEventoDeArribo => Comunes.ArriboColaB;
    }
}
