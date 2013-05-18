using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.Models;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Responses;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices
{
    public class RespostaService : IRespostaService
    {
        #region Private Members
        private Questao _questao;
        #endregion

        #region IRespostaService Members

        public RespostaResponse ResponderQuestao(RespostaRequest respostaRequest)
            {
            Entities db = new Entities();
            RespostaResponse respostaResponse = new RespostaResponse();
            _questao = db.Questao.Find(respostaRequest.Resposta.IdQuestao);

            respostaResponse.Mensagem = Validar(respostaRequest);
            if (respostaResponse.Mensagem.Count > 0)
            {
                respostaResponse.Erro = true;
                return respostaResponse;
            }

            Resposta resposta = new Resposta
            {
                QuestaoIdQuestao = respostaRequest.Resposta.IdQuestao,
                QuestionarioEscolaIdQuestionarioEscola = respostaRequest.Resposta.IdQuestionarioEscola,
                UsuarioBaseIdUsuarioBase = respostaRequest.Resposta.IdUsuario
            };

            if (respostaRequest.Resposta.Fotos != null && respostaRequest.Resposta.Fotos.Count > 0)
            {
                foreach (FotoDAO fotoDAO in respostaRequest.Resposta.Fotos)
                {
                    if (fotoDAO.Arquivo != null)
                        resposta.Fotos.Add(new Foto { Arquivo = fotoDAO.Arquivo });
                }
            }

            if (respostaRequest.Resposta.Opcoes != null)
            {
                if (_questao.Opcoes.Count > 0)
                    foreach (OpcaoDAO opcaoDAO in respostaRequest.Resposta.Opcoes)
                    {
                        if (opcaoDAO.Id != 0)
                        {
                            Opcao opcao = db.Opcao.Find(opcaoDAO.Id);
                            if (opcao != null)
                                resposta.Opcoes.Add(opcao);
                        }
                        else
                        {
                            resposta.Opcoes.Add(new Opcao
                            {
                                Descricao = opcaoDAO.Descricao,
                                QuestaoIdQuestao = opcaoDAO.IdQuestao
                            });
                        }
                    }
            }


            db.Resposta.Add(resposta);
            db.SaveChanges();

            respostaResponse.Mensagem.Add("Registro salvo com sucesso!");

            return respostaResponse;
        }

        #endregion

        private List<string> Validar(RespostaRequest respostaRequest)
        {
            List<string> retorno = new List<string>();

            if (respostaRequest == null)
                retorno.Add("Objeto request nulo!");
            else
            {
                if (respostaRequest.Resposta == null)
                    retorno.Add("Objeto resposta nulo!");
                else
                {
                    if (_questao == null)
                        retorno.Add("Questão não encontrada!");
                    else
                    {
                        if (_questao.TipoQuestao.IdTipoQuestao == 1)
                        {
                            if (respostaRequest.Resposta.Opcoes == null || respostaRequest.Resposta.Opcoes.Count == 0)
                                retorno.Add("Objeto opções nulo!");
                            else if (respostaRequest.Resposta.Opcoes.Count > 1)
                                retorno.Add("Esse tipo de questão só aceita uma resposta!");
                            else
                            {
                                if (respostaRequest.Resposta.Opcoes[0].Id != 0)
                                    retorno.Add("Esse tipo de questão só aceita uma resposta nova!");

                                if (string.IsNullOrEmpty(respostaRequest.Resposta.Opcoes[0].Descricao))
                                    retorno.Add("A descrição da opção da resposta não pode ser em branco!");
                            }
                        }
                        else if (_questao.TipoQuestao.IdTipoQuestao == 2)
                        {
                            if (respostaRequest.Resposta.Opcoes == null || respostaRequest.Resposta.Opcoes.Count == 0)
                                retorno.Add("Objeto opções nulo!");

                            foreach (OpcaoDAO opcao in respostaRequest.Resposta.Opcoes)
                            {
                                if (opcao.Id == 0)
                                    retorno.Add("O id da opção não pode ser 0!");
                            }
                        }
                        else if (_questao.TipoQuestao.IdTipoQuestao == 3)
                        {
                            if (respostaRequest.Resposta.Opcoes == null || respostaRequest.Resposta.Opcoes.Count == 0)
                                retorno.Add("Objeto opções nulo!");
                            else if (respostaRequest.Resposta.Opcoes.Count > 1)
                                retorno.Add("Esse tipo de questão só aceita uma resposta!");
                            else
                                if (respostaRequest.Resposta.Opcoes[0].Id == 0)
                                    retorno.Add("O id da opção não pode ser 0!");
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
