using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace WinFormsApp1.padroes
{

    /*
    Imagine que você tem um Home Theater em casa.Para assistir a um filme, você precisa:
    Ligar a TV
    Ligar o Som
    Configurar a entrada do HDMI
    Colocar o filme no player
    Apagar as luzes
    Dar Play

    Fazer isso toda vez pode ser cansativo!
    Então, criamos um controle remoto inteligente 🎮 que faz tudo isso com um só botão!
    Esse controle remoto será nossa Facade!

    video explicativo: https://youtu.be/0c1WdOthGSY
    */

    public interface ITV
    {
        void Ligar();
        void ConfigurarHDMI();
    }

    public interface ISistemaDeSom
    {
        void Ligar();
        void AjustarVolume();
    }

    public interface IReprodutorDeMidia
    {
        void Ligar();
        void CarregarFilme();
        void DarPlay();
    }

    public interface IIluminacao
    {
        void ApagarLuzes();
    }

    public class TV : ITV
    {
        public void Ligar() => Console.WriteLine("=> TV ligada.");
        public void ConfigurarHDMI() => Console.WriteLine("=> HDMI configurado.");
    }

    public class SistemaDeSom : ISistemaDeSom
    {
        public void Ligar() => Console.WriteLine("=> Sistema de Som ligado.");
        public void AjustarVolume() => Console.WriteLine("=> Volume ajustado para o nível ideal.");
    }

    public class ReprodutorDeMidia : IReprodutorDeMidia
    {
        public void Ligar() => Console.WriteLine("=> Reprodutor de Mídia ligado.");
        public void CarregarFilme() => Console.WriteLine("=> Filme carregado no player.");
        public void DarPlay() => Console.WriteLine("=> Play no filme.");
    }

    public class Iluminacao : IIluminacao
    {
        public void ApagarLuzes() => Console.WriteLine("=> Luzes apagadas para sessão de cinema.");
    }




    public interface IHomeTheaterFacade
    {
        public void AssistirFilme();
    }

    public class HomeTheaterFacade : IHomeTheaterFacade
    {
        private readonly ITV _tv;
        private readonly ISistemaDeSom _som;
        private readonly IReprodutorDeMidia _player;
        private readonly IIluminacao _iluminacao;

        public HomeTheaterFacade(ITV tv, ISistemaDeSom som, IReprodutorDeMidia player, IIluminacao iluminacao)
        {
            _tv = tv;
            _som = som;
            _player = player;
            _iluminacao = iluminacao;
        }

        public void AssistirFilme()
        {
            Console.WriteLine("Preparando Home Theater para assistir um filme...");
            _tv.Ligar();
            _tv.ConfigurarHDMI();
            _som.Ligar();
            _som.AjustarVolume();
            _player.Ligar();
            _player.CarregarFilme();
            _iluminacao.ApagarLuzes();
            _player.DarPlay();
            Console.WriteLine("Aproveite o filme!");
        }
    }


}
