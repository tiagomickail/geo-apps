using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class QuestionarioEscolaDAO
    {
        public QuestionarioEscolaDAO()
        {
            //this.Fotos = new HashSet<QuestionarioEscolaFoto>();
        }
    
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdEscola { get; set; }
        [DataMember]
        public int IdQuestionario { get; set; }
    
        //[DataMember]
        //public virtual ICollection<QuestionarioEscolaFoto> Fotos { get; set; }
        [DataMember]
        public virtual QuestionarioDAO Questionario { get; set; }
    }
}