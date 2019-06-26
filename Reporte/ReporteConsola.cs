using System;
using System.Linq;
using ModeloBasico.App;

namespace ModeloBasico.Reporte
{
    public class ReporteConsola
    {
        public void RegistrarEvento(Modelo modelo)
        {
            Console.WriteLine($"Reloj: { modelo.Reloj }");

            Console.WriteLine($"Estado del servidor: {(modelo.ServidorOcupado ? 1 : 0)}");
            Console.WriteLine($"Cantidad en cola: { modelo.CantidadEnCola }");
            Console.WriteLine($"Tiempos de arribo: { string.Join(",", modelo.ColaDeTiemposDeArribo) }");
            Console.WriteLine($"Tiempo del ultimo evento: {modelo.TiempoDelUltimoEvento}");

            Console.WriteLine($"Lista de eventos A: { modelo.ListaDeEventos['A'].Item1 }");
            Console.WriteLine($"Lista de eventos P: { modelo.ListaDeEventos['P'].Item1 }");

            Console.WriteLine($"Demoras completadas: { modelo.CantidadDeDemorasCompletadas }");
            Console.WriteLine($"Demora total: { modelo.TotalDemora }");
            Console.WriteLine($"Area bajo Q(t): { modelo.AreaBajoQ }");
            Console.WriteLine($"Area bajo B(t): { modelo.AreaBajoB }");

            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
