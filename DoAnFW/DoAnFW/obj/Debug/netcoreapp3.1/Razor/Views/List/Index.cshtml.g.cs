#pragma checksum "C:\Users\Dell\Desktop\test\DoAnFW\DoAnFW\DoAnFW\Views\list\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8abeaf291258e6e96f77c79c7dc89db64a8a7e6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_list_Index), @"mvc.1.0.view", @"/Views/list/Index.cshtml")]
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
#line 1 "C:\Users\Dell\Desktop\test\DoAnFW\DoAnFW\DoAnFW\Views\_ViewImports.cshtml"
using DoAnFW;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dell\Desktop\test\DoAnFW\DoAnFW\DoAnFW\Views\_ViewImports.cshtml"
using DoAnFW.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8abeaf291258e6e96f77c79c7dc89db64a8a7e6b", @"/Views/list/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de86b2deb08718bb05791c6fc6d1b33051a185be", @"/Views/_ViewImports.cshtml")]
    public class Views_list_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/List.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Dell\Desktop\test\DoAnFW\DoAnFW\DoAnFW\Views\list\Index.cshtml"
  
    ViewData["Title"] = "Danh sách sản phẩm";

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8abeaf291258e6e96f77c79c7dc89db64a8a7e6b4105", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8abeaf291258e6e96f77c79c7dc89db64a8a7e6b4371", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<div class=""main"">
    <div class="" qc"">
        <img src=""/image/qc.jpg"">
    </div>
    <div class=""dropdown"">
        <button class=""dropbtn"">Loại phụ kiện<i class=""fas fa-chevron-down""></i></button>
        <div class=""dropdown-content"">
            <a href=""#"">Tai nghe</a>
            <a href=""#"">Cáp sạc</a>
            <a href=""#"">Bao da, ốp</a>
        </div>
    </div>
    <br>
    <div class=""list"">
        <div class=""row"">
            <div class=""product"">
                <div class=""img""><a id=""1"" href=""/product""><img src=""/image/tai-nghe-iphone-5.jpg""></a></div>
                <a href=""/product""><label><b>Tai nghe iphone 5</b></label></a>
                <p style=""color: red;""><b> 150.000đ </b> </p>
                <div class=""button"">
                    <a");
            BeginWriteAttribute("href", " href=\"", 938, "\"", 945, 0);
            EndWriteAttribute();
            WriteLiteral(">Mua ngay</a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 983, "\"", 990, 0);
            EndWriteAttribute();
            WriteLiteral(@">Xem chi tiết</a>
                </div>
            </div>
            <div class=""product"">
                <div class=""img""><a id=""1"" href=""/product""><img src=""/image/tai-nghe-iphone-5.jpg""></a></div>
                <a href=""/product""><label><b>Tai nghe iphone 5</b></label></a>
                <p style=""color: red;""><b> 150.000đ </b> </p>
                <div class=""button"">
                    <a");
            BeginWriteAttribute("href", " href=\"", 1403, "\"", 1410, 0);
            EndWriteAttribute();
            WriteLiteral(">Mua ngay</a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1448, "\"", 1455, 0);
            EndWriteAttribute();
            WriteLiteral(@">Xem chi tiết</a>
                </div>
            </div>
            <div class=""product"">
                <div class=""img""><a id=""1"" href=""/product""><img src=""/image/tai-nghe-iphone-5.jpg""></a></div>
                <a href=""/product""><label><b>Tai nghe iphone 5</b></label></a>
                <p style=""color: red;""><b> 150.000đ </b> </p>
                <div class=""button"">
                    <a");
            BeginWriteAttribute("href", " href=\"", 1868, "\"", 1875, 0);
            EndWriteAttribute();
            WriteLiteral(">Mua ngay</a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1913, "\"", 1920, 0);
            EndWriteAttribute();
            WriteLiteral(">Xem chi tiết</a>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n        <br />\r\n    </div>\r\n</div>");
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
