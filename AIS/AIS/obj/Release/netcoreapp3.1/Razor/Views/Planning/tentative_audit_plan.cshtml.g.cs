#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4847c1d25a2f52d1ca6e1c32a51d7558494bda86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Planning_tentative_audit_plan), @"mvc.1.0.view", @"/Views/Planning/tentative_audit_plan.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4847c1d25a2f52d1ca6e1c32a51d7558494bda86", @"/Views/Planning/tentative_audit_plan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    public class Views_Planning_tentative_audit_plan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
  
    ViewData["Title"] = "Tentative Audit Plan";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<style type=""text/css"">
    .container {
        max-width: 100%;
    }

    .card-header {
        background-color: transparent !important;
        font-size: 20px;
        height: 100px;
    }

    .icon-card {
        margin: 10px;
    }
</style>

<script type=""text/javascript"">
    function createAuditEngagement(planId, name, size, risk, freq, days, auditperiod, periodId, code, zoneId, entity_id) {
        window.location.href = '/planning/tentative_engagement_plan?planId=' + planId + '&name=' + name + '&size=' + size + '&risk=' + risk + '&freq=' + freq + '&period=' + auditperiod + '&days=' + days + '&periodId=' + periodId + '&code=' + code + '&entityType=6' + '&zoneId=' + zoneId + '&entityId=' + entity_id;
    }
    $(document).ready(function () {
        $(""#searchTableRecord"").on(""keyup"", function () {
            var value = $(this).val().toLowerCase();
            $(""#tentative_plan_list tbody tr"").filter(function () {
                $(this).toggle($(this).text().toLower");
            WriteLiteral(@"Case().indexOf(value) > -1)
            });
        });
    });
      
</script>
<div class=""row col-md-12 mt-3"">
    <h3 style=""color: #45c545;"">Tentative Audit Plan </h3>
</div>
<div>
    
        <div class=""row col-md-12"">
            <input class=""form-control"" id=""searchTableRecord"" type=""text"" placeholder=""Search.."">
        </div>
 
    <br>
    <div class=""row col-md-12 mt-3"">
        <table  id=""tentative_plan_list"" class=""table table-hover table-bordered table-hover mt-3 table-striped"">
        <thead style=""background-color: rgb(181 229 117 / 93%) !important; "">
            <tr>
                <th width=""80"" style=""font-size:large"">Sr No</th>
                <th width=""150"" style=""font-size:large"">Audit Period</th>
                <th width=""250"" style=""font-size:large"">Reporting/Controlling Office</th>
                <th width=""150"" style=""font-size:large"">Entity Name</th>
                <th width=""150"" style=""font-size:large"">Entity Size</th>
                <th width");
            WriteLiteral(@"=""80"" style=""font-size:large"">Risk</th>
                <th width=""100"" style=""font-size:large"">Frequency</th>
                <th width=""150"" style=""font-size:large"">No. of Days</th>
                <th width=""100"" style=""font-size:large"">Actions</th>
            </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 63 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                  
                    if (ViewData["TentativePlansList"] != null)
                    {
                        int sr = 1;
                        
                        foreach (var item in (dynamic)(ViewData["TentativePlansList"]))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr ");
#nullable restore
#line 70 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                               Write(item.PLAN_ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n                                    <td align=\"center\">");
#nullable restore
#line 71 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                                                  Write(sr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"center\">");
#nullable restore
#line 72 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                                                  Write(item.PERIOD_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"left\">");
#nullable restore
#line 73 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                                                Write(item.REPORTING_OFFICE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"left\">");
#nullable restore
#line 74 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                                                Write(item.ENTITY_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"center\">");
#nullable restore
#line 75 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                                                  Write(item.BR_SIZE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"center\">");
#nullable restore
#line 76 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                                                  Write(item.RISK);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"center\">");
#nullable restore
#line 77 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                                                  Write(item.FREQUENCY_DESCRIPTION);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"center\">");
#nullable restore
#line 78 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                                                  Write(item.NO_OF_DAYS);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"center\"><small");
            BeginWriteAttribute("onclick", " onclick=\"", 3465, "\"", 3704, 24);
            WriteAttributeValue("", 3475, "createAuditEngagement(", 3475, 22, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3497, item.PLAN_ID, 3497, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3510, ",\'", 3510, 2, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3512, item.ENTITY_NAME, 3512, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3529, "\',\'", 3529, 3, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3532, item.BR_SIZE, 3532, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3545, "\',\'", 3545, 3, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3548, item.RISK, 3548, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3558, "\',\'", 3558, 3, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3561, item.FREQUENCY_DESCRIPTION, 3561, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3588, "\',\'", 3588, 3, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3591, item.NO_OF_DAYS, 3591, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3607, "\',", 3607, 2, true);
            WriteAttributeValue(" ", 3609, "\'", 3610, 2, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3611, item.PERIOD_NAME, 3611, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3628, "\',\'", 3628, 3, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3631, item.AUDIT_PERIOD_ID, 3631, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3652, "\',\'", 3652, 3, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3655, item.CODE, 3655, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3665, "\',\'", 3665, 3, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3668, item.AUDITEDBY, 3668, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3683, "\',\'", 3683, 3, true);
#nullable restore
#line 79 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
WriteAttributeValue("", 3686, item.ENTITY_ID, 3686, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3701, "\');", 3701, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"text-center text-danger text-hover\">Create</small></td>\r\n                                </tr>\r\n");
#nullable restore
#line 81 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Planning\tentative_audit_plan.cshtml"
                            sr = sr + 1;
                        }

                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
        <div class=""row w-100 mt-3 d-none"">
            <h4>Audit Zone Head Remarks</h4>
            <select id=""deptSelectionBox"" class=""form-select form-control"" aria-label=""Default select example"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4847c1d25a2f52d1ca6e1c32a51d7558494bda8614373", async() => {
                WriteLiteral("Remarks");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4847c1d25a2f52d1ca6e1c32a51d7558494bda8615861", async() => {
                WriteLiteral("1. Recommended for Approval");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4847c1d25a2f52d1ca6e1c32a51d7558494bda8617058", async() => {
                WriteLiteral("2. Refer back for changes in the above marked plans");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
        <div class=""row w-100 col-md-12 mt-3 d-none"">
            <div class=""col-md-6 mt-5"">
                <button onclick=""window.location.href = '';"" class=""btn-primary"">Submit</button>
            </div>
            <div class=""col-md-6 mt-5"">
                <button onclick=""window.location.href = '';"" class=""btn-primary"">Refer Back</button>
            </div>
        </div>
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
