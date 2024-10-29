using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using helpers;

namespace models
{
    public class Venda : IDisposable
    {
        private DbConn _dbConn;

        private MySqlConnection _connection;
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public int FormaPagamentoId { get; set; }
        public int Recorrente { get; set; }
        public int TipoCredito {  get; set; }
        public string DescricaoProduto { get; set; }

        public Venda()
        {
            _dbConn = new DbConn();
            _connection = _dbConn.GetConnection();
        }

        public bool CriarVenda()
        {

            try
            {
                if (Recorrente == 1 && TipoCredito == 1)
                {
                    CriarAssinatura();                        
                }


                var query = "INSERT INTO vendas (data_venda, cliente_id, vlr_total, forma_pagamento_id, recorrente) " +
                            "VALUES (@DataVenda, @ClienteId, @ValorTotal, @FormaPagamentoId, @Recorrente)";

                using (var cmd = new MySqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@DataVenda", DataVenda);
                    cmd.Parameters.AddWithValue("@ClienteId", ClienteId);
                    cmd.Parameters.AddWithValue("@ValorTotal", ValorTotal);
                    cmd.Parameters.AddWithValue("@FormaPagamentoId", FormaPagamentoId);
                    cmd.Parameters.AddWithValue("@Recorrente", Recorrente);

                    cmd.ExecuteNonQuery();
                    Id = (int)cmd.LastInsertedId;
                }

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public void AtualizarVenda()
        {
            var query = "UPDATE vendas SET data_venda = @DataVenda, cliente_id = @ClienteId, vlr_total = @ValorTotal, " +
                        "forma_pagamento_id = @FormaPagamentoId, recorrente = @Recorrente WHERE id = @Id";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@DataVenda", DataVenda);
                cmd.Parameters.AddWithValue("@ClienteId", ClienteId);
                cmd.Parameters.AddWithValue("@ValorTotal", ValorTotal);
                cmd.Parameters.AddWithValue("@FormaPagamentoId", FormaPagamentoId);
                cmd.Parameters.AddWithValue("@Recorrente", Recorrente);

                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirVenda(int id)
        {
            var query = "DELETE FROM vendas WHERE id = @Id";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Venda> PesquisarVendas(string nomeCliente = null)
        {
            var vendas = new List<Venda>();
            var query = "SELECT v.*, c.nome_cliente FROM vendas v " +
                        "JOIN cliente c ON c.id = v.cliente_id WHERE 1 = 1";

            if (!string.IsNullOrEmpty(nomeCliente))
                query += " AND c.nome_cliente LIKE @NomeCliente";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                if (!string.IsNullOrEmpty(nomeCliente))
                    cmd.Parameters.AddWithValue("@NomeCliente", $"%{nomeCliente}%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendas.Add(new Venda
                        {
                            Id = reader.GetInt32("id"),
                            DataVenda = reader.GetDateTime("data_venda"),
                            ClienteId = reader.GetInt32("cliente_id"),
                            ValorTotal = reader.GetDecimal("vlr_total"),
                            FormaPagamentoId = reader.GetInt32("forma_pagamento_id"),
                            Recorrente = reader.GetInt32("recorrente")
                        });
                    }
                }
            }
            return vendas;
        }

        private void CriarAssinatura()
        {
            helpers.ApiHelper.CriarAssinatura(ClienteId, ValorTotal, DescricaoProduto);
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
