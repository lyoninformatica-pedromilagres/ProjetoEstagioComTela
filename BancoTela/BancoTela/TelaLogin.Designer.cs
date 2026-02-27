namespace BancoTela
{
    partial class TelaLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtIDLogin = new TextBox();
            txtSenhaLogin = new TextBox();
            button2 = new Button();
            button3 = new Button();
            label3 = new Label();
            mostraSenha = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(60, 84);
            label1.Name = "label1";
            label1.Size = new Size(107, 21);
            label1.TabIndex = 0;
            label1.Text = "Insira seu ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Info;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(32, 140);
            label2.Name = "label2";
            label2.Size = new Size(135, 21);
            label2.TabIndex = 1;
            label2.Text = "Insira sua senha:";
            // 
            // txtIDLogin
            // 
            txtIDLogin.Location = new Point(171, 84);
            txtIDLogin.Name = "txtIDLogin";
            txtIDLogin.Size = new Size(100, 23);
            txtIDLogin.TabIndex = 2;
            // 
            // txtSenhaLogin
            // 
            txtSenhaLogin.Location = new Point(171, 142);
            txtSenhaLogin.Name = "txtSenhaLogin";
            txtSenhaLogin.Size = new Size(100, 23);
            txtSenhaLogin.TabIndex = 3;
            txtSenhaLogin.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            button2.Location = new Point(190, 224);
            button2.Name = "button2";
            button2.Size = new Size(97, 23);
            button2.TabIndex = 5;
            button2.Text = "Confirmar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(42, 224);
            button3.Name = "button3";
            button3.Size = new Size(97, 23);
            button3.TabIndex = 6;
            button3.Text = "Registar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Rockwell Extra Bold", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(87, 27);
            label3.Name = "label3";
            label3.Size = new Size(158, 24);
            label3.TabIndex = 7;
            label3.Text = "NossoBanco";
            label3.Click += label3_Click;
            // 
            // mostraSenha
            // 
            mostraSenha.AllowDrop = true;
            mostraSenha.AutoSize = true;
            mostraSenha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            mostraSenha.Location = new Point(171, 171);
            mostraSenha.Name = "mostraSenha";
            mostraSenha.Size = new Size(107, 19);
            mostraSenha.TabIndex = 8;
            mostraSenha.TabStop = false;
            mostraSenha.Text = "Mostrar Senha";
            mostraSenha.UseVisualStyleBackColor = true;
            // 
            // TelaLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(322, 271);
            Controls.Add(mostraSenha);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtSenhaLogin);
            Controls.Add(txtIDLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaLogin";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtIDLogin;
        private TextBox txtSenhaLogin;
        private Button button2;
        private Button button3;
        private Label label3;
        private CheckBox mostraSenha;
    }
}
