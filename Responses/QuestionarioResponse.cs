using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.Responses
{
    [DataContract]
    public class QuestionarioResponse
    {
        [DataMember]
        public bool Erro { get; set; }
        [DataMember]
        public List<string> Mensagem { get; set; }

        [DataMember]
        public QuestionarioEscolaDAO Questionario { get; set; }
        [DataMember]
        public List<QuestionarioDAO> Questionarios { get; set; }

        public QuestionarioResponse()
        {
            Mensagem = new List<string>();
        }

    }
}