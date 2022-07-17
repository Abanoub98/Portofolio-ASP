using System.IO;
using System.Threading.Tasks;
namespace Portofolio.AppModels.Models
{
    public class HTMLWithModel<T> where T : class
    {
        public T Model { get; set; }
        public string Path { get; set; }

        public string[] PlaceHolders { get; set; }

        public string[] PlaceHolderValues { get; set; }

        public string ToEmail { get; set; }

        public string HrefValue {get; set;}

        public async Task<string> GetHTMLAsync()
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                return await sr.ReadToEndAsync();
            }
        }
    }
}