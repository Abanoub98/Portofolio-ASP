#pragma checksum "E:\Personal\Portofolio\Views\Shared\_ScrollToTopBtn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74d8775bc4ed6d80cebba35e8a9f3b3aabbb694b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ScrollToTopBtn), @"mvc.1.0.view", @"/Views/Shared/_ScrollToTopBtn.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Personal\Portofolio\Views\_ViewImports.cshtml"
using Portofolio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Personal\Portofolio\Views\_ViewImports.cshtml"
using Portofolio.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Personal\Portofolio\Views\_ViewImports.cshtml"
using Portofolio.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Personal\Portofolio\Views\_ViewImports.cshtml"
using static Portofolio.AppModels.Utils.KeyConstants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Personal\Portofolio\Views\_ViewImports.cshtml"
using static Portofolio.AppModels.Utils.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Personal\Portofolio\Views\_ViewImports.cshtml"
using Portofolio.AppModels.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74d8775bc4ed6d80cebba35e8a9f3b3aabbb694b", @"/Views/Shared/_ScrollToTopBtn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"123f75ec33827d5e3826a487286a977b19ac1d40", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ScrollToTopBtn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <button class=""scroll-into-top"">
      <i class=""fas fa-arrow-alt-circle-up""></i>
    </button>
    <script>
            //visibilty of scroll to top button
    window.addEventListener('scroll',(event) => {
        if(document.documentElement.scrollTop=== 0)
        {
            document.getElementsByClassName(""scroll-into-top"")[0].style.display = ""None"";
            
        }
        else
        {
            document.getElementsByClassName(""scroll-into-top"")[0].style.display = ""Block"";
        }
    });
    var scrollButton = document.getElementsByClassName(""scroll-into-top"")[0];
    scrollButton.addEventListener(""click"", function () {
      document.getElementById(""home"").scrollIntoView({block: ""end"", inline: ""nearest"" });
    });
    </script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591