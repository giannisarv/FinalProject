#pragma checksum "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89289b7dbfc473c9913ea15db235628e261fd220"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PersonPackages_Index), @"mvc.1.0.view", @"/Views/PersonPackages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PersonPackages/Index.cshtml", typeof(AspNetCore.Views_PersonPackages_Index))]
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
#line 1 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\_ViewImports.cshtml"
using CrowdFunding;

#line default
#line hidden
#line 2 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\_ViewImports.cshtml"
using CrowdFunding.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89289b7dbfc473c9913ea15db235628e261fd220", @"/Views/PersonPackages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c5d4aac028336e59b6edff2605c84af21a2bbe2", @"/Views/_ViewImports.cshtml")]
    public class Views_PersonPackages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CrowdFunding.Models.PersonPackage>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(98, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(127, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a5157d7cf0a4a239576659a152ef7b4", async() => {
                BeginContext(150, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(164, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(257, 43, false);
#line 16 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Package));

#line default
#line hidden
            EndContext();
            BeginContext(300, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(356, 42, false);
#line 19 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Person));

#line default
#line hidden
            EndContext();
            BeginContext(398, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 25 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(516, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(565, 54, false);
#line 28 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Package.Description));

#line default
#line hidden
            EndContext();
            BeginContext(619, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(675, 47, false);
#line 31 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Person.Email));

#line default
#line hidden
            EndContext();
            BeginContext(722, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(778, 65, false);
#line 34 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(843, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(864, 71, false);
#line 35 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(935, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(956, 69, false);
#line 36 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1025, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 39 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\PersonPackages\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1064, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CrowdFunding.Models.PersonPackage>> Html { get; private set; }
    }
}
#pragma warning restore 1591
