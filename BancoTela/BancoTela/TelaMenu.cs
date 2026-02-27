using Models;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BancoTela
{
    public partial class TelaMenu : Form
    {
        private Transacoes _conta; // Onde guardamos os dados do cliente logado
        private ClienteService _clienteService;
        private TransacaoService _transacaoService;


        public TelaMenu(Transacoes conta, ClienteService clienteService)
        {
            InitializeComponent();
            this.Text = "Nosso Banco - Menu Principal";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            string conexao = ConexaoBanco.ObterStringConexao();
            var repo = new ClientesRepor(conexao);
            _transacaoService = new TransacaoService(repo);

            int centroDaTela = this.ClientSize.Width / 2;
            botaoSacar.Left = centroDaTela - (botaoSacar.Width / 2);
            botaoDepositar.Left = centroDaTela - (botaoDepositar.Width / 2);
            botaoEmprestimo.Left = centroDaTela - (botaoEmprestimo.Width / 2);
            botaoTransferencia.Left = centroDaTela - (botaoTransferencia.Width / 2);
            botaoExtrato.Left = centroDaTela - (botaoExtrato.Width / 2);
            botaoConfiguracao.Left = centroDaTela - (botaoConfiguracao.Width / 2);

            AtualizarTextoSaldo();
                


            _conta = conta;
            _clienteService = clienteService;


            // O label1 tem que estar no Designer para isso funcionar
            if (textoApresentacao != null)
                textoApresentacao.Text = $"Olá, {conta.Clientes.Nome}\nSeu saldo atual é {conta.Clientes.Saldo:C}";
        }

         public void AtualizarTextoSaldo()
        {
            if (textoApresentacao != null && _conta != null)
            {
                var saldoClienteAtualizado = _clienteService.ObterCliente(_conta.Clientes.Id);

                if (saldoClienteAtualizado != null)
                {
                    _conta.Clientes.Saldo = saldoClienteAtualizado.Saldo;

                    textoApresentacao.Text = $"Olá, {_conta.Clientes.Nome}\nSeu saldo atual é de: {_conta.Clientes.Saldo:C}";
                }
            }
        }

        
        private void botaoSair_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Fecha o sistema todo
        }

        private void botaoSacar_Click(object sender, EventArgs e)
        {

            string valorDigitadoSaque = Microsoft.VisualBasic.Interaction.InputBox("Valor:", "Saque");

            if (double.TryParse(valorDigitadoSaque, out double valor))
            {
                if (_transacaoService.Sacar(_conta, valor))
                {   
                    AtualizarTextoSaldo();
                    MessageBox.Show($"Saque realizado com sucesso no valor de {valor:C}");

                    
                }
                else
                {
                    MessageBox.Show("Saldo insuficiente ou valor inválido.");
                }
               
            }


        }

        private void botaoDepositar_Click (object sender, EventArgs e)
        {
            string valordeDeposito = Microsoft.VisualBasic.Interaction.InputBox("Digite o valor que deseja DEPOSITAR: ", "Deposito");

            if (double.TryParse(valordeDeposito, out double valor))
            {
                if(_transacaoService.Depositar(_conta, valor))
                {
                    AtualizarTextoSaldo();
                    MessageBox.Show($"Deposito realizado com sucesso no valor de {valor:C}");

                    
                }
                else
                {
                    MessageBox.Show($"Saldo insuficiente ou valor inválido.");
                }


            }

        }

        private void botaoEmprestimo_Click(object sender, EventArgs e)
        {
            string mensagem = "Você só pode solicitar empréstimo de R$ 10.000,00 se tiver saldo maior que R$ 5.000,00.\n\nDeseja solicitar agora?";
            DialogResult respostaEmprestimo = MessageBox.Show(mensagem, "Solicitação de Empréstimo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respostaEmprestimo == DialogResult.Yes)
            {
                if (_transacaoService.SolicitarEmprestimo(_conta))
                {
                    
                    MessageBox.Show($"Empréstimo concedido com sucesso!\nNovo saldo: {_conta.Clientes.Saldo:C}");
                    AtualizarTextoSaldo();
                }
                else
                {
                    MessageBox.Show("Saldo insuficiente para solicitar o empréstimo.", "Pedido Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void botaoTransferencia_Click(object sender, EventArgs e)
        {
            // 1. Pedir o ID ou CPF
            string identificador = Microsoft.VisualBasic.Interaction.InputBox(
                "Digite o CPF ou ID do destinatário:", "Transferência");

            if (string.IsNullOrWhiteSpace(identificador)) return;

            // Buscar o cliente
            var clienteDestino = int.TryParse(identificador, out int idDestino)
                ? _clienteService.ObterCliente(idDestino)
                : _clienteService.ObterClientePorCpf(identificador);

            if (clienteDestino == null)
            {
                MessageBox.Show("Conta não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Impedir transferência para si mesmo
            if (clienteDestino.Id == _conta.Clientes.Id || clienteDestino.Cpf == _conta.Clientes.Cpf)
            {
                MessageBox.Show("Você não pode transferir para sua própria conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Confirmar destinatário e pedir valor
            var contaDestino = new Transacoes(clienteDestino, clienteDestino.Saldo);
            string valorInput = Microsoft.VisualBasic.Interaction.InputBox(
                $"Transferindo para: {clienteDestino.Nome}\nCPF: {clienteDestino.Cpf}\n\nDigite o valor:",
                "Valor da Transferência");

            // 5. Validar valor e executar
            if (double.TryParse(valorInput, out double valorTransferencia))
            {
                if (_transacaoService.Transferir(_conta, contaDestino, valorTransferencia))
                {   
                    AtualizarTextoSaldo();
                    MessageBox.Show($"Transferência de {valorTransferencia:C} realizada com sucesso!", "Sucesso");

                                       
                }
                else
                {
                    MessageBox.Show("Não foi possível realizar a transferência. Verifique seu saldo.", "Erro");
                }
            }
            else if (!string.IsNullOrEmpty(valorInput))
            {
                MessageBox.Show("Valor inválido.", "Erro");
            }
        }

        private void botaoExtrato_Click(object sender, EventArgs e)
        {
            
            // Abre a janelinha nova passando o ID
            TelaExtrato tela = new TelaExtrato(_conta.Clientes.Id);
            tela.ShowDialog(); // ShowDialog faz o usuário ter que fechar o extrato para voltar ao menu
        }

        private void botaoConfiguracao_Click(object sender, EventArgs e)
        {

            TelaConfiguracao tela = new TelaConfiguracao(_conta.Clientes, _clienteService);

            tela.ShowDialog();

        }

    }
    }


