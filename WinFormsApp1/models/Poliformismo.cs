using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{

    public class Pagamento
    {
        public Pagamento(decimal valor, string numeroconta)
        {
            Valor = valor;
        }

        public decimal Valor { get; set; }

        public virtual void ProcessarPagamento()
        {
            Console.WriteLine("enviaria o dinheiro para a conta");
        }

        public void Teste()
        {
            Console.WriteLine("teste");
        }

    }

    public class PagamentoBoleto : Pagamento
    {
        public PagamentoBoleto(decimal valor, string numeroconta, string numeroCodigoBarras) : base(valor, numeroconta)
        {
            NumeroCodigoBarras = numeroCodigoBarras;
        }

        public string NumeroCodigoBarras { get; set; }

        public override void ProcessarPagamento() //sobrescrita
        {
            Console.WriteLine("abater boleto");
            base.ProcessarPagamento();
        }

        public void Teste(string teste)
        {
            var objet = new Gato();
            Console.WriteLine(objet);
        }

        public void Teste(int teste)
        {
            Console.WriteLine("teste");
        }

        public void Teste(double teste)
        {
            Console.WriteLine("teste");
        }

        public void Teste(string teste, int teste2)
        {
            Console.WriteLine("teste");
        }

    }

    public class PagamentoCartao : Pagamento
    {
        public PagamentoCartao(decimal valor, string numeroconta, int parcelas, string numeroCartao) : base(valor, numeroconta)
        {
            NumeroCartao = numeroCartao;
            Parcelas = parcelas;
        }

        public string NumeroCartao { get; set; }
        public int Parcelas { get; set; }

        public override void ProcessarPagamento() //sobrescrita
        {
            Console.WriteLine("pagamento cartao .....");
            base.ProcessarPagamento();
        }
    }
}
