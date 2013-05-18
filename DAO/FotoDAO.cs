using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class FotoDAO
    {
        [DataMember]
        public int IdFoto { get; set; }
        [DataMember]
        public byte[] Arquivo { get; set; }
    }
}