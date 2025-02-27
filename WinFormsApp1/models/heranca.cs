using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{
   
    interface IMovimentar
    {
        public void Correr(string Nome);
        public void Andar(string Nome);
    }
 
    interface IAnimal
    {
        public void EmitirSom();
    }

    public abstract class Animal : IMovimentar
    {        
        public string Nome { get; set; }
        public double Peso { get; set; }

        public void Andar(string Nome)
        {
            MessageBox.Show("andando");
        }

        public void Correr(string Nome)
        {
            MessageBox.Show("correndo");
        }

        public void Teste()
        {
            MessageBox.Show("testando");
        }

        public abstract void EmitirSom();
        public void EmitirSon(string som)
        {
            Console.WriteLine($@"emitindo um som:{som}");
        }
        
    }

    public class Gato : Animal
    {        
        public override void EmitirSom()
        {
            MessageBox.Show("miau");
        }
    }

    public class Cachorro : Animal
    {
        public override void EmitirSom()
        {
            MessageBox.Show("au au");
        }
    }

    

}
