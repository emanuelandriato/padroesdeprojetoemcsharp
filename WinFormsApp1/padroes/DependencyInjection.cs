using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.padroes
{
    /// <summary>
    ///     
    /// </summary>
    /// 

    //interfaces IPagamentos e IPedido
    public interface IPagamentos
    {
        public void RealizarPagamento();
    }

    public interface IPedido
    {
        public bool EfetuarCompra();
    }

    public class Pagamentos : IPagamentos
    {
        public Pagamentos() 
        { 
        }

        public void RealizarPagamento()
        {
            Console.WriteLine($"... pagamento realizado com sucesso ...");
        }
    }

    public class Pedido : IPedido
    {
        private readonly IPagamentos _pagamentos;
           
        //ao instanciar Pedido, a classe Pagamentos é injetada pelo prórprio framework
        public Pedido(IPagamentos pagamento) 
        { 
            _pagamentos = pagamento;
        }

        public bool EfetuarCompra()
        {
            try
            {
                //var pagamento = new Pagamentos(); //nao precisamos instanciar a classe manualmente utilizando DI
                _pagamentos.RealizarPagamento();
                return true;
            }
            catch
            (Exception ex)
            {
                Console.WriteLine($@"Erro: {ex.ToString()}");
                return false;
            }
            
        }

    }


}


