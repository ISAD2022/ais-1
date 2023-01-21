#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Engagement\change_request.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9ef525080dbda44984a4b9ab43197997858ffa4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Engagement_change_request), @"mvc.1.0.view", @"/Views/Engagement/change_request.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9ef525080dbda44984a4b9ab43197997858ffa4", @"/Views/Engagement/change_request.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Engagement_change_request : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Engagement\change_request.cshtml"
  
    ViewData["Title"] = "GL HEAD DETAILS";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">

    $('#document').ready(function () {
        var url_string = window.location;
        var url = new URL(url_string);
        var gl_id = url.searchParams.get(""GLCODE"");
        $.ajax({
            url: ""/Reports/Get_Glhead_Sub_Details"",
            type: ""POST"",
            data: {
                'gl_code': gl_id
            },
            cache: false,
            success: function (data) {
                //v = data;

                // console.log(data);

                $.each(data.gL_SUBDETAILS, function (i, v) {

                    $('#gldetailtab tbody').append('<tr><td>' + v.glcode + '</td><td>' + v.glsubname + '</td><td>' + v.datetime.split('T')[0] + '</td>  <td>' + v.runninG_CR + '</td><td>' + v.runninG_DR + '</td> <td>' + v.balance + '</td> </tr>')
                });
            },
            dataType: ""json"",
        });
    });


</script>

<div class=""row col-md-12 mt-3"">
    <h4 style=""display: block; color: #45c545;"">ARP");
            WriteLiteral(@"SE for the Year </h4>
</div>
<div class=""row mt-3 col-md-12"">
    <div class=""row col-md-2"">
        <label><b>Select Year</b></label>
    </div>
    <div class=""row col-md-10"">
        <div class=""col-md-12 pl-0 pr-0"">
            <select id=""auditCriteriaEntityField"" class=""form-select form-control"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9ef525080dbda44984a4b9ab43197997858ffa45379", async() => {
                WriteLiteral("--Select Year--");
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
        <div class=""col-md-3 pr-0 d-none"">
            <button onclick=""addAuditEntitiesModal();"" class=""btn btn-danger float-right d-none"">Add New Entity</button>
        </div>
    </div>
</div>
<div class=""row col-md-12 mt-3"">
    <div class=""row col-md-12"">
        <table id=""gldetailtab"" class=""col-md-12 table-bordered table-hover mt-1 table-striped"">
            <thead style=""background-color: rgb(181 229 117 / 93%) !important; "">
                <tr>
                    <th class=""col-md-2"">Reference to the Para Item</th>
                    <th class=""col-md-3"">Content of the Para/Item</th>
                    <th class=""col-md-2"">Reply of Ministry</th>
                    <th class=""col-md-2"">DAC Recommendation</th>
                    <th class=""col-md-2"">PAC Directives</th>
                    <th class=""col-md-2"">Progress</th>

                </tr>
            </thead>
          

            <tbody>
            </tbody>


        ");
            WriteLiteral("</table>\r\n    </div>\r\n</div>");
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
