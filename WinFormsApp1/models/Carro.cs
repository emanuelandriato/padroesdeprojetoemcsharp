using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{
    
    class Carro
    {
        //construtor
        public Carro() 
        {
            var teste = "estou construindo";
            VelocidadeMaxima = 250;
        }

        public string Marca;
        public string Cor;
        public int Velocidade;
        private int VelocidadeMaxima;


        public void Acelerar()
        {            
            if (Velocidade < VelocidadeMaxima)
            {
                Velocidade++;
            }
        }

        public void Frear()
        {
            if(Velocidade == 0)
            {
                Velocidade--;
            }            
        }

    }
    




}
