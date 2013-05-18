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

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AtendimentoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AtendimentoService.svc or AtendimentoService.svc.cs at the Solution Explorer and start debugging.
    public class AtendimentoService : IAtendimentoService
    {
        public AtendimentoResponse CriarAtendimento(AtendimentoRequest atendimentoRequest)
        {
            Entities db = new Entities();
            AtendimentoResponse atendimentoResponse = new AtendimentoResponse();

            atendimentoResponse.Mensagem = Validar(atendimentoRequest);
            if (atendimentoResponse.Mensagem.Count > 0)
            {
                atendimentoResponse.Erro = true;
                return atendimentoResponse;
            }

            Atendimento atendimento = new Atendimento();
            atendimento.NomeAtendimento = atendimentoRequest.atendimento.NomeAtendimento;
            atendimento.UsuarioBaseIdUsuarioBase = atendimentoRequest.atendimento.IdUsuarioBase;
            atendimento.EntidadeBaseIdEntidadeBase = atendimentoRequest.atendimento.IdEntidadeBase;
            atendimento.EscolaIdEscola = atendimentoRequest.atendimento.IdEscola;
            atendimento.IdStatus = TipoStatus.Aberto;

            if (atendimentoRequest.atendimento.Fotos != null && atendimentoRequest.atendimento.Fotos.Count > 0)
            {
                foreach (FotoDAO fotoDAO in atendimentoRequest.atendimento.Fotos)
                {
                    if (fotoDAO.Arquivo != null)
                        atendimento.Fotos.Add(new Foto { Arquivo = fotoDAO.Arquivo });
                }
            }

            db.Atendimento.Add(atendimento);
            db.SaveChanges();

            atendimentoResponse.Mensagem.Add("Registro salvo com sucesso!");

            return atendimentoResponse;
        }

        private List<string> Validar(AtendimentoRequest atendimento)
        {
            List<string> retorno = new List<string>();

            if (atendimento == null)
            {
                retorno.Add("Objeto request nulo!");
            }
            else
            {
                if (atendimento.atendimento == null)
                {
                    retorno.Add("Objeto Atendimento nulo!");
                }
            }

            return retorno;
        }
    }
}
