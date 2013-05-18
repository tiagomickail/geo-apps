using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class OpcaoDAO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdQuestao { get; set; }
        [DataMember]
        public string Descricao { get; set; }
    }
}