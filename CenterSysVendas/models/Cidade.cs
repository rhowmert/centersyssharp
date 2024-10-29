using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using helpers;

namespace models
{
    public class Cidade : IDisposable
    {
        private DbConn _dbConn;
        private MySqlConnection _connection;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoIBGE { get; set; }
        public string UfSigla { get; set; }

        public Cidade()
        {
            _dbConn = new DbConn();
            _connection = _dbConn.GetConnection();
        }

        public void CriarCidade()
        {
            var query = "INSERT INTO cidade (nome, codigo_ibge, uf_sigla) VALUES (@Nome, @CodigoIBGE, @UfSigla)";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@CodigoIBGE", CodigoIBGE);
                cmd.Parameters.AddWithValue("@UfSigla", UfSigla);
                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarCidade()
        {
            var query = "UPDATE cidade SET nome = @Nome, codigo_ibge = @CodigoIBGE, uf_sigla = @UfSigla WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@CodigoIBGE", CodigoIBGE);
                cmd.Parameters.AddWithValue("@UfSigla", UfSigla);
                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirCidade(int id)
        {
            var query = "DELETE FROM cidade WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Cidade> PesquisarCidades(string nome = null, string codigoIBGE = null)
        {
            var cidades = new List<Cidade>();
            var query = "SELECT * FROM cidade WHERE 1=1";
            if (!string.IsNullOrEmpty(nome))
                query += " AND nome LIKE @Nome";
            if (!string.IsNullOrEmpty(codigoIBGE))
                query += " AND codigo_ibge LIKE @CodigoIBGE";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                if (!string.IsNullOrEmpty(nome))
                    cmd.Parameters.AddWithValue("@Nome", $"%{nome}%");
                if (!string.IsNullOrEmpty(codigoIBGE))
                    cmd.Parameters.AddWithValue("@CodigoIBGE", $"%{codigoIBGE}%");

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cidades.Add(new Cidade
                    {
                        Id = reader.GetInt32("id"),
                        Nome = reader.GetString("nome"),
                        CodigoIBGE = reader.GetString("codigo_ibge"),
                        UfSigla = reader.IsDBNull(reader.GetOrdinal("uf_sigla")) ? null : reader.GetString("uf_sigla")
                    });
                }
            }
            return cidades;
        }


        public int? ObterIdCidadePorIBGE(string codigoIBGE)
        {
            int? id = 0;
            var query = "SELECT id FROM cidade WHERE codigo_ibge = @CodigoIBGE";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@CodigoIBGE", codigoIBGE);

                using (var reader = cmd.ExecuteReader())
                {
                    try
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32("id");
                        }
                    }
                    finally
                    {
                        if (!reader.IsClosed)
                            reader.Close();                            
                    }
                }
            }

            return id;
        }


        public (string Nome, string UfSigla, string ibge) ObterCidadePorId(int id)
        {
            string nomeCidade = "";
            string ufSigla = "";
            string ibge = "";

            var query = "SELECT nome, uf_sigla,codigo_ibge FROM cidade WHERE id = @id";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nomeCidade = reader.GetString("nome");
                        ufSigla = reader.GetString("uf_sigla");
                        ibge = reader.GetString("codigo_ibge");
                    }
                }
            }

            return (nomeCidade, ufSigla, ibge);
        }



        public void Dispose()
        {
            _dbConn.Dispose();
        }
    }
}
