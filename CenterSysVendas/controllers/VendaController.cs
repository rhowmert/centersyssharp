using System;
using System.Collections.Generic;
using models;

namespace controllers
{
    public class VendaController
    {
        private ProdutoController _produtoController;
        private FormaPagamentoController _formaPagamentoController;

       public VendaController()
        {
            _produtoController = new ProdutoController();   
            _formaPagamentoController = new FormaPagamentoController();
        }


        public void CriarNovaVenda(DateTime dataVenda, int clienteId, decimal valorTotal, int formaPagamentoId, int recorrente, string descProduto,int tipoCredito)
        {
            if (clienteId <= 0)
                throw new ArgumentException("Cliente inválido");

            if (valorTotal <= 0)
                throw new ArgumentException("Valor total inválido");


            if (formaPagamentoId <= 0)
                throw new ArgumentException("Forma de pagamento inválido");


            using (var venda = new Venda())
            {
                venda.DataVenda = dataVenda;
                venda.ClienteId = clienteId;
                venda.ValorTotal = valorTotal;
                venda.FormaPagamentoId = formaPagamentoId;
                venda.Recorrente = recorrente;
                venda.TipoCredito = tipoCredito;
                venda.DescricaoProduto = descProduto;
                
                if(!venda.CriarVenda())
                    throw new ArgumentException("Erro ao registrar venda!");

            }
        }

        public void AtualizarVendaExistente(int id, DateTime dataVenda, int clienteId, decimal valorTotal, int formaPagamentoId, int recorrente)
        {
            if (id <= 0)
                throw new ArgumentException("ID de venda inválido!");

            using (var venda = new Venda())
            {
                venda.Id = id;
                venda.DataVenda = dataVenda;
                venda.ClienteId = clienteId;
                venda.ValorTotal = valorTotal;
                venda.FormaPagamentoId = formaPagamentoId;
                venda.Recorrente = recorrente;
                venda.AtualizarVenda();
            }
        }

        public void ExcluirVenda(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de venda inválido!");

            using (var venda = new Venda())
            {
                venda.ExcluirVenda(id);
            }
        }

        public List<Venda> ObterVendas(string nomeCliente = null)
        {
            using (var venda = new Venda())
            {
                return venda.PesquisarVendas(nomeCliente);
            }
        }

        public decimal CalcularValorTotal(int produtoId, int formaPagamentoId)
        {
            try
            {
                var produto = _produtoController.ObterProdutos(null, produtoId).FirstOrDefault();
                var formaPagamento = _formaPagamentoController.ObterFormasPagamento(null, formaPagamentoId).FirstOrDefault();

                if (produto != null && formaPagamento != null)
                {
                    decimal valorDiferenca = formaPagamento.ValorDiferenca.HasValue ? formaPagamento.ValorDiferenca.Value : 0;
                    decimal precoProduto = produto.PrecoFinal.HasValue ? produto.PrecoFinal.Value : 0;

                    decimal valorTotal;
                    decimal percentual;

                    if (valorDiferenca > 0)
                    {
                        percentual = (valorDiferenca / 100);
                        valorTotal = percentual * precoProduto;
                        valorTotal = valorTotal + precoProduto;
                    }
                    else
                    {
                        valorTotal = precoProduto;
                    }

                    return valorTotal;
                }
            }
            catch(Exception ex)
            {  
            
            }
            return 0;
        }
    }
}
