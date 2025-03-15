using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.padroes
{

    public class ExibidorTemperatura : IObserver
    {
        public void Atualizar(float temperatura)
        {
            Console.WriteLine($"Temperatura atual: {temperatura}°C");
        }
    }

    public class AlertaTemperaturaAlta : IObserver
    {
        private float limiteAlerta = 30.0f;

        public void Atualizar(float temperatura)
        {
            if (temperatura > limiteAlerta)
            {
                Console.WriteLine("ALERTA! Temperatura alta: " + temperatura + "°C");
            }
        }
    }


}
