#pragma checksum "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ec0e7ba8b2d8f1ba828c8604815fc10d819c63fbd5779c7f863432818a251e99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RestaurantFood__FoodList), @"mvc.1.0.view", @"/Views/RestaurantFood/_FoodList.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\_ViewImports.cshtml"
using SiparisUygulama.Web

#nullable disable
    ;
#nullable restore
#line 2 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\_ViewImports.cshtml"
using SiparisUygulama.Web.Models

#nullable disable
    ;
#nullable restore
#line 3 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\_ViewImports.cshtml"
using SiparisUygulama.Web.Models.RestaurantFood

#nullable disable
    ;
#nullable restore
#line 4 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\_ViewImports.cshtml"
using SiparisUygulama.Web.Models.Restaurant

#nullable disable
    ;
#nullable restore
#line 5 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\_ViewImports.cshtml"
using SiparisUygulama.Web.Models.CartDetail

#nullable disable
    ;
#nullable restore
#line 6 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\_ViewImports.cshtml"
using SiparisUygulama.Web.Models.Cart

#nullable disable
    ;
#nullable restore
#line 7 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\_ViewImports.cshtml"
using SiparisUygulama.Web.Models.Order;

#nullable disable
#nullable restore
#line 2 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
 using SiparisUygulama.Contract.DataContract

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ec0e7ba8b2d8f1ba828c8604815fc10d819c63fbd5779c7f863432818a251e99", @"/Views/RestaurantFood/_FoodList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"860e600fac26fd2b009023a7fb030cddf25b3b4385b685351f748243426734f8", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_RestaurantFood__FoodList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RestaurantFoodViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid mb-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Files/noimage.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""blog_section layout_padding"">
    <div class=""container"">
        <div class=""row mb-5"">
            <div class=""col-md-12"">
                <h1 id=""Name"" class=""blog_taital"">Kafeler & Restoranlar</h1>
                <p class=""blog_text"">Lezzetli yemekler sunan çeşitli kafe ve restoranları keşfedin.</p>
            </div>
        </div>
        <div class=""blog_section_2"">
            <div class=""row"">
");
#nullable restore
#line 14 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <div class=\"col-md-4 mb-5\">\r\n                        <div class=\"blog_box)\">\r\n                            <div class=\"blog_img\">\r\n");
#nullable restore
#line 19 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                 if (!string.IsNullOrEmpty(item.FoodImgFileName))
                                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ec0e7ba8b2d8f1ba828c8604815fc10d819c63fbd5779c7f863432818a251e996799", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 894, "~/Files/RestaurantFood/", 894, 23, true);
            AddHtmlAttributeValue("", 917, 
#nullable restore
#line 21 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                                      item.FoodImgFileName

#line default
#line hidden
#nullable disable
            , 917, 21, false);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 945, 
#nullable restore
#line 21 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                                                                  item.RestaurantName

#line default
#line hidden
#nullable disable
            , 945, 20, false);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ec0e7ba8b2d8f1ba828c8604815fc10d819c63fbd5779c7f863432818a251e999500", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1172, 
#nullable restore
#line 25 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                                         item.RestaurantName

#line default
#line hidden
#nullable disable
            , 1172, 20, false);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                }

#line default
#line hidden
#nullable disable

            WriteLiteral("                                \r\n                            </div>\r\n                            <h4  class=\"burger_text restaurantName\">");
            Write(
#nullable restore
#line 29 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                                     item.RestaurantName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h4>\r\n");
            WriteLiteral("                            <h6 class=\"time_text\">");
            Write(
#nullable restore
#line 32 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                   item.FoodName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h6>\r\n                            <h6 class=\"time_text\">");
            Write(
#nullable restore
#line 33 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                   item.Price

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("₺</h6>\r\n                            <div>");
            Write(
#nullable restore
#line 34 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                  ViewBag.RestaurantId

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</div>\r\n                            <div>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec0e7ba8b2d8f1ba828c8604815fc10d819c63fbd5779c7f863432818a251e9913173", async() => {
                WriteLiteral("\r\n                                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1952, "\"", 1968, 1);
                WriteAttributeValue("", 1960, 
#nullable restore
#line 37 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                                 item.Id

#line default
#line hidden
#nullable disable
                , 1960, 8, false);
                EndWriteAttribute();
                WriteLiteral(" name=\"RestaurantId\" />\r\n                                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 2050, "\"", 2072, 1);
                WriteAttributeValue("", 2058, 
#nullable restore
#line 38 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                                 item.FoodName

#line default
#line hidden
#nullable disable
                , 2058, 14, false);
                EndWriteAttribute();
                WriteLiteral(" name=\"FoodName\" />\r\n                                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 2150, "\"", 2169, 1);
                WriteAttributeValue("", 2158, 
#nullable restore
#line 39 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                                 item.Price

#line default
#line hidden
#nullable disable
                , 2158, 11, false);
                EndWriteAttribute();
                WriteLiteral(" name=\"RestaurantFoodPrice\" />\r\n                                    <input");
                BeginWriteAttribute("id", " id=\"", 2244, "\"", 2266, 2);
                WriteAttributeValue("", 2249, "quantity_", 2249, 9, true);
                WriteAttributeValue("", 2258, 
#nullable restore
#line 40 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                         item.Id

#line default
#line hidden
#nullable disable
                , 2258, 8, false);
                EndWriteAttribute();
                WriteLiteral(" class=\"mail_text\" type=\"number\"");
                BeginWriteAttribute("value", " value=\"", 2299, "\"", 2307, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"Quantity\" style=\"width: 200px;margin-left:70px\" placeholder=\"Miktar\" />\r\n");
                WriteLiteral("                                    <button type=\"button\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2577, "\"", 2619, 3);
                WriteAttributeValue("", 2587, "validateAndAddProduct(", 2587, 22, true);
                WriteAttributeValue("", 2609, 
#nullable restore
#line 42 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                                                          item.Id

#line default
#line hidden
#nullable disable
                , 2609, 8, false);
                WriteAttributeValue("", 2617, ");", 2617, 2, true);
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-success\" style=\"margin-left:105px;width: 120px\"> Sepete Ekle</button>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1879, "form_", 1879, 5, true);
            AddHtmlAttributeValue("", 1884, 
#nullable restore
#line 36 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                                                item.Id

#line default
#line hidden
#nullable disable
            , 1884, 8, false);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 47 "C:\Users\Mehme\source\repos\SiparisUygulama\SiparisUygulama.Web\Views\RestaurantFood\_FoodList.cshtml"
                }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"            </div>
        </div>
    </div>
</div>
<script>
    $(document).ready(function () {
        var urlParams = new URLSearchParams(window.location.search);
        var restaurantName = urlParams.get('restaurantName');
        if (restaurantName) {
            $('#Name').text(restaurantName);
            $('.restaurantName').each(function () {
                $(this).hide();
            });

        }
        else {

        }
                           

    });
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RestaurantFoodViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
