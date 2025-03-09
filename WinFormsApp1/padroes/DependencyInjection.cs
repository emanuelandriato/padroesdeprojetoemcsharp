using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.padroes
{   
    public class Pagamentos
    {
        public Pagamentos() 
        { 
        }

        public void RealizarPagamento()
        {
            Console.WriteLine($"... pagamento realizado com sucesso ...");
        }
    }

    public class Pedido
    {
        public Pedido() 
        { 
        
        }

        public bool EfetuarCompra()
        {
            try
            {
                                
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


