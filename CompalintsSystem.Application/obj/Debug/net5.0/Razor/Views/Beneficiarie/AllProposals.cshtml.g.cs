#pragma checksum "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f9cc14d7d4d306d51757cb9450413e4589c6c15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Beneficiarie_AllProposals), @"mvc.1.0.view", @"/Views/Beneficiarie/AllProposals.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f9cc14d7d4d306d51757cb9450413e4589c6c15", @"/Views/Beneficiarie/AllProposals.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1524c428b22ec937f4d7973ab43c585c086b4e06", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Beneficiarie_AllProposals : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Proposal>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetailsProposal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-icon item-edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item text-danger delete-record"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Beneficiarie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
  
    ViewData["Title"] = "الاقتراحات";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""content-wrapper"">
  


        <div class=""container-xxl flex-grow-1 container-p-y"">
            <h4 class=""breadcrumb-wrapper py-3 mb-4"">
                <span class=""text-muted fw-light""> الاقتراحات/</span>  المقدمة من قبلك
            </h4>

            <div class=""card"">

                <div class=""row mx-2  "">
                    <div class=""col-md-6"">
                        <div class=""t-d"">
                            <h5 class=""card-header title-t""> الاقتراحات</h5>
                        </div>

                    </div>


                </div>

                <div class=""card-datatable table-responsive"">
                    <div id=""DataTables_Table_0_wrapper"" class=""dataTables_wrapper dt-bootstrap5 no-footer"">

                        <div class=""table-responsive text-nowrap"">
                            <table id=""example"" class=""datatables-users table border-top "">

                                <thead>
                                    <tr>");
            WriteLiteral(@"
                                        <th>
                                            عنوان الاقتراح
                                        </th>
                                        <th>
                                            تاريخ التقديم
                                        </th>
                                        <th>
                                            محتوى الاقتراح
                                        </th>

                                        <th>اجراء</th>
                                    </tr>
                                </thead>

                                <tbody>
");
#nullable restore
#line 55 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                     if (Model.Count() == 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <tr>
                                            <td colspan=""3"" style=""color:red"">
                                                لا يوجد نتائج
                                            </td>
                                        </tr>
");
#nullable restore
#line 62 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                    }
                                    else
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n");
#nullable restore
#line 68 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                                 if (item.TitileProposal.Length > 20)
                                                {
                                                    item.TitileProposal.Substring(0, 20);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>\r\n                                                        ");
#nullable restore
#line 72 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                                   Write(item.TitileProposal.Substring(0, 20));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                                    </td>\r\n");
#nullable restore
#line 75 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td> ");
#nullable restore
#line 76 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                                Write(Html.DisplayFor(modelItem => item.DateSubmeted));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                                <td> ");
#nullable restore
#line 78 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                                Write(Html.DisplayFor(modelItem => item.DescProposal));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n                                                <td");
            BeginWriteAttribute("style", " style=\"", 3190, "\"", 3198, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                    <div class=""d-inline-block"">
                                                        <button class=""btn btn-sm btn-icon dropdown-toggle hide-arrow"" data-bs-toggle=""dropdown"">
                                                            <i class=""bx bx-dots-vertical-rounded""></i>
                                                        </button>
                                                        <ul class=""dropdown-menu dropdown-menu-end"">
                                                            <li>
                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f9cc14d7d4d306d51757cb9450413e4589c6c1511961", async() => {
                WriteLiteral(@"
                                                                    <i class=""bi bi-eye icon-padding icon-color""></i>

                                                                    عرض
                                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                            </li>\r\n                                                            <li>\r\n                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f9cc14d7d4d306d51757cb9450413e4589c6c1514755", async() => {
                WriteLiteral(@"
                                                                    تعديل
                                                                    <i class=""bi bi-eye icon-padding icon-color""></i>
                                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                                                                                                             WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                            </li>\r\n                                                            <li>\r\n                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f9cc14d7d4d306d51757cb9450413e4589c6c1517554", async() => {
                WriteLiteral(@"
                                                                    <i class=""bi bi-eye icon-padding icon-color""></i>
                                                                    حذف
                                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                                                                                                                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                            </li>

                                                        </ul>

                                                    </div>


                                                </td>
                                            </tr>
");
#nullable restore
#line 115 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\Beneficiarie\AllProposals.cshtml"
                                         
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"



    <script>


        $('#CustomSearchTextField').keyup(function () {

            oTable.search($(this).val()).draw();

        });

        var oTable = $('#example').DataTable({

            language: {
                ""loadingRecords"": ""جارٍ التحميل..."",
                ""lengthMenu"": ""أظهر _MENU_ مدخلات"",
                ""zeroRecords"": ""لم يعثر على أي شكوى"",
                ""info"": ""إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل"",
                ""search"": ""ابحث:"",
                ""searchPlaceholder"": ""بحث عن شكوى"",
                ""paginate"": {
                    ""first"": ""الأول"",
                    ""previous"": ""السابق"",
                    ""next"": ""التالي"",
                    ""last"": ""الأخير""
                }

            },

            ""paging"": true,
            ""lengthChange"": false,
            /*""searching"": true,*/
            ""ordering"": false,
            ""info"": false,
            ""autoWidth"": false,
            ""responsive"": false,
            ""sear");
                WriteLiteral(@"ching"": true,
            //dom: '<""card-header flex-column flex-md-row""<""head-label text-center""><""dt-action-buttons text-end pt-3 pt-md-0""B>><""row""<""col-sm-12 col-md-6""l><""col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end""f>>t<""row""<""col-sm-12 col-md-6""i><""col-sm-12 col-md-6""p>>',
            displayLength: 4,
            //lengthMenu: [5, 10, 25, 50, 75, 100],
            //""columnDefs"": [
            //    target: 1,
            //    ordering: true
            //],
        });   //using Capital D, which is mandatory to retrieve ""api"" datatables' object, latest jquery Datatable





    </script>


    ");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Proposal>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
