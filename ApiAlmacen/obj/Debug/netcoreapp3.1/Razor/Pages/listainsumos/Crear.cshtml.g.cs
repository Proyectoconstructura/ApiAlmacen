#pragma checksum "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\listainsumos\Crear.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb0d01f06dc50049262dccb3ec9a8eb9a9298137"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ApiAlmacen.Pages.listainsumos.Pages_listainsumos_Crear), @"mvc.1.0.razor-page", @"/Pages/listainsumos/Crear.cshtml")]
namespace ApiAlmacen.Pages.listainsumos
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
#line 1 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\_ViewImports.cshtml"
using ApiAlmacen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\listainsumos\Crear.cshtml"
using ApiAlmacen.Pages.listainsumos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb0d01f06dc50049262dccb3ec9a8eb9a9298137", @"/Pages/listainsumos/Crear.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67cd4a5ec6f159fb64f09741c8c5efe7b4ad700e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_listainsumos_Crear : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1> Agregar una insumo a lista de insumos </h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb0d01f06dc50049262dccb3ec9a8eb9a92981373796", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 7 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\listainsumos\Crear.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb0d01f06dc50049262dccb3ec9a8eb9a92981375316", async() => {
                WriteLiteral("\r\n  <div class=\"form-group\">\r\n   \r\n   <div class=\"form-group\">\r\n    <label for=\"proyecto\">Proyecto</label>\r\n    <input type=\"text\" class=\"form-control\"\r\n        name=\"proyecto\" id=\"proyecto\"");
                BeginWriteAttribute("aria-describedby", " aria-describedby=\"", 422, "\"", 441, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    \r\n  </div>\r\n\r\n   <div class=\"form-group\">\r\n    <label for=\"clave\">Clave</label>\r\n    <input type=\"text\" class=\"form-control\"\r\n        name=\"clave\" id=\"clave\"");
                BeginWriteAttribute("aria-describedby", " aria-describedby=\"", 606, "\"", 625, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    \r\n  </div>\r\n\r\n  <div class=\"form-group\">\r\n    <label for=\"nombreinsumo\">Nombre insumo</label>\r\n    <input type=\"text\" class=\"form-control\"\r\n        name=\"nombreinsumo\" id=\"nombreinsumo\"");
                BeginWriteAttribute("aria-describedby", " aria-describedby=\"", 818, "\"", 837, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n        \r\n  </div>\r\n  <div class=\"form-group\">\r\n    <label for=\"partida\">Partida</label>\r\n    <input type=\"text\" class=\"form-control\"\r\n        name=\"partida\" id=\"partida\"");
                BeginWriteAttribute("aria-describedby", " aria-describedby=\"", 1011, "\"", 1030, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n  </div>\r\n\r\n<div class=\"form-group\">\r\n    <label for=\"cantidad\">Cantidad</label>\r\n    <input type=\"number\" class=\"form-control\"\r\n        name=\"cantidad\" id=\"cantidad\"");
                BeginWriteAttribute("aria-describedby", " aria-describedby=\"", 1200, "\"", 1219, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n  </div>\r\n\r\n  <div class=\"form-group\">\r\n    <label for=\"unidadmedida\">Unidad de medida</label>\r\n    <input type=\"text\" class=\"form-control\"\r\n        name=\"unidadmedida\" id=\"unidadmedida\"");
                BeginWriteAttribute("aria-describedby", " aria-describedby=\"", 1409, "\"", 1428, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n  </div>\r\n\r\n\r\n  </div>\r\n\r\n  <button type=\"submit\" class=\"btn btn-primary\">Crear</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrearModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CrearModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CrearModel>)PageContext?.ViewData;
        public CrearModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
