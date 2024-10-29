using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using helpers;
using System.Security.Cryptography;

namespace models
{
    public class Usuario : IDisposable
    {
        private DbConn _dbConn;
        private MySqlConnection _connection;

        public uint Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Ativo { get; set; }
        public int Perfil { get; set; }

        public Usuario()
        {
            _dbConn = new DbConn();
            _connection = _dbConn.GetConnection();
        }

        public List<Usuario> PesquisarUsuarios(string nome = null, uint? id = null)
        {
            var usuarios = new List<Usuario>();
            var query = "SELECT * FROM usuarios WHERE 1=1";

            // Verifica se há filtros por nome ou ID
            if (!string.IsNullOrEmpty(nome))
                query += " AND nome LIKE @Nome";
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
                        usuarios.Add(new Usuario
                        {
                            Id = reader.GetUInt32("id"),
                            Nome = reader.GetString("nome"),
                            Login = reader.GetString("login"),
                            Senha = reader.GetString("senha"),
                            Ativo = reader.GetInt32("ativo"),
                            Perfil = reader.GetInt32("perfil")
                        });
                    }
                }
            }
            return usuarios;
        }

        
        public void CriarUsuario()
        {
            Senha = helpers.MD5Helper.ConvertToMD5(Senha+Login);
            
            var query = "INSERT INTO usuarios (nome, login, senha, ativo, perfil) VALUES (@Nome, @Login, @Senha, @Ativo, @Perfil)";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Login", Login);
                cmd.Parameters.AddWithValue("@Senha", Senha);
                cmd.Parameters.AddWithValue("@Ativo", Ativo);
                cmd.Parameters.AddWithValue("@Perfil", Perfil);

                cmd.ExecuteNonQuery();
                Id = (uint)cmd.LastInsertedId;
            }
        }


        public void AtualizarUsuario()
        {
            Senha = helpers.MD5Helper.ConvertToMD5(Senha + Login);

            var query = "UPDATE usuarios SET nome = @Nome, login = @Login, ativo = @Ativo, perfil = @Perfil";

            if (!string.IsNullOrEmpty(Senha))
            {
                query += ", senha = @Senha";
            }

            query += " WHERE id = @Id";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Login", Login);
                cmd.Parameters.AddWithValue("@Ativo", Ativo);
                cmd.Parameters.AddWithValue("@Perfil", Perfil);

                if (!string.IsNullOrEmpty(Senha))
                {
                    cmd.Parameters.AddWithValue("@Senha", Senha);
                }

                cmd.ExecuteNonQuery();
            }
        }


        public void ExcluirUsuario()
        {
            var query = "DELETE FROM usuarios WHERE id = @Id";
            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }



        public bool login()
        {
            Senha = helpers.MD5Helper.ConvertToMD5(Senha+Login);

            var query = "SELECT * FROM usuarios WHERE login =@Login and senha = @Senha";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                if (!string.IsNullOrEmpty(Login))
                    cmd.Parameters.AddWithValue("@Login", $"{Login}");
                if (!string.IsNullOrEmpty(Senha))
                    cmd.Parameters.AddWithValue("@Senha", $"{Senha}");


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Id = reader.GetUInt32("id");
                        if(Id>0)
                            return true;
                        else
                            return false;
                    }
                }

                
            }
            return false;
        }



        public int getIdByLogin()
        {
            var query = "SELECT * FROM usuarios WHERE login =@Login and senha = @Senha";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                if (!string.IsNullOrEmpty(Login))
                    cmd.Parameters.AddWithValue("@Login", $"{Login}");
                if (!string.IsNullOrEmpty(Senha))
                    cmd.Parameters.AddWithValue("@Senha", $"{Senha}");


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return  (int)reader.GetUInt32("id");
                    }
                }


            }
            return 0;
        }


        public void Dispose()
        {
            _dbConn.Dispose();
        }
    }
}
