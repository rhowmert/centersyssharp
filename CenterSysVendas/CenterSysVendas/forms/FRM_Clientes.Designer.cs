namespace CenterSysVendas.forms
{
    partial class FRM_Clientes
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
            TBC_Clientes = new TabControl();
            TBP_ListaClientes = new TabPage();
            DGV_Clientes = new DataGridView();
            label10 = new Label();
            EDT_Pesquisa = new TextBox();
            TBP_CadastroClientes = new TabPage();
            BTN_Pesquisar = new Button();
            EDT_Bairro = new TextBox();
            label11 = new Label();
            EDT_CEP = new MaskedTextBox();
            EDT_DataNascimento = new MaskedTextBox();
            EDT_CPF = new MaskedTextBox();
            CBX_ClienteAtivo = new CheckBox();
            EDT_UF = new TextBox();
            label9 = new Label();
            EDT_Municipio = new TextBox();
            label8 = new Label();
            EDT_Complemento = new TextBox();
            label6 = new Label();
            EDT_Numero = new TextBox();
            label7 = new Label();
            EDT_Logradouro = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            EDT_Nome = new TextBox();
            label1 = new Label();
            TBP_PesqCidades = new TabPage();
            BTN_CancelaPesquisaCidade = new Button();
            label12 = new Label();
            DGV_Cidades = new DataGridView();
            EDT_PesqCidade = new TextBox();
            BTN_Salvar = new Button();
            BTN_Cancelar = new Button();
            BTN_Sair = new Button();
            BTN_Excluir = new Button();
            BTN_Novo = new Button();
            CBX_Inativos = new CheckBox();
            TBC_Clientes.SuspendLayout();
            TBP_ListaClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Clientes).BeginInit();
            TBP_CadastroClientes.SuspendLayout();
            TBP_PesqCidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Cidades).BeginInit();
            SuspendLayout();
            // 
            // TBC_Clientes
            // 
            TBC_Clientes.Controls.Add(TBP_ListaClientes);
            TBC_Clientes.Controls.Add(TBP_CadastroClientes);
            TBC_Clientes.Controls.Add(TBP_PesqCidades);
            TBC_Clientes.Location = new Point(12, 12);
            TBC_Clientes.Name = "TBC_Clientes";
            TBC_Clientes.SelectedIndex = 0;
            TBC_Clientes.Size = new Size(784, 397);
            TBC_Clientes.TabIndex = 4;
            // 
            // TBP_ListaClientes
            // 
            TBP_ListaClientes.Controls.Add(CBX_Inativos);
            TBP_ListaClientes.Controls.Add(DGV_Clientes);
            TBP_ListaClientes.Controls.Add(label10);
            TBP_ListaClientes.Controls.Add(EDT_Pesquisa);
            TBP_ListaClientes.Location = new Point(4, 24);
            TBP_ListaClientes.Name = "TBP_ListaClientes";
            TBP_ListaClientes.Padding = new Padding(3);
            TBP_ListaClientes.Size = new Size(776, 369);
            TBP_ListaClientes.TabIndex = 0;
            TBP_ListaClientes.Text = "Lista de Clientes";
            TBP_ListaClientes.UseVisualStyleBackColor = true;
            // 
            // DGV_Clientes
            // 
            DGV_Clientes.AllowUserToAddRows = false;
            DGV_Clientes.AllowUserToDeleteRows = false;
            DGV_Clientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Clientes.Location = new Point(14, 81);
            DGV_Clientes.Name = "DGV_Clientes";
            DGV_Clientes.ReadOnly = true;
            DGV_Clientes.Size = new Size(756, 261);
            DGV_Clientes.TabIndex = 2;
            DGV_Clientes.CellDoubleClick += DGV_Clientes_CellDoubleClick;
            DGV_Clientes.CellFormatting += DGV_Clientes_CellFormatting;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 15);
            label10.Name = "label10";
            label10.Size = new Size(108, 15);
            label10.TabIndex = 1;
            label10.Text = "Pequisa por Nome:";
            // 
            // EDT_Pesquisa
            // 
            EDT_Pesquisa.Location = new Point(14, 33);
            EDT_Pesquisa.Name = "EDT_Pesquisa";
            EDT_Pesquisa.Size = new Size(293, 23);
            EDT_Pesquisa.TabIndex = 0;
            EDT_Pesquisa.TextChanged += EDT_Pesquisa_TextChanged;
            // 
            // TBP_CadastroClientes
            // 
            TBP_CadastroClientes.Controls.Add(BTN_Pesquisar);
            TBP_CadastroClientes.Controls.Add(EDT_Bairro);
            TBP_CadastroClientes.Controls.Add(label11);
            TBP_CadastroClientes.Controls.Add(EDT_CEP);
            TBP_CadastroClientes.Controls.Add(EDT_DataNascimento);
            TBP_CadastroClientes.Controls.Add(EDT_CPF);
            TBP_CadastroClientes.Controls.Add(CBX_ClienteAtivo);
            TBP_CadastroClientes.Controls.Add(EDT_UF);
            TBP_CadastroClientes.Controls.Add(label9);
            TBP_CadastroClientes.Controls.Add(EDT_Municipio);
            TBP_CadastroClientes.Controls.Add(label8);
            TBP_CadastroClientes.Controls.Add(EDT_Complemento);
            TBP_CadastroClientes.Controls.Add(label6);
            TBP_CadastroClientes.Controls.Add(EDT_Numero);
            TBP_CadastroClientes.Controls.Add(label7);
            TBP_CadastroClientes.Controls.Add(EDT_Logradouro);
            TBP_CadastroClientes.Controls.Add(label5);
            TBP_CadastroClientes.Controls.Add(label4);
            TBP_CadastroClientes.Controls.Add(label3);
            TBP_CadastroClientes.Controls.Add(label2);
            TBP_CadastroClientes.Controls.Add(EDT_Nome);
            TBP_CadastroClientes.Controls.Add(label1);
            TBP_CadastroClientes.Location = new Point(4, 24);
            TBP_CadastroClientes.Name = "TBP_CadastroClientes";
            TBP_CadastroClientes.Padding = new Padding(3);
            TBP_CadastroClientes.Size = new Size(776, 369);
            TBP_CadastroClientes.TabIndex = 1;
            TBP_CadastroClientes.Text = "Cadastro de Clientes";
            TBP_CadastroClientes.UseVisualStyleBackColor = true;
            // 
            // BTN_Pesquisar
            // 
            BTN_Pesquisar.Location = new Point(403, 331);
            BTN_Pesquisar.Name = "BTN_Pesquisar";
            BTN_Pesquisar.Size = new Size(75, 23);
            BTN_Pesquisar.TabIndex = 31;
            BTN_Pesquisar.Text = "Pesquisar";
            BTN_Pesquisar.UseVisualStyleBackColor = true;
            BTN_Pesquisar.Click += BTN_Pesquisar_Click;
            // 
            // EDT_Bairro
            // 
            EDT_Bairro.Location = new Point(6, 283);
            EDT_Bairro.Name = "EDT_Bairro";
            EDT_Bairro.Size = new Size(314, 23);
            EDT_Bairro.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 265);
            label11.Name = "label11";
            label11.Size = new Size(41, 15);
            label11.TabIndex = 30;
            label11.Text = "Bairro:";
            // 
            // EDT_CEP
            // 
            EDT_CEP.Location = new Point(8, 128);
            EDT_CEP.Mask = "00000-000";
            EDT_CEP.Name = "EDT_CEP";
            EDT_CEP.Size = new Size(100, 23);
            EDT_CEP.TabIndex = 4;
            EDT_CEP.MaskInputRejected += EDT_CEP_MaskInputRejected;
            EDT_CEP.Leave += EDT_CEP_Leave;
            // 
            // EDT_DataNascimento
            // 
            EDT_DataNascimento.Location = new Point(184, 76);
            EDT_DataNascimento.Mask = "00/00/0000";
            EDT_DataNascimento.Name = "EDT_DataNascimento";
            EDT_DataNascimento.Size = new Size(136, 23);
            EDT_DataNascimento.TabIndex = 3;
            EDT_DataNascimento.ValidatingType = typeof(DateTime);
            EDT_DataNascimento.MaskInputRejected += EDT_DataNascimento_MaskInputRejected;
            // 
            // EDT_CPF
            // 
            EDT_CPF.Location = new Point(6, 76);
            EDT_CPF.Mask = "000,000,000-00";
            EDT_CPF.Name = "EDT_CPF";
            EDT_CPF.Size = new Size(159, 23);
            EDT_CPF.TabIndex = 2;
            EDT_CPF.Leave += EDT_CPF_Leave;
            // 
            // CBX_ClienteAtivo
            // 
            CBX_ClienteAtivo.AutoSize = true;
            CBX_ClienteAtivo.Checked = true;
            CBX_ClienteAtivo.CheckState = CheckState.Checked;
            CBX_ClienteAtivo.Location = new Point(363, 28);
            CBX_ClienteAtivo.Name = "CBX_ClienteAtivo";
            CBX_ClienteAtivo.Size = new Size(99, 19);
            CBX_ClienteAtivo.TabIndex = 1;
            CBX_ClienteAtivo.Text = "Cliente Ativo?";
            CBX_ClienteAtivo.UseVisualStyleBackColor = true;
            // 
            // EDT_UF
            // 
            EDT_UF.Location = new Point(336, 331);
            EDT_UF.Name = "EDT_UF";
            EDT_UF.ReadOnly = true;
            EDT_UF.Size = new Size(51, 23);
            EDT_UF.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(336, 313);
            label9.Name = "label9";
            label9.Size = new Size(24, 15);
            label9.TabIndex = 24;
            label9.Text = "UF:";
            // 
            // EDT_Municipio
            // 
            EDT_Municipio.Location = new Point(6, 331);
            EDT_Municipio.Name = "EDT_Municipio";
            EDT_Municipio.ReadOnly = true;
            EDT_Municipio.Size = new Size(314, 23);
            EDT_Municipio.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 313);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 22;
            label8.Text = "Município:";
            // 
            // EDT_Complemento
            // 
            EDT_Complemento.Location = new Point(184, 236);
            EDT_Complemento.Name = "EDT_Complemento";
            EDT_Complemento.Size = new Size(136, 23);
            EDT_Complemento.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(184, 218);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 20;
            label6.Text = "Complemento:";
            // 
            // EDT_Numero
            // 
            EDT_Numero.Location = new Point(6, 236);
            EDT_Numero.Name = "EDT_Numero";
            EDT_Numero.Size = new Size(136, 23);
            EDT_Numero.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 218);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 18;
            label7.Text = "Número:";
            // 
            // EDT_Logradouro
            // 
            EDT_Logradouro.Location = new Point(6, 182);
            EDT_Logradouro.Name = "EDT_Logradouro";
            EDT_Logradouro.Size = new Size(314, 23);
            EDT_Logradouro.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 164);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 16;
            label5.Text = "Logradouro:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 112);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 14;
            label4.Text = "CEP:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 58);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 12;
            label3.Text = "Data de Nascimento:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 58);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 10;
            label2.Text = "CPF:";
            // 
            // EDT_Nome
            // 
            EDT_Nome.Location = new Point(6, 26);
            EDT_Nome.Name = "EDT_Nome";
            EDT_Nome.Size = new Size(314, 23);
            EDT_Nome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 8);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 8;
            label1.Text = "Nome:";
            // 
            // TBP_PesqCidades
            // 
            TBP_PesqCidades.Controls.Add(BTN_CancelaPesquisaCidade);
            TBP_PesqCidades.Controls.Add(label12);
            TBP_PesqCidades.Controls.Add(DGV_Cidades);
            TBP_PesqCidades.Controls.Add(EDT_PesqCidade);
            TBP_PesqCidades.Location = new Point(4, 24);
            TBP_PesqCidades.Name = "TBP_PesqCidades";
            TBP_PesqCidades.Padding = new Padding(3);
            TBP_PesqCidades.Size = new Size(776, 369);
            TBP_PesqCidades.TabIndex = 2;
            TBP_PesqCidades.Text = "Cidades";
            TBP_PesqCidades.UseVisualStyleBackColor = true;
            // 
            // BTN_CancelaPesquisaCidade
            // 
            BTN_CancelaPesquisaCidade.Enabled = false;
            BTN_CancelaPesquisaCidade.Location = new Point(341, 331);
            BTN_CancelaPesquisaCidade.Name = "BTN_CancelaPesquisaCidade";
            BTN_CancelaPesquisaCidade.Size = new Size(75, 23);
            BTN_CancelaPesquisaCidade.TabIndex = 20;
            BTN_CancelaPesquisaCidade.Text = "Cancelar";
            BTN_CancelaPesquisaCidade.UseVisualStyleBackColor = true;
            BTN_CancelaPesquisaCidade.Click += BTN_CancelaPesquisaCidade_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 14);
            label12.Name = "label12";
            label12.Size = new Size(216, 15);
            label12.TabIndex = 5;
            label12.Text = "Pesquise por Nome ou Código do IBGE:";
            // 
            // DGV_Cidades
            // 
            DGV_Cidades.AllowUserToAddRows = false;
            DGV_Cidades.AllowUserToDeleteRows = false;
            DGV_Cidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Cidades.Location = new Point(12, 61);
            DGV_Cidades.Name = "DGV_Cidades";
            DGV_Cidades.ReadOnly = true;
            DGV_Cidades.Size = new Size(752, 256);
            DGV_Cidades.TabIndex = 4;
            DGV_Cidades.CellDoubleClick += DGV_Cidades_CellDoubleClick;
            // 
            // EDT_PesqCidade
            // 
            EDT_PesqCidade.Location = new Point(12, 32);
            EDT_PesqCidade.Name = "EDT_PesqCidade";
            EDT_PesqCidade.Size = new Size(397, 23);
            EDT_PesqCidade.TabIndex = 3;
            EDT_PesqCidade.TextChanged += EDT_PesqCidade_TextChanged;
            // 
            // BTN_Salvar
            // 
            BTN_Salvar.Enabled = false;
            BTN_Salvar.Location = new Point(97, 415);
            BTN_Salvar.Name = "BTN_Salvar";
            BTN_Salvar.Size = new Size(75, 23);
            BTN_Salvar.TabIndex = 20;
            BTN_Salvar.Text = "Salvar";
            BTN_Salvar.UseVisualStyleBackColor = true;
            BTN_Salvar.Click += BTN_Salvar_Click;
            // 
            // BTN_Cancelar
            // 
            BTN_Cancelar.Enabled = false;
            BTN_Cancelar.Location = new Point(178, 415);
            BTN_Cancelar.Name = "BTN_Cancelar";
            BTN_Cancelar.Size = new Size(75, 23);
            BTN_Cancelar.TabIndex = 19;
            BTN_Cancelar.Text = "Cancelar";
            BTN_Cancelar.UseVisualStyleBackColor = true;
            BTN_Cancelar.Click += BTN_Cancelar_Click;
            // 
            // BTN_Sair
            // 
            BTN_Sair.Location = new Point(342, 415);
            BTN_Sair.Name = "BTN_Sair";
            BTN_Sair.Size = new Size(75, 23);
            BTN_Sair.TabIndex = 18;
            BTN_Sair.Text = "Sair";
            BTN_Sair.UseVisualStyleBackColor = true;
            BTN_Sair.Click += BTN_Sair_Click;
            // 
            // BTN_Excluir
            // 
            BTN_Excluir.Enabled = false;
            BTN_Excluir.Location = new Point(261, 415);
            BTN_Excluir.Name = "BTN_Excluir";
            BTN_Excluir.Size = new Size(75, 23);
            BTN_Excluir.TabIndex = 17;
            BTN_Excluir.Text = "Excluir";
            BTN_Excluir.UseVisualStyleBackColor = true;
            BTN_Excluir.Click += BTN_Excluir_Click;
            // 
            // BTN_Novo
            // 
            BTN_Novo.Location = new Point(16, 415);
            BTN_Novo.Name = "BTN_Novo";
            BTN_Novo.Size = new Size(75, 23);
            BTN_Novo.TabIndex = 16;
            BTN_Novo.Text = "Novo";
            BTN_Novo.UseVisualStyleBackColor = true;
            BTN_Novo.Click += BTN_Novo_Click;
            // 
            // CBX_Inativos
            // 
            CBX_Inativos.AutoSize = true;
            CBX_Inativos.Checked = true;
            CBX_Inativos.CheckState = CheckState.Checked;
            CBX_Inativos.Location = new Point(339, 37);
            CBX_Inativos.Name = "CBX_Inativos";
            CBX_Inativos.Size = new Size(108, 19);
            CBX_Inativos.TabIndex = 3;
            CBX_Inativos.Text = "Incluir Inativos?";
            CBX_Inativos.UseVisualStyleBackColor = true;
            CBX_Inativos.CheckedChanged += CBX_Inativos_CheckedChanged;
            // 
            // FRM_Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(BTN_Salvar);
            Controls.Add(BTN_Cancelar);
            Controls.Add(BTN_Sair);
            Controls.Add(BTN_Excluir);
            Controls.Add(BTN_Novo);
            Controls.Add(TBC_Clientes);
            Name = "FRM_Clientes";
            Text = "Cadastro de Clientes";
            WindowState = FormWindowState.Maximized;
            Load += FRM_Clientes_Load;
            TBC_Clientes.ResumeLayout(false);
            TBP_ListaClientes.ResumeLayout(false);
            TBP_ListaClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Clientes).EndInit();
            TBP_CadastroClientes.ResumeLayout(false);
            TBP_CadastroClientes.PerformLayout();
            TBP_PesqCidades.ResumeLayout(false);
            TBP_PesqCidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Cidades).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TBC_Clientes;
        private TabPage TBP_ListaClientes;
        private TabPage TBP_CadastroClientes;        
        private Label label2;
        private TextBox EDT_Nome;
        private Label label1;
        private Button BTN_Salvar;
        private Button BTN_Cancelar;
        private Button BTN_Sair;
        private Button BTN_Excluir;
        private Button BTN_Novo;
        private Label label3;
        private Label label4;
        private TextBox EDT_Logradouro;
        private Label label5;
        private TextBox EDT_Complemento;
        private Label label6;
        private TextBox EDT_Numero;
        private Label label7;
        private TextBox EDT_Municipio;
        private Label label8;
        private TextBox EDT_UF;
        private Label label9;
        private CheckBox CBX_ClienteAtivo;
        private Label label10;
        private TextBox EDT_Pesquisa;
        private DataGridView DGV_Clientes;
        private MaskedTextBox EDT_CPF;
        private MaskedTextBox EDT_DataNascimento;
        private MaskedTextBox EDT_CEP;
        private TextBox EDT_Bairro;
        private Label label11;
        private Button BTN_Pesquisar;
        private TabPage TBP_PesqCidades;
        private DataGridView DGV_Cidades;
        private TextBox EDT_PesqCidade;
        private Label label12;
        private Button BTN_CancelaPesquisaCidade;
        private CheckBox CBX_Inativos;
    }
}