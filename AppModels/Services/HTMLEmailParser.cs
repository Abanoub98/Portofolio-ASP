using Portofolio.AppModels.Models;
using Portofolio.Models;
using System.Threading.Tasks;
namespace Portofolio.AppModels.Services
{
    public class HTMLEmailParser : IEmailParserFromModelAsync<HTMLModel>
    {
        public async Task<MailRequest> ParseAsync(HTMLModel model)
        {
            var request = new MailRequest();
            request.ToEmail = model.ToEmail;
            request.Subject = "Portofolio Password Reset";
            string body = await model.GetHTMLAsync();
            for(int i = 0; i < model.PlaceHolders.Length; i++)
            {
                body = body.Replace(model.PlaceHolders[i], model.PlaceHolderValues[i]);
            }
            request.Body = body;
            return request;
        }
    }
}