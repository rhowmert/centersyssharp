namespace CenterSysVendas.forms
{
    partial class FRM_FormaPagamento
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
            TBC_FormaPagamento = new TabControl();
            TBP_ListaFormasPagamento = new TabPage();
            DGV_FormasPagamento = new DataGridView();
            EDT_PesquisaFormaPagamento = new TextBox();
            label1 = new Label();
            TBP_CadastroFormasPagamento = new TabPage();
            RDB_Desconto = new RadioButton();
            RDB_Acrescimo = new RadioButton();
            NUD_ValorDiferenca = new NumericUpDown();
            label3 = new Label();
            EDT_FormaPagamento = new TextBox();
            label2 = new Label();
            BTN_Salvar = new Button();
            BTN_Cancelar = new Button();
            BTN_Sair = new Button();
            BTN_Excluir = new Button();
            BTN_Novo = new Button();
            CKB_Credito = new CheckBox();
            TBC_FormaPagamento.SuspendLayout();
            TBP_ListaFormasPagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_FormasPagamento).BeginInit();
            TBP_CadastroFormasPagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_ValorDiferenca).BeginInit();
            SuspendLayout();
            // 
            // TBC_FormaPagamento
            // 
            TBC_FormaPagamento.Controls.Add(TBP_ListaFormasPagamento);
            TBC_FormaPagamento.Controls.Add(TBP_CadastroFormasPagamento);
            TBC_FormaPagamento.Location = new Point(19, 6);
            TBC_FormaPagamento.Name = "TBC_FormaPagamento";
            TBC_FormaPagamento.SelectedIndex = 0;
            TBC_FormaPagamento.Size = new Size(757, 397);
            TBC_FormaPagamento.TabIndex = 0;
            // 
            // TBP_ListaFormasPagamento
            // 
            TBP_ListaFormasPagamento.Controls.Add(DGV_FormasPagamento);
            TBP_ListaFormasPagamento.Controls.Add(EDT_PesquisaFormaPagamento);
            TBP_ListaFormasPagamento.Controls.Add(label1);
            TBP_ListaFormasPagamento.Location = new Point(4, 24);
            TBP_ListaFormasPagamento.Name = "TBP_ListaFormasPagamento";
            TBP_ListaFormasPagamento.Padding = new Padding(3);
            TBP_ListaFormasPagamento.Size = new Size(749, 369);
            TBP_ListaFormasPagamento.TabIndex = 0;
            TBP_ListaFormasPagamento.Text = "Formas de Pagamento";
            TBP_ListaFormasPagamento.UseVisualStyleBackColor = true;
            // 
            // DGV_FormasPagamento
            // 
            DGV_FormasPagamento.AllowUserToAddRows = false;
            DGV_FormasPagamento.AllowUserToDeleteRows = false;
            DGV_FormasPagamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_FormasPagamento.Location = new Point(14, 83);
            DGV_FormasPagamento.Name = "DGV_FormasPagamento";
            DGV_FormasPagamento.ReadOnly = true;
            DGV_FormasPagamento.Size = new Size(717, 280);
            DGV_FormasPagamento.TabIndex = 2;
            DGV_FormasPagamento.CellDoubleClick += DGV_FormasPagamento_CellDoubleClick;
            DGV_FormasPagamento.CellFormatting += DGV_FormasPagamento_CellFormatting;
            // 
            // EDT_PesquisaFormaPagamento
            // 
            EDT_PesquisaFormaPagamento.Location = new Point(14, 43);
            EDT_PesquisaFormaPagamento.Name = "EDT_PesquisaFormaPagamento";
            EDT_PesquisaFormaPagamento.Size = new Size(385, 23);
            EDT_PesquisaFormaPagamento.TabIndex = 1;
            EDT_PesquisaFormaPagamento.TextChanged += EDT_PesquisaFormaPagamento_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 18);
            label1.Name = "label1";
            label1.Size = new Size(180, 15);
            label1.TabIndex = 0;
            label1.Text = "Pesquisar formas de pagamento:";
            // 
            // TBP_CadastroFormasPagamento
            // 
            TBP_CadastroFormasPagamento.Controls.Add(CKB_Credito);
            TBP_CadastroFormasPagamento.Controls.Add(RDB_Desconto);
            TBP_CadastroFormasPagamento.Controls.Add(RDB_Acrescimo);
            TBP_CadastroFormasPagamento.Controls.Add(NUD_ValorDiferenca);
            TBP_CadastroFormasPagamento.Controls.Add(label3);
            TBP_CadastroFormasPagamento.Controls.Add(EDT_FormaPagamento);
            TBP_CadastroFormasPagamento.Controls.Add(label2);
            TBP_CadastroFormasPagamento.Location = new Point(4, 24);
            TBP_CadastroFormasPagamento.Name = "TBP_CadastroFormasPagamento";
            TBP_CadastroFormasPagamento.Padding = new Padding(3);
            TBP_CadastroFormasPagamento.Size = new Size(749, 369);
            TBP_CadastroFormasPagamento.TabIndex = 1;
            TBP_CadastroFormasPagamento.Text = "Cadastrar Formas de Pagamento";
            TBP_CadastroFormasPagamento.UseVisualStyleBackColor = true;
            // 
            // RDB_Desconto
            // 
            RDB_Desconto.AutoSize = true;
            RDB_Desconto.Location = new Point(275, 98);
            RDB_Desconto.Name = "RDB_Desconto";
            RDB_Desconto.Size = new Size(75, 19);
            RDB_Desconto.TabIndex = 6;
            RDB_Desconto.TabStop = true;
            RDB_Desconto.Text = "Desconto";
            RDB_Desconto.UseVisualStyleBackColor = true;
            // 
            // RDB_Acrescimo
            // 
            RDB_Acrescimo.AutoSize = true;
            RDB_Acrescimo.Location = new Point(191, 98);
            RDB_Acrescimo.Name = "RDB_Acrescimo";
            RDB_Acrescimo.Size = new Size(78, 19);
            RDB_Acrescimo.TabIndex = 5;
            RDB_Acrescimo.TabStop = true;
            RDB_Acrescimo.Text = "Acréscmo";
            RDB_Acrescimo.UseVisualStyleBackColor = true;
            // 
            // NUD_ValorDiferenca
            // 
            NUD_ValorDiferenca.DecimalPlaces = 2;
            NUD_ValorDiferenca.Location = new Point(16, 98);
            NUD_ValorDiferenca.Name = "NUD_ValorDiferenca";
            NUD_ValorDiferenca.Size = new Size(153, 23);
            NUD_ValorDiferenca.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 80);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 2;
            label3.Text = "% acréscimo / desconto:";
            // 
            // EDT_FormaPagamento
            // 
            EDT_FormaPagamento.Location = new Point(16, 45);
            EDT_FormaPagamento.Name = "EDT_FormaPagamento";
            EDT_FormaPagamento.Size = new Size(334, 23);
            EDT_FormaPagamento.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 27);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 0;
            label2.Text = "Forma de pagamento:";
            // 
            // BTN_Salvar
            // 
            BTN_Salvar.Enabled = false;
            BTN_Salvar.Location = new Point(102, 415);
            BTN_Salvar.Name = "BTN_Salvar";
            BTN_Salvar.Size = new Size(75, 23);
            BTN_Salvar.TabIndex = 25;
            BTN_Salvar.Text = "Salvar";
            BTN_Salvar.UseVisualStyleBackColor = true;
            BTN_Salvar.Click += BTN_Salvar_Click;
            // 
            // BTN_Cancelar
            // 
            BTN_Cancelar.Enabled = false;
            BTN_Cancelar.Location = new Point(183, 415);
            BTN_Cancelar.Name = "BTN_Cancelar";
            BTN_Cancelar.Size = new Size(75, 23);
            BTN_Cancelar.TabIndex = 24;
            BTN_Cancelar.Text = "Cancelar";
            BTN_Cancelar.UseVisualStyleBackColor = true;
            BTN_Cancelar.Click += BTN_Cancelar_Click;
            // 
            // BTN_Sair
            // 
            BTN_Sair.Location = new Point(347, 415);
            BTN_Sair.Name = "BTN_Sair";
            BTN_Sair.Size = new Size(75, 23);
            BTN_Sair.TabIndex = 23;
            BTN_Sair.Text = "Sair";
            BTN_Sair.UseVisualStyleBackColor = true;
            BTN_Sair.Click += BTN_Sair_Click;
            // 
            // BTN_Excluir
            // 
            BTN_Excluir.Enabled = false;
            BTN_Excluir.Location = new Point(266, 415);
            BTN_Excluir.Name = "BTN_Excluir";
            BTN_Excluir.Size = new Size(75, 23);
            BTN_Excluir.TabIndex = 22;
            BTN_Excluir.Text = "Excluir";
            BTN_Excluir.UseVisualStyleBackColor = true;
            BTN_Excluir.Click += BTN_Excluir_Click;
            // 
            // BTN_Novo
            // 
            BTN_Novo.Location = new Point(21, 415);
            BTN_Novo.Name = "BTN_Novo";
            BTN_Novo.Size = new Size(75, 23);
            BTN_Novo.TabIndex = 21;
            BTN_Novo.Text = "Novo";
            BTN_Novo.UseVisualStyleBackColor = true;
            BTN_Novo.Click += BTN_Novo_Click;
            // 
            // CKB_Credito
            // 
            CKB_Credito.AutoSize = true;
            CKB_Credito.Location = new Point(378, 46);
            CKB_Credito.Name = "CKB_Credito";
            CKB_Credito.Size = new Size(124, 19);
            CKB_Credito.TabIndex = 7;
            CKB_Credito.Text = "Cartão de Crédito?";
            CKB_Credito.UseVisualStyleBackColor = true;
            // 
            // FRM_FormaPagamento
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
            Controls.Add(TBC_FormaPagamento);
            Name = "FRM_FormaPagamento";
            Text = "FRM_FormaPagamento";
            WindowState = FormWindowState.Maximized;
            Load += FRM_FormaPagamento_Load;
            TBC_FormaPagamento.ResumeLayout(false);
            TBP_ListaFormasPagamento.ResumeLayout(false);
            TBP_ListaFormasPagamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_FormasPagamento).EndInit();
            TBP_CadastroFormasPagamento.ResumeLayout(false);
            TBP_CadastroFormasPagamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_ValorDiferenca).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TBC_FormaPagamento;
        private TabPage TBP_ListaFormasPagamento;
        private TabPage TBP_CadastroFormasPagamento;
        private Button BTN_Salvar;
        private Button BTN_Cancelar;
        private Button BTN_Sair;
        private Button BTN_Excluir;
        private Button BTN_Novo;
        private TextBox EDT_PesquisaFormaPagamento;
        private Label label1;
        private DataGridView DGV_FormasPagamento;
        private TextBox EDT_FormaPagamento;
        private Label label2;
        private Label label3;
        private NumericUpDown NUD_ValorDiferenca;
        private RadioButton RDB_Desconto;
        private RadioButton RDB_Acrescimo;
        private CheckBox CKB_Credito;
    }
}