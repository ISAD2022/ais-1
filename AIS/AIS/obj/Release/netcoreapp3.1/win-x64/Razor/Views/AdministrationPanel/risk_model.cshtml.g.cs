#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\risk_model.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc9b547ae372f637db546b9e06c11e68aede21e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdministrationPanel_risk_model), @"mvc.1.0.view", @"/Views/AdministrationPanel/risk_model.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc9b547ae372f637db546b9e06c11e68aede21e0", @"/Views/AdministrationPanel/risk_model.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    public class Views_AdministrationPanel_risk_model : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\risk_model.cshtml"
  
    ViewData["Title"] = "Departments";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        var g_deptId = 0;
        $('#sidebar_policy').hide();
        $(""#searchTableRecord"").on(""keyup"", function () {
            var value = $(this).val().toLowerCase();
            $(""#listOfDepartment tbody tr"").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });

    function newDeptSetup() {
        g_deptId = 0;
        $('#setupDeptModal').modal('show');
        $('#deptCodeModalField').val('');
        $('#deptNameModalField').val('');
        $('#deptdivNameModalField').val('');
    }

    function setupDepartment(code, name, div_name, status, id, div_id) {
        g_deptId = id;
        $('#deptCodeModalField').val(code);
        $('#deptNameModalField').val(name);

        $('#deptdivNameModalField').val(div_id);
        if (status == ""Active"")
            $('#deptActiveModalField').click();
        else if (status == ""InActive"")
            $");
            WriteLiteral(@"('#deptInactiveModalField').click();

        $('#setupDeptModal').modal('show');
    }

    function publishDepartmentChanges() {

        var code = $('#deptCodeModalField').val();
        var name = $('#deptNameModalField').val();
        var div_id = $('#deptdivNameModalField').val();
        var div_name = $('#deptdivNameModalField option:selected').text();
        var status;
        var badge;
        if ($('#deptActiveModalField').is(':checked')) {
            status = 'Active';
            badge = 'badge-success ';
        }
        else {
            status = 'InActive';
            badge = 'badge-danger ';
        }
        if (g_deptId == 0)
            var row = ""<tr id=\""dept_"" + g_deptId + ""\""><td class=\""dept_code\""><p class=\""fw-normal mb-1\"">"" + code + ""</p></td><td class=\""dept_name\""><p class=\""fw-normal mb-1\"">"" + name + ""</p></td ><td class=\""dept_div\""><p class=\""fw-normal mb-1\"">"" + div_name + ""</p></td><td class=\""dept_status\""><span class=\""badge "" + badge + "" rounded-pill d-inline\""");
            WriteLiteral(@">"" + status + ""</span></td><td class=\""dept_action\""><button type=\""button\"" class=\""btn btn-link text-danger btn-sm btn-rounded\"" onclick=\""setupDepartment('"" + code + ""','"" + name + ""','"" + div_name + ""','"" + status + ""','"" + g_deptId + ""','"" + div_id + ""');\"">Edit</button></td></tr>"";
        else
            $('#dept_' + g_deptId).html(""<td class=\""dept_code\""><p class=\""fw-normal mb-1\"">"" + code + ""</p></td><td class=\""dept_name\""><p class=\""fw-normal mb-1\"">"" + name + ""</p></td ><td class=\""dept_div\""><p class=\""fw-normal mb-1\"">"" + div_name + ""</p></td><td class=\""dept_status\""><span class=\""badge "" + badge + "" rounded-pill d-inline\"">"" + status + ""</span></td><td class=\""dept_action\""><button type=\""button\"" class=\""btn btn-link text-danger btn-sm btn-rounded\"" onclick=\""setupDepartment('"" + code + ""','"" + name + ""','"" + div_name + ""','"" + status + ""','"" + g_deptId + ""','"" + div_id + ""');\"">Edit</button></td>"");
        $('#listOfDepartment tbody').append(row);
        $('#setupDeptModal').modal('hide");
            WriteLiteral(@"');
        $.ajax({
            url: ""/Setup/department_add"",
            type: ""POST"",
            data: {
                'id': g_deptId,
                'code': code,
                'name': name,
                'div_id': div_id,
                'status': status
            },
            cache: false,
            success: function (data) {
                console.log(data);
                window.location = window.location.pathname;

            },
            dataType: ""json"",
        });
    }
</script>



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
