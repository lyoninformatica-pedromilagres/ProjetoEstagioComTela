namespace BancoTela
{
    partial class TelaExtrato
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
            listBoxExtrato = new ListBox();
            SuspendLayout();
            // 
            // listBoxExtrato
            // 
            listBoxExtrato.BackColor = SystemColors.Info;
            listBoxExtrato.Dock = DockStyle.Fill;
            listBoxExtrato.FormattingEnabled = true;
            listBoxExtrato.HorizontalScrollbar = true;
            listBoxExtrato.IntegralHeight = false;
            listBoxExtrato.Location = new Point(0, 0);
            listBoxExtrato.Name = "listBoxExtrato";
            listBoxExtrato.Size = new Size(491, 462);
            listBoxExtrato.TabIndex = 0;
            // 
            // TelaExtrato
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackColor = SystemColors.Info;
            ClientSize = new Size(491, 462);
            Controls.Add(listBoxExtrato);
            MaximizeBox = false;
            Name = "TelaExtrato";
            Text = "TelaExtrato";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxExtrato;
    }
}