using Microsoft.AspNetCore.Mvc.ViewFeatures;
using static Portofolio.AppModels.Utils.KeyConstants;
using Portofolio.ViewModels;
using Json.Net;
namespace Portofolio.AppModels.Services
{
    public class OutputDisplayer : IDisplayOutput
    {
        public void DisplayOutput(ITempDataDictionary tempData, bool isSuccess, string message)
        {
            var viewModel = new ResultMsgViewModel();
            if(isSuccess)
            {
                viewModel.CssClass = ResultMsgViewModel.CssClassSuccess;
            }
            else
            {
                viewModel.CssClass = ResultMsgViewModel.CssClassFailed;
            }
            viewModel.Message = message;
            tempData[ResultMessageKey] = JsonNet.Serialize(viewModel);
        }
    }
}