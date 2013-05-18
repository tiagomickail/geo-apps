using System;
using System.Linq;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.Models;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Responses;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices
{
    public class UsuarioService : IUsuarioService
    {
        #region IUsuarioService Members

        public UsuarioResponse AutenticarUsuario(UsuarioRequest request)
        {
            UsuarioResponse resposta = new UsuarioResponse();
            Entities db = new Entities();
            UsuarioBase usuario = db.UsuarioBase
                                                .Include("Perfis")
                                                .Where(x => x.LoginUsuario.Equals(request.Usuario.Login) && x.SenhaUsuario.Equals(request.Usuario.Senha))
                                                .SingleOrDefault();
            
            if (usuario != null)
            {
                if (usuario.GetType().BaseType.Name == "Aluno")
                {
                    Aluno aluno = (Aluno)usuario;
                    AlunoDAO usuarioDAO = new AlunoDAO
                    {
                        IdEscola = aluno.IdEntidadeBase,
                        Ra = aluno.RaAluno,
                        Ativo = usuario.AtivoUsuario,
                        Email = usuario.EmailUsuario,
                        Id = usuario.IdUsuarioBase,
                        Login = request.Usuario.Login,
                        Nome = usuario.NomeUsuario,
                        Tipo = TipoUsuario.Aluno
                    };

                    foreach (Perfil perfil in usuario.ListaPerfis)
                    {
                        usuarioDAO.Perfis.Add(new PerfilDAO
                        {
                            Ativo = perfil.AtivoPerfil,
                            Id = perfil.IdPerfil,
                            Nome = perfil.NomePerfil
                        });
                    }

                    resposta.EhAutenticado = true;
                    resposta.Sessao = Guid.NewGuid();
                    resposta.Usuario = usuarioDAO;
                    return resposta;
                }
                else
                {
                    Funcionario funcionario = (Funcionario)usuario;
                    FuncionarioDAO usuarioDAO = new FuncionarioDAO
                    {
                        Rg = funcionario.RgFuncionario,
                        Cpf = funcionario.CpfFuncionario,
                        Ativo = usuario.AtivoUsuario,
                        Email = usuario.EmailUsuario,
                        Id = usuario.IdUsuarioBase,
                        Login = request.Usuario.Login,
                        Nome = usuario.NomeUsuario,
                        Tipo = TipoUsuario.Funcionario
                    };

                    foreach (Perfil perfil in usuario.ListaPerfis)
                    {
                        usuarioDAO.Perfis.Add(new PerfilDAO
                        {
                            Ativo = perfil.AtivoPerfil,
                            Id = perfil.IdPerfil,
                            Nome = perfil.NomePerfil
                        });
                    }

                    resposta.EhAutenticado = true;
                    resposta.Sessao = Guid.NewGuid();
                    resposta.Usuario = usuarioDAO;
                    return resposta;
                }
            }

            return new UsuarioResponse();
        }

        #endregion
    }
}
