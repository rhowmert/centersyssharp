using System;
using System.Collections.Generic;
using System.Windows.Forms;
using controllers;
using helpers;
using models;

namespace CenterSysVendas.forms
{
    public partial class FRM_Clientes : Form
    {
        private ClienteController _clienteController;
        int editMode = 0;
        int cidadeId = 0;
        string codigoIBGE = null;
        public FRM_Clientes()
        {
            InitializeComponent();
            _clienteController = new ClienteController();
        }

        private void FRM_Clientes_Load(object sender, EventArgs e)
        {
            TBC_Clientes.TabPages.Remove(TBP_CadastroClientes);
            TBC_Clientes.TabPages.Remove(TBP_PesqCidades);
            CarregarClientes();
        }

        private void BTN_Novo_Click(object sender, EventArgs e)
        {
            LimparCamposEdicao();
            TBC_Clientes.TabPages.Add(TBP_CadastroClientes);
            TBC_Clientes.SelectedTab = TBP_CadastroClientes;
            BTN_Novo.Enabled = false;
            BTN_Cancelar.Enabled = true;
            BTN_Salvar.Enabled = true;
            SetControlsEnabled(TBP_CadastroClientes, true);
            editMode = 1;
            TBC_Clientes.TabPages.Remove(TBP_ListaClientes);
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            string tipoEdicao = editMode == 1 ? "inclusão" : "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Deseja realmente cancelar a {tipoEdicao} do cliente?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    SetControlsEnabled(TBP_CadastroClientes, false);
                    TBC_Clientes.SelectedTab = TBP_ListaClientes;
                    BTN_Novo.Enabled = true;
                    BTN_Cancelar.Enabled = false;
                    TBC_Clientes.TabPages.Add(TBP_ListaClientes);
                    TBC_Clientes.TabPages.Remove(TBP_CadastroClientes);
                    editMode = 0;
                    BTN_Salvar.Enabled = false;
                    BTN_Excluir.Enabled = false;
                }
            }
        }

        private void BTN_Sair_Click(object sender, EventArgs e)
        {
            string tipoEdicao = editMode == 1 ? "inclusão" : "edição";

            if (editMode != 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Deseja realmente cancelar a {tipoEdicao} do cliente?",
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

        private void CarregarClientes(string nomeFiltro = null, string cpfFiltro = null,bool inativos = true)
        {
            inativos =  CBX_Inativos.Checked;
            List<Cliente> listaClientes = _clienteController.ObterClientes(nomeFiltro, cpfFiltro, inativos);
            DGV_Clientes.DataSource = listaClientes;
            NomesColunas();
        }

        private void LimparCamposEdicao()
        {
            foreach (Control control in TBP_CadastroClientes.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
                if (control is MaskedTextBox mktextBox)
                {
                    mktextBox.Clear();
                }
            }
        }

        private void BTN_Salvar_Click(object sender, EventArgs e)
        {
            CidadeController cidade = new CidadeController();

            int cidadeId = 0;

            try
            {
                string nome = EDT_Nome.Text;
                string cpf = EDT_CPF.Text;
                DateTime dataNascimento = DateTime.Parse(EDT_DataNascimento.Text);
                string cep = EDT_CEP.Text;
                string logradouro = EDT_Logradouro.Text;
                string numero = EDT_Numero.Text;
                string bairro = EDT_Bairro.Text;

                if (cidade.ObterIdCidadePorIBGE(codigoIBGE) == 0)
                {
                    _clienteController.CadastraCidadeInexistente(codigoIBGE, EDT_Municipio.Text, EDT_UF.Text);
                }

                cidadeId = cidade.ObterIdCidadePorIBGE(codigoIBGE) ?? 0;


                int situacao = CBX_ClienteAtivo.Checked ? 1 : 0;
                
                string complemento = EDT_Complemento.Text;

                if (editMode == 1)
                {
                    _clienteController.CriarNovoCliente(nome, cpf, dataNascimento, cep, logradouro, numero, cidadeId, situacao, complemento,bairro);
                    MessageBox.Show("Cliente criado com sucesso!");
                }
                else if (editMode == 2)
                {
                    int id = Convert.ToInt32(DGV_Clientes.CurrentRow.Cells["Id"].Value);
                    _clienteController.AtualizarClienteExistente(id, nome, cpf, dataNascimento, cep, logradouro, numero, cidadeId, situacao, complemento,bairro);
                    MessageBox.Show("Cliente atualizado com sucesso!");
                }

                CarregarClientes();
                TBC_Clientes.TabPages.Add(TBP_ListaClientes);
                TBC_Clientes.TabPages.Remove(TBP_CadastroClientes);
                TBC_Clientes.SelectedTab = TBP_ListaClientes;                
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

        private void BTN_Excluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DGV_Clientes.CurrentRow.Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                  $"Deseja realmente excluir o cliente {EDT_Nome.Text}?",
                  "Confirmação",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );

            if (result == DialogResult.Yes)
            {
                _clienteController.ExcluirCliente(id);
                CarregarClientes();
                MessageBox.Show("Cliente excluído com sucesso!");
                editMode = 0;
                SetControlsEnabled(TBP_CadastroClientes, false);
                TBC_Clientes.SelectedTab = TBP_ListaClientes;
                BTN_Novo.Enabled = true;
                BTN_Cancelar.Enabled = false;
                TBC_Clientes.TabPages.Add(TBP_ListaClientes);
                TBC_Clientes.TabPages.Remove(TBP_CadastroClientes);
                BTN_Salvar.Enabled = false;
                BTN_Excluir.Enabled = false;
            }
        }

        private void EDT_Pesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarClientes(nomeFiltro: EDT_Pesquisa.Text);
        }

        private void EDT_CPF_Leave(object sender, EventArgs e)
        {
            string cpf = EDT_CPF.Text.Replace(".", "").Replace("-", "").Trim();

            if (cpf.Length == 0)
                return;

            if (!helpers.Utils.ValidarCPF(EDT_CPF.Text))
            {
                MessageBox.Show("CPF Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EDT_CPF.Clear();
                EDT_CPF.Focus();
                return;
            }
        }

        private async void EDT_CEP_Leave(object sender, EventArgs e)
        {
            string cep = EDT_CEP.Text.Replace("-", "").Trim();

            EDT_Logradouro.ReadOnly = true;
            EDT_Bairro.ReadOnly = true;
            EDT_Municipio.ReadOnly = true;
            EDT_UF.ReadOnly = true;


            if (cep.Length == 8 && cep.All(char.IsDigit))
            {
                try
                {
                    var endereco = await helpers.Utils.ObterEnderecoPorCepAsync(cep);

                    if (endereco.Cep != null)
                    {

                        EDT_Logradouro.Text = endereco.Logradouro;
                        EDT_Bairro.Text = endereco.Bairro;
                        EDT_Municipio.Text = endereco.Localidade;
                        EDT_UF.Text = endereco.Uf;
                        codigoIBGE = endereco.Ibge;
                    }

                    EDT_Logradouro.ReadOnly = false;
                    EDT_Bairro.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar endereço: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("CEP inválido. Informe um CEP com 8 dígitos numéricos.");
            }
        }

        private void EDT_CEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("CEP Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            EDT_CEP.Focus();
        }

        private void EDT_DataNascimento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Data de nascimento inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            EDT_DataNascimento.Focus();
        }

        private void BTN_Pesquisar_Click(object sender, EventArgs e)
        {
            BTN_Novo.Visible = false;
            BTN_Salvar.Visible = false;
            BTN_Cancelar.Visible = false;
            BTN_Excluir.Visible = false;
            BTN_Sair.Visible = false;
            CarregarCidades();
            TBC_Clientes.TabPages.Add(TBP_PesqCidades);
            TBC_Clientes.TabPages.Remove(TBP_CadastroClientes);
            BTN_CancelaPesquisaCidade.Enabled = true;
        }

        private void CarregarCidades(string nomeFiltro = null, string codigoIBGEFiltro = null)
        {
            CidadeController _cidadeController = new CidadeController();
            List<Cidade> listaCidades = _cidadeController.ObterCidades(nomeFiltro, codigoIBGEFiltro);
            DGV_Cidades.DataSource = listaCidades;
        }

        private void EDT_PesqCidade_TextChanged(object sender, EventArgs e)
        {
            CarregarCidades(EDT_PesqCidade.Text);
        }

        private void BTN_CancelaPesquisaCidade_Click(object sender, EventArgs e)
        {
            BTN_Novo.Visible = true;
            BTN_Salvar.Visible = true;
            BTN_Cancelar.Visible = true;
            BTN_Excluir.Visible = true;
            BTN_Sair.Visible = true;
            CarregarCidades();
            TBC_Clientes.TabPages.Add(TBP_CadastroClientes);
            TBC_Clientes.TabPages.Remove(TBP_PesqCidades);
        }


        private void DGV_Clientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_Clientes.Columns[e.ColumnIndex].Name == "Situacao" && e.Value != null)
            {
                int ativoValue = (int)e.Value;
                e.Value = ativoValue == 1 ? "Ativo" : "Inativo";
            }
        }



        private void NomesColunas()
        {
            DGV_Clientes.Columns["Situacao"].HeaderText = "Situação";
            DGV_Clientes.Columns["NomeCliente"].HeaderText = "Nome";
            DGV_Clientes.Columns["DataNascimento"].HeaderText = "Nascimento";
            DGV_Clientes.Columns["CidadeId"].Visible = false;
            DGV_Clientes.Columns["CEP"].Visible = false;
            DGV_Clientes.Columns["Numero"].Visible = false;
            DGV_Clientes.Columns["Logradouro"].Visible = false;
            DGV_Clientes.Columns["Bairro"].Visible = false;
            DGV_Clientes.Columns["Complemento"].Visible = false;
            DGV_Clientes.Columns["UsuarioId"].Visible = false;
        }

        private void DGV_Clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CidadeController cidade = new CidadeController();


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_Clientes.Rows[e.RowIndex];

                EDT_Nome.Text = row.Cells["NomeCliente"].Value.ToString();
                EDT_CPF.Text = row.Cells["CPF"].Value.ToString();


                if (row.Cells["DataNascimento"].Value != null && DateTime.TryParse(row.Cells["DataNascimento"].Value.ToString(),
                    out DateTime dataNascimento))
                {
                    EDT_DataNascimento.Text = dataNascimento.ToString("dd/MM/yyyy");
                }


                EDT_CEP.Text = row.Cells["CEP"].Value?.ToString();
                EDT_Logradouro.Text = row.Cells["Logradouro"].Value?.ToString();
                EDT_Numero.Text = row.Cells["Numero"].Value?.ToString();

                cidadeId = (int)row.Cells["CidadeId"].Value;

                var (nome, uf, ibge) = cidade.ObterCidadePorId(cidadeId);

                EDT_Municipio.Text = nome;
                EDT_UF.Text = uf;

                CBX_ClienteAtivo.Checked = (row.Cells["Situacao"].Value.ToString() == "1") ? true : false;

                EDT_Bairro.Text = row.Cells["Bairro"].Value.ToString();
                EDT_Complemento.Text = row.Cells["Complemento"].Value.ToString();

                codigoIBGE = ibge;



                TBC_Clientes.TabPages.Add(TBP_CadastroClientes);
                TBC_Clientes.SelectedTab = TBP_CadastroClientes;
                BTN_Novo.Enabled = false;
                BTN_Cancelar.Enabled = true;
                SetControlsEnabled(TBP_CadastroClientes, true);
                editMode = 2;
                TBC_Clientes.TabPages.Remove(TBP_ListaClientes);
                BTN_Salvar.Enabled = true;
                BTN_Excluir.Enabled = true;
            }
        }

        private void DGV_Cidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LimparCamposEdicao();

                DataGridViewRow row = DGV_Cidades.Rows[e.RowIndex];
                EDT_Municipio.Text = row.Cells["Nome"].Value.ToString();
                EDT_UF.Text = row.Cells["UfSigla"].Value.ToString();
                codigoIBGE = row.Cells["CodigoIBGE"].Value.ToString();
                TBC_Clientes.TabPages.Add(TBP_CadastroClientes);
                TBC_Clientes.TabPages.Remove(TBP_PesqCidades);
                BTN_Novo.Visible = true;
                BTN_Salvar.Visible = true;
                BTN_Cancelar.Visible = true;
                BTN_Excluir.Visible = true;
                BTN_Sair.Visible = true;
            }
        }

        private void CBX_Inativos_CheckedChanged(object sender, EventArgs e)
        {
            CarregarClientes();
        }
    }
}
