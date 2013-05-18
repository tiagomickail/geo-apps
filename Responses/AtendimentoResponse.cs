using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.Responses
{
    [DataContract]
    public class AtendimentoResponse
    {
        [DataMember]
        public bool Erro { get; set; }
        [DataMember]
        public List<string> Mensagem { get; set; }

        public AtendimentoResponse()
        {
            Mensagem = new List<string>();
        }
    }
}