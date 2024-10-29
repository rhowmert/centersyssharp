using System;
using System.Collections.Generic;
using models;

namespace controllers
{
    public class ProdutoController
    {
        public void CriarNovoProduto(string nomeProduto, decimal? precoFinal, int planoRecorrente)
        {
            using (var produto = new Produto())
            {
                produto.NomeProduto = nomeProduto;
                produto.PrecoFinal = precoFinal;
                produto.PlanoRecorrente = planoRecorrente;
                produto.CriarProduto();
            }
        }

        public void AtualizarProdutoExistente(int id, string nomeProduto, decimal? precoFinal, int planoRecorrente)
        {
            using (var produto = new Produto())
            {
                produto.Id = id;
                produto.NomeProduto = nomeProduto;
                produto.PrecoFinal = precoFinal;
                produto.PlanoRecorrente = planoRecorrente;
                produto.AtualizarProduto();
            }
        }

        public void ExcluirProduto(int id)
        {
            using (var produto = new Produto())
            {
                produto.ExcluirProduto(id);
            }
        }

        public List<Produto> ObterProdutos(string nome = null, int? id = null)
        {
            using (var produto = new Produto())
            {
                return produto.PesquisarProdutos(nome, id);
            }
        }
    }
}
