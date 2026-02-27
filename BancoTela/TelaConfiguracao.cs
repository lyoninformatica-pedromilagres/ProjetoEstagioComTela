using System;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows.Forms;
using Models;
using Services;

namespace BancoTela
{
    public partial class TelaConfiguracao : Form
    {
        private readonly Clientes _cliente;
        private readonly ClienteService _clienteService;

        public TelaConfiguracao(Clientes cliente, ClienteService service)
        {
            InitializeComponent();
            _cliente = cliente;
            _clienteService = service;

            // Configurações iniciais de segurança
            ConfigurarCamposSenha();

            // Se quiser que o painel comece escondido, mude para false 
            // e chame num botão. Se quiser que apareça direto, deixe true.


            this.Text = "Segurança - Alteração de Senha";
        }

        private void ConfigurarCamposSenha()
        {
            // Garante que ninguém veja a senha digitada
            txtSenhaAtual.UseSystemPasswordChar = true;
            txtNovaSenha.UseSystemPasswordChar = true;
            txtConfirmaSenha.UseSystemPasswordChar = true;
        }




        private void alterarSenha_Click(object sender, EventArgs e)
        {

            painelTrocaSenha.Visible = true;
            painelTrocaSenha.BringToFront();
            painelTrocaSenha.Left = (this.ClientSize.Width - painelTrocaSenha.Width) / 2; 
            painelTrocaSenha.Top = (this.ClientSize.Height - painelTrocaSenha.Height) / 2; 
            txtSenhaAtual.Focus();


        }

        private void voltarMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void botaoConfirmar_Click(object sender, EventArgs e)
        {
            string senhaAtual = txtSenhaAtual.Text;
            string novaSenha = txtNovaSenha.Text;
            string confirmaSenha = txtConfirmaSenha.Text;
            

            if (senhaAtual != _cliente.Senha)
            {
                MessageBox.Show("A senha atual informada está incorreta!", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaAtual.Clear();
                txtSenhaAtual.Focus();
                return;
            }

            // 2. Validação
            if (novaSenha != confirmaSenha)
            {
                MessageBox.Show("As novas senhas não coincidem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validação de Segurança
            if (string.IsNullOrWhiteSpace(novaSenha) || novaSenha.Length < 4)
            {
                MessageBox.Show("A nova senha deve ter pelo menos 4 caracteres!", "Aviso");
                return;
            }

            // 4. AT Banco de Dados
            try
            {
                _cliente.Senha = novaSenha; // Atualiza o objeto em memória
                _clienteService.AtualizarSenha(_cliente); // Chama o seu repositório/service

                MessageBox.Show("Sua senha foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha a tela de config e volta ao menu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro técnico ao atualizar banco: {ex.Message}", "Erro Crítico");
            }
            this.Close();
        }

            public void botaoVoltar_Click(object sender, EventArgs e)
            {
            this.Close();    

            }
            
    }
}