using ModeloBasico.App;
using System;
using System.Collections.Generic;

namespace ModeloBasico.Infraestructura
{
    public class Configuraciones
    {
        private readonly IoCContainer container;

        public Configuraciones(IoCContainer container)
        {
            this.container = container;
        }

        public Dictionary<string, decimal> ObtenerTiemposPromedioDeLosEventos()
        {
            return new Dictionary<string, decimal>
            {
                // NOTAS:
                //      Aqui configuraremos los tiempos promedios de cada uno de los eventos Arribos o Tiempos de servicio (Partidas).
                //      Ingresaremos los valores de las "tasas" de arribo o servicio, por lo que haremos 1/tasa para obtener la media exponencial.
                // Ej:  (tasa)          alfa    = 0.7   cli/ut ;  
                //      (tiempo prom)   t prom  = 1/0.7 ut/cli  = 1.43 ut / cli

                { Comunes.ArriboColaUno, 1/0.5m },            

                { Comunes.PartidaServidorUno, 1/0.4m },
                { Comunes.PartidaServidorDos, 1/0.4m },

                { Comunes.PartidaServidorA, 1/0.2m },
                { Comunes.PartidaServidorB, 1/0.2m },
                { Comunes.PartidaServidorC, 1/0.2m },

                // No se configuran ya que dependen de la partida de Servidor Uno y Dos.

                //{ Comunes.ArriboColaA, 1m }, 
                //{ Comunes.ArriboColaB, 1m },
                //{ Comunes.ArriboColaC, 1m },
            };
        }

        public List<Cola> ObtenerColas()
        {
            return new List<Cola>
            {
                this.container.InjectColaUno(),
                this.container.InjectColaA(),
                this.container.InjectColaB(),
                this.container.InjectColaC()
            };
        }

        public List<Servidor> ObtenerServidores()
        {
            return new List<Servidor>
            {
                this.container.InjectServidorUno(),
                this.container.InjectServidorDos(),
                this.container.InjectServidorA(),
                this.container.InjectServidorB(),
                this.container.InjectServidorC()
            };
        }

        public Dictionary<string, Tuple<decimal, IEvento>> ObtenerListaDeEventos(decimal primerArribo)
        {
            return new Dictionary<string, Tuple<decimal, IEvento>>
            {
                { Comunes.ArriboColaUno, new Tuple<decimal, IEvento>(primerArribo, container.InjectArriboColaUno()) },

                { Comunes.PartidaServidorUno, new Tuple<decimal, IEvento>(decimal.MaxValue, container.InjectPartidaServidorUno()) },
                { Comunes.PartidaServidorDos, new Tuple<decimal, IEvento>(decimal.MaxValue, container.InjectPartidaServidorDos()) },

                { Comunes.ArriboColaA, new Tuple<decimal, IEvento>(decimal.MaxValue, container.InjectArriboColaA()) },
                { Comunes.ArriboColaB, new Tuple<decimal, IEvento>(decimal.MaxValue, container.InjectArriboColaB()) },
                { Comunes.ArriboColaC, new Tuple<decimal, IEvento>(decimal.MaxValue, container.InjectArriboColaC()) },

                { Comunes.PartidaServidorA, new Tuple<decimal, IEvento>(decimal.MaxValue, container.InjectPartidaServidorA()) },
                { Comunes.PartidaServidorB, new Tuple<decimal, IEvento>(decimal.MaxValue, container.InjectPartidaServidorB()) },
                { Comunes.PartidaServidorC, new Tuple<decimal, IEvento>(decimal.MaxValue, container.InjectPartidaServidorC()) }
            };
        }
    }
}
