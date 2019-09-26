using ModeloBasico.App.Colas;
using ModeloBasico.GeneradoresAleatorios;
using ModeloBasico.Infraestructura;
using ModeloBasico.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModeloBasico.App
{
    public class Modelo
    {
        private readonly IoCContainer container;

        private readonly IGeneradorArribos generadorEventos;

        private readonly ReporteConsola reporte;

        private readonly Dictionary<string, decimal> tasasDeEventosAleatorios;

        public List<Servidor> Servidores { get; private set; }

        public Modelo(IoCContainer container)
        {
            this.container = container;
            this.generadorEventos = container.InjectGeneradorDeEventosAleatorios();

            var configuraciones = new Configuraciones(container);
            this.reporte = new ReporteConsola(configuraciones);

            this.tasasDeEventosAleatorios = configuraciones.ObtenerTiemposPromedioDeLosEventos();
            this.Servidores = configuraciones.ObtenerServidores();

            // Se fuerza un evento arribo generando un valor y quitando de consideracion las partidas.
            var primerArribo = this.generadorEventos.ObtenerProximo(this.tasasDeEventosAleatorios[Comunes.ArriboColaUno]);
            this.ListaDeEventos = configuraciones.ObtenerListaDeEventos(primerArribo);

            // Registramos paso inicializacion en reporte.
            this.reporte.RegistrarEvento(this);
        }

        public decimal Reloj { get; private set; }

        public Dictionary<string, Tuple<decimal, IEvento>> ListaDeEventos { get; private set; }
        
        public void IniciarSimulacion()
        {
            var cantidadEventosOcurridos = 0;

            while (cantidadEventosOcurridos < 1000)
            {
                IEvento evento = this.RutinaDeTiempo();
                evento.RutinaEvento(this);

                //this.reporte.RegistrarEvento(this);

                //Console.ReadKey();

                cantidadEventosOcurridos++;
            }

            Console.ReadKey();

            // Calcular medidas de rendimiento.
            this.reporte.ObtenerMedidasDeRendimiento(this);

            throw new InvalidOperationException("Condición de fin de sumulación cumplida.");
        }

        public void EstablecerEventoArriboInmediato(string nombreEvento)
        {
            IEvento evento = this.ListaDeEventos.FirstOrDefault(e => e.Key == nombreEvento).Value.Item2;
            this.ListaDeEventos[nombreEvento] = new Tuple<decimal, IEvento>(this.Reloj, evento);
        }

        public void EstablecerProximoEvento(string nombreEvento)
        {
            // Establecer proximo arribo en la lista de eventos.
            var proximoEvento = this.generadorEventos.ObtenerProximo(this.tasasDeEventosAleatorios[nombreEvento]);

            IEvento evento = this.ListaDeEventos.FirstOrDefault(e => e.Key == nombreEvento).Value.Item2;
            this.ListaDeEventos[nombreEvento] = new Tuple<decimal, IEvento>(this.Reloj + proximoEvento, evento);

        }

        public void QuitarEventoDeConsideracion(string nombreEvento)
        {
            IEvento evento = this.ListaDeEventos.FirstOrDefault(e => e.Key == nombreEvento).Value.Item2;
            this.ListaDeEventos[nombreEvento] = new Tuple<decimal, IEvento>(decimal.MaxValue, evento);
        }
        
        private IEvento RutinaDeTiempo()
        {
            // 1. Determinamos proximo evento:
            // Ordenamos por proximo evento (menor tiempo) y tomamos el primero.
            Tuple<decimal, IEvento> proximoEvento = this.ListaDeEventos.OrderBy(x => x.Value.Item1).First().Value;

            // 2. Avanzamos reloj de simulacion.
            this.Reloj = proximoEvento.Item1;

            // Devolvemos objeto que se encarga de rutina de evento.
            return proximoEvento.Item2;
        }

        public IEnumerable<Servidor> DeterminarServidoresConLosQueTrabajaUnaCola(Cola cola)
        {
            return this.Servidores.Where(s => cola.SirveAServidores.Contains(s.NombreDelEventoDePartida));
        }
    }
}
