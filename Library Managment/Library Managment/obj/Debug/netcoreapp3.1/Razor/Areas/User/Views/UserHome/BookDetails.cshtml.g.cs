#pragma checksum "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f70be2312469288cc319fbfed445e14df6ea8e8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_UserHome_BookDetails), @"mvc.1.0.view", @"/Areas/User/Views/UserHome/BookDetails.cshtml")]
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
#line 1 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\_ViewImports.cshtml"
using Library_Managment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\_ViewImports.cshtml"
using Library_Managment.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f70be2312469288cc319fbfed445e14df6ea8e8f", @"/Areas/User/Views/UserHome/BookDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2ac3a4bc54ecfcf55449845799eb5c817b1ea15", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_UserHome_BookDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Library_Managment.Models.Book>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f70be2312469288cc319fbfed445e14df6ea8e8f3778", async() => {
                WriteLiteral(@"
   
    <style>
        .bookdeets {
            background-color: #F2ECFF;
            padding: 30px;
            display: flex;
            margin: 40px;
        }

        .part1, .part2 {
            background-color: #FFF;
            text-align: center;
            padding: 30px;
            margin: 10px;
        }

        .img {
            margin: 10px;
            text-align: center;
            padding: 20px;
            background-color: #FDFDFE;
            box-shadow: 5px 5px 5px 0px rgba(0,0,0,0.75);
            -webkit-box-shadow: 5px 5px 5px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: 5px 5px 5px 0px rgba(0,0,0,0.75);
        }

        .part2 {
            font-family: monospace;
            display: flex;
            justify-content: center;
            flex-direction: column;
            box-shadow: 5px 5px 5px 5px rgba(0,0,0,0.75);
            -moz-box-shadow: 5px 5px 5px 5px rgba(0,0,0,0.75);
            -webkit-box-shadow: 5px 5px 5px 5px rgba(0");
                WriteLiteral(@",0,0,0.75);
            -o-box-shadow: 5px 5px 5px 5px rgba(0,0,0,0.75);
            margin: 30px;
        }

        .part1 {
            border-radius: 10px;
        }
        .img img{
            width:100%;
            height:100%
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"bookdeets\">\r\n        <div class=\"part1\">\r\n            <div class=\"img\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f70be2312469288cc319fbfed445e14df6ea8e8f6203", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1476, "~/BookImages/", 1476, 13, true);
#nullable restore
#line 55 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
AddHtmlAttributeValue("", 1489, Model.Image, 1489, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n            <h4>");
#nullable restore
#line 56 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
           Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <h5>");
#nullable restore
#line 57 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
           Write(Model.PublishDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n           \r\n");
#nullable restore
#line 59 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
               
            if(Model.Available != 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                 <h3>Available ");
#nullable restore
#line 61 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
                          Write(Model.Available);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 61 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
                                             Write(Model.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 62 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
            } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                   <h3>Not Available ");
#nullable restore
#line 63 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
                                Write(Model.Available);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 63 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
                                                   Write(Model.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 64 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("          \r\n        </div>\r\n        <div class=\"part2\">\r\n            <h5>");
#nullable restore
#line 69 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
           Write(Model.ISBN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h2>");
#nullable restore
#line 70 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <h4>");
#nullable restore
#line 71 "C:\Users\IT\Desktop\HyrjeNeWeb\Library Managment\Library Managment\Areas\User\Views\UserHome\BookDetails.cshtml"
           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        </div>\r\n        </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Library_Managment.Models.Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
