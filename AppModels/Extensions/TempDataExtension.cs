using Portofolio.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using static Portofolio.AppModels.Utils.KeyConstants;
using Json.Net;
namespace Portofolio.AppModels.Extensions
{
    public static class TempDataExtension
    {
        public static ResultMsgViewModel GetResultMessage(this ITempDataDictionary tempData)
        {
            return JsonNet.Deserialize<ResultMsgViewModel>(tempData[ResultMessageKey].ToString());
        }
    }
}