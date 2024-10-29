namespace CenterSysVendas.forms
{
    partial class FRM_Cidades
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
            BTN_Salvar = new Button();
            BTN_Cancelar = new Button();
            BTN_Sair = new Button();
            BTN_Excluir = new Button();
            BTN_Novo = new Button();
            TBC_Cidades = new TabControl();
            TBP_ListaCidades = new TabPage();
            label1 = new Label();
            DGV_Cidades = new DataGridView();
            EDT_Pesquisa = new TextBox();
            TBP_CadastroCidades = new TabPage();
            linkLabel1 = new LinkLabel();
            EDT_UF = new TextBox();
            label4 = new Label();
            EDT_NomeCidade = new TextBox();
            label3 = new Label();
            EDT_CodigoIBGE = new TextBox();
            label2 = new Label();
            TBC_Cidades.SuspendLayout();
            TBP_ListaCidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Cidades).BeginInit();
            TBP_CadastroCidades.SuspendLayout();
            SuspendLayout();
            // 
            // BTN_Salvar
            // 
            BTN_Salvar.Enabled = false;
            BTN_Salvar.Location = new Point(93, 415);
            BTN_Salvar.Name = "BTN_Salvar";
            BTN_Salvar.Size = new Size(75, 23);
            BTN_Salvar.TabIndex = 20;
            BTN_Salvar.Text = "Salvar";
            BTN_Salvar.UseVisualStyleBackColor = true;
            BTN_Salvar.Click += BTN_Salvar_Click_1;
            // 
            // BTN_Cancelar
            // 
            BTN_Cancelar.Enabled = false;
            BTN_Cancelar.Location = new Point(174, 415);
            BTN_Cancelar.Name = "BTN_Cancelar";
            BTN_Cancelar.Size = new Size(75, 23);
            BTN_Cancelar.TabIndex = 19;
            BTN_Cancelar.Text = "Cancelar";
            BTN_Cancelar.UseVisualStyleBackColor = true;
            BTN_Cancelar.Click += BTN_Cancelar_Click;
            // 
            // BTN_Sair
            // 
            BTN_Sair.Location = new Point(338, 415);
            BTN_Sair.Name = "BTN_Sair";
            BTN_Sair.Size = new Size(75, 23);
            BTN_Sair.TabIndex = 18;
            BTN_Sair.Text = "Sair";
            BTN_Sair.UseVisualStyleBackColor = true;
            BTN_Sair.Click += BTN_Sair_Click_1;
            // 
            // BTN_Excluir
            // 
            BTN_Excluir.Enabled = false;
            BTN_Excluir.Location = new Point(257, 415);
            BTN_Excluir.Name = "BTN_Excluir";
            BTN_Excluir.Size = new Size(75, 23);
            BTN_Excluir.TabIndex = 17;
            BTN_Excluir.Text = "Excluir";
            BTN_Excluir.UseVisualStyleBackColor = true;
            BTN_Excluir.Click += BTN_Excluir_Click;
            // 
            // BTN_Novo
            // 
            BTN_Novo.Location = new Point(12, 415);
            BTN_Novo.Name = "BTN_Novo";
            BTN_Novo.Size = new Size(75, 23);
            BTN_Novo.TabIndex = 16;
            BTN_Novo.Text = "Novo";
            BTN_Novo.UseVisualStyleBackColor = true;
            BTN_Novo.Click += BTN_Novo_Click;
            // 
            // TBC_Cidades
            // 
            TBC_Cidades.Controls.Add(TBP_ListaCidades);
            TBC_Cidades.Controls.Add(TBP_CadastroCidades);
            TBC_Cidades.Location = new Point(12, 6);
            TBC_Cidades.Name = "TBC_Cidades";
            TBC_Cidades.SelectedIndex = 0;
            TBC_Cidades.Size = new Size(776, 403);
            TBC_Cidades.TabIndex = 21;
            // 
            // TBP_ListaCidades
            // 
            TBP_ListaCidades.Controls.Add(label1);
            TBP_ListaCidades.Controls.Add(DGV_Cidades);
            TBP_ListaCidades.Controls.Add(EDT_Pesquisa);
            TBP_ListaCidades.Location = new Point(4, 24);
            TBP_ListaCidades.Name = "TBP_ListaCidades";
            TBP_ListaCidades.Padding = new Padding(3);
            TBP_ListaCidades.Size = new Size(768, 375);
            TBP_ListaCidades.TabIndex = 0;
            TBP_ListaCidades.Text = "Cidades";
            TBP_ListaCidades.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 23);
            label1.Name = "label1";
            label1.Size = new Size(216, 15);
            label1.TabIndex = 3;
            label1.Text = "Pesquise por Nome ou Código do IBGE:";
            // 
            // DGV_Cidades
            // 
            DGV_Cidades.AllowUserToAddRows = false;
            DGV_Cidades.AllowUserToDeleteRows = false;
            DGV_Cidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Cidades.Location = new Point(10, 70);
            DGV_Cidades.Name = "DGV_Cidades";
            DGV_Cidades.ReadOnly = true;
            DGV_Cidades.Size = new Size(752, 275);
            DGV_Cidades.TabIndex = 2;
            DGV_Cidades.CellClick += DGV_Cidades_CellClick;
            DGV_Cidades.CellContentClick += DGV_Cidades_CellContentClick;
            DGV_Cidades.CellDoubleClick += DGV_Cidades_CellDoubleClick;
            // 
            // EDT_Pesquisa
            // 
            EDT_Pesquisa.Location = new Point(10, 41);
            EDT_Pesquisa.Name = "EDT_Pesquisa";
            EDT_Pesquisa.Size = new Size(397, 23);
            EDT_Pesquisa.TabIndex = 1;
            EDT_Pesquisa.TextChanged += EDT_Pesquisa_TextChanged;
            // 
            // TBP_CadastroCidades
            // 
            TBP_CadastroCidades.Controls.Add(linkLabel1);
            TBP_CadastroCidades.Controls.Add(EDT_UF);
            TBP_CadastroCidades.Controls.Add(label4);
            TBP_CadastroCidades.Controls.Add(EDT_NomeCidade);
            TBP_CadastroCidades.Controls.Add(label3);
            TBP_CadastroCidades.Controls.Add(EDT_CodigoIBGE);
            TBP_CadastroCidades.Controls.Add(label2);
            TBP_CadastroCidades.Location = new Point(4, 24);
            TBP_CadastroCidades.Name = "TBP_CadastroCidades";
            TBP_CadastroCidades.Padding = new Padding(3);
            TBP_CadastroCidades.Size = new Size(768, 375);
            TBP_CadastroCidades.TabIndex = 1;
            TBP_CadastroCidades.Text = "Cadastro de Cidades";
            TBP_CadastroCidades.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(351, 40);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(140, 15);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Não sei o código do IBGE";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // EDT_UF
            // 
            EDT_UF.Location = new Point(20, 155);
            EDT_UF.MaxLength = 2;
            EDT_UF.Name = "EDT_UF";
            EDT_UF.Size = new Size(66, 23);
            EDT_UF.TabIndex = 5;
            EDT_UF.TextChanged += EDT_UF_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 137);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 4;
            label4.Text = "UF:";
            // 
            // EDT_NomeCidade
            // 
            EDT_NomeCidade.Location = new Point(20, 89);
            EDT_NomeCidade.Name = "EDT_NomeCidade";
            EDT_NomeCidade.Size = new Size(307, 23);
            EDT_NomeCidade.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 71);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 2;
            label3.Text = "Cidade:";
            // 
            // EDT_CodigoIBGE
            // 
            EDT_CodigoIBGE.Location = new Point(20, 32);
            EDT_CodigoIBGE.Name = "EDT_CodigoIBGE";
            EDT_CodigoIBGE.Size = new Size(307, 23);
            EDT_CodigoIBGE.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 14);
            label2.Name = "label2";
            label2.Size = new Size(148, 15);
            label2.TabIndex = 0;
            label2.Text = "Informe o Código do IBGE:";
            // 
            // FRM_Cidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(TBC_Cidades);
            Controls.Add(BTN_Salvar);
            Controls.Add(BTN_Cancelar);
            Controls.Add(BTN_Sair);
            Controls.Add(BTN_Excluir);
            Controls.Add(BTN_Novo);
            Name = "FRM_Cidades";
            Text = "Cadastro de Cidades";
            WindowState = FormWindowState.Maximized;
            Load += FRM_Cidades_Load;
            TBC_Cidades.ResumeLayout(false);
            TBP_ListaCidades.ResumeLayout(false);
            TBP_ListaCidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Cidades).EndInit();
            TBP_CadastroCidades.ResumeLayout(false);
            TBP_CadastroCidades.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BTN_Salvar;
        private Button BTN_Cancelar;
        private Button BTN_Sair;
        private Button BTN_Excluir;
        private Button BTN_Novo;
        private TabControl TBC_Cidades;
        private TabPage TBP_ListaCidades;
        private TabPage TBP_CadastroCidades;
        private TextBox EDT_Pesquisa;
        private DataGridView DGV_Cidades;
        private Label label2;
        private TextBox EDT_CodigoIBGE;
        private TextBox EDT_UF;
        private Label label4;
        private TextBox EDT_NomeCidade;
        private Label label3;
        private LinkLabel linkLabel1;
        private Label label1;
    }
}