using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Responses;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices
{
    [ServiceContract]
    public interface IEscolaService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/ListarEscolasPorPosicao")]
        EscolaResponse ListarEscolasPorPosicao(EscolaRequest request);
    }
}
