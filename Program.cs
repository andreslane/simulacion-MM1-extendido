using ModeloBasico.App;
using ModeloBasico.Infraestructura;
using System;

namespace ModeloBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            var injector = new InjectGeneradores();

            try
            {
                var modelo = new Modelo(injector);
                modelo.IniciarSimulacion();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
