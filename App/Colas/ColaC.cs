using System.Collections.Generic;

namespace ModeloBasico.App.Colas
{
    public class ColaC : Cola
    {
        public ColaC(List<string> servidores) : base(servidores)
        {
        }

        public override string NombreDelEventoDeArribo => Comunes.ArriboColaC;
    }
}
