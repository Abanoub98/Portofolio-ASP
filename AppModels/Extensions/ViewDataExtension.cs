using Portofolio.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using static Portofolio.AppModels.Utils.KeyConstants;
using Json.Net;
namespace Portofolio.AppModels.Extensions
{
    public static class ViewDataExtension
    {
        public static ResultMsgViewModel GetResultMessage(this ViewDataDictionary viewData)
        {
            return JsonNet.Deserialize<ResultMsgViewModel>(viewData[ResultMessageKey].ToString());
        }
    }
}