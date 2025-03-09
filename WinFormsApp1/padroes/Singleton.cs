using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.padroes
{
    /// <summary>
    /// https://youtu.be/2nLDS9RF13Y
    /// </summary>
    
    //classe Singleton no modelo tradicional    
    public sealed class Parametros                      //classe selada (para evitar que alguma classe herde essa classe)
    {                   
        private static Parametros _instance;            //instancia privada dessa classe, objeto que somente a própria classe pode manipular
        private static readonly object _lock = new();   //objeto para tratamento de concorrencias em sistemas multitheads

        private Parametros()                            //construtor privado para realizacoes de tarefas internas da classe
        {
            CarregarParametros();
        }


        private void CarregarParametros()              //metodo para exemplificar a inicializacao dos atributos etc 
        {
            //carregar informacoes do banco de dados, arquivo texto etc e tal
            Versao = "1.0";
            NomeDoSistema = "Programar é Arte";
        }

        public static Parametros Instance              //atributo para obtencao da instancia da classe 
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Parametros();
                        }
                    }
                }
                return _instance;
            }
        }        

        //atributos da classe, aonde somente expoe o get e priva o set
        public string Versao { get; private set; }
        public string NomeDoSistema { get; private set; }


    }

    /*
    //classe Singleton utilizando Lazy
    public sealed class Parametros  
    {
        //Lazy<T> garante que a instância só será criada quando for realmente necessária.
        //Evita problemas em ambientes multi-thread.

        private static readonly Lazy<Parametros> _instance = new(() => new Parametros());       

        private Parametros()
        {
            CarregarParametros();
        }

        private void CarregarParametros()
        {
            Versao = "1.0";
            NomeDoSistema = "Programar é Arte";
        }

        public static Parametros Instance => _instance.Value; //quando value é chamado, a instancia do objeto é de fato realizada
        public string Versao { get; private set; }
        public string NomeDoSistema { get; private set; }

    }
    */
}
