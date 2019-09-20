using ModeloBasico.App.Colas;

namespace ModeloBasico.App.Eventos
{
    public class ArriboColaA : EventoArribo
    {
        protected ArriboColaA()
        {
        }

        public ArriboColaA(Cola cola)
        {
            this.Cola = cola;
        }

        public override Cola Cola { get; protected set; }
    }
}
