using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Responses;

namespace GeoApps.GeoQuest.SecretariaEducacao.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAtendimentoService" in both code and config file together.
    [ServiceContract]
    public interface IAtendimentoService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/CriarAtendimento")]
        AtendimentoResponse CriarAtendimento(AtendimentoRequest atendimentoRequest);
    }
}
