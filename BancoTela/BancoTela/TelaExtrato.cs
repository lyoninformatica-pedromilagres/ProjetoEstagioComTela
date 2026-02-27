using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BancoTela
{
    public partial class TelaExtrato : Form
    {
        public TelaExtrato(int clienteId)
        {
            InitializeComponent();
            this.Text = "Nosso Banco - Menu Principal";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            CarregarExtrato(clienteId);
        }

        private void CarregarExtrato(int id)
        {
            // Aqui você usa o código que já criamos
            var extrato = Repositories.TransacoesRepor.ObterExtratoPorCliente(id);
            listBoxExtrato.Items.Clear();
            foreach (var linha in extrato)
            {
                listBoxExtrato.Items.Add(linha.Replace("\n", "").Trim());
            }
        }
    }
}
