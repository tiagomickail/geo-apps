using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public enum TipoUsuario
    {
        [EnumMember]
        Aluno = 1,
        [EnumMember]
        Funcionario = 2    
    }
}