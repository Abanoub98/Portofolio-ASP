
namespace Portofolio.ViewModels
{
    public class ResultMsgViewModel
    {
        public string Message {get; set;}

        public string CssClass {get; set;}

        public static  string CssClassSuccess
        {
            get
            {
                return "alert alert-success";
            }
        }

        public static string CssClassFailed
        {
            get
            {
                return "alert alert-danger";
            }
        }

    }
}