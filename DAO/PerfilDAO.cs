﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO
{
    [DataContract]
    public class PerfilDAO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public bool Ativo { get; set; }
        [DataMember]
        public string Nome { get; set; }
    }
}