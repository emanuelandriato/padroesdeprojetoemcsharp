using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.padroes
{
    public interface IObserver
    {
        void Atualizar(float temperatura);
    }

    public interface ITemperatura
    {
        public void AdicionarObservador(IObserver observer);
        public void RemoverObservador(IObserver observer);
        public void AtualizarTemperatura(float temperatura);

    }

    public class Temperatura : ITemperatura
    {
        private List<IObserver> _listaObservadores;
        public float _temperatura;


        public Temperatura()
        {
            _listaObservadores = new List<IObserver>();
        }

        public void AdicionarObservador(IObserver observer)
        {
            _listaObservadores.Add(observer);
        }

        public void RemoverObservador(IObserver observer)
        {
            _listaObservadores.Remove(observer);
        }

        public void AtualizarTemperatura(float temperatura)
        {
            _temperatura = temperatura;
            foreach (var observador in _listaObservadores)
            {
                observador.Atualizar(_temperatura);
            }
        }
    }
}
