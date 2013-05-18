using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.Requests
{
    [DataContract]
    public class EscolaRequest
    {
        [DataMember]
        public Guid Sessao { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public EscolaDAO Escola { get; set; }
    }
}