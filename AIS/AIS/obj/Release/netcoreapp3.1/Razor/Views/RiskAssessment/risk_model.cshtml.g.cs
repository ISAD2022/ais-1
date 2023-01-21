#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\RiskAssessment\risk_model.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a93d45b64eb23e225be90243a22e44e401b54c62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RiskAssessment_risk_model), @"mvc.1.0.view", @"/Views/RiskAssessment/risk_model.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a93d45b64eb23e225be90243a22e44e401b54c62", @"/Views/RiskAssessment/risk_model.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55a5612a483914c0ca2f8e8f7a380dade0d90ed8", @"/Views/RiskAssessment/_ViewImports.cshtml")]
    #nullable restore
    public class Views_RiskAssessment_risk_model : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\RiskAssessment\risk_model.cshtml"
  
    ViewData["Title"] = "Risk Model";
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

<div class=""row text-center mt-3 pl-2"">
    <h4 style="" display:block;color: #45c545;"">Risk Model</h4>
</div>
<div class=""row col-md-12 mt-3"">
    <div class=""row col-md-2"">
        <h5>Audit Period</h5>
    </div>
<div class=""row col-md-6"">
        <select id=""auditCriteriaPeriodField"" class=""form-select form-control"" aria-label=""Default select example"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a93d45b64eb23e225be90243a22e44e401b54c624809", async() => {
                WriteLiteral("--Select Audit Period--");
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
            WriteLiteral("\r\n");
#nullable restore
#line 32 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\RiskAssessment\risk_model.cshtml"
              
                if (ViewData["AuditPeriodList"] != null)
                {

                    foreach (var period in (dynamic)(ViewData["AuditPeriodList"]))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a93d45b64eb23e225be90243a22e44e401b54c626792", async() => {
#nullable restore
#line 38 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\RiskAssessment\risk_model.cshtml"
                                                                                    Write(period.DESCRIPTION);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 38 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\RiskAssessment\risk_model.cshtml"
AddHtmlAttributeValue("", 1026, period.AUDITPERIODID, 1026, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\RiskAssessment\risk_model.cshtml"
                                                      WriteLiteral(period.AUDITPERIODID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 39 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\RiskAssessment\risk_model.cshtml"
                    }

                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </select>
    </div>
</div>
<!--  <div class=""row col-md-12"">
        <center class=""w-100"">
            <table class=""table ml-3 table-bordered table-sm mb-0 mt-3 bg-white table-hover table-striped"" style=""width:600px;"" id=""portfolio"">
                <thead>
                    <tr>
                        <th class=""bg-primary"" style=""text-align:center;"" colspan=""8"">Enter Portfolio (Mn)</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class=""bg-primary"" width=""100"">
</td>
<td class=""bg-success"" width=""600""><input class=""form-select form-control"" type=""number"" /></td>
                    </tr>
                </tbody>
            </table>
        </center>
    </div>
<div class=""row col-md-12"">
    <center class=""w-100"">
        <table class=""table ml-3 table-bordered mb-0 mt-3 bg-white table-hover table-striped"" style=""width:600px;"" id=""risk control assessment"">
            <thead>
         ");
            WriteLiteral(@"       <tr>
                    <th style=""text-align:center;"">Risk Control Assessment</th>
                    <th style=""text-align:center;"">Weighted Average Score</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><b>Internal Control Risk Assessment</b></>
                    <td><input class=""form-select form-control"" type=""number"" /></td>
                </tr>
                <tr>
                    <td><b>Shortfall/ Risks in Key Perforamance Indicators</b></>
                    <td><input class=""form-select form-control"" type=""number"" /></td>
                </tr>
                <tr>
                    <td><b>Operatinal Risks Assessments</b></>
                    <td><input class=""form-select form-control"" type=""number"" /></td>
                </tr>
            </tbody>
        </table>
    </center>
</div>


<div class=""row col-md-12 mt-3"">
    <table class=""table table-bordered mb-0 table-sm mt-3 bg-white table");
            WriteLiteral(@"-hover table-striped"" id=""Risk Rating"">
        <thead>
            <tr>
                <th class=""bg-primary"" style=""text-align:center;"" colspan=""4"">Final Risk Rating</th>
                <th>Portfolio</th>
                <th>Branch Size</th>
                <th>Low Risk</th>
                <th>Medium Risk</th>
                <th>High Risk</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class=""bg-primary"" style=""text-align:center;"">Branch Size</td>
                <td style=""text-align:center;"" class=""bg-primary"" colspan=""3"">Risk Rating</td>
                <td class=""bg-primary"">Upto 300Mn.</td>
                <td class=""bg-primary"">Small</td>
                <td class=""bg-primary"">Upto 10</td>
                <td class=""bg-primary"">11 - 40</td>
                <td class=""bg-primary""> > 40 </td>
            </tr>
            <tr>
                <td class=""bg-success"" style=""text-align:center;"">
                    <select id=""branchsi");
            WriteLiteral(@"ze"" class=""form-select form-control""></select>
                </td>
                <td class=""bg-danger""><input class=""form-select form-control"" type=""number"" /></td>
                <td>
                    <select id=""risktype"" class=""form-select form-control""></select>
                </td>
                <td class=""bg-danger""><input class=""form-select form-control"" type=""number"" /></td>
                <td class=""bg-danger"">Rs.301Mn. to Rs.699Mn</td>
                <td class=""bg-danger"">Medium</td>
                <td class=""bg-danger"">Upto 15</td>
                <td class=""bg-danger"">16 - 50</td>
                <td class=""bg-danger""> > 60 </td>
            </tr>
            <tr>
                <td style=""text-align:center;"">
                    <select id=""branchsize"" class=""form-select form-control""></select>
                </td>
                <td><input class=""form-select form-control"" type=""number"" /></td>
                <td>
                    <select id=""risktype"" clas");
            WriteLiteral(@"s=""form-select form-control""></select>
                </td>
                <td><input class=""form-select form-control"" type=""number"" /></td>
                <td class=""bg-light"">Rs.700Mn. & Above</td>
                <td class=""bg-light"">Large</td>
                <td class=""bg-light"">Upto 20</td>
                <td class=""bg-light"">21 - 70</td>
                <td class=""bg-light""> > 70 </td>
            </tr>
        </tbody>
    </table>
</div>
-->
<div class=""row w-100 mt-3 pl-2"">
    <table class=""table table-bordered bg-white table-hover table-striped"" id=""criteria"">
        <thead>
            <tr style=""background-color: rgb(181 229 117 / 93%) !important; "">
                <th width=""600px"" rowspan=""3"" style=""text-align:center;"">Audit Entity</th>
                <th colspan=""7"" style=""text-align:center;"">Internal Control Risk Assessment</th>
                <!--<th colspan=""5"" style=""text-align:center;"">Risks in Key Perforamance Indicators</th>
    <th style=""text-align:center;");
            WriteLiteral(@""">Non Rectification of Previous Audit Irregularities</th>
    <th style=""text-align:center;"" colspan=""3"">Loss Making Branch</th>
    <th style=""text-align:center;"">Security Arrangements</th>-->
                <th colspan=""6"" style=""text-align:center;"">Preventive & Detection Risk</th>
            </tr>
            <tr style=""background-color: rgb(181 229 117 / 93%) !important; "">
                <td colspan=""4"" style=""text-align:center;"">Non Compliance of Bank’s policies /procedures /SBP directives</td>
                <td rowspan=""2"" style=""text-align:center;"">Lapses in Management Information System (MIS)</td>
                <td rowspan=""2"" style=""text-align:center;"">Cash Related Violations</td>
                <td rowspan=""2"" style=""text-align:center;"">Branch Control violations</td>
                <!--<td rowspan=""2"" style=""text-align:center;"">i.Increase in NPL</td>
    <td rowspan=""2"" style=""text-align:center;"">ii.Increase in SAM</td>
    <td rowspan=""2"" style=""text-align:center;"">iii.Recover");
            WriteLiteral(@"y Lapses</td>
    <td rowspan=""2"" style=""text-align:center;"">iv.Disbursement Target Shortfall Vs Budget</td>
    <td rowspan=""2"" style=""text-align:center;"">v.Deposit Target Shortfall Vs Budget</td>
    <td rowspan=""2"" style=""text-align:center;"">Vol. 1 Outstanding Observation</td>
    <td rowspan=""2"" style=""text-align:center;"">if Up to Rs 0.100</td>
    <td rowspan=""2"" style=""text-align:center;"">if From Rs 0.101 to Rs 1.000</td>
    <td rowspan=""2"" style=""text-align:center;"">Rs 1.001-10.00, Rs.10.001 Mn. To 50 Mn., Rs. 50.001 Mn-above</td>
    <td rowspan=""2"" style=""text-align:center;"">Installation & use of CCTV</td>-->
                <td rowspan=""2"" style=""text-align:center;"">Fraud & Forgery</td>
                <td rowspan=""2"" style=""text-align:center;"">Redemption of Land in alive loan cases</td>
                <td rowspan=""2"" style=""text-align:center;"">Misuse of Credit powers</td>
                <td rowspan=""2"" style=""text-align:center;"">Instances Where Bank's Funds are Not Safe</td>
        ");
            WriteLiteral(@"        <td rowspan=""2"" style=""text-align:center;"">Non Balancing of Branches</td>
                <td rowspan=""2"" style=""text-align:center;"">SBP Penalty</td>
            </tr>
            <tr style=""background-color: rgb(181 229 117 / 93%) !important; "">
                <td>NON  Compliance of SBP Directives</td>
                <td>NON Compliance of   ZTBL directives</td>
                <td>Violations in  Authorization and Approval Procedures</td>
                <td>Internal Controls Violations</td>
                
            </tr>
        </thead>
        <tbody>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <!--<td></td>
    <td></");
            WriteLiteral(@"td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>-->
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <!--<td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>-->
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
     ");
            WriteLiteral(@"           <td></td>
                <td></td>
                <td></td>
                <td></td>
                <!--<td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>-->
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <!--<td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>-->
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></t");
            WriteLiteral(@"d>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <!--<td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>-->
            </tr>
        </tbody>
    </table>
</div>");
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
