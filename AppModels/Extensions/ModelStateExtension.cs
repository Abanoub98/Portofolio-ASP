using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Portofolio.ViewModels;
using static Portofolio.AppModels.Utils.KeyConstants;
namespace Portofolio.AppModels.Extensions
{
    public static class ModelStateExtension
    {
        public static string GetErrors(this ModelStateDictionary modelState)
        {
            string errors = string.Join("\n", modelState.Values.SelectMany((ms) =>
            {
                return ms.Errors.Select((err)=>{
                    return err.ErrorMessage;
                });
            }));
            return errors;
        }

        public static void AssignViewDataWithErrors(this ModelStateDictionary modelState, ViewDataDictionary viewData)
        {
            viewData[ResultMessageKey] = new ResultMsgViewModel
            {
                Message = modelState.GetErrors(),
                CssClass = ResultMsgViewModel.CssClassFailed
            };
        }
    }
}