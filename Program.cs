using ModeloBasico.App;
using ModeloBasico.Infraestructura;
using System;

namespace ModeloBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new IoCContainer();

            try
            {
                var modelo = new Modelo(container);
                modelo.IniciarSimulacion();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Continue para cerrar.");
                    Console.ReadLine();
                }
            }
        }
    }
}
