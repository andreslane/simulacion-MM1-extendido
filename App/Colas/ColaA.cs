using System.Collections.Generic;

namespace ModeloBasico.App.Colas
{
    public class ColaA : Cola
    {
        public ColaA(List<string> servidores) : base(servidores)
        {
        }

        public override string NombreDelEventoDeArribo => Comunes.ArriboColaA;
    }
}
