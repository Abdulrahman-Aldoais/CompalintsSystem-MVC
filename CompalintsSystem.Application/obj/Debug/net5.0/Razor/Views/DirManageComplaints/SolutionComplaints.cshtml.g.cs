#pragma checksum "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56b675ecf7cf26f91ccdfa8f922939db1f54d1bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DirManageComplaints_SolutionComplaints), @"mvc.1.0.view", @"/Views/DirManageComplaints/SolutionComplaints.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b675ecf7cf26f91ccdfa8f922939db1f54d1bf", @"/Views/DirManageComplaints/SolutionComplaints.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1524c428b22ec937f4d7973ab43c585c086b4e06", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_DirManageComplaints_SolutionComplaints : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UploadsComplainte>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
  
    ViewData["Title"] = "إدارة الشكاوى في المديرية";
    ViewData["SubTitle"] = "المديرية";
    ViewData["SubTitle2"] = "إدارة الشكاوى  ";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""content-wrapper"">

    <div class=""container-xxl flex-grow-1 container-p-y"">
        <div class=""container-xxl flex-grow-1 container-p-y"">
            <h4 class=""breadcrumb-wrapper py-3 mb-4"">
                <span class=""text-muted fw-light"">");
#nullable restore
#line 17 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                             Write(ViewData["SubTitle2"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("/</span> ");
#nullable restore
#line 17 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                                                            Write(ViewData["SubTitle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </h4>

            <div class=""card"">
                <div class=""card-body"">
                    <div class=""row mx-2  "">
                        <div class=""col-md-6"">
                            <div class=""t-d"">
                                <h5 class=""card-header title-t"">  الشكاوى المحلولة</h5>
                            </div>

                        </div>
                        <div class=""col-md-6"">
                            <div class=""dropdown"" style=""text-align-last: end;"">

");
            WriteLiteral(@"                                    <div class=""btn-group"">
                                        <span class=""badge bg-label-primary badgess "" style=""    padding-left: 36px;
                        line-height: 1.99;
                        width: 152.35px;"">العدد الكلي ");
#nullable restore
#line 38 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                                 Write(ViewBag.totaleComp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n");
            WriteLiteral(@"                            </div>

                        </div>

                    </div>

                    <div class=""card-datatable table-responsive"">
                        <div id=""DataTables_Table_0_wrapper"" class=""dataTables_wrapper dt-bootstrap5 no-footer"">
                            <div class=""table-responsive text-nowrap"">
                                <table id=""example"" class=""table table-bordered table table-bordered"" style=""border-radius: 0.25rem;"">

                                    <thead>
                                        <tr>
                                            <th>
                                                العنوان
                                            </th>
                                            <th>
                                                تاريخ
                                            </th>
                                            <th>
                                                المحافظة
                  ");
            WriteLiteral(@"                          </th>
                                            <th>
                                                المرحلة
                                            </th>
                                            <th>
                                                الحالة
                                            </th>
                                            <th>الاجراءات</th>
                                        </tr>
                                    </thead>

                                    <tbody>
");
#nullable restore
#line 75 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                         if (Model.Count() == 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <tr>
                                                <td colspan=""3"" style=""color:red"">
                                                    لا يوجد نتائج
                                                </td>
                                            </tr>
");
#nullable restore
#line 82 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 89 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.TitleComplaint));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td> ");
#nullable restore
#line 91 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                                    Write(Html.DisplayFor(modelItem => item.UploadDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 93 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Governorate.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td> ");
#nullable restore
#line 95 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                                    Write(Html.DisplayFor(modelItem => item.StatusCompalint.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td> ");
#nullable restore
#line 96 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                                    Write(Html.DisplayFor(modelItem => item.TypeComplaint.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n                                                    <td data-title=\"الاجراءات :\">\r\n                                                        <a");
            BeginWriteAttribute("href", " href=\"", 4694, "\"", 4781, 1);
#nullable restore
#line 101 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
WriteAttributeValue("", 4701, Url.Action("ViewCompalintDetails", "DirManageComplaints", new { id = item.Id }), 4701, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                                                           class=""btn btn-info""
                                                           style=""padding: 0px; margin: 0px 2px 0px 2px"">
                                                            <i class=""material-icons"" style=""padding: 4px;"">عرض</i>
                                                        </a>
                                                      
                                                    </td>

                                                </tr>
");
#nullable restore
#line 110 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 110 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\DirManageComplaints\SolutionComplaints.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </tbody>
                                </table>
                            </div>

                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</div>



");
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
                ""search"": ""البحث:"",
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
            ""responsive"": true,
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



    <script>
        //فلترة نوع الشاكي
        $(""#FilterType"").change(function () {
            var value = $(this).val().toLowerCase();
            $("".table tbody tr"").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });
        //
    </script>
    <script>

        $(document)");
                WriteLiteral(@".ready(function () {
            $(""#typeComp"").change(function () {
                $('#tableComp').childern(""tr"").remove();
                $.get(""/UploadsComplainte/ViewCompalintsByStutas"", { id: $('#typeComp').val() }, function (data) {
                    $.each(data, function (Index, row) {
                        $('#tableComp').oppend(""<tr><td>"" + row.Id + ""</td><td>"" + row.TitleComplaint + ""</td><td>""
                            + row.CompDate + ""</td><tr>"");
                    });
                });
            });
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UploadsComplainte>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
