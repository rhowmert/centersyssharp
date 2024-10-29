using System;
using System.Collections.Generic;
using System.Windows.Forms;
using controllers;
using models;

namespace CenterSysVendas.forms
{
    public partial class FRM_Produtos : Form
    {
        private ProdutoController _produtoController;
        int editMode = 0;

        public FRM_Produtos()
        {
            InitializeComponent();
            _produtoController = new ProdutoController();
        }

        private void FRM_Produtos_Load(object sender, EventArgs e)
        {
            TBC_Produtos.TabPages.Remove(TBP_CadastroProdutos);
            CarregarProdutos();
        }

        private void BTN_Novo_Click(object sender, EventArgs e)
        {
            LimparCamposEdicao();
            TBC_Produtos.TabPages.Add(TBP_CadastroProdutos);
            TBC_Produtos.SelectedTab = TBP_CadastroProdutos;
            BTN_Novo.Enabled = false;
            BTN_Cancelar.Enabled = true;
            BTN_Salvar.Enabled = true;
            SetControlsEnabled(TBP_CadastroProdutos, true);
            editMode = 1;
            TBC_Produtos.TabPages.Remove(TBP_ListaProdutos);
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            string tipoEdicao = editMode == 1 ? "inclusão" : "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Deseja realmente cancelar a {tipoEdicao} do produto?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    TBC_Produtos.TabPages.Remove(TBP_CadastroProdutos);
                    TBC_Produtos.TabPages.Add(TBP_ListaProdutos);
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
                string nomeProduto = EDT_NomeProduto.Text;
                decimal? precoFinal = NUD_PrecoFinal.Value;
                int planoRecorrente = RDB_RecorrenteSim.Checked ? 1 : 0;

                if (editMode == 1)
                {
                    _produtoController.CriarNovoProduto(nomeProduto, precoFinal, planoRecorrente);
                    MessageBox.Show("Produto criado com sucesso!");
                }
                else if (editMode == 2)
                {
                    int id = Convert.ToInt32(DGV_Produtos.CurrentRow.Cells["Id"].Value);
                    _produtoController.AtualizarProdutoExistente(id, nomeProduto, precoFinal, planoRecorrente);
                    MessageBox.Show("Produto atualizado com sucesso!");
                }

                TBC_Produtos.TabPages.Remove(TBP_CadastroProdutos);
                TBC_Produtos.TabPages.Add(TBP_ListaProdutos);
                TBC_Produtos.SelectedTab = TBP_ListaProdutos;
                CarregarProdutos();
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
            if (DGV_Produtos.CurrentRow == null)
                return;

            int id = Convert.ToInt32(DGV_Produtos.CurrentRow.Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                  "Deseja realmente excluir este produto?",
                  "Confirmação",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );

            if (result == DialogResult.Yes)
            {
                _produtoController.ExcluirProduto(id);
                CarregarProdutos();
                MessageBox.Show("Produto excluído com sucesso!");
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

        private void CarregarProdutos(string nome = null)
        {
            var listaProdutos = _produtoController.ObterProdutos(nome);
            DGV_Produtos.DataSource = listaProdutos;
            DGV_Produtos.Columns["Id"].Visible = false;
            NomesColunas();
        }

        private void NomesColunas()
        {
            DGV_Produtos.Columns["NomeProduto"].HeaderText = "Nome do Produto";
            DGV_Produtos.Columns["PrecoFinal"].HeaderText = "Preço Final";
            DGV_Produtos.Columns["PlanoRecorrente"].HeaderText = "Plano Recorrente";
        }

        private void LimparCamposEdicao()
        {
            EDT_NomeProduto.Text = string.Empty;
            NUD_PrecoFinal.Value = 0;
            RDB_RecorrenteSim.Checked = false;
            RDB_RecorrenteNao.Checked = false;
        }

        private void DGV_Produtos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_Produtos.Rows[e.RowIndex];
                EDT_NomeProduto.Text = row.Cells["NomeProduto"].Value.ToString();
                NUD_PrecoFinal.Value = Convert.ToDecimal(row.Cells["PrecoFinal"].Value);
                int planoRecorrente = Convert.ToInt32(row.Cells["PlanoRecorrente"].Value);

                RDB_RecorrenteSim.Checked = planoRecorrente == 1;
                RDB_RecorrenteNao.Checked = planoRecorrente == 0;

                TBC_Produtos.TabPages.Remove(TBP_ListaProdutos);
                TBC_Produtos.TabPages.Add(TBP_CadastroProdutos);
                TBC_Produtos.SelectedTab = TBP_CadastroProdutos;
                BTN_Novo.Enabled = false;
                BTN_Cancelar.Enabled = true;
                BTN_Salvar.Enabled = true;
                editMode = 2;
            }
        }

        private void EDT_PesquisaProduto_TextChanged(object sender, EventArgs e)
        {
            CarregarProdutos(EDT_PesquisaProduto.Text);
        }

        private void BTN_Sair_Click(object sender, EventArgs e)
        {
            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    "Você tem uma edição não salva. Deseja sair mesmo assim?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            this.Close();
        }

    }
}
