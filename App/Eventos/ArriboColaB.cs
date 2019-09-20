using ModeloBasico.App.Colas;

namespace ModeloBasico.App.Eventos
{
    public class ArriboColaB : EventoArribo
    {
        protected ArriboColaB()
        {
        }

        public ArriboColaB(Cola cola)
        {
            this.Cola = cola;
        }

        public override Cola Cola { get; protected set; }
    }
}