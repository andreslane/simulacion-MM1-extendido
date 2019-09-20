using ModeloBasico.App;
using ModeloBasico.App.Colas;
using ModeloBasico.App.Eventos;
using ModeloBasico.App.Servidores;
using ModeloBasico.GeneradoresAleatorios;
using ModeloBasico.GeneradoresAleatorios.NumerosAleatorios;
using System.Collections.Generic;

namespace ModeloBasico.Infraestructura
{
    // Esta clase debe instanciarse en un unico lugar de toda la app.
    public class IoCContainer
    {

        private IGeneradorArribos generadorArribos;
        public IGeneradorArribos InjectGeneradorDeEventosAleatorios()
        {
            if (this.generadorArribos == null)
            {
                this.generadorArribos = new GeneradorArribosDistribucionExponencial(this.InjectGeneradorNumerosAleatorios());
            }
            return this.generadorArribos;
        }

        private IGeneradorNumerosAleatorios generadorNumerosAleatorios;
        public IGeneradorNumerosAleatorios InjectGeneradorNumerosAleatorios()
        {
            if (this.generadorNumerosAleatorios == null)
            {
                //this.generadorNumerosAleatorios = new GeneradorNumerosAleatoriosUniformeEjemplo();
                this.generadorNumerosAleatorios = new GeneradorNumerosAleatoriosUniforme();
            }
            return this.generadorNumerosAleatorios;
        }

        private ArriboColaUno arriboColaUno;
        public IEvento InjectArriboColaUno()
        {
            if (this.arriboColaUno == null)
            {
                var colaUno = this.InjectColaUno();

                this.arriboColaUno = new ArriboColaUno(colaUno);
            }
            return this.arriboColaUno;
        }

        private ArriboColaA arriboColaA;
        public IEvento InjectArriboColaA()
        {
            if (this.arriboColaA == null)
            {
                var colaA = this.InjectColaA();

                this.arriboColaA = new ArriboColaA(colaA);
            }
            return this.arriboColaA;
        }

        private ArriboColaB arriboColaB;
        public IEvento InjectArriboColaB()
        {
            if (this.arriboColaB == null)
            {
                var colaB = this.InjectColaB();

                this.arriboColaB = new ArriboColaB(colaB);
            }
            return this.arriboColaB;
        }

        private ArriboColaC arriboColaC;
        public IEvento InjectArriboColaC()
        {
            if (this.arriboColaC == null)
            {
                var colaC = this.InjectColaC();

                this.arriboColaC = new ArriboColaC(colaC);
            }
            return this.arriboColaC;
        }

        private PartidaServidorUno partidaServidorUno;
        public IEvento InjectPartidaServidorUno()
        {
            if (this.partidaServidorUno == null)
            {
                var servidorUno = this.InjectServidorUno();

                this.partidaServidorUno = new PartidaServidorUno(servidorUno);
            }
            return this.partidaServidorUno;
        }

        private PartidaServidorDos partidaServidorDos;
        public IEvento InjectPartidaServidorDos()
        {
            if (this.partidaServidorDos == null)
            {
                var servidorDos = this.InjectServidorDos();

                this.partidaServidorDos = new PartidaServidorDos(servidorDos);
            }
            return this.partidaServidorDos;
        }

        private PartidaServidorA partidaServidorA;
        public IEvento InjectPartidaServidorA()
        {
            if (this.partidaServidorA == null)
            {
                var servidorA = this.InjectServidorA();

                this.partidaServidorA = new PartidaServidorA(servidorA);
            }
            return this.partidaServidorA;
        }

        private PartidaServidorB partidaServidorB;
        public IEvento InjectPartidaServidorB()
        {
            if (this.partidaServidorB == null)
            {
                var servidorB = this.InjectServidorB();

                this.partidaServidorB = new PartidaServidorB(servidorB);
            }
            return this.partidaServidorB;
        }

        private PartidaServidorC partidaServidorC;
        public IEvento InjectPartidaServidorC()
        {
            if (this.partidaServidorC == null)
            {
                var servidorC = this.InjectServidorC();

                this.partidaServidorC = new PartidaServidorC(servidorC);
            }
            return this.partidaServidorC;
        }

       

        private Cola colaUno;
        public Cola InjectColaUno()
        {
            if (this.colaUno == null)
            {
                var servidores = new List<string>
                {
                    Comunes.PartidaServidorUno,
                    Comunes.PartidaServidorDos
                };
                this.colaUno = new ColaUno(servidores);
            }
            return this.colaUno;
        }

        private Cola colaA;
        public Cola InjectColaA()
        {
            if (this.colaA == null)
            {
                var servidores = new List<string> { Comunes.PartidaServidorA };
                this.colaA = new ColaA(servidores);
            }
            return this.colaA;
        }

        private Cola colaB;
        public Cola InjectColaB()
        {
            if (this.colaB == null)
            {
                var servidores = new List<string> { Comunes.PartidaServidorB };
                this.colaB = new ColaB(servidores);
            }
            return this.colaB;
        }

        private Cola colaC;
        public Cola InjectColaC()
        {
            if (this.colaC == null)
            {
                var servidores = new List<string> { Comunes.PartidaServidorC };
                this.colaC = new ColaC(servidores);
            }
            return this.colaC;
        }

        private Servidor servidorUno;
        public Servidor InjectServidorUno()
        {
            if (this.servidorUno == null)
            {
                var colaUno = this.InjectColaUno();
                var colasPosteriores = new List<Cola>
                {
                    this.InjectColaA(),
                    this.InjectColaB(),
                    this.InjectColaC()
                };

                this.servidorUno = new ServidorUno(colaUno, colasPosteriores);
            }
            return this.servidorUno;
        }

        private Servidor servidorDos;
        public Servidor InjectServidorDos()
        {
            if (this.servidorDos == null)
            {
                var colaUno = this.InjectColaUno();
                var colasPosteriores = new List<Cola>
                {
                    this.InjectColaA(),
                    this.InjectColaB(),
                    this.InjectColaC()
                };

                this.servidorDos = new ServidorDos(colaUno, colasPosteriores);
            }
            return this.servidorDos;
        }

        private Servidor servidorA;
        public Servidor InjectServidorA()
        {
            if (this.servidorA == null)
            {
                var colaA = this.InjectColaA();
                var colasPosteriores = new List<Cola>
                {
                };

                this.servidorA = new ServidorA(colaA, colasPosteriores);
            }
            return this.servidorA;
        }

        private Servidor servidorB;
        public Servidor InjectServidorB()
        {
            if (this.servidorB == null)
            {
                var colaB = this.InjectColaB();
                var colasPosteriores = new List<Cola>
                {
                };

                this.servidorB = new ServidorB(colaB, colasPosteriores);
            }
            return this.servidorB;
        }

        private Servidor servidorC;
        public Servidor InjectServidorC()
        {
            if (this.servidorC == null)
            {
                var colaC = this.InjectColaC();
                var colasPosteriores = new List<Cola>
                {
                };

                this.servidorC = new ServidorC(colaC, colasPosteriores);
            }
            return this.servidorC;
        }
    }
}
