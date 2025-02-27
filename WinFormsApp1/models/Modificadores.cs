using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{

    //modificadores (internal, public, private, protected e static)


    public class MinhaClasseEstatica
    {
        public static void Testar()
        {
            Console.WriteLine("testou");
        }

        private void teste()
        {
            Console.WriteLine("ninguem usa");
        }

        public void MetodoPublico()
        {
            Console.WriteLine("metodo publico");
        }

    }


    public class Teste
    {

    }
    public class MinhaClasse
    {

        private int _id { get;  }

        protected Teste _teste { get; set;  }


    }

    public class OutraClasse : MinhaClasse
    { 
    
        public void Teste()
        {
            _teste = new Teste();
        }
    }

    





}
