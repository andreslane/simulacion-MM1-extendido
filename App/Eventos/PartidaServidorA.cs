namespace ModeloBasico.App.Eventos
{
    public class PartidaServidorA : EventoPartida
    {
        protected PartidaServidorA()
        {
        }

        public PartidaServidorA(Servidor servidor)
        {
            this.Servidor = servidor;
        }

        public override Servidor Servidor { get; protected set; }
    }
}
