namespace CenterSysVendas.forms
{
    partial class FRM_Login
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
            label1 = new Label();
            label2 = new Label();
            EDT_Login = new TextBox();
            EDT_Senha = new TextBox();
            BTN_Login = new Button();
            pictureBox1 = new PictureBox();
            BTN_Sair = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(229, 200);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Login:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 260);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Senha:";
            // 
            // EDT_Login
            // 
            EDT_Login.Location = new Point(229, 218);
            EDT_Login.Name = "EDT_Login";
            EDT_Login.Size = new Size(246, 23);
            EDT_Login.TabIndex = 2;
            // 
            // EDT_Senha
            // 
            EDT_Senha.Location = new Point(229, 278);
            EDT_Senha.Name = "EDT_Senha";
            EDT_Senha.PasswordChar = '*';
            EDT_Senha.Size = new Size(246, 23);
            EDT_Senha.TabIndex = 3;
            // 
            // BTN_Login
            // 
            BTN_Login.Location = new Point(316, 325);
            BTN_Login.Name = "BTN_Login";
            BTN_Login.Size = new Size(75, 23);
            BTN_Login.TabIndex = 4;
            BTN_Login.Text = "&Login";
            BTN_Login.UseVisualStyleBackColor = true;
            BTN_Login.Click += BTN_Login_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_centersys;
            pictureBox1.Location = new Point(49, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(599, 143);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // BTN_Sair
            // 
            BTN_Sair.Location = new Point(316, 354);
            BTN_Sair.Name = "BTN_Sair";
            BTN_Sair.Size = new Size(75, 23);
            BTN_Sair.TabIndex = 6;
            BTN_Sair.Text = "&Sair";
            BTN_Sair.UseVisualStyleBackColor = true;
            BTN_Sair.Click += BTN_Sair_Click;
            // 
            // FRM_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 450);
            ControlBox = false;
            Controls.Add(BTN_Sair);
            Controls.Add(pictureBox1);
            Controls.Add(BTN_Login);
            Controls.Add(EDT_Senha);
            Controls.Add(EDT_Login);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FRM_Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += FRM_Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox EDT_Login;
        private TextBox EDT_Senha;
        private Button BTN_Login;
        private PictureBox pictureBox1;
        private Button BTN_Sair;
    }
}