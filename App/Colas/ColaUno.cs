using System.Collections.Generic;

namespace ModeloBasico.App.Colas
{
    public class ColaUno : Cola
    {
        public ColaUno(List<string> servidores) : base(servidores)
        {
        }

        public override string NombreDelEventoDeArribo => Comunes.ArriboColaUno;
    }
}
