namespace ModeloBasico.App.Eventos
{
    public class PartidaServidorDos : EventoPartida
    {
        protected PartidaServidorDos()
        {
        }

        public PartidaServidorDos(Servidor servidor)
        {
            this.Servidor = servidor;
        }

        public override Servidor Servidor { get; protected set; }
    }
}
