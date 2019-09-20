namespace ModeloBasico.App.Eventos
{
    public class PartidaServidorUno : EventoPartida
    {
        protected PartidaServidorUno()
        {
        }

        public PartidaServidorUno(Servidor servidor)
        {
            this.Servidor = servidor;
        }

        public override Servidor Servidor { get; protected set; }
    }
}
