using System;
using System.Collections.Generic;
using models;

namespace controllers
{
    public class UsuarioController
    {
        public List<Usuario> ObterUsuarios(string nome = null, uint? id = null, bool apenasAtivos = false)
        {
            using (var model = new Usuario())
            {
               
                List<Usuario> usuarios;

                if (!string.IsNullOrEmpty(nome) || id.HasValue)
                {
                    usuarios = model.PesquisarUsuarios(nome, id);
                }
                else
                {                    
                    usuarios = model.PesquisarUsuarios();
                }

                if (apenasAtivos)
                {
                    usuarios = usuarios.FindAll(u => u.Ativo == 1);
                }

                return usuarios;
            }
        }

        public void CriarNovoUsuario(string nome, string login, string senha, int perfil, int ativo)
        {
            validacao(nome, login, senha, perfil);

            using (var model = new Usuario())
            {
                model.Nome = nome;
                model.Login = login;
                model.Senha = senha;
                model.Ativo = ativo;
                model.Perfil = perfil;
                model.CriarUsuario();
            }
        }

        public void AtualizarUsuarioExistente(uint id, string nome, string login, string senha, int ativo, int perfil)
        {
            if (id == 0)
                throw new ArgumentException("ID do usuário inválido!");                    

            validacao(nome, login, senha, perfil, false);

            using (var model = new Usuario())
            {
                model.Id = id;
                model.Nome = nome;
                model.Login = login;

                if (senha != "")
                    model.Senha = senha;

                model.Ativo = ativo;
                model.Perfil = perfil;
                model.AtualizarUsuario();
            }
        }

        public void ExcluirUsuario(uint id)
        {
            if (id == 0)
                throw new ArgumentException("ID do usuário inválido!");

            using (var model = new Usuario())
            {
                model.Id = id;
                model.ExcluirUsuario();
            }
        }

        private void validacao(string nome, string login, string senha, int perfil, bool validasenha = true)
        {
            switch (true)
            {
                case var _ when string.IsNullOrEmpty(nome):
                    throw new ArgumentException("O campo 'Nome' é obrigatório e não pode estar vazio.");

                case var _ when string.IsNullOrEmpty(login):
                    throw new ArgumentException("O campo 'Login' é obrigatório e não pode estar vazio.");

                case var _ when string.IsNullOrEmpty(senha) && validasenha == true:
                    throw new ArgumentException("O campo 'Senha' é obrigatório e não pode estar vazio.");

                case var _ when perfil < 1 || perfil > 2:
                    throw new ArgumentException("O campo 'Perfil' Administrador ou Usuário");

                default:
                    break;
            }
        }


        public bool login(string login, string senha)
        {            
            using (var model = new Usuario())
            {
                model.Login = login;
                model.Senha = senha;    
                return model.login();                
            }

        }
        
        public int PegaIdPeloLogin(string login)
        {
            using (var model = new Usuario())
            {
                model.Login = login;
                return (int)model.Id;
            }

        }
    }
}
