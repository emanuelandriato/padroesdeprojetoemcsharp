using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.padroes;

namespace WinFormsApp1.padroes
{

    /*
    Imagine que você tem uma pizzaria e vende pizzas básicas. Mas os clientes querem adicionar ingredientes extras como queijo, tomate seco, borda recheada, etc.
    Como podemos adicionar esses ingredientes sem modificar a classe original da pizza?
    Usamos o padrão Decorator!     

    video explicativo: https://youtu.be/0c1WdOthGSY
    */
    public interface IPizza
    {
        List<string> Ingredientes { get; }
        double Preco { get; }
        void AdicionarIngrediente(string nome, double valor);
        string Descricao();
    }

    public class PizzaSimples : IPizza
    {
        private double _valorTotal = 20.00;
        private List<string> _ingredientes = new List<string>();

        public PizzaSimples()
        {
            _ingredientes.Add("Pizza Base");
        }

        public List<string> Ingredientes => _ingredientes;
        public double Preco => _valorTotal;

        public void AdicionarIngrediente(string nome, double valor)
        {
            _ingredientes.Add(nome);
            _valorTotal += valor;
        }

        public string Descricao()
        {
            return string.Join(", ", _ingredientes);
        }
    }





    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;
        protected double _precoExtra;

        public PizzaDecorator(IPizza pizza, string nomeIngrediente, double precoExtra)
        {
            _pizza = pizza;
            _precoExtra = precoExtra;
            _pizza.AdicionarIngrediente(nomeIngrediente, precoExtra);
        }

        public List<string> Ingredientes => _pizza.Ingredientes;
        public double Preco => _pizza.Preco;

        public void AdicionarIngrediente(string nome, double valor)
        {
            _pizza.AdicionarIngrediente(nome, valor);
        }

        public string Descricao()
        {
            return _pizza.Descricao();
        }
    }


    public class Queijo : PizzaDecorator
    {
        public Queijo(IPizza pizza) : base(pizza, "Queijo Extra", 9.00) { }
    }

    public class BordaRecheada : PizzaDecorator
    {
        public BordaRecheada(IPizza pizza) : base(pizza, "Borda Recheada", 10.00) { }
    }

    public class Tomate : PizzaDecorator
    {
        public Tomate(IPizza pizza) : base(pizza, "Tomate", 11.00) { }
    }

    public class Calabresa : PizzaDecorator
    {
        public Calabresa(IPizza pizza) : base(pizza, "Calabresa", 8.00) { }
    }

    public class Azeitona : PizzaDecorator
    {
        public Azeitona(IPizza pizza) : base(pizza, "Azeitona", 8.00) { }
    }


}


 















/*
O Decorator permite adicionar comportamentos extras a um objeto sem modificar seu código original.
Podemos encadear vários decorators para personalizar o objeto como quisermos!
Exemplo real: Em um sistema de pedidos, podemos adicionar opções extras sem precisar modificar a classe original.
*/