namespace BancoTela
{
    partial class TelaMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            botaoSacar = new Button();
            botaoDepositar = new Button();
            botaoEmprestimo = new Button();
            botaoTransferencia = new Button();
            botaoExtrato = new Button();
            botaoConfiguracao = new Button();
            botaoSair = new Button();
            textoApresentacao = new Label();
            SuspendLayout();
            // 
            // botaoSacar
            // 
            botaoSacar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botaoSacar.Location = new Point(101, 90);
            botaoSacar.Name = "botaoSacar";
            botaoSacar.Size = new Size(118, 29);
            botaoSacar.TabIndex = 0;
            botaoSacar.Text = "Sacar";
            botaoSacar.UseVisualStyleBackColor = true;
            botaoSacar.Click += botaoSacar_Click;
            // 
            // botaoDepositar
            // 
            botaoDepositar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botaoDepositar.Location = new Point(101, 146);
            botaoDepositar.Name = "botaoDepositar";
            botaoDepositar.Size = new Size(118, 29);
            botaoDepositar.TabIndex = 1;
            botaoDepositar.Text = "Depositar";
            botaoDepositar.UseVisualStyleBackColor = true;
            botaoDepositar.Click += botaoDepositar_Click;
            // 
            // botaoEmprestimo
            // 
            botaoEmprestimo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botaoEmprestimo.Location = new Point(101, 203);
            botaoEmprestimo.Name = "botaoEmprestimo";
            botaoEmprestimo.Size = new Size(118, 29);
            botaoEmprestimo.TabIndex = 2;
            botaoEmprestimo.Text = "Empréstimo";
            botaoEmprestimo.UseVisualStyleBackColor = true;
            botaoEmprestimo.Click += botaoEmprestimo_Click;
            // 
            // botaoTransferencia
            // 
            botaoTransferencia.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botaoTransferencia.Location = new Point(101, 262);
            botaoTransferencia.Name = "botaoTransferencia";
            botaoTransferencia.Size = new Size(118, 29);
            botaoTransferencia.TabIndex = 3;
            botaoTransferencia.Text = "Transferências";
            botaoTransferencia.UseVisualStyleBackColor = true;
            botaoTransferencia.Click += botaoTransferencia_Click;
            // 
            // botaoExtrato
            // 
            botaoExtrato.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botaoExtrato.Location = new Point(101, 323);
            botaoExtrato.Name = "botaoExtrato";
            botaoExtrato.Size = new Size(118, 29);
            botaoExtrato.TabIndex = 4;
            botaoExtrato.Text = "Extrato";
            botaoExtrato.UseVisualStyleBackColor = true;
            botaoExtrato.Click += botaoExtrato_Click;
            // 
            // botaoConfiguracao
            // 
            botaoConfiguracao.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botaoConfiguracao.Location = new Point(101, 381);
            botaoConfiguracao.Name = "botaoConfiguracao";
            botaoConfiguracao.Size = new Size(118, 29);
            botaoConfiguracao.TabIndex = 5;
            botaoConfiguracao.Text = "Configuração";
            botaoConfiguracao.UseVisualStyleBackColor = true;
            botaoConfiguracao.Click += botaoConfiguracao_Click;
            // 
            // botaoSair
            // 
            botaoSair.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            botaoSair.Location = new Point(238, 448);
            botaoSair.Name = "botaoSair";
            botaoSair.Size = new Size(70, 27);
            botaoSair.TabIndex = 6;
            botaoSair.Text = "Sair";
            botaoSair.UseVisualStyleBackColor = true;
            botaoSair.Click += botaoSair_Click;
            // 
            // textoApresentacao
            // 
            textoApresentacao.AutoSize = true;
            textoApresentacao.Dock = DockStyle.Top;
            textoApresentacao.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            textoApresentacao.Location = new Point(0, 0);
            textoApresentacao.Name = "textoApresentacao";
            textoApresentacao.Size = new Size(63, 25);
            textoApresentacao.TabIndex = 7;
            textoApresentacao.Text = "label1";
            textoApresentacao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TelaMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(320, 487);
            Controls.Add(textoApresentacao);
            Controls.Add(botaoSair);
            Controls.Add(botaoConfiguracao);
            Controls.Add(botaoExtrato);
            Controls.Add(botaoTransferencia);
            Controls.Add(botaoEmprestimo);
            Controls.Add(botaoDepositar);
            Controls.Add(botaoSacar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaMenu";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button botaoSacar;
        private Button botaoDepositar;
        private Button botaoEmprestimo;
        private Button botaoTransferencia;
        private Button botaoExtrato;
        private Button botaoConfiguracao;
        private Button botaoSair;
        private Label textoApresentacao;
    }
}