using System;
using System.Collections.Generic;
using System.Windows.Forms;
using controllers;
using models;

namespace CenterSysVendas.forms
{
    public partial class FRM_Cidades : Form
    {
        private CidadeController _cidadeController;
        int editMode = 0;

        public FRM_Cidades()
        {
            InitializeComponent();
            _cidadeController = new CidadeController();
        }

        private void FRM_Cidades_Load(object sender, EventArgs e)
        {
            TBC_Cidades.TabPages.Remove(TBP_CadastroCidades);
            CarregarCidades();
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, "https://www.ibge.gov.br/explica/codigos-dos-municipios.php");
        }

        private void BTN_Novo_Click(object sender, EventArgs e)
        {
            TBC_Cidades.TabPages.Add(TBP_CadastroCidades);
            TBC_Cidades.SelectedTab = TBP_CadastroCidades;
            BTN_Novo.Enabled = false;
            BTN_Cancelar.Enabled = true;
            BTN_Salvar.Enabled = true;
            SetControlsEnabled(TBP_CadastroCidades, true);
            LimparCamposEdicao();
            editMode = 1;
            TBC_Cidades.TabPages.Remove(TBP_ListaCidades);
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            string TipoEdicao = editMode == 1 ? "inclusão" : "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Deseja realmente cancelar a {TipoEdicao} da cidade?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    SetControlsEnabled(TBP_CadastroCidades, false);
                    TBC_Cidades.SelectedTab = TBP_CadastroCidades;
                    BTN_Novo.Enabled = true;
                    BTN_Cancelar.Enabled = false;
                    TBC_Cidades.TabPages.Add(TBP_ListaCidades);
                    TBC_Cidades.TabPages.Remove(TBP_CadastroCidades);
                    editMode = 0;
                    BTN_Salvar.Enabled = false;
                    BTN_Excluir.Enabled = false;
                }
            }
        }


        private void SetControlsEnabled(TabPage tabPage, bool enabled)
        {
            foreach (Control control in tabPage.Controls)
            {
                control.Enabled = enabled;
            }
        }

        private void CarregarCidades(string nomeFiltro = null, string codigoIBGEFiltro = null)
        {
            List<Cidade> listaCidades = _cidadeController.ObterCidades(nomeFiltro, codigoIBGEFiltro);
            DGV_Cidades.DataSource = listaCidades;
        }



        private void LimparCamposEdicao()
        {
            foreach (Control control in TBP_CadastroCidades.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void EDT_UF_TextChanged(object sender, EventArgs e)
        {
            EDT_UF.Text = EDT_UF.Text.ToUpper();
            EDT_UF.SelectionStart = EDT_UF.Text.Length;
        }

        private void BTN_Salvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string nome = EDT_NomeCidade.Text;
                string codigoIBGE = EDT_CodigoIBGE.Text;
                string uf = EDT_UF.Text;

                if (editMode == 1)
                {
                    _cidadeController.CriarNovaCidade(nome, codigoIBGE, uf);
                    MessageBox.Show("Cidade criada com sucesso!");
                }
                else if (editMode == 2)
                {
                    int id = Convert.ToInt32(DGV_Cidades.CurrentRow.Cells["Id"].Value);
                    _cidadeController.AtualizarCidadeExistente(id, nome, codigoIBGE, uf);
                    MessageBox.Show("Cidade atualizada com sucesso!");
                }

                TBC_Cidades.TabPages.Add(TBP_ListaCidades);
                TBC_Cidades.TabPages.Remove(TBP_CadastroCidades);
                TBC_Cidades.SelectedTab = TBP_ListaCidades;
                CarregarCidades();
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
            int id = Convert.ToInt32(DGV_Cidades.CurrentRow.Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                  $"Deseja realmente excluir a cidade {EDT_NomeCidade.Text}?",
                  "Confirmação",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );

            if (result == DialogResult.Yes)
            {
                _cidadeController.ExcluirCidade(id);
                CarregarCidades();
                MessageBox.Show("Cidade excluída com sucesso!");
                editMode = 0;
                SetControlsEnabled(TBP_CadastroCidades, false);
                TBC_Cidades.SelectedTab = TBP_ListaCidades;
                BTN_Novo.Enabled = true;
                BTN_Cancelar.Enabled = false;
                TBC_Cidades.TabPages.Add(TBP_ListaCidades);
                TBC_Cidades.TabPages.Remove(TBP_CadastroCidades);
                BTN_Salvar.Enabled = false;
                BTN_Excluir.Enabled = false;
            }

        }

        private void EDT_Pesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarCidades(nomeFiltro: EDT_Pesquisa.Text);
        }

        private void DGV_Cidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void BTN_Sair_Click_1(object sender, EventArgs e)
        {
            string TipoEdicao;

            if (editMode == 1)
                TipoEdicao = "inclusão";
            else
                TipoEdicao = "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    "Deseja realmente cancelar a " + TipoEdicao + " da cidade?",
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

        private void DGV_Cidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV_Cidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_Cidades.Rows[e.RowIndex];

                EDT_NomeCidade.Text = row.Cells["Nome"].Value.ToString();
                EDT_CodigoIBGE.Text = row.Cells["CodigoIBGE"].Value.ToString();
                EDT_UF.Text = row.Cells["UfSigla"].Value.ToString();

                TBC_Cidades.TabPages.Add(TBP_CadastroCidades);
                TBC_Cidades.SelectedTab = TBP_CadastroCidades;
                BTN_Novo.Enabled = false;
                BTN_Cancelar.Enabled = true;
                SetControlsEnabled(TBP_CadastroCidades, true);
                editMode = 2;
                TBC_Cidades.TabPages.Remove(TBP_ListaCidades);
                BTN_Salvar.Enabled = true;
                BTN_Excluir.Enabled = true;
            }
        }
    }

}
