#pragma checksum "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fff54d22b3088f2ba620f53cbcbc3e044945ee7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ApiAlmacen.Pages.Inventario.Pages_Inventario_Index), @"mvc.1.0.razor-page", @"/Pages/Inventario/Index.cshtml")]
namespace ApiAlmacen.Pages.Inventario
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
#line 2 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
using ApiAlmacen.Pages.Inventario;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff54d22b3088f2ba620f53cbcbc3e044945ee7a", @"/Pages/Inventario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67cd4a5ec6f159fb64f09741c8c5efe7b4ad700e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Inventario_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
  
    var i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2>Inventario</h2>

<table class=""table"">
  <thead class=""thead-dark"">
    <tr>
        <th scope=""col"">#</th>
        <th scope=""col"">NombreInsumo</th>
        <th scope=""col"">Cantidad</th>
        <th scope=""col"">Precio Unitario</th>
        <th scope=""col"">Importe</th>
        <th scope=""col"">Partida</th>
      <th>&nbsp;</th>
    </tr>
  </thead>
  <tbody>
");
#nullable restore
#line 22 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
     foreach (var al in Model.inventario)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n      <td>");
#nullable restore
#line 25 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
     Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 26 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
     Write(al.nombreinsumo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 27 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
     Write(al.Cantidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 28 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
     Write(al.PrecioUnitario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 29 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
     Write(al.Importe);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 30 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
     Write(al.Partida);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n    </tr>\r\n");
#nullable restore
#line 33 "C:\App Almacen\apidotnetcore\ApiAlmacen\ApiAlmacen\Pages\Inventario\Index.cshtml"
        i++;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("   \r\n  </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
