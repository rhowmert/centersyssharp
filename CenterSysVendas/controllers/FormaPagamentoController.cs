using System;
using System.Collections.Generic;
using models;

namespace controllers
{
    public class FormaPagamentoController
    {
        public void CriarNovaFormaPagamento(string descricao, decimal? valorDiferenca, int tipo, int tipoCredito)
        {
            ValidarCamposObrigatorios(descricao, tipo);

            using (var formaPagamento = new FormaPagamento())
            {
                formaPagamento.Descricao = descricao;
                formaPagamento.ValorDiferenca = valorDiferenca;
                formaPagamento.Tipo = tipo;
                formaPagamento.TipoCredito = tipoCredito;

                formaPagamento.CriarFormaPagamento();
            }
        }

        public void AtualizarFormaPagamentoExistente(int id, string descricao, decimal? valorDiferenca, int tipo,int tipoCredito)
        {
            if (id <= 0)
                throw new ArgumentException("ID da forma de pagamento é inválido!");

            ValidarCamposObrigatorios(descricao, tipo);

            using (var formaPagamento = new FormaPagamento())
            {
                formaPagamento.Id = id;
                formaPagamento.Descricao = descricao;
                formaPagamento.ValorDiferenca = valorDiferenca;
                formaPagamento.Tipo = tipo;
                formaPagamento.TipoCredito = tipoCredito;
                formaPagamento.AtualizarFormaPagamento();
            }
        }

        public void ExcluirFormaPagamento(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID da forma de pagamento é inválido!");

            using (var formaPagamento = new FormaPagamento())
            {
                formaPagamento.ExcluirFormaPagamento(id);
            }
        }

        public List<FormaPagamento> ObterFormasPagamento(string descricao = null, int id = 0)
        {
            using (var formaPagamento = new FormaPagamento())
            {
                return formaPagamento.PesquisarFormaPagamento(descricao,id);
            }
        }

        private void ValidarCamposObrigatorios(string descricao, int tipo)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException("O campo 'Descrição' é obrigatório.");

            if (tipo < 0 || tipo > 2)
                throw new ArgumentException("O campo 'Tipo' deve ser 0 (Nenhum), 1 (Acréscimo) ou 2 (Desconto).");
        }
    }
}
