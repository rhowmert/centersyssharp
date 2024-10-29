namespace CenterSysVendas.forms
{
    partial class FRM_Produtos
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
            TBC_Produtos = new TabControl();
            TBP_ListaProdutos = new TabPage();
            DGV_Produtos = new DataGridView();
            EDT_PesquisaProduto = new TextBox();
            label1 = new Label();
            TBP_CadastroProdutos = new TabPage();
            label4 = new Label();
            RDB_RecorrenteNao = new RadioButton();
            RDB_RecorrenteSim = new RadioButton();
            label3 = new Label();
            NUD_PrecoFinal = new NumericUpDown();
            EDT_NomeProduto = new TextBox();
            label2 = new Label();
            BTN_Salvar = new Button();
            BTN_Cancelar = new Button();
            BTN_Sair = new Button();
            BTN_Excluir = new Button();
            BTN_Novo = new Button();
            TBC_Produtos.SuspendLayout();
            TBP_ListaProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Produtos).BeginInit();
            TBP_CadastroProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_PrecoFinal).BeginInit();
            SuspendLayout();
            // 
            // TBC_Produtos
            // 
            TBC_Produtos.Controls.Add(TBP_ListaProdutos);
            TBC_Produtos.Controls.Add(TBP_CadastroProdutos);
            TBC_Produtos.Location = new Point(14, 10);
            TBC_Produtos.Name = "TBC_Produtos";
            TBC_Produtos.SelectedIndex = 0;
            TBC_Produtos.Size = new Size(762, 390);
            TBC_Produtos.TabIndex = 0;
            // 
            // TBP_ListaProdutos
            // 
            TBP_ListaProdutos.Controls.Add(DGV_Produtos);
            TBP_ListaProdutos.Controls.Add(EDT_PesquisaProduto);
            TBP_ListaProdutos.Controls.Add(label1);
            TBP_ListaProdutos.Location = new Point(4, 24);
            TBP_ListaProdutos.Name = "TBP_ListaProdutos";
            TBP_ListaProdutos.Padding = new Padding(3);
            TBP_ListaProdutos.Size = new Size(754, 362);
            TBP_ListaProdutos.TabIndex = 0;
            TBP_ListaProdutos.Text = "Lista de Produtos";
            TBP_ListaProdutos.UseVisualStyleBackColor = true;
            // 
            // DGV_Produtos
            // 
            DGV_Produtos.AllowUserToAddRows = false;
            DGV_Produtos.AllowUserToDeleteRows = false;
            DGV_Produtos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Produtos.Location = new Point(6, 72);
            DGV_Produtos.Name = "DGV_Produtos";
            DGV_Produtos.ReadOnly = true;
            DGV_Produtos.Size = new Size(742, 284);
            DGV_Produtos.TabIndex = 2;
            // 
            // EDT_PesquisaProduto
            // 
            EDT_PesquisaProduto.Location = new Point(6, 26);
            EDT_PesquisaProduto.Name = "EDT_PesquisaProduto";
            EDT_PesquisaProduto.Size = new Size(296, 23);
            EDT_PesquisaProduto.TabIndex = 1;
            EDT_PesquisaProduto.TextChanged += EDT_PesquisaProduto_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 8);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 0;
            label1.Text = "Pesquisar Produtos:";
            // 
            // TBP_CadastroProdutos
            // 
            TBP_CadastroProdutos.Controls.Add(label4);
            TBP_CadastroProdutos.Controls.Add(RDB_RecorrenteNao);
            TBP_CadastroProdutos.Controls.Add(RDB_RecorrenteSim);
            TBP_CadastroProdutos.Controls.Add(label3);
            TBP_CadastroProdutos.Controls.Add(NUD_PrecoFinal);
            TBP_CadastroProdutos.Controls.Add(EDT_NomeProduto);
            TBP_CadastroProdutos.Controls.Add(label2);
            TBP_CadastroProdutos.Location = new Point(4, 24);
            TBP_CadastroProdutos.Name = "TBP_CadastroProdutos";
            TBP_CadastroProdutos.Padding = new Padding(3);
            TBP_CadastroProdutos.Size = new Size(754, 362);
            TBP_CadastroProdutos.TabIndex = 1;
            TBP_CadastroProdutos.Text = "Cadastro de Produtos";
            TBP_CadastroProdutos.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 145);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 6;
            label4.Text = "Plano Recorrente?";
            // 
            // RDB_RecorrenteNao
            // 
            RDB_RecorrenteNao.AutoSize = true;
            RDB_RecorrenteNao.Location = new Point(68, 163);
            RDB_RecorrenteNao.Name = "RDB_RecorrenteNao";
            RDB_RecorrenteNao.Size = new Size(47, 19);
            RDB_RecorrenteNao.TabIndex = 5;
            RDB_RecorrenteNao.TabStop = true;
            RDB_RecorrenteNao.Text = "Não";
            RDB_RecorrenteNao.UseVisualStyleBackColor = true;
            // 
            // RDB_RecorrenteSim
            // 
            RDB_RecorrenteSim.AutoSize = true;
            RDB_RecorrenteSim.Location = new Point(17, 163);
            RDB_RecorrenteSim.Name = "RDB_RecorrenteSim";
            RDB_RecorrenteSim.Size = new Size(45, 19);
            RDB_RecorrenteSim.TabIndex = 4;
            RDB_RecorrenteSim.TabStop = true;
            RDB_RecorrenteSim.Text = "Sim";
            RDB_RecorrenteSim.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 78);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 3;
            label3.Text = "Valor:";
            // 
            // NUD_PrecoFinal
            // 
            NUD_PrecoFinal.DecimalPlaces = 2;
            NUD_PrecoFinal.Location = new Point(17, 96);
            NUD_PrecoFinal.Name = "NUD_PrecoFinal";
            NUD_PrecoFinal.Size = new Size(120, 23);
            NUD_PrecoFinal.TabIndex = 2;
            // 
            // EDT_NomeProduto
            // 
            EDT_NomeProduto.Location = new Point(17, 30);
            EDT_NomeProduto.Name = "EDT_NomeProduto";
            EDT_NomeProduto.Size = new Size(546, 23);
            EDT_NomeProduto.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 12);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 0;
            label2.Text = "Produto:";
            // 
            // BTN_Salvar
            // 
            BTN_Salvar.Enabled = false;
            BTN_Salvar.Location = new Point(102, 406);
            BTN_Salvar.Name = "BTN_Salvar";
            BTN_Salvar.Size = new Size(75, 23);
            BTN_Salvar.TabIndex = 30;
            BTN_Salvar.Text = "Salvar";
            BTN_Salvar.UseVisualStyleBackColor = true;
            BTN_Salvar.Click += BTN_Salvar_Click;
            // 
            // BTN_Cancelar
            // 
            BTN_Cancelar.Enabled = false;
            BTN_Cancelar.Location = new Point(183, 406);
            BTN_Cancelar.Name = "BTN_Cancelar";
            BTN_Cancelar.Size = new Size(75, 23);
            BTN_Cancelar.TabIndex = 29;
            BTN_Cancelar.Text = "Cancelar";
            BTN_Cancelar.UseVisualStyleBackColor = true;
            BTN_Cancelar.Click += BTN_Cancelar_Click;
            // 
            // BTN_Sair
            // 
            BTN_Sair.Location = new Point(347, 406);
            BTN_Sair.Name = "BTN_Sair";
            BTN_Sair.Size = new Size(75, 23);
            BTN_Sair.TabIndex = 28;
            BTN_Sair.Text = "Sair";
            BTN_Sair.UseVisualStyleBackColor = true;
            BTN_Sair.Click += BTN_Sair_Click;
            // 
            // BTN_Excluir
            // 
            BTN_Excluir.Enabled = false;
            BTN_Excluir.Location = new Point(266, 406);
            BTN_Excluir.Name = "BTN_Excluir";
            BTN_Excluir.Size = new Size(75, 23);
            BTN_Excluir.TabIndex = 27;
            BTN_Excluir.Text = "Excluir";
            BTN_Excluir.UseVisualStyleBackColor = true;
            BTN_Excluir.Click += BTN_Excluir_Click;
            // 
            // BTN_Novo
            // 
            BTN_Novo.Location = new Point(21, 406);
            BTN_Novo.Name = "BTN_Novo";
            BTN_Novo.Size = new Size(75, 23);
            BTN_Novo.TabIndex = 26;
            BTN_Novo.Text = "Novo";
            BTN_Novo.UseVisualStyleBackColor = true;
            BTN_Novo.Click += BTN_Novo_Click;
            // 
            // FRM_Produtos
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
            Controls.Add(TBC_Produtos);
            Name = "FRM_Produtos";
            Text = "FRM_Produtos";
            WindowState = FormWindowState.Maximized;
            Load += FRM_Produtos_Load;
            TBC_Produtos.ResumeLayout(false);
            TBP_ListaProdutos.ResumeLayout(false);
            TBP_ListaProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Produtos).EndInit();
            TBP_CadastroProdutos.ResumeLayout(false);
            TBP_CadastroProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_PrecoFinal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TBC_Produtos;
        private TabPage TBP_ListaProdutos;
        private TabPage TBP_CadastroProdutos;
        private Button BTN_Salvar;
        private Button BTN_Cancelar;
        private Button BTN_Sair;
        private Button BTN_Excluir;
        private Button BTN_Novo;
        private Label label1;
        private TextBox EDT_PesquisaProduto;
        private DataGridView DGV_Produtos;
        private NumericUpDown NUD_PrecoFinal;
        private TextBox EDT_NomeProduto;
        private Label label2;
        private Label label3;
        private RadioButton RDB_RecorrenteSim;
        private Label label4;
        private RadioButton RDB_RecorrenteNao;
    }
}