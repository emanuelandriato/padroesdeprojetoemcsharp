using System.Net.Http.Headers;
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.ThreadException += new ThreadExceptionEventHandler(GlobalExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandlerDomain);

                        
            

            Application.Run(new Form1());
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