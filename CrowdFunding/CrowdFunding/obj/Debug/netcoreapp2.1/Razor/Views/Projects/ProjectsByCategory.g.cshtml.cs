#pragma checksum "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bde04b7b01230e7556a4a97fb4c8d323948c817c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects_ProjectsByCategory), @"mvc.1.0.view", @"/Views/Projects/ProjectsByCategory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Projects/ProjectsByCategory.cshtml", typeof(AspNetCore.Views_Projects_ProjectsByCategory))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bde04b7b01230e7556a4a97fb4c8d323948c817c", @"/Views/Projects/ProjectsByCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c5d4aac028336e59b6edff2605c84af21a2bbe2", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects_ProjectsByCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CrowdFunding.Models.Project>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(92, 104, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(197, 46, false);
#line 13 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.PictureUrl));

#line default
#line hidden
            EndContext();
            BeginContext(243, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(299, 41, false);
#line 16 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(340, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(396, 47, false);
#line 19 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(443, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(499, 44, false);
#line 22 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.Deadline));

#line default
#line hidden
            EndContext();
            BeginContext(543, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(599, 40, false);
#line 25 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.Goal));

#line default
#line hidden
            EndContext();
            BeginContext(639, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(695, 44, false);
#line 28 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
            EndContext();
            BeginContext(739, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(795, 42, false);
#line 31 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.Person));

#line default
#line hidden
            EndContext();
            BeginContext(837, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 37 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(972, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1033, 45, false);
#line 41 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.PictureUrl));

#line default
#line hidden
            EndContext();
            BeginContext(1078, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1146, 40, false);
#line 44 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1186, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1254, 46, false);
#line 47 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1300, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1368, 43, false);
#line 50 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Deadline));

#line default
#line hidden
            EndContext();
            BeginContext(1411, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1479, 39, false);
#line 53 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Goal));

#line default
#line hidden
            EndContext();
            BeginContext(1518, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1586, 48, false);
#line 56 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Category.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1634, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1702, 47, false);
#line 59 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Person.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1749, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
            BeginContext(2036, 24, true);
            WriteLiteral("                    <a> ");
            EndContext();
            BeginContext(2061, 85, false);
#line 65 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
                   Write(Html.ActionLink("Updates", "AnonIndex", "Details", new { id = item.ProjectId }, null));

#line default
#line hidden
            EndContext();
            BeginContext(2146, 32, true);
            WriteLiteral("</a> |\r\n                    <a> ");
            EndContext();
            BeginContext(2179, 87, false);
#line 66 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
                   Write(Html.ActionLink("Packages", "AnonIndex", "Packages", new { id = item.ProjectId }, null));

#line default
#line hidden
            EndContext();
            BeginContext(2266, 48, true);
            WriteLiteral("</a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 69 "C:\cchaldezos\Desktop\.net academy\FPCrowdFunding\FinalProject\CrowdFunding\CrowdFunding\Views\Projects\ProjectsByCategory.cshtml"
        }

#line default
#line hidden
            BeginContext(2325, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CrowdFunding.Models.Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591