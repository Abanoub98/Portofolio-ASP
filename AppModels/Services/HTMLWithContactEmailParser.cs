using Portofolio.AppModels.Models;
using Portofolio.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace Portofolio.AppModels.Services
{
    public class HTMLWithContactEmailParser : IEmailParserFromModelAsync<HTMLWithModel<Contact>>
    {
        private readonly MailSettings mailSettings;

        public HTMLWithContactEmailParser(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }
        public async Task<MailRequest> ParseAsync(HTMLWithModel<Contact> model)
        {
            var request = new MailRequest();
            request.ToEmail = mailSettings.Mail;
            request.Subject = "Service Request";
            model.PlaceHolders = GetPlaceholders();
            model.PlaceHolderValues = GetPlaceholderValues(model);
            string body = await model.GetHTMLAsync();
            for (int i = 0; i < model.PlaceHolders.Length; i++)
            {
                body = body.Replace(model.PlaceHolders[i], model.PlaceHolderValues[i]);
            }
            request.Body = body;
            return request;
        }

        private string[] GetPlaceholders()
        {
            string[] placeholders = new string[6];
            placeholders[0] = "[Name]";
            placeholders[1] = "[Email]";
            placeholders[2] = "[PhoneNumber]";
            placeholders[3] = "[Message]";
            placeholders[4] = "[RequestedServices]";
            placeholders[5] = "[href]";
            return placeholders;
        }

        private string[] GetPlaceholderValues(HTMLWithModel<Contact> model)
        {
            string[] placeholderValues = new string[6];
            placeholderValues[0] = model.Model.ContactName;
            placeholderValues[1] = model.Model.Email;
            placeholderValues[2] = model.Model.Phone;
            placeholderValues[3] = model.Model.Message;
            placeholderValues[4] = string.Empty;
            foreach (var service in model.Model.RequestedServices)
            {
                placeholderValues[4] += $"{service.AssociatedService.ServiceName}<br/>";
            }
            placeholderValues[5] = model.HrefValue;
            return placeholderValues;
        }
    }
}