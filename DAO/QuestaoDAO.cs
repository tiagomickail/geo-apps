using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class QuestaoDAO
    {
        public QuestaoDAO()
        {
            this.Opcoes = new HashSet<OpcaoDAO>();
        }
    
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Enunciado { get; set; }
        [DataMember]
        public int IdTipoQuestao { get; set; }
        [DataMember]
        public int IdQuestionario { get; set; }

        [DataMember]
        public virtual ICollection<OpcaoDAO> Opcoes { get; set; }
    }
}