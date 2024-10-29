namespace CenterSysVendas.forms
{
    partial class FRM_Usuarios
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
            BTN_Novo = new Button();
            BTN_Excluir = new Button();
            BTN_Sair = new Button();
            TBC_Usuarios = new TabControl();
            TBP_Lista = new TabPage();
            DGV_Usuarios = new DataGridView();
            EDT_FiltroLista = new TextBox();
            label5 = new Label();
            TBP_Cadastro = new TabPage();
            LBL_SenhaVazia = new Label();
            label4 = new Label();
            CBB_Ativo = new ComboBox();
            CBX_Ativo = new CheckBox();
            EDT_Senha = new TextBox();
            label3 = new Label();
            EDT_Login = new TextBox();
            label2 = new Label();
            EDT_NomeUsuario = new TextBox();
            label1 = new Label();
            BTN_Cancelar = new Button();
            BTN_Salvar = new Button();
            TBC_Usuarios.SuspendLayout();
            TBP_Lista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Usuarios).BeginInit();
            TBP_Cadastro.SuspendLayout();
            SuspendLayout();
            // 
            // BTN_Novo
            // 
            BTN_Novo.Location = new Point(12, 415);
            BTN_Novo.Name = "BTN_Novo";
            BTN_Novo.Size = new Size(75, 23);
            BTN_Novo.TabIndex = 0;
            BTN_Novo.Text = "Novo";
            BTN_Novo.UseVisualStyleBackColor = true;
            BTN_Novo.Click += BTN_Novo_Click;
            // 
            // BTN_Excluir
            // 
            BTN_Excluir.Enabled = false;
            BTN_Excluir.Location = new Point(257, 415);
            BTN_Excluir.Name = "BTN_Excluir";
            BTN_Excluir.Size = new Size(75, 23);
            BTN_Excluir.TabIndex = 2;
            BTN_Excluir.Text = "Excluir";
            BTN_Excluir.UseVisualStyleBackColor = true;
            BTN_Excluir.Click += BTN_Excluir_Click;
            // 
            // BTN_Sair
            // 
            BTN_Sair.Location = new Point(338, 415);
            BTN_Sair.Name = "BTN_Sair";
            BTN_Sair.Size = new Size(75, 23);
            BTN_Sair.TabIndex = 3;
            BTN_Sair.Text = "Sair";
            BTN_Sair.UseVisualStyleBackColor = true;
            BTN_Sair.Click += BTN_Sair_Click;
            // 
            // TBC_Usuarios
            // 
            TBC_Usuarios.Controls.Add(TBP_Lista);
            TBC_Usuarios.Controls.Add(TBP_Cadastro);
            TBC_Usuarios.Location = new Point(5, 3);
            TBC_Usuarios.Name = "TBC_Usuarios";
            TBC_Usuarios.SelectedIndex = 0;
            TBC_Usuarios.Size = new Size(797, 406);
            TBC_Usuarios.TabIndex = 13;
            // 
            // TBP_Lista
            // 
            TBP_Lista.Controls.Add(DGV_Usuarios);
            TBP_Lista.Controls.Add(EDT_FiltroLista);
            TBP_Lista.Controls.Add(label5);
            TBP_Lista.Location = new Point(4, 24);
            TBP_Lista.Name = "TBP_Lista";
            TBP_Lista.Padding = new Padding(3);
            TBP_Lista.Size = new Size(789, 378);
            TBP_Lista.TabIndex = 0;
            TBP_Lista.Text = "Lista de Usuários";
            TBP_Lista.UseVisualStyleBackColor = true;
            // 
            // DGV_Usuarios
            // 
            DGV_Usuarios.AllowUserToAddRows = false;
            DGV_Usuarios.AllowUserToDeleteRows = false;
            DGV_Usuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Usuarios.Location = new Point(16, 90);
            DGV_Usuarios.Name = "DGV_Usuarios";
            DGV_Usuarios.ReadOnly = true;
            DGV_Usuarios.Size = new Size(745, 244);
            DGV_Usuarios.TabIndex = 2;
            DGV_Usuarios.CellClick += DGV_Usuarios_CellClick;
            DGV_Usuarios.CellDoubleClick += DGV_Usuarios_CellDoubleClick;
            DGV_Usuarios.CellFormatting += DGV_Usuarios_CellFormatting;
            // 
            // EDT_FiltroLista
            // 
            EDT_FiltroLista.Location = new Point(16, 35);
            EDT_FiltroLista.Name = "EDT_FiltroLista";
            EDT_FiltroLista.Size = new Size(297, 23);
            EDT_FiltroLista.TabIndex = 1;
            EDT_FiltroLista.TextChanged += EDT_FiltroLista_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 17);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 0;
            label5.Text = "Filtrar por nome:";
            // 
            // TBP_Cadastro
            // 
            TBP_Cadastro.Controls.Add(LBL_SenhaVazia);
            TBP_Cadastro.Controls.Add(label4);
            TBP_Cadastro.Controls.Add(CBB_Ativo);
            TBP_Cadastro.Controls.Add(CBX_Ativo);
            TBP_Cadastro.Controls.Add(EDT_Senha);
            TBP_Cadastro.Controls.Add(label3);
            TBP_Cadastro.Controls.Add(EDT_Login);
            TBP_Cadastro.Controls.Add(label2);
            TBP_Cadastro.Controls.Add(EDT_NomeUsuario);
            TBP_Cadastro.Controls.Add(label1);
            TBP_Cadastro.Location = new Point(4, 24);
            TBP_Cadastro.Name = "TBP_Cadastro";
            TBP_Cadastro.Padding = new Padding(3);
            TBP_Cadastro.Size = new Size(789, 378);
            TBP_Cadastro.TabIndex = 1;
            TBP_Cadastro.Text = "Cadastro de Usuáios";
            TBP_Cadastro.UseVisualStyleBackColor = true;
            // 
            // LBL_SenhaVazia
            // 
            LBL_SenhaVazia.AutoSize = true;
            LBL_SenhaVazia.Location = new Point(312, 166);
            LBL_SenhaVazia.Name = "LBL_SenhaVazia";
            LBL_SenhaVazia.Size = new Size(229, 15);
            LBL_SenhaVazia.TabIndex = 31;
            LBL_SenhaVazia.Text = "Se a senha estiver Vazia, não será alterada. ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 256);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 30;
            label4.Text = "Perfil:";
            // 
            // CBB_Ativo
            // 
            CBB_Ativo.DropDownStyle = ComboBoxStyle.DropDownList;
            CBB_Ativo.Enabled = false;
            CBB_Ativo.FormattingEnabled = true;
            CBB_Ativo.Items.AddRange(new object[] { "Administrador", "Usuário" });
            CBB_Ativo.Location = new Point(17, 286);
            CBB_Ativo.Name = "CBB_Ativo";
            CBB_Ativo.Size = new Size(121, 23);
            CBB_Ativo.TabIndex = 4;
            // 
            // CBX_Ativo
            // 
            CBX_Ativo.AutoSize = true;
            CBX_Ativo.Checked = true;
            CBX_Ativo.CheckState = CheckState.Checked;
            CBX_Ativo.Enabled = false;
            CBX_Ativo.Location = new Point(17, 209);
            CBX_Ativo.Name = "CBX_Ativo";
            CBX_Ativo.Size = new Size(54, 19);
            CBX_Ativo.TabIndex = 3;
            CBX_Ativo.Text = "Ativo";
            CBX_Ativo.UseVisualStyleBackColor = true;
            // 
            // EDT_Senha
            // 
            EDT_Senha.Enabled = false;
            EDT_Senha.Location = new Point(15, 163);
            EDT_Senha.MaxLength = 10;
            EDT_Senha.Name = "EDT_Senha";
            EDT_Senha.PasswordChar = '*';
            EDT_Senha.Size = new Size(291, 23);
            EDT_Senha.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 143);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 26;
            label3.Text = "Senha:";
            // 
            // EDT_Login
            // 
            EDT_Login.Enabled = false;
            EDT_Login.Location = new Point(14, 103);
            EDT_Login.MaxLength = 10;
            EDT_Login.Name = "EDT_Login";
            EDT_Login.Size = new Size(291, 23);
            EDT_Login.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 83);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 24;
            label2.Text = "Login do Usuário:";
            // 
            // EDT_NomeUsuario
            // 
            EDT_NomeUsuario.Enabled = false;
            EDT_NomeUsuario.Location = new Point(15, 42);
            EDT_NomeUsuario.MaxLength = 250;
            EDT_NomeUsuario.Name = "EDT_NomeUsuario";
            EDT_NomeUsuario.Size = new Size(291, 23);
            EDT_NomeUsuario.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 22);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 22;
            label1.Text = "Nome do Usuário:";
            // 
            // BTN_Cancelar
            // 
            BTN_Cancelar.Enabled = false;
            BTN_Cancelar.Location = new Point(174, 415);
            BTN_Cancelar.Name = "BTN_Cancelar";
            BTN_Cancelar.Size = new Size(75, 23);
            BTN_Cancelar.TabIndex = 14;
            BTN_Cancelar.Text = "Cancelar";
            BTN_Cancelar.UseVisualStyleBackColor = true;
            BTN_Cancelar.Click += BTN_Cancelar_Click;
            // 
            // BTN_Salvar
            // 
            BTN_Salvar.Enabled = false;
            BTN_Salvar.Location = new Point(93, 415);
            BTN_Salvar.Name = "BTN_Salvar";
            BTN_Salvar.Size = new Size(75, 23);
            BTN_Salvar.TabIndex = 15;
            BTN_Salvar.Text = "Salvar";
            BTN_Salvar.UseVisualStyleBackColor = true;
            BTN_Salvar.Click += BTN_Salvar_Click;
            // 
            // FRM_Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(BTN_Salvar);
            Controls.Add(BTN_Cancelar);
            Controls.Add(TBC_Usuarios);
            Controls.Add(BTN_Sair);
            Controls.Add(BTN_Excluir);
            Controls.Add(BTN_Novo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FRM_Usuarios";
            Text = "Cadastro de Usuários";
            WindowState = FormWindowState.Maximized;
            Load += FRM_Usuarios_Load;
            TBC_Usuarios.ResumeLayout(false);
            TBP_Lista.ResumeLayout(false);
            TBP_Lista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Usuarios).EndInit();
            TBP_Cadastro.ResumeLayout(false);
            TBP_Cadastro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BTN_Novo;
        private Button BTN_Excluir;
        private Button BTN_Sair;
        private TabControl TBC_Usuarios;
        private TabPage TBP_Lista;
        private TabPage TBP_Cadastro;
        private Label label4;
        private ComboBox CBB_Ativo;
        private CheckBox CBX_Ativo;
        private TextBox EDT_Senha;
        private Label label3;
        private TextBox EDT_Login;
        private Label label2;
        private TextBox EDT_NomeUsuario;
        private Label label1;
        private TextBox EDT_FiltroLista;
        private Label label5;
        private DataGridView DGV_Usuarios;
        private Button BTN_Cancelar;
        private Button BTN_Salvar;
        private Label LBL_SenhaVazia;
    }
}