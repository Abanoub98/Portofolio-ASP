using System.Drawing;
using System.Collections.Generic;
namespace Portofolio.AppModels.Utils
{
    public class Constants
    {
        public enum UserRoles { Admin }
        public static Size ProjectImageSize { get => new Size(1024, 1024); }

        public static Size UserImageSize { get => new Size(475, 475); }

        public static Size ServiceImageSize { get => new Size(475, 475); }

        public static string ProjectImageDeleteAction { get => "Project image deleted"; }

        public static string ProjectUipDeleteAction { get => "User in project deleted"; }

        public enum LogActions { Update, Create, Delete }

        public enum ContactStatuses { Pending, Completed, InProgress }

        public static string ContactHtmlTemplatePath { get => "templates/servicerequest.html"; }

        public static string PasswordResetHtmlTemplatePath { get => "templates/resetpassword.html"; }

        public static string TeamLeaderRole { get => "Team Leader"; }

        public enum Roles { Admin };

        public static string LinksDefault { get => "#"; }

        public enum LinkTypes { Url, Github, LinkedIn, Facebook }

        public static IDictionary<string, string> LinkIconsDictionary
        {
            get
            {
                var dict = new Dictionary<string, string>();
                dict.Add(LinkTypes.Url.ToString(), "mdi mdi-link");
                dict.Add(LinkTypes.Github.ToString(), "mdi mdi-github-box");
                dict.Add(LinkTypes.LinkedIn.ToString(), "mdi mdi-linkedin-box");
                dict.Add(LinkTypes.Facebook.ToString(), "mdi mdi-facebook-box");
                return dict;
            }
        }

        public static string NotAssigned { get => "N/A"; }

        public static string DateFormat { get => "ddd, dd MMM yyyy"; }

        public static string DateTimeFormat { get => "ddd, dd MMM yyyy hh:mm tt"; }

        public static int NumOfLatestItems { get => 4; }

    }

}