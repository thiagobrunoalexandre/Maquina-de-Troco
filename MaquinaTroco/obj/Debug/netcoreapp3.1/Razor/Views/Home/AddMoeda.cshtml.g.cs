#pragma checksum "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d7b183465ab263ea66aca2ffa4601f1926d5800"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AddMoeda), @"mvc.1.0.view", @"/Views/Home/AddMoeda.cshtml")]
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
#line 1 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\_ViewImports.cshtml"
using MaquinaTroco;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\_ViewImports.cshtml"
using MaquinaTroco.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d7b183465ab263ea66aca2ffa4601f1926d5800", @"/Views/Home/AddMoeda.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"112675f7214377920bdcb7c9dca9eab8f0bf77a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AddMoeda : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MaquinaTroco.Models.Moeda>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
  
    ViewData["Title"] = "Moedas disponíveis";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-md-12\">\r\n    <h4> Preencha os campos para cadastrar ou adicionar uma quantidade de moeda </h4>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
     using (Html.BeginForm("AddMoeda", "Home", new { }, FormMethod.Post, false, new { @id = "register-form" }))
    {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""form-group intra-form"">

            <table class=""table table-responsive"">

                <thead>

                    <tr>

                        <th> Valor </th>

                        <th> Quantidade </th>

                    </tr>

                </thead>
                <tbody>


                    <tr>

                        <td>
                            ");
#nullable restore
#line 33 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
                       Write(Html.TextBoxFor(model => model.valor, new { @class = "form-control", @min = "0", @maxlength = "4" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
                       Write(Html.TextBoxFor(model => model.quantidade, new { @class = "form-control", @min = "0", @maxlength = "4" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>

                    </tr>

                    <tr>

                        <td>


                            <a>

                                <input type=""submit"" value=""Confiirmar"" class=""btn-success btn"" />

                            </a>

                        </td>

                    </tr>


                </tbody>

            </table>


        </div>
");
#nullable restore
#line 65 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
         if (TempData["MensagemErro"] != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span style=\"color:red \" class=\"error-message\">");
#nullable restore
#line 67 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
                                                      Write(TempData["MensagemErro"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 68 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
         

    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
    <div class=""col-md-8"">
        <h2>Moedas disponíveis</h2>
        <table class=""table table-responsive"">

            <thead>

                <tr>

                    <td>
                        Valor
                    </td>
                    <td>
                        Quantidade
                    </td>


                </tr>

            </thead>
            <tbody>
");
#nullable restore
#line 92 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
                 foreach (Moeda moeda in ViewBag.moedas)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 98 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
                       Write(moeda.valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 101 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"
                       Write(moeda.quantidade);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 105 "C:\Users\Thiago Alexandre\source\repos\MaquinaTroco\MaquinaTroco\Views\Home\AddMoeda.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n\r\n\r\n        </table>\r\n        <br />\r\n        <br />\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MaquinaTroco.Models.Moeda> Html { get; private set; }
    }
}
#pragma warning restore 1591
