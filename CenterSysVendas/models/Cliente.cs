using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using helpers;

namespace models
{
    public class Cliente : IDisposable
    {
        private DbConn _dbConn;
        private MySqlConnection _connection;

        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public int CidadeId { get; set; }
        public int UsuarioId { get; set; } 
        public int Situacao { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }

        public Cliente()
        {
            _dbConn = new DbConn();
            _connection = _dbConn.GetConnection();
        }

        public void CriarCliente()
        {
            var query = @"INSERT INTO cliente (nome_cliente, cpf, dat_nascimento, cep, logradouro, numero, cidade_id, usuarios_id, situacao,complemento) 
                          VALUES (@NomeCliente, @CPF, @DataNascimento, @CEP, @Logradouro, @Numero, @CidadeId, @UsuarioId, @Situacao,@Complemento)";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@NomeCliente", NomeCliente);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@DataNascimento", DataNascimento);
                cmd.Parameters.AddWithValue("@CEP", CEP);
                cmd.Parameters.AddWithValue("@Logradouro", Logradouro);
                cmd.Parameters.AddWithValue("@Numero", Numero);
                cmd.Parameters.AddWithValue("@CidadeId", CidadeId);
                cmd.Parameters.AddWithValue("@UsuarioId", UsuarioId);
                cmd.Parameters.AddWithValue("@Situacao", Situacao);
                cmd.Parameters.AddWithValue("@Complemento", Complemento);
                cmd.Parameters.AddWithValue("@Bairro", Bairro);

                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarCliente()
        {
            var query = @"UPDATE cliente 
                          SET nome_cliente = @NomeCliente, cpf = @CPF, dat_nascimento = @DataNascimento, 
                              cep = @CEP, logradouro = @Logradouro, numero = @Numero, cidade_id = @CidadeId, 
                              situacao = @Situacao, bairro = @Bairro 
                          WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@NomeCliente", NomeCliente);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@DataNascimento", DataNascimento);
                cmd.Parameters.AddWithValue("@CEP", CEP);
                cmd.Parameters.AddWithValue("@Logradouro", Logradouro);
                cmd.Parameters.AddWithValue("@Numero", Numero);
                cmd.Parameters.AddWithValue("@CidadeId", CidadeId);
                cmd.Parameters.AddWithValue("@Situacao", Situacao);
                cmd.Parameters.AddWithValue("@Complemento", Complemento);
                cmd.Parameters.AddWithValue("@Bairro", Bairro);
                cmd.Parameters.AddWithValue("@UsuarioId", UsuarioId);

                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirCliente(int id)
        {
            var query = "DELETE FROM cliente WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Cliente> PesquisarClientes(string nome = null, string cpf = null,  bool inativos = true)
        {
            var clientes = new List<Cliente>();
            var query = "SELECT * FROM cliente WHERE 1=1";
            if (!string.IsNullOrEmpty(nome))
                query += " AND nome_cliente LIKE @Nome";
            if (!string.IsNullOrEmpty(cpf))
                query += " AND cpf LIKE @CPF";                                   
            if (inativos == false)
                query += " AND situacao <> 0 ";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                if (!string.IsNullOrEmpty(nome))
                    cmd.Parameters.AddWithValue("@Nome", $"%{nome}%");
                if (!string.IsNullOrEmpty(cpf))
                    cmd.Parameters.AddWithValue("@CPF", $"%{cpf}%");

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        Id = reader.GetInt32("id"),
                        NomeCliente = reader.GetString("nome_cliente"),
                        CPF = reader.GetString("cpf"),
                        DataNascimento = reader.GetDateTime("dat_nascimento"),
                        CEP = reader.IsDBNull(reader.GetOrdinal("cep")) ? null : reader.GetString("cep"),
                        Logradouro = reader.IsDBNull(reader.GetOrdinal("logradouro")) ? null : reader.GetString("logradouro"),
                        Numero = reader.IsDBNull(reader.GetOrdinal("numero")) ? null : reader.GetString("numero"),
                        CidadeId = reader.GetInt32("cidade_id"),
                        UsuarioId = reader.GetInt32("usuarios_id"),
                        Situacao = reader.GetInt32("situacao"),
                        Complemento = reader.GetString("complemento"),
                        Bairro = reader.GetString("bairro")
                    });
                }
            }
            return clientes;
        }

        public void Dispose()
        {
            _dbConn.Dispose();
        }
    }
}
