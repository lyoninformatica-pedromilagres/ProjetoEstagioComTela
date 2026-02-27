namespace BancoTela
{
    partial class TelaConfiguracao
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
            alterarSenha = new Button();
            voltarMenu = new Button();
            txtSenhaAtual = new TextBox();
            txtNovaSenha = new TextBox();
            txtConfirmaSenha = new TextBox();
            senhaAtual = new Label();
            label1 = new Label();
            label2 = new Label();
            botaoConfirmar = new Button();
            botaoVoltar = new Button();
            painelTrocaSenha = new Panel();
            painelTrocaSenha.SuspendLayout();
            SuspendLayout();
            // 
            // alterarSenha
            // 
            alterarSenha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            alterarSenha.Location = new Point(64, 71);
            alterarSenha.Name = "alterarSenha";
            alterarSenha.Size = new Size(132, 26);
            alterarSenha.TabIndex = 0;
            alterarSenha.Text = "Alterar minha Senha";
            alterarSenha.UseVisualStyleBackColor = true;
            alterarSenha.Click += alterarSenha_Click;
            // 
            // voltarMenu
            // 
            voltarMenu.Location = new Point(89, 211);
            voltarMenu.Name = "voltarMenu";
            voltarMenu.Size = new Size(93, 23);
            voltarMenu.TabIndex = 1;
            voltarMenu.Text = "Voltar";
            voltarMenu.UseVisualStyleBackColor = true;
            voltarMenu.Click += voltarMenu_Click;
            // 
            // txtSenhaAtual
            // 
            txtSenhaAtual.Location = new Point(106, 30);
            txtSenhaAtual.Name = "txtSenhaAtual";
            txtSenhaAtual.Size = new Size(100, 23);
            txtSenhaAtual.TabIndex = 0;
            // 
            // txtNovaSenha
            // 
            txtNovaSenha.Location = new Point(106, 91);
            txtNovaSenha.Name = "txtNovaSenha";
            txtNovaSenha.Size = new Size(100, 23);
            txtNovaSenha.TabIndex = 1;
            // 
            // txtConfirmaSenha
            // 
            txtConfirmaSenha.Location = new Point(106, 153);
            txtConfirmaSenha.Name = "txtConfirmaSenha";
            txtConfirmaSenha.Size = new Size(100, 23);
            txtConfirmaSenha.TabIndex = 2;
            // 
            // senhaAtual
            // 
            senhaAtual.AutoSize = true;
            senhaAtual.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            senhaAtual.Location = new Point(24, 37);
            senhaAtual.Name = "senhaAtual";
            senhaAtual.Size = new Size(77, 16);
            senhaAtual.TabIndex = 3;
            senhaAtual.Text = "Senha Atual";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 98);
            label1.Name = "label1";
            label1.Size = new Size(76, 16);
            label1.TabIndex = 4;
            label1.Text = "Nova Senha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(-3, 160);
            label2.Name = "label2";
            label2.Size = new Size(103, 16);
            label2.TabIndex = 5;
            label2.Text = "Confirmar Senha";
            // 
            // botaoConfirmar
            // 
            botaoConfirmar.Location = new Point(160, 209);
            botaoConfirmar.Name = "botaoConfirmar";
            botaoConfirmar.Size = new Size(93, 23);
            botaoConfirmar.TabIndex = 4;
            botaoConfirmar.Text = "Confirmar";
            botaoConfirmar.UseVisualStyleBackColor = true;
            botaoConfirmar.Click += botaoConfirmar_Click;
            // 
            // botaoVoltar
            // 
            botaoVoltar.Location = new Point(13, 209);
            botaoVoltar.Name = "botaoVoltar";
            botaoVoltar.Size = new Size(93, 23);
            botaoVoltar.TabIndex = 3;
            botaoVoltar.Text = "Voltar";
            botaoVoltar.UseVisualStyleBackColor = true;
            botaoVoltar.Click += botaoVoltar_Click;
            // 
            // painelTrocaSenha
            // 
            painelTrocaSenha.Controls.Add(botaoVoltar);
            painelTrocaSenha.Controls.Add(botaoConfirmar);
            painelTrocaSenha.Controls.Add(label2);
            painelTrocaSenha.Controls.Add(label1);
            painelTrocaSenha.Controls.Add(senhaAtual);
            painelTrocaSenha.Controls.Add(txtConfirmaSenha);
            painelTrocaSenha.Controls.Add(txtNovaSenha);
            painelTrocaSenha.Controls.Add(txtSenhaAtual);
            painelTrocaSenha.Location = new Point(-1, -1);
            painelTrocaSenha.Name = "painelTrocaSenha";
            painelTrocaSenha.Size = new Size(269, 235);
            painelTrocaSenha.TabIndex = 2;
            painelTrocaSenha.Visible = false;
            
            // 
            // TelaConfiguracao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(264, 237);
            Controls.Add(painelTrocaSenha);
            Controls.Add(voltarMenu);
            Controls.Add(alterarSenha);
            MaximizeBox = false;
            Name = "TelaConfiguracao";
            Text = "TelaConfiguracao";
            painelTrocaSenha.ResumeLayout(false);
            painelTrocaSenha.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button alterarSenha;
        private Button voltarMenu;
        private TextBox txtSenhaAtual;
        private TextBox txtNovaSenha;
        private TextBox txtConfirmaSenha;
        private Label senhaAtual;
        private Label label1;
        private Label label2;
        private Button botaoConfirmar;
        private Button botaoVoltar;
        private Panel painelTrocaSenha;
    }
}