using System;
using System.Collections.Generic;
using models;

namespace controllers
{
    public class CidadeController
    {
        public void CriarNovaCidade(string nome, string codigoIBGE, string uf)
        {
            ValidarCamposObrigatorios(nome, codigoIBGE, uf);

            using (var cidade = new Cidade())
            {
                cidade.Nome = nome;
                cidade.CodigoIBGE = codigoIBGE;
                cidade.UfSigla = uf;
                cidade.CriarCidade();
            }
        }

        public void AtualizarCidadeExistente(int id, string nome, string codigoIBGE, string uf)
        {
            if (id <= 0)
                throw new ArgumentException("ID da cidade é inválido!");

            ValidarCamposObrigatorios(nome, codigoIBGE, uf);

            using (var cidade = new Cidade())
            {
                cidade.Id = id;
                cidade.Nome = nome;
                cidade.CodigoIBGE = codigoIBGE;
                cidade.UfSigla = uf;
                cidade.AtualizarCidade();
            }
        }

        public void ExcluirCidade(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID da cidade é inválido!");

            using (var cidade = new Cidade())
            {
                cidade.ExcluirCidade(id);
            }
        }

        public List<Cidade> ObterCidades(string nome = null, string codigoIBGE = null)
        {
            using (var cidade = new Cidade())
            {
                return cidade.PesquisarCidades(nome, codigoIBGE);
            }
        }

        private void ValidarCamposObrigatorios(string nome, string codigoIBGE, string uf)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O campo 'Nome' é obrigatório.");

            if (string.IsNullOrEmpty(codigoIBGE))
                throw new ArgumentException("O campo 'Código IBGE' é obrigatório.");

            if (string.IsNullOrEmpty(uf) || uf.Length != 2)
                throw new ArgumentException("O campo 'UF' é obrigatório e deve ter 2 caracteres.");
        }

        public int? ObterIdCidadePorIBGE(string ibge)
        {
            using (var cidade = new Cidade())
            {
                return cidade.ObterIdCidadePorIBGE(ibge);
            }
        }

        public (string Nome, string UfSigla, string ibge) ObterCidadePorId(int id)
        {
            using (var cidade = new Cidade())
            {
                return cidade.ObterCidadePorId(id);
            }
        }


    }
}
