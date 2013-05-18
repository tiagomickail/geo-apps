using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Responses
{
    [DataContract]
    public class UsuarioResponse
    {
        [DataMember]
        public bool Erro { get; set; }
        [DataMember]
        public List<string> Mensagem { get; set; }
        [DataMember]
        public UsuarioBaseDAO Usuario { get; set; }
        [DataMember]
        public Guid Sessao { get; set; }
        [DataMember]
        public bool EhAutenticado { get; set; }
    }
}