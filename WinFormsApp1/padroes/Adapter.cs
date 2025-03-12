using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.padroes
{
    /*
	O Adapter permite que classes com interfaces incompatíveis trabalhem juntas.
	O Adapter é muito útil quando precisamos integrar sistemas com APIs incompatíveis.
	Ele evita modificações desnecessárias no código original e mantém a arquitetura desacoplada.

    video explicativo: https://youtu.be/0c1WdOthGSY
	*/


    //interface representando um assistente virtual
    public interface IAssistenteEmIngles
    {
        public void RespostanEmIngles(string mensagem);
    }

    //classe do assistente em ingles, que não possui um método para traduzir para português
    //suponhamos que essa classe fosse de uma biblioteca que voce nao possui acesso, sendo assim nao poderia realizar ajustes nela
    public class AssistenteEmIngles : IAssistenteEmIngles
    {
        public void RespostanEmIngles(string mensagem)
        {
            Console.WriteLine($"English: {mensagem}");
        }
    }



    public interface IAssistenteVirtualAdapter
    {
        void ResponderEmPortugues(string mensagem);
    }

    //classe para adaptar a classe AssistenteEmIngles e adicionar o metodo para enviar mensagens em portugues
    public class AssistenteVirtualAdapter : IAssistenteVirtualAdapter
    {
        private readonly IAssistenteEmIngles _assistenteIngles;

        public AssistenteVirtualAdapter(IAssistenteEmIngles assistenteIngles)
        {
            _assistenteIngles = assistenteIngles;
        }

        public void ResponderEmPortugues(string mensagem)
        {
            string mensagemTraduzida = TraduzirParaIngles(mensagem);
            _assistenteIngles.RespostanEmIngles(mensagemTraduzida);
        }

        private string TraduzirParaIngles(string mensagem)
        {         
            //aqui você implementaria um tradutor ou utilizaria a api do google para traduzir
            return "Hello! How are you?";
        }
    }    
    
}
