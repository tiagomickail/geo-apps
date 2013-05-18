using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Responses;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRespostaService" in both code and config file together.
    [ServiceContract]
    public interface IRespostaService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/ResponderQuestao")]
         RespostaResponse ResponderQuestao(RespostaRequest respostaRequest);
    }
}
