#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Engagement\ccqs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd9f1cfc85dbb8ad72730f92b261f3635253195f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Engagement_ccqs), @"mvc.1.0.view", @"/Views/Engagement/ccqs.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd9f1cfc85dbb8ad72730f92b261f3635253195f", @"/Views/Engagement/ccqs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    public class Views_Engagement_ccqs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Engagement\ccqs.cshtml"
  
    ViewData["Title"] = "CCQs";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"">
    $(document).ready(function () {
        ShowEmployeeContainer();
        $(""#searchTeamFormation"").on(""keyup"", function () {
            var value = $(this).val().toLowerCase();
            $(""#listOfEmployeeTeam tbody tr"").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });

    });

    function ShowEmployeeContainer() {
        //console.log($('#deptSelectionBox option:selected').val());
        if ($('#deptSelectionBox option:selected').val() == 0)
            $('#listOfEmployeeTeam tbody').empty();
        else {
            $('#listOfEmployeeTeam tbody').empty();
            $.ajax({
                url: ""/Planning/audit_team"",
                type: ""POST"",
                data: {
                    'dept_code': $('#deptSelectionBox option:selected').val()
                },
                cache: false,
                success: function (data) {
                  ");
            WriteLiteral(@"  //console.log(data);
                    var teamId = 0;
                    var srNo = 1;
                    var teamMembers = [];
                    $.each(data, function (index, team) {

                        if (team.iS_TEAMLEAD == ""Y"") {
                            $('#listOfEmployeeTeam tbody').append('<tr id=teamcode_' + team.code + '><td class=""searchable""><p class=""fw-normal mb-1"">' + srNo + '</p></td><td class=""searchable""><p class=""fw-normal mb-1"">' + team.name + ' </p></td><td class=""searchable""><p class=""empName fw-normal mb-1"">' + team.employeename + ' </p></td><td class=""empMembers""></td><td> <small onclick=""deleteTeam(\'' + team.code + '\');"" class=""text-danger deleteTeam"">Delete</small></td></tr>');
                        } else {
                            teamMembers.push(team);
                            if (team.code != teamId) {
                                teamId = team.code;
                                srNo++;
                            }
                ");
            WriteLiteral(@"        }
                    });
                    $.each(teamMembers, function (index, team) {
                        if (team.iS_TEAMLEAD != ""Y"") {
                            prevText = $('#listOfEmployeeTeam tbody #teamcode_' + team.code + ' .empMembers').html();
                            if (prevText != '')
                                prevText += "", "";
                            $('#listOfEmployeeTeam tbody #teamcode_' + team.code + ' .empMembers').text(prevText + team.employeename);
                        }
                    });
                },
                dataType: ""json"",
            });
        }
    }
    function addccq() {
        $('#teamNameModalField').val('');
        $('#teamCodeModalField').val('');
        $.each($('.participantcheckboxes'), function (index, member) { $(member).attr('checked', false); });
        $.each($('.teamleadradio'), function (index, member) { $(member).attr('checked', false); });

        $('#setupAuditTeam').modal('show');");
            WriteLiteral(@"
    }
    function publishNewTeamChanges() {


        var teamCode = $('#teamCodeModalField').val()
        if (teamCode == '') {
            alert('Enter Sr. No.');
            return false;
        }
        var Entity = $('#EntityModalField').val();

        if (Entity == '') {
            alert('Enter Entity');
            return false;
        }
        var Question = $('#QuestionModalField').val();
        if (Question == '') {
            alert('Enter Question');
            return false;
        }
        var ControlViolation = $('#ControlViolationModalField').val();
                if (ControlViolation == '') {
            alert('Enter Control Violation');
            return false;
        }
        var Risk = $('#RiskModalField').val();
                if (Risk == '') {
            alert('Enter Risk');
            return false;
        }
                var Status = $('#StatusModalField').val();
                if (Status == '') {
            alert('Enter Status');");
            WriteLiteral(@"
            return false;
        }
        ;





    }
    function deleteTeam(teamCode) {

        $.ajax({
            url: ""/Planning/delete_audit_team"",
            type: ""POST"",
            data: {
                'T_CODE': teamCode
            },
            cache: false,
            success: function (data) {
                window.location = window.location.pathname;
            },
            dataType: ""json"",
        });


    }
</script>
<div class=""row col-md-12"">
    <div class=""row col-md-8 mt-3"">
        <h4 style="" display:block;color: #45c545;"" class=""mt-2"">Compliance & Control Questionnaire</h4>
    </div>
    <div class=""col-md-4 mt-3"">
        <button onclick=""addccq();"" class=""btn btn-danger"" style=""float:right;"">Add CCQ</button>
    </div>
</div>

<div class=""row col-md-12"">
    <table class=""table table-bordered mb-0 mt-3 bg-white table-hover table-striped"" id=""Reply"">
        <thead style="" background-color: rgb(181 229 117 / 93%) !important; "">");
            WriteLiteral(@"
            <tr>
                <th class=""col-md-1"">Sr. No.</th>
                <th class=""col-md-2"">Audit Entity</th>
                <th class=""col-md-2"">Reference</th>
                <th class=""col-md-3"">Questions</th>
                <th class=""col-md-2"">Control Violation</th>
                <th class=""col-md-2"">Risk</th>
                <th class=""col-md-2"">Status</th>
            </tr>
        </thead>
        <tbody>
          
        </tbody>
    </table>
</div>

<div id=""setupAuditTeam"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog  modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-danger text-white"">
                <h5 class=""modal-title"">New Questionaire</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body");
            WriteLiteral("\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd9f1cfc85dbb8ad72730f92b261f3635253195f9841", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label for=""teamCodeModalField"">Sr. No.</label>
                        <input type=""number"" class=""form-control"" id=""teamCodeModalField"" aria-describedby=""brcode"" placeholder=""Sr. No."">

                    </div>
                    <div class=""form-group"">
                        <label for=""branchCodeModalField"">Audit Entity</label>
                        <input type=""text"" class=""form-control"" id=""teamNameModalField"" aria-describedby=""brcode"" placeholder=""Entity"">

                    </div>
                                        <div class=""form-group"">
                        <label for=""branchCodeModalField"">Question</label>
                        <input type=""text"" class=""form-control"" id=""teamNameModalField"" aria-describedby=""brcode"" placeholder=""Question"">

                    </div>
                                        <div class=""form-group"">
                        <label for=""branchCodeModalField"">Contr");
                WriteLiteral(@"ol Violation</label>
                        <input type=""text"" class=""form-control"" id=""teamNameModalField"" aria-describedby=""brcode"" placeholder=""Control Violation"">
                    </div>
                                   <div class=""form-group"">
                        <label for=""branchCodeModalField"">Risk</label>
                        <input type=""text"" class=""form-control"" id=""teamNameModalField"" aria-describedby=""brcode"" placeholder=""Risk"">

                    </div>
                                        <div class=""form-group"">
                        <label for=""branchCodeModalField"">Status</label>
                        <input type=""text"" class=""form-control"" id=""teamNameModalField"" aria-describedby=""brcode"" placeholder=""Status"">

                    </div>





                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button onclick=""publishNewTeamChanges();"" type=""button"" class=""btn btn-danger"">Save changes</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
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
