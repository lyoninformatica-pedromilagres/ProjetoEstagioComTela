using Menu;       // para acessar MenuOperacoes
using Models;     // para acessar Clientes, Transacoes etc.
using Repositories;
using Services;   // para acessar ClienteService

namespace BancoTela
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
            mostraSenha.CheckedChanged += mostraSenha_CheckedChanged;

            this.Text = "Nosso Banco - Login";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idText = txtIDLogin.Text.Trim();
            string senhaText = txtSenhaLogin.Text.Trim();

            // Usa a classe ConexaoBanco para obter a string de conexão
            string conexao = ConexaoBanco.ObterStringConexao();
            var clientesRepor = new ClientesRepor(conexao);
            var clienteService = new ClienteService(clientesRepor);

            if (int.TryParse(idText, out int id))
            {
                var cliente = clienteService.ObterCliente(id);
                if (cliente != null && cliente.Senha == senhaText)
                {
                    Transacoes conta = new Transacoes(cliente, cliente.Saldo);
                    TelaMenu menu = new TelaMenu(conta, clienteService);
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ID ou senha inválidos.");
                }
            }
            else
            {
                MessageBox.Show("Digite um ID válido.");
            }
        }

        private void mostraSenha_CheckedChanged(object sender, EventArgs e)
        {
            txtSenhaLogin.UseSystemPasswordChar = !mostraSenha.Checked;
        }


        private void button3_Click(object sender, EventArgs e)
        {
        
            TelaRegistro registro = new TelaRegistro();

            registro.ShowDialog();
            
        }


    }
}
