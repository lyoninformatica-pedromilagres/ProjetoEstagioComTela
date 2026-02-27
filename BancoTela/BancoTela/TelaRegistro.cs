using Models;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Models;
using Repositories;
using Services;

namespace BancoTela
{
    public partial class TelaRegistro : Form
    {
        private readonly ClienteService _clienteService;

        public TelaRegistro()
        {
            InitializeComponent();

            this.Text = "Registro";


            // cria o service com a conexão do banco
            string conexao = ConexaoBanco.ObterStringConexao();
            var clientesRepor = new ClientesRepor(conexao);
            _clienteService = new ClienteService(clientesRepor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // pega os valores dos TextBox
            string idText = textBox2.Text.Trim();
            string nome = textBox1.Text.Trim();
            string cpf = textBox3.Text.Trim();
            string senha = textBox4.Text.Trim();

            // validar CPF
            if (!Models.Clientes.ValidarFormatoCpf(cpf))
            {
                MessageBox.Show("CPF inválido! Por favor, digite os 11 números do CPF.",
                                "Erro de Cadastro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBox3.Focus(); // Coloca o cursor no campo de CPF para o usuário corrigir
                return; 
            }


            // validacao ID
            if (int.TryParse(idText, out int id))
            {
                var clienteExistente = _clienteService.ObterCliente(id);
                if (clienteExistente != null)
                {
                    MessageBox.Show("ID já existe. Por favor, escolha outro ID.");
                    return;
                }

                // gera saldo aleatório
                var saldo = new Random().Next(100, 5001);

                var titular = new Clientes(id, nome, cpf, saldo, senha);
                _clienteService.RegistrarCliente(titular);

                Transacoes conta = new Transacoes(titular, saldo);

                MessageBox.Show($"Cliente {nome}, você foi registrado. Seu saldo atual é de R$ {saldo:F2}");

                // opcional: fechar tela de registro e voltar para login
                this.Close();
            }
            else
            {
                MessageBox.Show("Digite um ID válido.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}
