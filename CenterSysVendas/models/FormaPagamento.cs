using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using helpers;

namespace models
{
    public class FormaPagamento : IDisposable
    {
        private DbConn _dbConn;
        private MySqlConnection _connection;

        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal? ValorDiferenca { get; set; }
        public int Tipo { get; set; } // 0 - Nenhum, 1 - Acréscimo, 2 - Desconto
        public int TipoCredito { get; set; } // 0 - Não,  1 - Sim

        public FormaPagamento()
        {
            _dbConn = new DbConn();
            _connection = _dbConn.GetConnection();
        }

        public void CriarFormaPagamento()
        {
            var query = @"INSERT INTO forma_pagamento (des_forma_pagamento, vlr_diferenca, tipo) 
                          VALUES (@Descricao, @ValorDiferenca, @Tipo,@TipoCredito)";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Descricao", Descricao);
                cmd.Parameters.AddWithValue("@ValorDiferenca", ValorDiferenca);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@TipoCredito", TipoCredito);

                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarFormaPagamento()
        {
            var query = @"UPDATE forma_pagamento 
                          SET des_forma_pagamento = @Descricao, vlr_diferenca = @ValorDiferenca, tipo = @Tipo , tipoCredito = @TipoCredito
                          WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Descricao", Descricao);
                cmd.Parameters.AddWithValue("@ValorDiferenca", ValorDiferenca);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@TipoCredito", TipoCredito);

                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirFormaPagamento(int id)
        {
            var query = "DELETE FROM forma_pagamento WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<FormaPagamento> PesquisarFormaPagamento(string descricao = null, int id = 0)
        {
            var formasPagamento = new List<FormaPagamento>();
            var query = "SELECT * FROM forma_pagamento WHERE 1=1";
            
            if (!string.IsNullOrEmpty(descricao))
                query += " AND des_forma_pagamento LIKE @Descricao";

            if (id > 0)
                query += " AND id = @Id";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                if (!string.IsNullOrEmpty(descricao))
                    cmd.Parameters.AddWithValue("@Descricao", $"%{descricao}%");
                
                if (id > 0 )
                    cmd.Parameters.AddWithValue("@Id", $"{id}");

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    formasPagamento.Add(new FormaPagamento
                    {
                        Id = reader.GetInt32("id"),
                        Descricao = reader.GetString("des_forma_pagamento"),
                        ValorDiferenca = reader.IsDBNull(reader.GetOrdinal("vlr_diferenca")) ? (decimal?)null : reader.GetDecimal("vlr_diferenca"),
                        Tipo = reader.GetInt32("tipo"),
                        TipoCredito = reader.GetInt32("tipocredito")
                    });
                }
            }
            return formasPagamento;
        }

        public void Dispose()
        {
            _dbConn.Dispose();
        }
    }
}
