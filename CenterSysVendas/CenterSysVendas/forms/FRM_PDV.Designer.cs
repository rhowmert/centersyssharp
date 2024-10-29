namespace CenterSysVendas.forms
{
    partial class FRM_PDV
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
            CBB_Produto = new ComboBox();
            CBB_Cliente = new ComboBox();
            label2 = new Label();
            CBB_FormaPagamento = new ComboBox();
            label3 = new Label();
            BTN_GerarVenda = new Button();
            button2 = new Button();
            label4 = new Label();
            NUD_ValorTotal = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NUD_ValorTotal).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione o Produto:";
            // 
            // CBB_Produto
            // 
            CBB_Produto.DropDownStyle = ComboBoxStyle.DropDownList;
            CBB_Produto.FormattingEnabled = true;
            CBB_Produto.Location = new Point(12, 88);
            CBB_Produto.Name = "CBB_Produto";
            CBB_Produto.Size = new Size(345, 23);
            CBB_Produto.TabIndex = 1;
            CBB_Produto.SelectedIndexChanged += CBB_Produto_SelectedIndexChanged;
            // 
            // CBB_Cliente
            // 
            CBB_Cliente.DropDownStyle = ComboBoxStyle.DropDownList;
            CBB_Cliente.FormattingEnabled = true;
            CBB_Cliente.Location = new Point(12, 30);
            CBB_Cliente.Name = "CBB_Cliente";
            CBB_Cliente.Size = new Size(345, 23);
            CBB_Cliente.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 2;
            label2.Text = "Selecione o Cliente:";
            // 
            // CBB_FormaPagamento
            // 
            CBB_FormaPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            CBB_FormaPagamento.FormattingEnabled = true;
            CBB_FormaPagamento.Location = new Point(12, 147);
            CBB_FormaPagamento.Name = "CBB_FormaPagamento";
            CBB_FormaPagamento.Size = new Size(345, 23);
            CBB_FormaPagamento.TabIndex = 5;
            CBB_FormaPagamento.SelectedIndexChanged += CBB_FormaPagamento_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 129);
            label3.Name = "label3";
            label3.Size = new Size(184, 15);
            label3.TabIndex = 4;
            label3.Text = "Selecione a forma de pagamento:";
            // 
            // BTN_GerarVenda
            // 
            BTN_GerarVenda.Location = new Point(82, 271);
            BTN_GerarVenda.Name = "BTN_GerarVenda";
            BTN_GerarVenda.Size = new Size(163, 23);
            BTN_GerarVenda.TabIndex = 6;
            BTN_GerarVenda.Text = "Gerar Venda";
            BTN_GerarVenda.UseVisualStyleBackColor = true;
            BTN_GerarVenda.Click += BTN_GerarVenda_Click;
            // 
            // button2
            // 
            button2.Location = new Point(121, 328);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Sair";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 193);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 8;
            label4.Text = "Valor Total R$:";
            // 
            // NUD_ValorTotal
            // 
            NUD_ValorTotal.DecimalPlaces = 2;
            NUD_ValorTotal.Location = new Point(12, 211);
            NUD_ValorTotal.Name = "NUD_ValorTotal";
            NUD_ValorTotal.ReadOnly = true;
            NUD_ValorTotal.Size = new Size(345, 23);
            NUD_ValorTotal.TabIndex = 9;
            // 
            // FRM_PDV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 450);
            ControlBox = false;
            Controls.Add(NUD_ValorTotal);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(BTN_GerarVenda);
            Controls.Add(CBB_FormaPagamento);
            Controls.Add(label3);
            Controls.Add(CBB_Cliente);
            Controls.Add(label2);
            Controls.Add(CBB_Produto);
            Controls.Add(label1);
            Name = "FRM_PDV";
            Text = "FRM_PDV";
            WindowState = FormWindowState.Maximized;
            Load += FRM_PDV_Load;
            ((System.ComponentModel.ISupportInitialize)NUD_ValorTotal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox CBB_Produto;
        private ComboBox CBB_Cliente;
        private Label label2;
        private ComboBox CBB_FormaPagamento;
        private Label label3;
        private Button BTN_GerarVenda;
        private Button button2;
        private Label label4;
        private NumericUpDown NUD_ValorTotal;
    }
}