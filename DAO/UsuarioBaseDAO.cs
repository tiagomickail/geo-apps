using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class UsuarioBaseDAO
    {    
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Senha { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public bool Ativo { get; set; }
        [DataMember]
        public TipoUsuario Tipo { get; set; }

        [DataMember]
        public List<PerfilDAO> Perfis { get; set; }

        public UsuarioBaseDAO()
        {
            this.Perfis = new List<PerfilDAO>();
        }
    }
}