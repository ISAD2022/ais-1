#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Reports\significant_finding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c72156a507b09c8bf92d0f9940f76d69169f75d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_significant_finding), @"mvc.1.0.view", @"/Views/Reports/significant_finding.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c72156a507b09c8bf92d0f9940f76d69169f75d9", @"/Views/Reports/significant_finding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_significant_finding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Reports\significant_finding.cshtml"
   ViewData["Title"] = "Significant Findings";
    Layout = "_Layout"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        $('#sidebar_policy').hide();
    })
</script>
<div class=""mt-3 mb-4"">
    <h3 style="" display:block;color: #45c545;"">Significant Findings</h3>
</div>


<script type=""text/javascript"">
    var g_teams = [];
    var g_branches = [];
    $(document).ready(function () {
        $('#deptSelectionBox').addClass('d-none');
        $('.hiddenContainers').addClass('d-none');
        $('.fieldAuditFields').addClass('d-none');
        $('.nonFieldAuditFields').addClass('d-none');
        $('#branchInfoArea').addClass('d-none');
        ShowDepartmentAuditPeriods();

    });
    function getBusinessDateCount(startDate, endDate) {
        var elapsed, daysBeforeFirstSaturday, daysAfterLastSunday;
        var ifThen = function (a, b, c) {
            return a == b ? c : a;
        };

        elapsed = endDate - startDate;
        elapsed /= 86400000;

        daysBeforeFirstSunday = (7 - startDate.getDay()) % 7;
 ");
            WriteLiteral(@"       daysAfterLastSunday = endDate.getDay();

        elapsed -= (daysBeforeFirstSunday + daysAfterLastSunday);
        elapsed = (elapsed / 7) * 5;
        elapsed += ifThen(daysBeforeFirstSunday - 1, -1, 0) + ifThen(daysAfterLastSunday, 6, 5);

        return Math.ceil(elapsed);
    }
    function ShowDepartmentAuditPeriods() {
        if ($('#deptSelectionBox option:selected').val() == 0)
            $('.hiddenContainers').addClass('d-none');
        else {
            $('.hiddenContainers').removeClass('d-none');
            if ($('#deptSelectionBox option:selected').val() == '473') {
                $('.fieldAuditFields').removeClass('d-none');
                $('.nonFieldAuditFields').addClass('d-none');
            } else {
                $('.nonFieldAuditFields').removeClass('d-none');
                $('.fieldAuditFields').addClass('d-none');
            }
            $.ajax({
                url: ""/Planning/audit_periods"",
                type: ""POST"",
                data:");
            WriteLiteral(@" {
                    'dept_code': $('#deptSelectionBox option:selected').val()
                },
                cache: false,
                success: function (data) {
                    $('#periodSelectionBox').empty();
                    $('#periodSelectionBox').append('<option value=""0"" id=""0"">--Select Audit Period--</option>')
                    //console.log(data);
                    $.each(data, function (index, period) {
                        $('#periodSelectionBox').append('<option value=""' + period.id + '"" id=""' + period.id + '"">' + period.description + '</option>')
                    });

                },
                dataType: ""json"",
            });
            $.ajax({
                url: ""/Planning/audit_teams"",
                type: ""POST"",
                data: {
                    'dept_code': $('#deptSelectionBox option:selected').val()
                },
                cache: false,
                success: function (data) {
                    $('");
            WriteLiteral(@"#teamSelectionBox').empty();
                    $('#teamSelectionBox').append('<option value=""0"" id=""0"">--Select Audit Team--</option>')
                    g_teams = data;
                    $.each(data, function (index, team) {
                        if (team.iS_TEAMLEAD == 'Y')
                            $('#teamSelectionBox').append('<option value=""' + team.code + '"" id=""' + team.code + '"">' + team.name + '</option>')
                    });

                },
                dataType: ""json"",
            });
        }
    }
    function ShowSelectedZonesBranches() {
        if ($('#auditZoneSelectionBox option:selected').val() == 0) {
            $('#branchSelectionBox').empty();
            $('#branchInfoArea').addClass('d-none');
            $('#branchSelectionBox').append('<option value=""0"" id=""0"">--Select Audit Branch--</option>');
        }
        else {
            $('#branchSelectionBox').empty();
            $('#branchInfoArea').removeClass('d-none');
            $('#b");
            WriteLiteral(@"ranchSelectionBox').append('<option value=""0"" id=""0"">--Select Audit Branch--</option>')
            $.ajax({
                url: ""/Planning/zone_branches"",
                type: ""POST"",
                data: {
                    'zone_code': $('#auditZoneSelectionBox option:selected').val()
                },
                cache: false,
                success: function (data) {
                    g_branches = data;
                    $('#branchSelectionBox').empty();
                    $('#branchInfoArea').hide();
                    $('#branchSelectionBox').append('<option value=""0"" id=""0"">--Select Audit Branch--</option>')
                    //console.log(data);
                    $.each(data, function (index, branch) {
                        $('#branchSelectionBox').append('<option value=""' + branch.id + '"" id=""' + branch.id + '"">' + branch.description + '</option>')
                    });

                },
                dataType: ""json"",
            });
        }
    ");
            WriteLiteral(@"}
    function ShowSelectedDivisionDepartments() {
        if ($('#divSelectionBox option:selected').val() == 0) {
            $('#divDeptSelectionBox').empty();
            $('#divDeptSelectionBox').append('<option value=""0"" id=""0"">--Select Audit Department--</option>')
        }
        else {
            $('#divDeptSelectionBox').empty();
            $.ajax({
                url: ""/Planning/div_departments"",
                type: ""POST"",
                data: {
                    'div_code': $('#divSelectionBox option:selected').val()
                },
                cache: false,
                success: function (data) {
                    $('#divDeptSelectionBox').empty();
                    $('#divDeptSelectionBox').append('<option value=""0"" id=""0"">--Select Audit Department--</option>')
                    //console.log(data);
                    $.each(data, function (index, dept) {
                        $('#divDeptSelectionBox').append('<option value=""' + dept.id + '"" id=""'");
            WriteLiteral(@" + dept.id + '"">' + dept.name + '</option>')
                    });

                },
                dataType: ""json"",
            });
            getSubEntities();
        }
    }
    function ShowBranchInfoBox() {
        if ($('#branchSelectionBox option:selected').val() == 0) {
            $('#branchInfoArea').addClass('d-none');
        } else {
            $('#branchInfoArea').removeClass('d-none');
        }
    }
    function previewAuditPlan() {

        $('#previewAuditPlan').modal('show');
        $('#auditorDept').text($('#deptSelectionBox option:selected').text());
        $('#auditorPlan').text($('#periodSelectionBox option:selected').text());
        $('#descModal_field').html($('#entitySelectionBox option:selected').text());
        if ($('#deptSelectionBox option:selected').val() == '473') {
            $('#divzone_field').text($('#auditZoneSelectionBox option:selected').text());
            $('#deptBranch_field').text($('#branchSelectionBox option:selected').text(");
            WriteLiteral(@"));

        } else {
            $('#divzone_field').text($('#divSelectionBox option:selected').text());
            $('#deptBranch_field').text($('#divDeptSelectionBox option:selected').text());

        }
        $('#exeFrom_field').html($('#executionPeriodFromField').val());
        $('#exeTo_field').html($('#executionPeriodToField').val());
        $('#operationalFrom_field').html($('#auditPeriodFromField').val());
        $('#operationalTo_field').html($('#auditPeriodToField').val());
        //
        if ($('#isTravelingRequiredField').is("":checked""))
            $('#travelingReq_field').html('Yes');
        else
            $('#travelingReq_field').html('No');
        $('#remarksAddtn_field').html($('#remarksAdditionalInfoField').val());
        $('#teamName_field').text($('#teamSelectionBox option:selected').text());
        //
        var teamMembersFields = """";
        $.each(g_teams, function (index, team) {
            if (team.name == $('#teamSelectionBox option:selected').");
            WriteLiteral(@"text()) {
                if (team.iS_TEAMLEAD == ""Y"")
                    teamMembersFields += team.employeename + "" "" + team.teammembeR_ID + "" (L)<br>"";
                else
                    teamMembersFields += team.employeename + "" "" + team.teammembeR_ID + "" (M)<br>"";
            }
        });
        $('#teamMembers_field').html(teamMembersFields);

    }
    function publishNewAuditPlanChanges() {

        alert(""Under Construction"");
        return false;
        var periodId = $('#periodSelectionBox option:selected').val();
        var stDate = $('#executionPeriodFromField').val();
        var edDate = $('#executionPeriodToField').val();
        var period_stDate = $('#auditPeriodFromField').val();
        var period_edDate = $('#auditPeriodToField').val();
        var conducted_by = $('#deptSelectionBox option:selected').val();
        var no_days = getBusinessDateCount(new Date(stDate), new Date(edDate));
        var zoneId = $('#auditZoneSelectionBox option:selected').val();");
            WriteLiteral(@"
        var branchId = 0;
        if (zoneId != 0)
            branchId = $('#branchSelectionBox option:selected').val();

        var divId = $('#divSelectionBox option:selected').val();
        var deptId = 0;
        if (divId != 0)
            deptId = $('#divDeptSelectionBox option:selected').val();

        var teamId = $('#teamSelectionBox option:selected').val();
        var status = 1;
        var desc = $('#descriptionAuditPlanField').val();

        $.ajax({
            url: ""/Planning/add_audit_plan"",
            type: ""POST"",
            data: {
                'AUDITPERIOD_ID': periodId,
                'AUDIT_STARTDATE': stDate,
                'AUDIT_ENDDATE': edDate,
                'AUDITPERIOD_FROM': period_stDate,
                'AUDITPERIOD_TO': period_edDate,
                'AUDIT_CONDUCTBY_DEPT': conducted_by,
                'NO_OF_DAYS_AUDIT': no_days,
                'AUDIT_ZONEID': zoneId,
                'BRANCHID': branchId,
                'DIVISION_");
            WriteLiteral(@"ID': divId,
                'DEPARTMENT_ID': deptId,
                'TEAM_CONST_ID': teamId,
                'STATUS': status,
                'DESCRIPTION': desc
            },
            cache: false,
            success: function (data) {
                window.location.href = ""/Planning/audit_plan?dept="" + $('#deptSelectionBox option:selected').val() + ""&periodId="" + $('#periodSelectionBox option:selected').val();
            },
            dataType: ""json"",
        });
    }
    function getSubEntities() {
        if ($('#divSelectionBox option:selected').val() != 0) {
            $('#entitySelectionBox').empty();
            $('#entitySelectionBox').append('<option value=""0"" id=""0"" selected=""selected"">--Select Sub Entity--</option>');
            $.ajax({
                url: ""/Setup/get_sub_entities"",
                type: ""POST"",
                data: {
                    'div_id': $('#divSelectionBox option:selected').val(),
                    'dept_id': $('#divDeptSelection");
            WriteLiteral(@"Box option:selected').val(),
                },
                cache: false,
                success: function (data) {
                    $.each(data, function (index, ent) {
                        $('#entitySelectionBox').append('<option value=""' + ent.id + '"" id=""' + ent.id + '"" >' + ent.name + '</option>');
                    });

                },
                dataType: ""json"",
            });

        } else {
            $('#entitySelectionBox').empty();
            $('#entitySelectionBox').append('<option value=""0"" id=""0"" selected=""selected"">--Select Sub Entity--</option>');
        }


    }
</script>




<div class=""row col-md-12 mt-3"">
    <div class=""row col-md-6 mr-2"">
        <label>Select Department</label>
        <select id=""entity"" onchange=""ShowDepartmentAuditPeriods();"" class=""form-select form-control"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72156a507b09c8bf92d0f9940f76d69169f75d919084", async() => {
                WriteLiteral("--Select Department--");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72156a507b09c8bf92d0f9940f76d69169f75d920665", async() => {
                WriteLiteral("Information Systems Audit Department");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72156a507b09c8bf92d0f9940f76d69169f75d921950", async() => {
                WriteLiteral("Corporate Audit Department");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72156a507b09c8bf92d0f9940f76d69169f75d923225", async() => {
                WriteLiteral("Field Audit Department");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72156a507b09c8bf92d0f9940f76d69169f75d924496", async() => {
                WriteLiteral("Inspection & Complaint Department");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </select>\r\n    </div>\r\n    <div class=\"row col-md-6\" >\r\n        <label>Audit Year</label>\r\n        <select id=\"entitySelectionBox\" class=\"form-select form-control\" aria-label=\"Default select example\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72156a507b09c8bf92d0f9940f76d69169f75d926006", async() => {
                WriteLiteral("--Select Audit Year--");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </select>
    </div>
</div>
<div class=""row mt-3 col-md-12"">
    <div class=""row col-md-6"">
        <label>Start Date:</label><input class=""form-control"" type=""date"" />
    </div>
    <div class=""row col-md-6"" style=""margin-left:10px;"">
        <label>End Date:</label><input class=""form-control"" type=""date"" />
    </div>
</div>


<div class=""row col-md-12 w-100 mt-3"">
    
        <button class=""btn btn-primary"">Find</button>
    
</div>

<div class=""row col-md-12 mt-4"">
    <table id=""Risk wise observation"" class=""table table-hover table-bordered table-hover mt-3 table-striped"">
        <thead style=""background-color: rgb(181 229 117 / 93%) !important; "">
            <tr>
                <th class=""col-md-1"">Sr. No.</th>
                <th class=""col-md-4"">Name of Audit Report</th>
                <th class=""col-md-4"">Observation</th>
                <th class=""col-md-2"">Risk Category</th>
                <th class=""col-md-1"">Status</th>
            </tr>
        </the");
            WriteLiteral(@"ad>
        <tbody>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>

                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </tbody>
    </table>
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
