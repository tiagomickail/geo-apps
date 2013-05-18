using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class QuestionarioDAO
    {
        public QuestionarioDAO()
        {
            this.Questoes = new List<QuestaoDAO>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public bool Ativo { get; set; }

        [DataMember]
        public virtual List<QuestaoDAO> Questoes { get; set; }
    }
}