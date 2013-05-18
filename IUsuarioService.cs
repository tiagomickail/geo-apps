using System.ServiceModel;
using System.ServiceModel.Web;
using GeoApps.GeoQuest.SecretariaEducacao.WebServices.DAO;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Requests;
using GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices.Responses;

namespace GeoApps.GeoQuest.SecretariaEducacao.Admin.WebServices
{
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json/AutenticarUsuario")]
        UsuarioResponse AutenticarUsuario(UsuarioRequest request);
    }
}
