#pragma checksum "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7eb72a3cc4cbcc095c3122a7050bde85124f441c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GeneralFederation_PrintReports), @"mvc.1.0.view", @"/Views/GeneralFederation/PrintReports.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7eb72a3cc4cbcc095c3122a7050bde85124f441c", @"/Views/GeneralFederation/PrintReports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1524c428b22ec937f4d7973ab43c585c086b4e06", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_GeneralFederation_PrintReports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"



<div class=""card  border-bottom  m-4"">
    <div class=""card card-headerText"" style=""margin-bottom: 2px;"">
        <div class=""card-header border-bottom  "">

            <div class=""row "">
                <div class="" col-md-11"">
                    <i class=""menu-icon tf-icons bx bx-carousel""></i>    تقارير النظام
                </div>

                <div class=""card-header border-bottom cardhead"">
                    <div class="" "">
                        <input type=""button"" value=""طباعة"" class=""bx bx-printer me-2""
                               onclick=""printDiv()"">

                    </div>

                </div>
            </div>
        </div>
    </div>


    <div class=""p-4 "">
        <h3 class=""card-title mb-2"">  عدد المستخدمين في المحافظات</h3>
        <div class=""table-responsive text-nowrap mt-4 mb-4"">
            <table class=""table table-bordered table table-bordered"">
                <thead>
                    <tr>

                        <th> المح");
            WriteLiteral("افظة</th>\r\n                        <th>العدد </th>\r\n                        <th> النسبة </th>\r\n");
            WriteLiteral("\r\n                    </tr>\r\n                </thead>\r\n                <tbody class=\"table-border-bottom-0\">\r\n");
#nullable restore
#line 45 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                     foreach (var item in ViewBag.totalGovermentuser)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 48 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 49 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.totalUsers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            <td>% ");
#nullable restore
#line 51 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                              Write(Math.Round(@item.Users, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 53 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
    <div class=""p-4 "">
        <h3 class=""card-title mb-2"">  احصائيات انواع الموضفين</h3>
        <div class=""table-responsive text-nowrap mt-4 mb-4"">
            <table class=""table table-bordered table table-bordered"">
                <thead>
                    <tr>
                        <th> نوع الصلاحية</th>
                        <th>العدد </th>
                        <th> النسبة المؤوية</th>
                    </tr>
                </thead>
                <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 70 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                     foreach (var item in ViewBag.totalUserByRoles)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 73 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 74 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.TotalCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            <td>%");
#nullable restore
#line 76 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                             Write(Math.Round(@item.RolsTot, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 78 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </tbody>
            </table>
        </div>
    </div>

    <div class=""p-4 "">
        <h3 class=""card-title mb-2"">  احصائيات انواع الشكاوى</h3>
        <div class=""table-responsive text-nowrap mt-4 mb-4"">
            <table class=""table table-bordered table table-bordered"">
                <thead>
                    <tr>

                        <th> نوع الشكوى</th>
                        <th>العدد </th>
                        <th> النسبة المؤوية</th>

                    </tr>
                </thead>
                <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 99 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                     foreach (var item in ViewBag.GrapComplanrType)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n\r\n                            <td>");
#nullable restore
#line 103 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 104 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.TotalCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            <td>%");
#nullable restore
#line 106 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                             Write(Math.Round(@item.TypeComp, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 110 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



                </tbody>
            </table>
        </div>
    </div>

    <div class=""p-4 "">
        <h3 class=""card-title mb-2"">  احصائيات حالات الشكاوى</h3>
        <div class=""table-responsive text-nowrap mt-4 mb-4"">
            <table class=""table table-bordered table table-bordered"">
                <thead>
                    <tr>

                        <th>  الحالة</th>
                        <th>العدد </th>
                        <th> النسبة المؤوية</th>

                    </tr>
                </thead>
                <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 135 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                     foreach (var item in ViewBag.GrapComplanrStutus)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n\r\n                            <td>");
#nullable restore
#line 139 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 140 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.TotalCountStutus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            <td>%");
#nullable restore
#line 142 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                             Write(Math.Round(@item.stutus, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 146 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



                </tbody>
            </table>
        </div>
    </div>


    <div class=""p-4 "">
        <h3 class=""card-title mb-2"">  احصائيات البلاغات</h3>
        <div class=""table-responsive text-nowrap mt-4 mb-4"">
            <table class=""table table-bordered table table-bordered"">
                <thead>
                    <tr>

                        <th>  البلاغ</th>
                        <th>العدد </th>
                        <th> النسبة المؤوية</th>

                    </tr>
                </thead>
                <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 172 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                     foreach (var item in ViewBag.totalcommunications)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n\r\n                            <td>");
#nullable restore
#line 176 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 177 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                           Write(item.TotalCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            <td>%");
#nullable restore
#line 179 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"
                             Write(Math.Round(@item.TypeComp, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 183 "E:\My_GitHub\CompalintsSystem-MVC\CompalintsSystem.Application\Views\GeneralFederation\PrintReports.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n    <!-- Column Chart -->\r\n   \r\n</div>\r\n<!-- / Content -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
