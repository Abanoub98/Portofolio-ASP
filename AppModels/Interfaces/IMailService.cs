using System.Threading.Tasks;
using Portofolio.Models;
namespace Portofolio.AppModels.Services{
    public interface IMailService{
        Task SendEmailAsync(MailRequest mailRequest);
    }
}