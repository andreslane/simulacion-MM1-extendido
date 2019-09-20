using ModeloBasico.App.Colas;

namespace ModeloBasico.App.Eventos
{
    public class ArriboColaC : EventoArribo
    {
        protected ArriboColaC()
        {
        }

        public ArriboColaC(Cola cola)
        {
            this.Cola = cola;
        }

        public override Cola Cola { get; protected set; }
    }
}