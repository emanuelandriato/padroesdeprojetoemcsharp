using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{
    //https://youtu.be/yG1KTNxeWy0
    public class ContaBancaria
    {                  
        public ContaBancaria(string NumeroConta) 
        {
            Saldo = BuscarSaldo(NumeroConta);
        }

        public string Numero { get; set; }
        private decimal _saldo { get; set; }
        
                
        
        public decimal Saldo
        {
            get { return _saldo; }
            private set { _saldo = value; }
        }
        

        private decimal BuscarSaldo(string numeroConta)
        {
            return 6000;
        }

        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado. Saldo atual: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Valor inválido para depósito!");
            }
        }

        public void Sacar(decimal valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado. Saldo atual: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente ou valor inválido!");
            }
        }
    } 
}
