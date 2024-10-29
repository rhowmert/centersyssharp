using System;
using System.Collections.Generic;
using models;

namespace controllers
{
    public class ClienteController
    {
        public void CriarNovoCliente(string nome, string cpf, DateTime dataNascimento, string cep, string logradouro, string numero, int cidadeId, int situacao, string complemento, string bairro)
        {
            ValidarCamposObrigatorios(nome, cpf, dataNascimento, cidadeId);

            using (var cliente = new Cliente())
            {
                cliente.NomeCliente = nome;
                cliente.CPF = cpf;
                cliente.DataNascimento = dataNascimento;
                cliente.CEP = cep;
                cliente.Logradouro = logradouro;
                cliente.Numero = numero;
                cliente.CidadeId = cidadeId;
                cliente.Situacao = situacao;
                cliente.Complemento = complemento;
                cliente.Bairro = bairro;
                cliente.UsuarioId = helpers.Globais.UsuarioId;
                cliente.CriarCliente();
            }
        }

        public void AtualizarClienteExistente(int id, string nome, string cpf, DateTime dataNascimento, string cep, string logradouro, string numero, int cidadeId, int situacao, string complemento, string bairro)
        {
            if (id <= 0)
                throw new ArgumentException("ID do cliente é inválido!");

            ValidarCamposObrigatorios(nome, cpf, dataNascimento, cidadeId);

            using (var cliente = new Cliente())
            {
                cliente.Id = id;
                cliente.NomeCliente = nome;
                cliente.CPF = cpf;
                cliente.DataNascimento = dataNascimento;
                cliente.CEP = cep;
                cliente.Logradouro = logradouro;
                cliente.Numero = numero;
                cliente.CidadeId = cidadeId;
                cliente.Situacao = situacao;
                cliente.Complemento = complemento;
                cliente.Bairro = bairro;
                cliente.UsuarioId = helpers.Globais.UsuarioId ;
                cliente.AtualizarCliente();
            }
        }

        public void ExcluirCliente(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID do cliente é inválido!");

            using (var cliente = new Cliente())
            {
                cliente.ExcluirCliente(id);
            }
        }

        public List<Cliente> ObterClientes(string nome = null, string cpf = null, bool inativos = true)
        {
            using (var cliente = new Cliente())
            {
                return cliente.PesquisarClientes(nome, cpf, inativos);
            }
        }

        private void ValidarCamposObrigatorios(string nome, string cpf, DateTime dataNascimento, int cidadeId)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O campo 'Nome do Cliente' é obrigatório.");

            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException("O campo 'CPF' é obrigatório.");

            if (dataNascimento == default(DateTime))
                throw new ArgumentException("O campo 'Data de Nascimento' é obrigatório.");

            if (cidadeId <= 0)
                throw new ArgumentException("O campo 'Cidade' é obrigatório.");
        }

        public int CadastraCidadeInexistente(string ibge, string nome, string uf)
        {
            int cidadeId = 0;            
            CidadeController cidadeController = new CidadeController();
            cidadeController.CriarNovaCidade(nome, ibge, uf);
            cidadeId = (int)cidadeController.ObterIdCidadePorIBGE(ibge);
            return cidadeId;
        }
    }
}
