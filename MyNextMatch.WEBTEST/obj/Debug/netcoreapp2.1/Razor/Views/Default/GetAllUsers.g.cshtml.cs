#pragma checksum "E:\Projects\MyNextMatch\MyNextMatch.API\MyNextMatch.WEBTEST\Views\Default\GetAllUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2721e568fe565a4694efe432611fd81a33322c69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default_GetAllUsers), @"mvc.1.0.view", @"/Views/Default/GetAllUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Default/GetAllUsers.cshtml", typeof(AspNetCore.Views_Default_GetAllUsers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2721e568fe565a4694efe432611fd81a33322c69", @"/Views/Default/GetAllUsers.cshtml")]
    public class Views_Default_GetAllUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MyNextMatch.Entities.Classes.User>>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Projects\MyNextMatch\MyNextMatch.API\MyNextMatch.WEBTEST\Views\Default\GetAllUsers.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(75, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(104, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a40d51d689d4e69ad8b63434fc7c4d1", async() => {
                BeginContext(110, 95, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Get All Users</title>\r\n");
                EndContext();
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
            EndContext();
            BeginContext(212, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(214, 251, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84d388de4a634a44bbd5bea53b8df33d", async() => {
                BeginContext(220, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 14 "E:\Projects\MyNextMatch\MyNextMatch.API\MyNextMatch.WEBTEST\Views\Default\GetAllUsers.cshtml"
     foreach (var user in Model)
    {

#line default
#line hidden
                BeginContext(263, 40, true);
                WriteLiteral("        <div>\r\n            <b>name:</b> ");
                EndContext();
                BeginContext(304, 9, false);
#line 17 "E:\Projects\MyNextMatch\MyNextMatch.API\MyNextMatch.WEBTEST\Views\Default\GetAllUsers.cshtml"
                    Write(user.Name);

#line default
#line hidden
                EndContext();
                BeginContext(313, 36, true);
                WriteLiteral("<br />\r\n            <b>surname:</b> ");
                EndContext();
                BeginContext(350, 12, false);
#line 18 "E:\Projects\MyNextMatch\MyNextMatch.API\MyNextMatch.WEBTEST\Views\Default\GetAllUsers.cshtml"
                       Write(user.Surname);

#line default
#line hidden
                EndContext();
                BeginContext(362, 34, true);
                WriteLiteral("<br />\r\n            <b>email:</b> ");
                EndContext();
                BeginContext(397, 10, false);
#line 19 "E:\Projects\MyNextMatch\MyNextMatch.API\MyNextMatch.WEBTEST\Views\Default\GetAllUsers.cshtml"
                     Write(user.Email);

#line default
#line hidden
                EndContext();
                BeginContext(407, 44, true);
                WriteLiteral("<br />\r\n            <hr />\r\n        </div>\r\n");
                EndContext();
#line 22 "E:\Projects\MyNextMatch\MyNextMatch.API\MyNextMatch.WEBTEST\Views\Default\GetAllUsers.cshtml"
    }

#line default
#line hidden
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(465, 11, true);
            WriteLiteral("\r\n</html>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MyNextMatch.Entities.Classes.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591