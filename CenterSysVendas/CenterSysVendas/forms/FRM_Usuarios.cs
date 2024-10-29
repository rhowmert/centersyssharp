using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using controllers;
using models;

namespace CenterSysVendas.forms
{
    public partial class FRM_Usuarios : Form
    {
        private UsuarioController _usuarioController;
        int editMode = 0;

        public FRM_Usuarios()
        {
            InitializeComponent();
            _usuarioController = new UsuarioController();
        }

        private void FRM_Usuarios_Load(object sender, EventArgs e)
        {
            TBC_Usuarios.TabPages.Remove(TBP_Cadastro);
            CarregarUsuarios();
            CBB_Ativo.SelectedIndex = 0;
        }

        private void BTN_Novo_Click(object sender, EventArgs e)
        {
            TBC_Usuarios.TabPages.Add(TBP_Cadastro);
            TBC_Usuarios.SelectedTab = TBP_Cadastro;
            BTN_Novo.Enabled = false;
            BTN_Cancelar.Enabled = true;
            BTN_Salvar.Enabled = true;
            SetControlsEnabled(TBP_Cadastro, true);
            editMode = 1;
            TBC_Usuarios.TabPages.Remove(TBP_Lista);
            LBL_SenhaVazia.Visible = false;
            EDT_Login.ReadOnly = false;
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            string TipoEdicao;

            if (editMode == 1)
                TipoEdicao = "inclusão";
            else
                TipoEdicao = "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    "Deseja realmente cancelar a " + TipoEdicao + " do usuário?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    SetControlsEnabled(TBP_Cadastro, false);
                    TBC_Usuarios.SelectedTab = TBP_Cadastro;
                    BTN_Novo.Enabled = true;
                    BTN_Cancelar.Enabled = false;
                    TBC_Usuarios.TabPages.Add(TBP_Lista);
                    TBC_Usuarios.TabPages.Remove(TBP_Cadastro);
                    editMode = 0;
                    BTN_Salvar.Enabled = false;
                    BTN_Excluir.Enabled = false;
                }
            }
        }

        private void BTN_Sair_Click(object sender, EventArgs e)
        {
            string TipoEdicao;

            if (editMode == 1)
                TipoEdicao = "inclusão";
            else
                TipoEdicao = "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    "Deseja realmente cancelar a " + TipoEdicao + " do usuário?",
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

        private void SetControlsEnabled(TabPage tabPage, bool enabled)
        {
            foreach (Control control in tabPage.Controls)
            {
                control.Enabled = enabled;
            }
        }

        private void CarregarUsuarios(bool apenasAtivos = false, string nomeFiltro = null, uint? idFiltro = null)
        {
            List<Usuario> listaUsuarios = _usuarioController.ObterUsuarios(nomeFiltro, idFiltro, apenasAtivos);
            DGV_Usuarios.DataSource = listaUsuarios;
            DGV_Usuarios.Columns["Senha"].Visible = false;
        }

        private void DGV_Usuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_Usuarios.Columns[e.ColumnIndex].Name == "Perfil" && e.Value != null)
            {
                int perfilValue = (int)e.Value;
                e.Value = perfilValue == 1 ? "Administrador" : perfilValue == 2 ? "Usuário" : "Desconhecido";
            }

            if (DGV_Usuarios.Columns[e.ColumnIndex].Name == "Ativo" && e.Value != null)
            {
                int ativoValue = (int)e.Value;
                e.Value = ativoValue == 1 ? "Ativo" : "Inativo";
            }
        }

        private void EDT_FiltroLista_TextChanged(object sender, EventArgs e)
        {
            CarregarUsuarios(nomeFiltro: EDT_FiltroLista.Text);
        }

        private void BTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = EDT_NomeUsuario.Text;
                string login = EDT_Login.Text;
                string senha = EDT_Senha.Text;
                int perfil = CBB_Ativo.SelectedIndex == 0 ? 1 : 2;
                int ativo = CBX_Ativo.Checked ? 1 : 0;

                if (editMode == 1)
                {
                    _usuarioController.CriarNovoUsuario(nome, login, senha, perfil, ativo);
                    MessageBox.Show("Usuário criado com sucesso!");
                }
                else if (editMode == 2)
                {
                    uint id = Convert.ToUInt32(DGV_Usuarios.CurrentRow.Cells["Id"].Value);
                    _usuarioController.AtualizarUsuarioExistente(id, nome, login, senha, ativo, perfil);
                    MessageBox.Show("Usuário atualizado com sucesso!");
                }

                TBC_Usuarios.TabPages.Add(TBP_Lista);
                TBC_Usuarios.TabPages.Remove(TBP_Cadastro);
                TBC_Usuarios.SelectedTab = TBP_Lista;
                CarregarUsuarios();
                BTN_Novo.Enabled = true;
                BTN_Cancelar.Enabled = false;
                BTN_Salvar.Enabled = false;
                BTN_Excluir.Enabled = false;
                editMode = 0;
                LimparCamposEdicao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_Usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void LimparCamposEdicao()
        {
            foreach (Control control in TBP_Cadastro.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void BTN_Excluir_Click(object sender, EventArgs e)
        {
            uint id = Convert.ToUInt32(DGV_Usuarios.CurrentRow.Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                  "Deseja realmente excluir o usuário " + EDT_NomeUsuario.Text + " ?",
                  "Confirmação",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );

            if (result == DialogResult.Yes)
            {
                _usuarioController.ExcluirUsuario(id);
                CarregarUsuarios();
                MessageBox.Show("Usuário exlcuído com sucesso!");
                editMode = 0;
                SetControlsEnabled(TBP_Cadastro, false);
                TBC_Usuarios.SelectedTab = TBP_Cadastro;
                BTN_Novo.Enabled = true;
                BTN_Cancelar.Enabled = false;
                TBC_Usuarios.TabPages.Add(TBP_Lista);
                TBC_Usuarios.TabPages.Remove(TBP_Cadastro);
                BTN_Salvar.Enabled = false;
                BTN_Excluir.Enabled = false;
            }

        }

        private void DGV_Usuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_Usuarios.Rows[e.RowIndex];

                EDT_NomeUsuario.Text = row.Cells["Nome"].Value.ToString();
                EDT_Login.Text = row.Cells["Login"].Value.ToString();
                CBB_Ativo.SelectedIndex = (int)row.Cells["Perfil"].Value == 1 ? 0 : 1;
                CBX_Ativo.Checked = (int)row.Cells["Ativo"].Value == 1;

                TBC_Usuarios.TabPages.Add(TBP_Cadastro);
                TBC_Usuarios.SelectedTab = TBP_Cadastro;
                BTN_Novo.Enabled = false;
                BTN_Cancelar.Enabled = true;
                SetControlsEnabled(TBP_Cadastro, true);
                editMode = 2;
                TBC_Usuarios.TabPages.Remove(TBP_Lista);
                LBL_SenhaVazia.Visible = true;
                BTN_Salvar.Enabled = true;
                BTN_Excluir.Enabled = true;
                EDT_Login.ReadOnly = true;
            }
        }
    }
}
