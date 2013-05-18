using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class AtendimentoDAO
    {
        public AtendimentoDAO()
        {
            this.Fotos = new List<FotoDAO>();
        }

        [DataMember]
        public int IdAtendimento { get; set; }
        [DataMember]
        public string NomeAtendimento { get; set; }
        [DataMember]
        public int IdUsuarioBase { get; set; }
        [DataMember]
        public int IdEntidadeBase { get; set; }
        [DataMember]
        public int IdEscola { get; set; }
        [DataMember]
        public int IdStatus { get; set; }

        [DataMember]
        public virtual List<FotoDAO> Fotos { get; set; }
    }
}