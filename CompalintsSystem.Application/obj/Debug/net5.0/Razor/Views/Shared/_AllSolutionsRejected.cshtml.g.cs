#pragma checksum "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b504820ff120079aa07070ba88e31f8d290c9f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AllSolutionsRejected), @"mvc.1.0.view", @"/Views/Shared/_AllSolutionsRejected.cshtml")]
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
#line 1 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\_ViewImports.cshtml"
using CompalintsSystem.Application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\_ViewImports.cshtml"
using CompalintsSystem.Core.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\_ViewImports.cshtml"
using CompalintsSystem.Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b504820ff120079aa07070ba88e31f8d290c9f7", @"/Views/Shared/_AllSolutionsRejected.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1524c428b22ec937f4d7973ab43c585c086b4e06", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__AllSolutionsRejected : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProvideSolutionsVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-bs-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-bs-target", new global::Microsoft.AspNetCore.Html.HtmlString("#modalLong"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("الحل المقترح"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"

<div class=""table-responsive text-nowrap"">
    <table id=""example"" class=""table table-bordered table table-bordered"" style=""border-radius: 0.25rem;"">

        <thead>
            <tr>
                <th class=""row-cols-md-4"">
                    الموضف الذي قام برفضها
                </th>

                <th class=""col-sm-1"">
                    سبب الرفض
                </th>
                <th class=""col-sm-2"">
                    الصلاحية
                </th>
                <th class=""col-sm-1"">
                    تاريخ الرفض
                </th>


            </tr>
        </thead>

        <tbody>
");
#nullable restore
#line 29 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
             if (Model.Compalints_SolutionList.Count() == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"3\" style=\"color:red\">\r\n                        لم يتم رفض هذه الشكوى من قبل اي موضف\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 36 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                 foreach (var item in Model.ComplaintsRejectedList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td class=\"width content\">\r\n                            ");
#nullable restore
#line 43 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                       Write(Html.DisplayFor(modelItem => item.RejectedProvName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                        <td>
                            <div class=""row demo-vertical-spacing"">
                                <div class=""d-inline-block"">
                                    <button type=""button""
                                            class=""btn btn-primary""
                                            data-bs-toggle=""modal""
                                            data-bs-target=""#modalLong""
                                            ");
            WriteLiteral(">\r\n                                        انقر هنا لعرض الحل\r\n                                    </button>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b504820ff120079aa07070ba88e31f8d290c9f78112", async() => {
                WriteLiteral("\r\n\r\n                                        انقر هنا لعرض الحل\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                </div>\r\n\r\n\r\n");
            WriteLiteral(@"
                                <div class=""modal fade"" id=""modalScrollable"" tabindex=""-1"" aria-hidden=""true"">
                                    <div class=""modal-dialog modal-dialog-scrollable"" role=""document"">
                                        <div class=""modal-content"">
                                            <div class=""modal-header"">
                                                <h5 class=""modal-title"" id=""modalScrollableTitle"">Modal title</h5>
                                                <button type=""button""
                                                        class=""btn-close""
                                                        data-bs-dismiss=""modal""
                                                        aria-label=""Close""></button>
                                            </div>
                                            <div class=""modal-body"">
                                                <p>
                                                    ");
#nullable restore
#line 88 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                                               Write(Html.DisplayFor(modelItem => @item.reume));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </p>

                                            </div>
                                            <div class=""modal-footer"">
                                                <button type=""button"" class=""btn btn-label-secondary"" data-bs-dismiss=""modal"">
                                                    Close
                                                </button>

                                            </div>
                                        </div>
                                    </div>
                                </div>

");
            WriteLiteral("\r\n\r\n                            </div>\r\n                        </td>\r\n\r\n\r\n\r\n\r\n                        <td>\r\n");
#nullable restore
#line 112 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                             if (@item.Role == "AdminGeneralFederation")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge bg-label-success\">مدير اتحاد</span>\r\n");
#nullable restore
#line 115 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                            }
                            else if (@item.Role == "AdminGovernorate")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge bg-label-warning\"> مدير محافظة</span>\r\n");
#nullable restore
#line 119 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                            }
                            else if (@item.Role == "AdminDirectorate")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge bg-label-warning\"> مدير مديرة</span>\r\n");
#nullable restore
#line 123 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                            }
                            else if (@item.Role == "AdminSubDirectorate")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge bg-label-warning\"> مدير عزلة</span>\r\n");
#nullable restore
#line 127 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            ");
#nullable restore
#line 129 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DateSolution));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 133 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Shared\_AllSolutionsRejected.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProvideSolutionsVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
