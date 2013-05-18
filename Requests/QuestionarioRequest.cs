using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.Requests
{
    [DataContract]
    public class QuestionarioRequest
    {
        [DataMember]
        public Guid Sessao { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public QuestionarioEscolaDAO QuestionarioEscola { get; set; }

        [DataMember]
        public List<RespostaDAO> Respostas { get; set; } 

    }
}