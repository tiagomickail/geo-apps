using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract(Name = "FuncionarioDAO")]
    public class FuncionarioDAO : UsuarioBaseDAO
    {
        [DataMember]
        public string Rg { get; set; }
        [DataMember]
        public string Cpf { get; set; }
    }
}