using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.Models;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Responses;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices
{
    public class EscolaService : IEscolaService
    {
        #region IEscolaService Members

        public EscolaResponse ListarEscolasPorPosicao(EscolaRequest request)
        {
            EscolaResponse resposta = new EscolaResponse();

            List<EscolaDAO> escolasDAO = new List<EscolaDAO>();

            Entities db = new Entities();

            List<Escola> escolas = db.RetornaEscolasPorLocalizacao(request.Escola.Latitude, request.Escola.Longitude, 500).ToList();

            if (escolas != null && escolas.Count > 0)
                foreach (Escola escola in escolas)
                    escolasDAO.Add(new EscolaDAO
                    {  
                        Bairro = escola.BairroEscola,
                        Cep = escola.CepEscola,
                        CodigoCie = escola.CodigoCieEscola,
                        Complemento = escola.ComplementoEscola,
                        Endereco = escola.EnderecoEscola,
                        IdDiretoria = escola.IdDiretoria,
                        Id = escola.IdEntidadeBase,
                        Latitude = escola.Localizacao_Latitude,
                        Longitude = escola.Localizacao_Longitude,
                        Nome = escola.NomeEntidade,
                        Numero = escola.NumeroEscola
                    });

            resposta.Escolas = escolasDAO;

            return resposta;
        }

        #endregion
    }
}
