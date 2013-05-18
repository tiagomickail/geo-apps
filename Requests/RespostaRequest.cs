using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Requests
{
    [DataContract]
    public class RespostaRequest
    {
        [DataMember]
        public Guid Sessao { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public RespostaDAO Resposta { get; set; }
    }
}