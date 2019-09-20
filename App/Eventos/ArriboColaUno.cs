using ModeloBasico.App.Colas;

namespace ModeloBasico.App.Eventos
{
    public class ArriboColaUno : EventoArribo
    {
        protected ArriboColaUno()
        {
        }

        public ArriboColaUno(Cola cola)
        {
            this.Cola = cola;
        }

        public override Cola Cola { get; protected set; }
    }
}
