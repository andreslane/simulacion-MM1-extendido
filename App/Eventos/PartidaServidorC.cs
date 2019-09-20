using System;

namespace ModeloBasico.App.Eventos
{
    public class PartidaServidorC : EventoPartida
    {
        protected PartidaServidorC()
        {
        }

        public PartidaServidorC(Servidor servidor)
        {
            this.Servidor = servidor;
        }

        public override Servidor Servidor { get; protected set; }
    }
}
