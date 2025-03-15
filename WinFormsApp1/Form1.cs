using WinFormsApp1.models;
using WinFormsApp1.padroes;

namespace WinFormsApp1
{
    public partial class Form1 : Form, IObserver
    {
        private readonly ITemperatura _temperatura;
        public Form1(ITemperatura temperatura)
        {            
            _temperatura = temperatura;
            _temperatura.AdicionarObservador(this);                
            InitializeComponent();
        }

        public void Atualizar(float temperatura)
        {
            textBox1.Text = temperatura.ToString();
            label1.Text = @$"A temperatura atual é de {temperatura}º C";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TestandoExcecoes.VaiDarRuim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestandoExcecoes.SalvarDados(null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _temperatura.AtualizarTemperatura(float.Parse(textBox1.Text));
        }
    }
}
