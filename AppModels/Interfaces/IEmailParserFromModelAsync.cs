using System.Threading.Tasks;
using Portofolio.Models;
namespace Portofolio.AppModels.Services
{
    public interface IEmailParserFromModelAsync<T> where T : class
    {
        Task<MailRequest> ParseAsync(T model);
    }
}