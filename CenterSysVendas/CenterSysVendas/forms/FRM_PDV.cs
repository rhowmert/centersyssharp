using helpers;
using models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using controllers;


namespace CenterSysVendas.forms
{
    public partial class FRM_PDV : Form
    {
        ClienteController _clienteController;
        ProdutoController _produtoController;
        FormaPagamentoController _formaPagamentoController;
        VendaController _vendaController;


        public FRM_PDV()
        {
            InitializeComponent();
        }

        private void FRM_PDV_Load(object sender, EventArgs e)
        {
            _clienteController = new ClienteController();
            _produtoController = new ProdutoController();
            _formaPagamentoController = new FormaPagamentoController();
            _vendaController = new VendaController();
            loader();
        }


        private void loader()
        {
            var listaClientes = _clienteController.ObterClientes(null, null, false);
            var listaProdutos = _produtoController.ObterProdutos();
            var listaFormaPagamento = _formaPagamentoController.ObterFormasPagamento();



            var clientesLista = listaClientes.Select(cliente => new
            {
                Id = cliente.Id,
                DescricaoCompleta = $"{cliente.NomeCliente} -  CPF:{cliente.CPF:F2}"
            }).ToList();

            clientesLista.Insert(0, new { Id = -1, DescricaoCompleta = "Selecione um Cliente" });
            CBB_Cliente.DataSource = clientesLista;
            CBB_Cliente.DisplayMember = "DescricaoCompleta";
            CBB_Cliente.ValueMember = "Id";
            CBB_Cliente.SelectedIndex = 0;


            var produtoslista = listaProdutos.Select(produto => new
            {
                Id = produto.Id,
                DescricaoCompleta = $"{produto.NomeProduto} - R$ {produto.PrecoFinal:F2}"
            }).ToList();

            produtoslista.Insert(0, new { Id = -1, DescricaoCompleta = "Selecione um Produto" });
            CBB_Produto.DataSource = produtoslista;
            CBB_Produto.DisplayMember = "DescricaoCompleta";
            CBB_Produto.ValueMember = "Id";
            CBB_Produto.SelectedIndex = 0;


            var formapagamentolista = listaFormaPagamento.Select(formapagamento => new
            {
                Id = formapagamento.Id,
                DescricaoCompleta = $"{formapagamento.Descricao} - % {formapagamento.ValorDiferenca:F2}"
            }).ToList();
            formapagamentolista.Insert(0, new { Id = -1, DescricaoCompleta = "Selecione uma Forma de Pagamento" });
            CBB_FormaPagamento.DataSource = formapagamentolista;
            CBB_FormaPagamento.DisplayMember = "DescricaoCompleta";
            CBB_FormaPagamento.ValueMember = "Id";
            CBB_FormaPagamento.SelectedIndex = 0;

            AtualizaValorTotal();

        }

        private void CBB_FormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaValorTotal();
        }

        private void AtualizaValorTotal()
        {
            try
            {
                int formaPagamentoId = 0;
                int produtoId = 0;
                
                
                if(CBB_Produto !=null && CBB_Produto.SelectedValue != null)
                produtoId = (int)CBB_Produto.SelectedValue;

                if(CBB_FormaPagamento != null && CBB_FormaPagamento.SelectedValue != null)
                formaPagamentoId = (int)CBB_FormaPagamento.SelectedValue;

                decimal valorTotal = _vendaController.CalcularValorTotal(produtoId, formaPagamentoId);
                NUD_ValorTotal.Value = valorTotal;
            }
            catch (Exception ex)
            {

            }
        }


        private void CBB_Produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaValorTotal();
        }

        private void BTN_GerarVenda_Click(object sender, EventArgs e)
        {
            int cliId = (int)CBB_Cliente.SelectedValue;
            DateTime dataVenda = DateTime.Now;
            decimal valorTotal = NUD_ValorTotal.Value;
            var fpag = _formaPagamentoController.ObterFormasPagamento(null, (int)CBB_FormaPagamento.SelectedValue).FirstOrDefault();
            var prod = _produtoController.ObterProdutos(null, (int)CBB_Produto.SelectedValue).FirstOrDefault();


            if (cliId <= 0)
            {
                MessageBox.Show("Erro: Precisa selecionar um cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (fpag.Id <= 0 || fpag == null)
            {
                MessageBox.Show("Erro: Precisa selecionar uma forma de pagamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (prod.Id <= 0 || prod == null)
            {
                MessageBox.Show("Erro: Precisa selecionar um produto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _vendaController.CriarNovaVenda(dataVenda, cliId, valorTotal, fpag.Id, prod.PlanoRecorrente, prod.NomeProduto, fpag.TipoCredito);
                MessageBox.Show("Venda gerada com sucesso!", "Parabéns!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {                
                CBB_Cliente.SelectedIndex = -1;
                CBB_FormaPagamento.SelectedIndex = -1;
                CBB_Produto.SelectedIndex = -1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Deseja realmente sair?",
              "Confirmação",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
              );
            if (result == DialogResult.Yes)
                this.Close();
        }
    }
}
