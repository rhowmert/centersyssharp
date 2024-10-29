using System;
using System.Collections.Generic;
using System.Windows.Forms;
using controllers;
using models;

namespace CenterSysVendas.forms
{
    public partial class FRM_FormaPagamento : Form
    {
        private FormaPagamentoController _formaPagamentoController;
        int editMode = 0;

        public FRM_FormaPagamento()
        {
            InitializeComponent();
            _formaPagamentoController = new FormaPagamentoController();
        }

        private void FRM_FormaPagamento_Load(object sender, EventArgs e)
        {
            TBC_FormaPagamento.TabPages.Remove(TBP_CadastroFormasPagamento);
            CarregarFormasPagamento();
        }

        private void BTN_Novo_Click(object sender, EventArgs e)
        {
            LimparCamposEdicao();
            TBC_FormaPagamento.TabPages.Add(TBP_CadastroFormasPagamento);
            TBC_FormaPagamento.SelectedTab = TBP_CadastroFormasPagamento;
            BTN_Novo.Enabled = false;
            BTN_Cancelar.Enabled = true;
            BTN_Salvar.Enabled = true;
            SetControlsEnabled(TBP_CadastroFormasPagamento, true);
            editMode = 1;
            TBC_FormaPagamento.TabPages.Remove(TBP_ListaFormasPagamento);
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            string tipoEdicao = editMode == 1 ? "inclusão" : "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Deseja realmente cancelar a {tipoEdicao} da forma de pagamento?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    TBC_FormaPagamento.TabPages.Remove(TBP_CadastroFormasPagamento);
                    TBC_FormaPagamento.TabPages.Add(TBP_ListaFormasPagamento);
                    BTN_Novo.Enabled = true;
                    BTN_Cancelar.Enabled = false;
                    BTN_Salvar.Enabled = false;
                    editMode = 0;
                }
            }
        }

        private void BTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = EDT_FormaPagamento.Text;
                decimal? valorDiferenca = NUD_ValorDiferenca.Value;
                int tipo = RDB_Acrescimo.Checked ? 1 : (RDB_Desconto.Checked ? 2 : 0);
                int tipoCredito = CKB_Credito.Checked ? 1 : 0;

                if (editMode == 1)
                {
                    _formaPagamentoController.CriarNovaFormaPagamento(descricao, valorDiferenca, tipo, tipoCredito);
                    MessageBox.Show("Forma de pagamento criada com sucesso!");
                }
                else if (editMode == 2)
                {
                    int id = Convert.ToInt32(DGV_FormasPagamento.CurrentRow.Cells["Id"].Value);
                    _formaPagamentoController.AtualizarFormaPagamentoExistente(id, descricao, valorDiferenca, tipo, tipoCredito);
                    MessageBox.Show("Forma de pagamento atualizada com sucesso!");
                }

                TBC_FormaPagamento.TabPages.Remove(TBP_CadastroFormasPagamento);
                TBC_FormaPagamento.TabPages.Add(TBP_ListaFormasPagamento);
                TBC_FormaPagamento.SelectedTab = TBP_ListaFormasPagamento;
                CarregarFormasPagamento();
                BTN_Novo.Enabled = true;
                BTN_Cancelar.Enabled = false;
                BTN_Salvar.Enabled = false;
                editMode = 0;
                LimparCamposEdicao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_Excluir_Click(object sender, EventArgs e)
        {
            if (DGV_FormasPagamento.CurrentRow == null)
                return;

            int id = Convert.ToInt32(DGV_FormasPagamento.CurrentRow.Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                  "Deseja realmente excluir esta forma de pagamento?",
                  "Confirmação",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );

            if (result == DialogResult.Yes)
            {
                _formaPagamentoController.ExcluirFormaPagamento(id);
                CarregarFormasPagamento();
                MessageBox.Show("Forma de pagamento excluída com sucesso!");
                LimparCamposEdicao();
                editMode = 0;
            }
        }

        private void SetControlsEnabled(TabPage tabPage, bool enabled)
        {
            foreach (Control control in tabPage.Controls)
            {
                control.Enabled = enabled;
            }
        }

        private void CarregarFormasPagamento(string descricao = null)
        {
            var listaFormasPagamento = _formaPagamentoController.ObterFormasPagamento(descricao);
            DGV_FormasPagamento.DataSource = listaFormasPagamento;
            DGV_FormasPagamento.Columns["Id"].Visible = false;
            NomesColunas();
        }

        private void NomesColunas()
        {
            DGV_FormasPagamento.Columns["Descricao"].HeaderText = "Descrição";
            DGV_FormasPagamento.Columns["ValorDiferenca"].HeaderText = "%";
            DGV_FormasPagamento.Columns["Tipo"].HeaderText = "Tipo";
            DGV_FormasPagamento.Columns["TipoCredito"].HeaderText = "Cartão de Crédito";

        }


        private void LimparCamposEdicao()
        {
            EDT_FormaPagamento.Text = string.Empty;
            NUD_ValorDiferenca.Value = 0;
            RDB_Acrescimo.Checked = false;
            RDB_Desconto.Checked = false;
        }

        private void EDT_PesquisaFormaPagamento_TextChanged(object sender, EventArgs e)
        {
            CarregarFormasPagamento(EDT_PesquisaFormaPagamento.Text);
        }



        private void BTN_Sair_Click(object sender, EventArgs e)
        {
            string tipoEdicao = editMode == 1 ? "inclusão" : "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Deseja realmente cancelar a {tipoEdicao} da forma de pagamento?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void DGV_FormasPagamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_FormasPagamento.Rows[e.RowIndex];
                EDT_FormaPagamento.Text = row.Cells["Descricao"].Value.ToString();
                NUD_ValorDiferenca.Value = Convert.ToDecimal(row.Cells["ValorDiferenca"].Value);
                int tipo = Convert.ToInt32(row.Cells["Tipo"].Value);

                RDB_Acrescimo.Checked = tipo == 1;
                RDB_Desconto.Checked = tipo == 2;

                TBC_FormaPagamento.TabPages.Remove(TBP_ListaFormasPagamento);
                TBC_FormaPagamento.TabPages.Add(TBP_CadastroFormasPagamento);
                TBC_FormaPagamento.SelectedTab = TBP_CadastroFormasPagamento;
                BTN_Novo.Enabled = false;
                BTN_Cancelar.Enabled = true;
                BTN_Salvar.Enabled = true;
                editMode = 2;
            }
        }

        private void DGV_FormasPagamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_FormasPagamento.Columns[e.ColumnIndex].Name == "Tipo" && e.Value != null)
            {
                int tipoValue = (int)e.Value;
                e.Value = tipoValue switch
                {
                    0 => "Nenhum",
                    1 => "Acréscimo",
                    2 => "Desconto",
                    _ => "Desconhecido" 
                };
            }

            if (DGV_FormasPagamento.Columns[e.ColumnIndex].Name == "TipoCredito" && e.Value != null)
            {
                int tipoValue = (int)e.Value;
                e.Value = tipoValue switch
                {
                    0 => "Sim",
                    1 => "Não"
                };
            }


        }
    }
}
