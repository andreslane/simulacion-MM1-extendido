namespace ModeloBasico.App.Eventos
{
    public class PartidaServidorB : EventoPartida
    {
        protected PartidaServidorB()
        {
        }

        public PartidaServidorB(Servidor servidor)
        {
            this.Servidor = servidor;
        }

        public override Servidor Servidor { get; protected set; }
    }
}
