using System;
using System.Collections.Generic;
using helpers;
using MySql.Data.MySqlClient;

namespace models
{
    public class Produto : IDisposable
    {

        private DbConn _dbConn;
        private MySqlConnection _connection;

        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal? PrecoFinal { get; set; }
        public int PlanoRecorrente { get; set; }

        public Produto()
        {
            _dbConn = new DbConn();
            _connection = _dbConn.GetConnection();
        }

        public void CriarProduto()
        {
            var query = "INSERT INTO produtos (nome_produto, preco_final, plano_recorrente) VALUES (@NomeProduto, @PrecoFinal, @PlanoRecorrente)";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@NomeProduto", NomeProduto);
                cmd.Parameters.AddWithValue("@PrecoFinal", PrecoFinal);
                cmd.Parameters.AddWithValue("@PlanoRecorrente", PlanoRecorrente);
                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarProduto()
        {
            var query = "UPDATE produtos SET nome_produto = @NomeProduto, preco_final = @PrecoFinal, plano_recorrente = @PlanoRecorrente WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@NomeProduto", NomeProduto);
                cmd.Parameters.AddWithValue("@PrecoFinal", PrecoFinal);
                cmd.Parameters.AddWithValue("@PlanoRecorrente", PlanoRecorrente);
                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirProduto(int id)
        {
            var query = "DELETE FROM produtos WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Produto> PesquisarProdutos(string nome = null, int? id = null)
        {
            var produtos = new List<Produto>();
            var query = "SELECT * FROM produtos WHERE 1=1";

            if (!string.IsNullOrEmpty(nome))
                query += " AND nome_produto LIKE @Nome";
            if (id.HasValue)
                query += " AND id = @Id";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                if (!string.IsNullOrEmpty(nome))
                    cmd.Parameters.AddWithValue("@Nome", $"%{nome}%");
                if (id.HasValue)
                    cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produtos.Add(new Produto
                        {
                            Id = reader.GetInt32("id"),
                            NomeProduto = reader["nome_produto"] as string,
                            PrecoFinal = reader["preco_final"] as decimal?,
                            PlanoRecorrente = reader.GetInt32("plano_recorrente")
                        });
                    }
                }
            }

            return produtos;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
