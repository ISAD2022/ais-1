#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Engagement\Join.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "997de98141ed8e2776401f95bd57af535ab799c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Engagement_Join), @"mvc.1.0.view", @"/Views/Engagement/Join.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"997de98141ed8e2776401f95bd57af535ab799c8", @"/Views/Engagement/Join.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    public class Views_Engagement_Join : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Engagement\Join.cshtml"
  
    ViewData["Title"] = "Join";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    var g_joinRes = null;
    $('#document').ready(function () {
        var url_string = window.location;
        var url = new URL(url_string);
        var eng_id = url.searchParams.get(""id"");
        $.ajax({
            url: ""/Engagement/get_joining_details"",
            type: ""POST"",
            data: {
                'engId': eng_id
            },
            cache: false,
            success: function (data) {
                g_joinRes = data;
                $('#ent_name_field').html(data.entitY_NAME);
                $('#ent_risk_field').html(data.risk);
                $('#ent_size_field').html(data.size);
                var sDate = data.starT_DATE.split('T')[0];
                var sfromat = sDate.split('-')[2] + ""/"" + sDate.split('-')[1] + ""/"" + sDate.split('-')[0];
                var eDate = data.enD_DATE.split('T')[0];
                var efromat = eDate.split('-')[2] + ""/"" + eDate.split('-')[1] + ""/"" + eDate.split('-')[0];
             ");
            WriteLiteral(@"   $('#ent_start_field').html(sfromat);
                $('#ent_end_field').html(efromat);
                $('#ent_team_name_field').html(data.teaM_NAME);
                $('#ent_period_field').html(data.audiT_PERIOD);
                $.each(data.teaM_DETAILS, function (i, v) {
                    $('#teamDetailsPanel tbody').append('<tr><td>' + v.emP_NAME + '</td><td>' + v.pP_NO + '</td><td><input id=""joinDate_' + v.pP_NO + '"" type=""date"" class=""form-control"" /></td><td><input id=""completeDate_' + v.pP_NO +'"" type=""date"" class=""form-control"" /></td><td>' + v.iS_TEAM_LEAD +'</td></tr>')
                });

            },
            dataType: ""json"",
        });
    });

    function publishJoinReport() {
        $.each(g_joinRes.teaM_DETAILS, function (i, v) {
        $.ajax({
            url: ""/Engagement/add_joining_report"",
            type: ""POST"",
            data: {
                'ID': 0,
                'ENG_PLAN_ID': g_joinRes.enG_PLAN_ID,
                'TEAM_MEM_PPNO': v.pP");
            WriteLiteral(@"_NO,
                'JOINING_DATE': $('#joinDate_' + v.pP_NO).val(),
                'COMPLETION_DATE': $('#completeDate_' + v.pP_NO).val()
            },
            cache: false,
            success: function (data) {

            },
            dataType: ""json"",
        });
        });
        alert(""<p>Succesfully done</p>"");
        onAlertCallback(redirectToTaskList);
    }
    function redirectToTaskList() {
        window.location = ""/Engagement/task_list"";
    }
</script>

<div class=""row mt-3"">
        <h4 style=""display: block; color: #45c545;"">Joining Report</h4>
</div>
<div class=""row col-md-12"">
    <div class=""col-md-6"">

        <table class=""table table-bordered mb-0 mt-3 bg-white table-hover table-striped"" >
            <thead>
                <tr>
                    <td><h6>Audit Plan</h6></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Audit Period</td>
                    <td id=""ent_perio");
            WriteLiteral(@"d_field""></td>
                </tr>
                <tr>
                    <td width=""150"">Entity</td>
                    <td id=""ent_name_field"" width=""200""></td>
                </tr>
                <tr>
                    <td>Entity Risk</td>
                    <td id=""ent_risk_field""></td>
                </tr>
                <tr>
                    <td>Entity Size</td>
                    <td id=""ent_size_field""></td>
                </tr>

                <tr>
                    <td>Start Date</td>
                    <td id=""ent_start_field""></td>
                </tr>
                <tr>
                    <td>End Date</td>
                    <td id=""ent_end_field""></td>
                </tr>

                <tr>
                    <td>Audit Conducted by</td>
                    <td id=""ent_team_name_field""></td>
                </tr>

            </tbody>
        </table>

    </div>

    <div class=""col-md-6"">

        <table class=""table table-bord");
            WriteLiteral(@"ered table-sm mb-0 mt-3 bg-white table-hover table-striped"" id=""Joining Report"">
            <thead>
                <tr>
                    <th>Sample Criteria</th>
                </tr>
            </thead>
                <tbody>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>

                </tbody>
        </table>
    </div>

</div>

    <div class=""mt-3"">
        <table id=""teamDetailsPanel"" class=""table table-bordered mb-0 mt-3 bg-white table-hover table-striped"" >
            <thead>
                <tr>
    ");
            WriteLiteral(@"                <th class=""font-weight-bold"">Name</th>
                    <th class=""font-weight-bold"">P.P. No</th>
                    <th class=""font-weight-bold"">Joining Date</th>
                    <th class=""font-weight-bold"">Completion Date</th>
                    <th class=""font-weight-bold"">Is team Lead</th>
                </tr>
</thead>
           <tbody></tbody>
        </table>
    </div>
    <div class=""row"">
       
        <div class=""col-md-6 mt-5"">
            <button onclick=""publishJoinReport();"" class=""btn btn-primary"" style=""float:left;"">Submit</button>
        </div>
    </div>
");
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
