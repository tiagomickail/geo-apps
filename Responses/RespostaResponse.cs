using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Responses
{
    [DataContract]
    public class RespostaResponse
    {
        [DataMember]
        public bool Erro { get; set; }
        [DataMember]
        public List<string> Mensagem { get; set; }
        [DataMember]
        public Guid Sessao { get; set; }
        [DataMember]
        public bool EhAutenticado { get; set; }

        [DataMember]
        public RespostaDAO Resposta { get; set; }

        public RespostaResponse()
        {
            this.Mensagem = new List<string>();
        }
    }
}