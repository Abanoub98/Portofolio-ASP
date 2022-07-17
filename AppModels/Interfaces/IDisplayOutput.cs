using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace Portofolio.AppModels.Services
{
    public interface IDisplayOutput
    {
        void DisplayOutput(ITempDataDictionary tempData, bool isSuccess, string message);
    }
}