using ModeloBasico.GeneradoresAleatorios;
using ModeloBasico.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModeloBasico.App
{
    public class Modelo
    {
        private readonly IGeneradorArribos GeneradorArribos;
        private readonly IGeneradorPartidas GeneradorPartidas;

        public Modelo()
        {
            // Implementamos estos "instanciadores" para abstraernos de la generacion de numeros aleatorios.
            this.GeneradorArribos = InjectGeneradores.InjectGeneradorDeArribos();
            this.GeneradorPartidas = InjectGeneradores.InjectGeneradorDePartidas();

            // Rutina inicializacion. 
            // 1. Reloj de simulacion en 0. (Se hace por defecto)

            // 2. Inicializar estado de sistema y contadores estadisticos.
            this.ColaDeTiemposDeArribo = new List<decimal>();

            // 3. Inicializar lista de eventos.
            // Se fuerza un evento arribo generando un valor y quitando de consideracion las partidas.
            var primerArribo = this.GeneradorArribos.ObtenerProximo();

            this.ListaDeEventos = new Dictionary<char, Tuple<decimal, IEvento>>
            {
                { 'A', new Tuple<decimal, IEvento>(primerArribo, new EventoArribo()) },
                { 'P', new Tuple<decimal, IEvento>(decimal.MaxValue, new EventoPartida()) }
            }; 
        }

        public bool ServidorOcupado { get; private set; }
        public int CantidadEnCola { get { return this.ColaDeTiemposDeArribo.Count;  } }

        private List<decimal> ColaDeTiemposDeArribo { get; set; } // times of arrival.
        public decimal TiempoDelUltimoEvento { get; private set; } 

        private decimal Reloj { get; set; }
        private Dictionary<char, Tuple<decimal, IEvento>> ListaDeEventos { get; set; }

        public int CantidadDeDemorasCompletadas { get; private set; } // Number delayed
        public decimal TotalDemora { get; private set; } // Total delay
        public decimal AreaBajoQ { get; private set; }
        public decimal AreaBajoB { get; private set; }

        public void IniciarSimulacion()
        {

            while (this.CantidadDeDemorasCompletadas < 6) // Condicion de fin de simulacion: cuando cantidad de demoras sea 6. Pagina 25.
            {
                IEvento evento = this.RutinaDeTiempo();
                evento.RutinaEvento(this);
            }
        }

        public void EstablecerDemoraCompletada()
        {
            this.CantidadDeDemorasCompletadas++;
        }
        public void ComputarDemoraCompletada()
        {
            // Se acumula el tiempo que estuvo esperando el primero en cola hasta ser atendido.
            this.TotalDemora = this.TotalDemora + this.Reloj - this.ColaDeTiemposDeArribo.FirstOrDefault();
        }

        public void EstablecerServidorOcupado()
        {
            this.ServidorOcupado = true;
        }

        public void EstablecerServidorLibre()
        {
            this.ServidorOcupado = false;
        }

        public void AgregarALaColaDeEspera()
        {
            this.ColaDeTiemposDeArribo.Add(this.Reloj);
        }

        public void QuitarUltimoDeLaColaDeEspera()
        {
            this.ColaDeTiemposDeArribo.RemoveAt(0);
        }

        public void EstablecerProximoEventoArribo()
        {
            // Establecer proximo arribo en la lista de eventos.
            var proximoArribo = this.GeneradorArribos.ObtenerProximo();

            this.ListaDeEventos['A'] = new Tuple<decimal, IEvento>(this.Reloj + proximoArribo, new EventoArribo());

        }
        public void EstablecerProximoEventoPartida()
        {
            // Establecer proxima partida en la lista de eventos.
            var proximaPartida = this.GeneradorPartidas.ObtenerProxima();

            this.ListaDeEventos['P'] = new Tuple<decimal, IEvento>(this.Reloj + proximaPartida, new EventoPartida());
        }

        public void QuitarPartidasDeConsideracion()
        {
            this.ListaDeEventos['P'] = new Tuple<decimal, IEvento>(decimal.MaxValue, new EventoPartida());
        }

        public void AcumularAreaBajoB()
        {
            if (this.ServidorOcupado)
            {
                this.AreaBajoB = this.AreaBajoB + 1 * (this.Reloj - this.TiempoDelUltimoEvento);
                // El valor 1 en el producto es teorico, la curva B(t) tendra valor 0 ó 1.
            }
        }

        public void AcumularAreaBajoQ()
        {
            this.AreaBajoQ = this.AreaBajoQ + this.CantidadEnCola * (this.Reloj - this.TiempoDelUltimoEvento);
        }

        private IEvento RutinaDeTiempo()
        {
            // 1. Determinamos proximo evento:
            // Ordenamos por proximo evento (menor tiempo) y tomamos el primero.
            Tuple<decimal, IEvento> proximoEvento = this.ListaDeEventos.OrderBy(x => x.Value.Item1).First().Value;

            // Este paso no esta detallado en diagrama de libro. (Si en el ejemplo)
            this.TiempoDelUltimoEvento = this.Reloj;

            // 2. Avanzamos reloj de simulacion.
            this.Reloj = proximoEvento.Item1;

            // devolvemos objeto que se encarga de rutina de evento.
            return proximoEvento.Item2;
        }
    }
}
