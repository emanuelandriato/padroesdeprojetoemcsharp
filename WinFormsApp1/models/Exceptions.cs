using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{

    public class EmanuelException : SystemException
    {
        public EmanuelException(Exception innerException) : base("Emanuel Pisou aqui!") 
        {
            var stacktrace = innerException.StackTrace;                  
        }          

    }


    //(try, catch e finally)
    static class TestandoExcecoes
    {
        private static void Commit()
        {
            Console.WriteLine("commit sucess");
        }

        private static void RollBack()
        {
            Console.WriteLine("rollback sucess");
        }

        public static bool SalvarDados(object obj)
        {            
            try
            {
                int x = 0;
                int y = 10;
                y = y / x;

                Commit();
                return true;                
            }
            catch (Exception ex) 
            {               
                RollBack();
                throw new EmanuelException(ex);
                return false;
            }
            finally
            {
                var teste = "teste";
            }                       
        }
        
        public static void VaiDarRuim()
        {
            int x = 0;
            int y = 10;
            y = y / x;
        }

    }

}
   
    
