using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.Responses;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IQuestionarioService" in both code and config file together.
    [ServiceContract]
    public interface IQuestionarioService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/ListarQuestionariosEscola")]
        //string usuarioId, string sessao, string escolaId
        QuestionarioResponse ListarQuestionariosEscola(QuestionarioRequest questionarioRequest);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/LerQuestionario")]
        //string usuarioId, string sessao, string questionarioId
        QuestionarioResponse LerQuestionario(QuestionarioRequest questionarioRequest);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/ResponderQuestionario")]
        QuestionarioResponse ResponderQuestionario(QuestionarioRequest questionarioRequest);
    }
}
