using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.Models;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Responses;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices
{
    public class QuestionarioService : IQuestionarioService
    {
        #region IQuestionarioService Members

        public QuestionarioResponse ListarQuestionariosEscola(QuestionarioRequest request)
        {
            QuestionarioResponse resposta = new QuestionarioResponse();

            Entities db = new Entities();

            List<QuestionarioDAO> questionariosDAO = new List<QuestionarioDAO>();

            List<QuestionarioEscola> questionariosEscola = db.QuestionarioEscola.Where(x => x.EscolaIdEscola.Equals(request.QuestionarioEscola.IdEscola))
                                                                                .ToList();

            if (questionariosEscola != null && questionariosEscola.Count > 0)
            {
                foreach (QuestionarioEscola questionarioEscola in questionariosEscola)
                {
                    questionariosDAO.Add(new QuestionarioDAO
                    {
                        Ativo = questionarioEscola.Questionario.AtivoQuestionario,
                        Nome = questionarioEscola.Questionario.NomeQuestionario,
                        Descricao = questionarioEscola.Questionario.DescricaoQuestionario,
                        Id = questionarioEscola.Questionario.IdQuestionario
                    });
                }
            }

            resposta.Questionarios = questionariosDAO;

            return resposta;
        }

        public QuestionarioResponse LerQuestionario(QuestionarioRequest request)
        {
            QuestionarioResponse resposta = new QuestionarioResponse();

            Entities db = new Entities();

            QuestionarioEscola questionarioEscola = db.QuestionarioEscola.Find(request.QuestionarioEscola.IdQuestionario);

            if (questionarioEscola != null)
            {
                QuestionarioEscolaDAO questionarioEscolaDAO = new QuestionarioEscolaDAO
                {
                    Id = questionarioEscola.IdQuestionarioEscola,
                    IdEscola = questionarioEscola.EscolaIdEscola,
                    IdQuestionario = questionarioEscola.IdQuestionarioEscola
                };

                QuestionarioDAO questionarioDAO = new QuestionarioDAO
                {
                    Ativo = questionarioEscola.Questionario.AtivoQuestionario,
                    Descricao = questionarioEscola.Questionario.DescricaoQuestionario,
                    Id = questionarioEscola.Questionario.IdQuestionario,
                    Nome = questionarioEscola.Questionario.NomeQuestionario
                };

                foreach (Questao questao in questionarioEscola.Questionario.Questoes)
                {
                    QuestaoDAO questaoDAO = new QuestaoDAO
                    {
                        Enunciado = questao.EnunciadoQuestao,
                        Id = questao.IdQuestao,
                        IdQuestionario = questao.QuestionarioIdQuestionario,
                        IdTipoQuestao = questao.TipoQuestaoIdTipoQuestao
                    };

                    foreach (Opcao opcao in questao.Opcoes)
                    {
                        OpcaoDAO opcaoDAO = new OpcaoDAO
                        {
                            Descricao = opcao.Descricao,
                            Id = opcao.IdOpcao,
                            IdQuestao = opcao.QuestaoIdQuestao
                        };
                        questaoDAO.Opcoes.Add(opcaoDAO);
                    }

                    questionarioDAO.Questoes.Add(questaoDAO);
                }

                questionarioEscolaDAO.Questionario = questionarioDAO;
                resposta.Questionario = questionarioEscolaDAO;
                return resposta;
            }

            return new QuestionarioResponse();
        }

        public QuestionarioResponse ResponderQuestionario(QuestionarioRequest questionarioRequest)
        {
            Entities db = new Entities();
            QuestionarioResponse response = new QuestionarioResponse();

            List<string> erros = Validar(questionarioRequest);

            if (erros.Count > 0)
            {
                response.Erro = true;
                response.Mensagem = erros;
            }
            else
            {
                QuestionarioEscola questionarioEscola = db.QuestionarioEscola.Single(
                    q => q.EscolaIdEscola == questionarioRequest.QuestionarioEscola.IdEscola
                         && q.QuestionarioIdQuestionario == questionarioRequest.QuestionarioEscola.IdQuestionario);

                foreach (var resp in questionarioRequest.Respostas)
                {
                    Resposta resposta = new Resposta();

                    resposta.QuestaoIdQuestao = resp.IdQuestao;
                    resposta.QuestionarioEscolaIdQuestionarioEscola = resp.IdQuestionarioEscola;
                    resposta.UsuarioBaseIdUsuarioBase = resp.IdUsuario;

                    foreach (var o in resp.Opcoes)
                    {
                        Opcao opcao = (from op in db.Opcao
                                       where op.IdOpcao == o.Id
                                             && op.QuestaoIdQuestao == o.IdQuestao
                                       select op).Single();
                        resposta.Opcoes.Add(opcao);
                    }

                    if (resp.Fotos != null && resp.Fotos.Count > 0)
                    {
                        foreach (FotoDAO fotoDAO in resp.Fotos)
                        {
                            if (fotoDAO.Arquivo != null)
                                resposta.Fotos.Add(new Foto { Arquivo = fotoDAO.Arquivo });
                        }
                    }

                    questionarioEscola.Respostas.Add(resposta);

                }

                //todo Mudar o status para o id da tabela de status
                questionarioEscola.IdStatus = TipoStatus.Fechado;

                db.SaveChanges();

                response.Mensagem.Add("O Questionario foi finalizado com sucesso!");
            }
            return response;
        }

        public List<string> Validar(QuestionarioRequest quest)
        {
            List<string> retorno = new List<string>();

            if (quest == null)
                retorno.Add("Objeto request nulo!");
            else
            {
                if (quest.QuestionarioEscola == null)
                {
                    retorno.Add("Objeto de Questionario escola nulo!");
                }

                if (quest.Respostas == null || quest.Respostas.Count == 0)
                {
                    retorno.Add("Objeto da lista de respostas nulo!");
                }
                else
                {
                    foreach (var resp in quest.Respostas)
                    {
                        if (resp == null || resp.Id == 0)
                        {
                            retorno.Add("Objeto de resposta nulo!");
                        }
                    }
                }


            }
            return retorno;
        }

        #endregion
    }
}
