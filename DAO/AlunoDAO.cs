using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract(Name="AlunoDAO")]
    public class AlunoDAO : UsuarioBaseDAO
    {
        [DataMember]
        public string Ra { get; set; }
        [DataMember]
        public int IdEscola { get; set; }

        [DataMember]
        public EscolaDAO Escola { get; set; }
    }
}