using System;
using System.Linq;
using ModeloBasico.App;
using ModeloBasico.App.Colas;
using ModeloBasico.Infraestructura;

namespace ModeloBasico.Reporte
{
    public class ReporteConsola
    {
        private readonly Configuraciones configuraciones;

        public ReporteConsola(Configuraciones configuraciones)
        {
            this.configuraciones = configuraciones;
        }

        public void RegistrarEvento(Modelo modelo)
        {
            var servidores = this.configuraciones.ObtenerServidores();
            var colas = this.configuraciones.ObtenerColas();

            Console.WriteLine($"#############################");
            Console.WriteLine($"Reloj: { modelo.Reloj }");
            Console.WriteLine();

            Console.WriteLine("Lista de eventos:");
            decimal[] eventos = 
                {
                    modelo.ListaDeEventos[Comunes.ArriboColaUno].Item1,
                    modelo.ListaDeEventos[Comunes.PartidaServidorUno].Item1,
                    modelo.ListaDeEventos[Comunes.PartidaServidorDos].Item1,
                    modelo.ListaDeEventos[Comunes.ArriboColaA].Item1,
                    modelo.ListaDeEventos[Comunes.ArriboColaB].Item1,
                    modelo.ListaDeEventos[Comunes.ArriboColaC].Item1,
                    modelo.ListaDeEventos[Comunes.PartidaServidorA].Item1,
                    modelo.ListaDeEventos[Comunes.PartidaServidorB].Item1,
                    modelo.ListaDeEventos[Comunes.PartidaServidorC].Item1,
                };
            var proximoEvento = eventos.Min();

            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.ArriboColaUno].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.ArriboColaUno}: {modelo.ListaDeEventos[Comunes.ArriboColaUno].Item1}");
            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.PartidaServidorUno].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.PartidaServidorUno}: {modelo.ListaDeEventos[Comunes.PartidaServidorUno].Item1}");
            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.PartidaServidorDos].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.PartidaServidorDos}: {modelo.ListaDeEventos[Comunes.PartidaServidorDos].Item1}");

            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.ArriboColaA].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.ArriboColaA}: {modelo.ListaDeEventos[Comunes.ArriboColaA].Item1}");
            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.ArriboColaB].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.ArriboColaB}: {modelo.ListaDeEventos[Comunes.ArriboColaB].Item1}");
            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.ArriboColaC].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.ArriboColaC}: {modelo.ListaDeEventos[Comunes.ArriboColaC].Item1}");

            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.PartidaServidorA].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.PartidaServidorA}: {modelo.ListaDeEventos[Comunes.PartidaServidorA].Item1}");
            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.PartidaServidorB].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.PartidaServidorB}: {modelo.ListaDeEventos[Comunes.PartidaServidorB].Item1}");
            Console.WriteLine($"{(modelo.ListaDeEventos[Comunes.PartidaServidorC].Item1 == proximoEvento ? ">>" : string.Empty)}\t{Comunes.PartidaServidorC}: {modelo.ListaDeEventos[Comunes.PartidaServidorC].Item1}");

            Console.WriteLine();
            Console.WriteLine($"Cola 1: \t{ string.Join(",", colas.First(s => s.NombreDelEventoDeArribo == Comunes.ArriboColaUno).ColaDeTiemposDeArribo) }");

            var servidor1 = servidores.First(s => s.NombreDelEventoDePartida == Comunes.PartidaServidorUno);
            var servidor2 = servidores.First(s => s.NombreDelEventoDePartida == Comunes.PartidaServidorDos);
            Console.WriteLine($"Servidor 1: \t{(servidor1.ServidorOcupado ? "OCUPADO" : "LIBRE")}");
            Console.WriteLine($"Servidor 2: \t{(servidor2.ServidorOcupado ? "OCUPADO" : "LIBRE")}");

            Console.WriteLine($"Cola A: \t{ string.Join(",", colas.First(s => s.NombreDelEventoDeArribo == Comunes.ArriboColaA).ColaDeTiemposDeArribo) }");
            Console.WriteLine($"Cola B: \t{ string.Join(",", colas.First(s => s.NombreDelEventoDeArribo == Comunes.ArriboColaB).ColaDeTiemposDeArribo) }");
            Console.WriteLine($"Cola C: \t{ string.Join(",", colas.First(s => s.NombreDelEventoDeArribo == Comunes.ArriboColaC).ColaDeTiemposDeArribo) }");

            var servidorA = servidores.First(s => s.NombreDelEventoDePartida == Comunes.PartidaServidorA);
            var servidorB = servidores.First(s => s.NombreDelEventoDePartida == Comunes.PartidaServidorB);
            var servidorC = servidores.First(s => s.NombreDelEventoDePartida == Comunes.PartidaServidorC);
            Console.WriteLine($"Servidor A: \t{(servidorA.ServidorOcupado ? "OCUPADO" : "LIBRE")}");
            Console.WriteLine($"Servidor B: \t{(servidorB.ServidorOcupado ? "OCUPADO" : "LIBRE")}");
            Console.WriteLine($"Servidor C: \t{(servidorC.ServidorOcupado ? "OCUPADO" : "LIBRE")}");

            Console.WriteLine();
            Console.WriteLine();
        }

        public void ObtenerMedidasDeRendimiento(Modelo modelo)
        {
            var tasasDeEventosAleatorios = this.configuraciones.ObtenerTiemposPromedioDeLosEventos();

            Console.WriteLine("#############################");
            Console.WriteLine("Configuración:");

            Console.WriteLine();

            Console.WriteLine($"Tasa de arribo:");
            Console.WriteLine($"\tCola 1: { 1/tasasDeEventosAleatorios[Comunes.ArriboColaUno]} cli/u.t. \t (Tiempo promedio entre arribos: {tasasDeEventosAleatorios[Comunes.ArriboColaUno]} u.t./cli)");

            Console.WriteLine();

            Console.WriteLine("Tasas de servicio:");
            Console.WriteLine($"\tServidor 1: { 1/tasasDeEventosAleatorios[Comunes.PartidaServidorUno] } cli/u.t. \t (Tiempo promedio entre servicios { tasasDeEventosAleatorios[Comunes.PartidaServidorUno] } u.t./cli");
            Console.WriteLine($"\tServidor 2: { 1/tasasDeEventosAleatorios[Comunes.PartidaServidorDos] } cli/u.t. \t (Tiempo promedio entre servicios { tasasDeEventosAleatorios[Comunes.PartidaServidorDos] } u.t./cli");
            Console.WriteLine($"\tServidor A: { 1/tasasDeEventosAleatorios[Comunes.PartidaServidorA] } cli/u.t. \t (Tiempo promedio entre servicios { tasasDeEventosAleatorios[Comunes.PartidaServidorA] } u.t./cli");
            Console.WriteLine($"\tServidor B: { 1/tasasDeEventosAleatorios[Comunes.PartidaServidorB] } cli/u.t. \t (Tiempo promedio entre servicios { tasasDeEventosAleatorios[Comunes.PartidaServidorB] } u.t./cli");
            Console.WriteLine($"\tServidor C: { 1/tasasDeEventosAleatorios[Comunes.PartidaServidorC] } cli/u.t. \t (Tiempo promedio entre servicios { tasasDeEventosAleatorios[Comunes.PartidaServidorC] } u.t./cli");

            Console.WriteLine();
            Console.WriteLine($"Fin de la simulación: 1000 eventos ejecutados.");
            Console.WriteLine();

            Console.WriteLine("#############################");
            Console.WriteLine("Medidas de rendimiento: ");

            Console.WriteLine();

            Console.WriteLine($"Tiempo en el que finalizó la simulación: {modelo.Reloj}");

            Console.WriteLine();

            var servidores = this.configuraciones.ObtenerServidores();
            var colas = this.configuraciones.ObtenerColas();

            // Numero promedio clientes que tuvieron que esperar para ser atendidos. [d(n)]
            Console.WriteLine($"Número promedio clientes que tuvieron que esperar para ser atendidos. [d(n)]:");

            var cola1 = colas.First(c => c.NombreDelEventoDeArribo == Comunes.ArriboColaUno);
            var colaA = colas.First(c => c.NombreDelEventoDeArribo == Comunes.ArriboColaA);
            var colaB = colas.First(c => c.NombreDelEventoDeArribo == Comunes.ArriboColaB);
            var colaC = colas.First(c => c.NombreDelEventoDeArribo == Comunes.ArriboColaC);

            var promedioClientesQueEsperaronCola1 = cola1.TotalDemora / cola1.CantidadDeDemorasCompletadas;
            var promedioClientesQueEsperaronColaA = colaA.TotalDemora / colaA.CantidadDeDemorasCompletadas;
            var promedioClientesQueEsperaronColaB = colaB.TotalDemora / colaB.CantidadDeDemorasCompletadas;
            var promedioClientesQueEsperaronColaC = colaC.TotalDemora / colaC.CantidadDeDemorasCompletadas;

            Console.WriteLine($"\tCola 1: {decimal.Round(promedioClientesQueEsperaronCola1, 2)}");
            Console.WriteLine($"\tCola A: {decimal.Round(promedioClientesQueEsperaronColaA, 2)}");
            Console.WriteLine($"\tCola B: {decimal.Round(promedioClientesQueEsperaronColaB, 2)}");
            Console.WriteLine($"\tCola C: {decimal.Round(promedioClientesQueEsperaronColaC, 2)}");

            Console.WriteLine();

            // Numero promedio de clientes en cola [q(n)]
            Console.WriteLine($"Número promedio de clientes en cola [q(n)]:");

            var promedioClientesEnCola1 = colas.First(c => c.NombreDelEventoDeArribo == Comunes.ArriboColaUno).AreaBajoQ / modelo.Reloj;
            var promedioClientesEnColaA = colas.First(c => c.NombreDelEventoDeArribo == Comunes.ArriboColaA).AreaBajoQ / modelo.Reloj;
            var promedioClientesEnColaB = colas.First(c => c.NombreDelEventoDeArribo == Comunes.ArriboColaB).AreaBajoQ / modelo.Reloj;
            var promedioClientesEnColaC = colas.First(c => c.NombreDelEventoDeArribo == Comunes.ArriboColaC).AreaBajoQ / modelo.Reloj;

            Console.WriteLine($"\tCola 1: {decimal.Round(promedioClientesEnCola1, 2)}");
            Console.WriteLine($"\tCola A: {decimal.Round(promedioClientesEnColaA, 2)}");
            Console.WriteLine($"\tCola B: {decimal.Round(promedioClientesEnColaB, 2)}");
            Console.WriteLine($"\tCola C: {decimal.Round(promedioClientesEnColaC, 2)}");

            Console.WriteLine();

            // Uso promedio de los servidores.
            Console.WriteLine($"Uso promedio de los servidores [u(n)]:");

            var usoServidor1 = servidores.First(c => c.NombreDelEventoDePartida == Comunes.PartidaServidorUno).AreaBajoB / modelo.Reloj;
            var usoServidor2 = servidores.First(c => c.NombreDelEventoDePartida == Comunes.PartidaServidorDos).AreaBajoB / modelo.Reloj;
            var usoServidorA = servidores.First(c => c.NombreDelEventoDePartida == Comunes.PartidaServidorA).AreaBajoB / modelo.Reloj;
            var usoServidorB = servidores.First(c => c.NombreDelEventoDePartida == Comunes.PartidaServidorB).AreaBajoB / modelo.Reloj;
            var usoServidorC = servidores.First(c => c.NombreDelEventoDePartida == Comunes.PartidaServidorC).AreaBajoB / modelo.Reloj;

            Console.WriteLine($"\tServidor 1: {decimal.Round(usoServidor1, 2)}");
            Console.WriteLine($"\tServidor 2: {decimal.Round(usoServidor2, 2)}");
            Console.WriteLine($"\tServidor A: {decimal.Round(usoServidorA, 2)}");
            Console.WriteLine($"\tServidor B: {decimal.Round(usoServidorB, 2)}");
            Console.WriteLine($"\tServidor C: {decimal.Round(usoServidorC, 2)}");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
