using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract(Name="EscolaDAO")]
    public class EscolaDAO : EntidadeBaseDAO
    {
        [DataMember]
        public string Endereco { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Bairro { get; set; }
        [DataMember]
        public string Cep { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [DataMember]
        public string CodigoCie { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }
        [DataMember]
        public int IdDiretoria { get; set; }
    }
}