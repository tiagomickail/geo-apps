using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class RespostaDAO
    {
        public RespostaDAO()
        {
            this.Fotos = new List<FotoDAO>();
            this.Opcoes = new List<OpcaoDAO>();
        }
    
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public int IdQuestionarioEscola { get; set; }
        [DataMember]
        public int IdQuestao { get; set; }

        [DataMember]
        public virtual List<FotoDAO> Fotos { get; set; }
        [DataMember]
        public virtual List<OpcaoDAO> Opcoes { get; set; }
    }
}