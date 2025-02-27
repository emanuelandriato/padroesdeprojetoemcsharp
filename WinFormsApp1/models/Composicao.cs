using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{


    public class Motor
    {
        public void Ligar()
        {
            Console.WriteLine("Motor Ligado");
        }
    }

    public class Passageiro
    {
        public string Nome { get; set; }
    }


    public class Veiculo
    {
        public Veiculo()
        {
            Motor = new Motor();
            Passageiros = new List<Passageiro>();
        }

        private Motor Motor;
        private List<Passageiro> Passageiros { get; set; }

        public void LigarVeiculo()

        {
            Motor.Ligar();
            Console.WriteLine("O veiculo esta ligado");
        }

        public void AdicionarPassageiro(Passageiro passageiro)
        {
            Passageiros.Add(passageiro);
        }

        public void ListarPassageiros()
        {
            foreach (var passageiro in Passageiros)
            {
                Console.WriteLine($@"{passageiro.Nome}");
            }
        }

    }









}
