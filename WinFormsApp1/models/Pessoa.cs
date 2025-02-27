using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{
    public class Pessoa
    {
        //construtor
        public Pessoa()
        {

        }

        //atributos
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade 
        {
            get 
            {
                return CalcularIdade(DataNascimento);
            }
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - DataNascimento.Year;
            
            if (DataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }

    }



}
