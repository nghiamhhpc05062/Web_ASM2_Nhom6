#pragma checksum "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "dd5b1f264323dc045daace4153391595dbd8022720ce132f6f887dd8ac138452"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_GetIDMenuOfProduct), @"mvc.1.0.view", @"/Views/Product/GetIDMenuOfProduct.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\_ViewImports.cshtml"
using Web_ASM_Nhom6;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\_ViewImports.cshtml"
using Web_ASM_Nhom6.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"dd5b1f264323dc045daace4153391595dbd8022720ce132f6f887dd8ac138452", @"/Views/Product/GetIDMenuOfProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"c7851df2479b6fe10a7e5d661f5e8ecbd969f5f357248a94a70d99b458a4e6c5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Product_GetIDMenuOfProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Web_ASM_Nhom6.Models.Product>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd5b1f264323dc045daace4153391595dbd8022720ce132f6f887dd8ac1384523659", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 10 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayNameFor(model => model.MenuId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayNameFor(model => model.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayNameFor(model => model.IsDelete));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayFor(modelItem => item.MenuId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayFor(modelItem => item.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsDelete));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 59 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 60 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 63 "D:\C#5\Web_ASM2_Nhom6\Web_ASM_Nhom6\Web_ASM_Nhom6\Views\Product\GetIDMenuOfProduct.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Web_ASM_Nhom6.Models.Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
