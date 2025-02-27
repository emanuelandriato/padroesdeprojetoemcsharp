using WinFormsApp1.models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
