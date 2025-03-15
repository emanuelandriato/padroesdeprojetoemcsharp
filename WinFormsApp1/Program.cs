using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using System.Numerics;
using WinFormsApp1.models;
using WinFormsApp1.padroes;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            

            //adicionar no serviceProvider, as interfaces e classes, para que ele saiba o que terá que instanciar
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPedido, Pedido>()                
                .AddScoped<IPagamentos, Pagamentos>()
                .AddScoped<IAssistenteEmIngles, AssistenteEmIngles>()
                .AddScoped<IAssistenteVirtualAdapter, AssistenteVirtualAdapter>()
                .AddScoped<ITV, TV>()
                .AddScoped<ISistemaDeSom, SistemaDeSom>()
                .AddScoped<IReprodutorDeMidia, ReprodutorDeMidia>()
                .AddScoped<IIluminacao, Iluminacao>()
                .AddScoped<IHomeTheaterFacade, HomeTheaterFacade>()                
                .AddSingleton<ITemperatura, Temperatura>()
                .BuildServiceProvider();            

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandlerDomain);

                        
            bool testarDI = false;
            if (testarDI)
            {
                //Dependency Injection aonde eu instancio Pagamentos 
                IPagamentos pag = new Pagamentos();
                var teste = new Pedido(pag);
                teste.EfetuarCompra();

                //DI, deixando o framework se virar e gerenciar a instancia da classe
                var pedido = serviceProvider.GetRequiredService<IPedido>();
                pedido.EfetuarCompra();
            }


            bool testarAdapter = false;
            if (testarAdapter)
            {

                var assistenteAdaptado = serviceProvider.GetRequiredService<IAssistenteVirtualAdapter>();
                assistenteAdaptado.ResponderEmPortugues("Olá, como você está?");
            }

            bool testarDecorator = false;
            if (testarDecorator)
            {
                //Decorando nossa pizza com ingredientes extras!
                IPizza minhaPizza = new PizzaSimples();
                minhaPizza = new BordaRecheada(minhaPizza);
                minhaPizza = new Queijo(minhaPizza);
                minhaPizza = new Tomate(minhaPizza);
                minhaPizza = new Calabresa(minhaPizza);

                Console.WriteLine($"Descrição: {minhaPizza.Descricao()}");
                Console.WriteLine($"Preço total: R$ {minhaPizza.Preco:F2}");
                
            }

            bool testarFacade = false;
            if (testarFacade)
            {
                var homeTheater = serviceProvider.GetRequiredService<IHomeTheaterFacade>();
                homeTheater.AssistirFilme();
            }

            bool testandoObserver = true;
            if(testandoObserver)
            {
                var temperatura = serviceProvider.GetRequiredService<ITemperatura>();
                
                ExibidorTemperatura exibirTemperatura = new ExibidorTemperatura();
                temperatura.AdicionarObservador(exibirTemperatura);

                AlertaTemperaturaAlta alerta = new AlertaTemperaturaAlta();
                temperatura.AdicionarObservador(alerta);

                temperatura.AtualizarTemperatura(15);

                temperatura.AtualizarTemperatura(33);
            }









            var temp = serviceProvider.GetRequiredService<ITemperatura>();
            Application.Run(new Form1(temp));
        }



        private static void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Erro na UI: {e.Exception.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void GlobalExceptionHandlerDomain(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show($"Erro crítico: {ex?.Message}", "Erro Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
