#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Reports\approved_plan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf5f7a5c421f81fb9fea6d225fec5b4b423f74cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_approved_plan), @"mvc.1.0.view", @"/Views/Reports/approved_plan.cshtml")]
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
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\_ViewImports.cshtml"
using AIS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\_ViewImports.cshtml"
using AIS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf5f7a5c421f81fb9fea6d225fec5b4b423f74cb", @"/Views/Reports/approved_plan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_approved_plan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Reports\approved_plan.cshtml"
  
    ViewData["Title"] = "Audit Criterai";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $('#document').ready(function () {
        $('#sidebar_policy').hide();
    });
</script>

<div class=""row text-center"" style=""margin-top:50px;"">
   <h3>AUDIT CRITERIA</h3>
</div>

<div>
    <div class=""row"" style=""margin-top:50px;"">
        <div class=""row w-100"">
            <center>
                <h6 style=""display:block;"">Criteria For Chalking Out Audit Plan</h6>
            </center>
        </div>

        <table class=""table table-bordered table mb-0 mt-1 bg-white table-hover table-striped"" id=""Audit Criteria"">
            <tbody>
                <tr>
                    <td>1</td>
                    <td>Branch Size (small)</td>
                    <td>04 Days</td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>Branch Size (medium)</td>
                    <td>05 Days</td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>Branch Size");
            WriteLiteral(@" (large)</td>
                    <td>07 Days</td>
                </tr>
                <tr>
                    <td>4</td>
                    <td>For Management Audit of Zonal Office</td>
                    <td>02 Days</td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>For Audit of HO Units</td>
                    <td>01 Day</td>
                </tr>
                <tr>
                    <td>6</td>
                    <td>For Checking of utilization/spot visits</td>
                    <td>01 to 02 Days (Keeping in view the volume of work in branch)</td>
                </tr>
                <tr>
                    <td>7</td>
                    <td>For Checking of Revenue Record</td>
                    <td>01 to 02 Days (Keeping in view the volume of work in branch)</td>
                </tr>
                <tr>
                    <td>8</td>
                    <td>Discussion of Audit Report</td>
                    <t");
            WriteLiteral(@"d>One Day (*)</td>
                </tr>
                <tr>
                    <td>9</td>
                    <td colspan=""2"">Journey time may also kept in view and an additional day be allowed where justified.</td>
                </tr>
                <tr>
                    <td colspan=""3"">(*) Discussion may be held on the last day of audit or next day keeping in view the volume of work. <br /> (SVP/Incharge, Audit Zone may reduce No. of days, if work can be completed in lesser days)</td>
                </tr>
            </tbody>
        </table>
        <label>
            (Criteria for Audit of CAD Hub) = No of Days (Workload will be allocated on the basis of 50 loan cases per member per day)
        </label>
    </div>
</div>");
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
