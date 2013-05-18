using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.Responses
{
    [DataContract]
    public class EscolaResponse
    {
        [DataMember]
        public bool Erro { get; set; }
        [DataMember]
        public List<string> Mensagem { get; set; }

        [DataMember]
        public List<EscolaDAO> Escolas { get; set; }

        public EscolaResponse()
        {
            Mensagem = new List<string>();
        }
    }
}