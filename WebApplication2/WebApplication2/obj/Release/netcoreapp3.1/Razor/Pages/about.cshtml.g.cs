#pragma checksum "E:\Нова папка\ggames\WebApplication2\WebApplication2\Pages\about.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "895e29e48bb4de3885c8340f6e7e1614f08dd662"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication2.Pages.Pages_about), @"mvc.1.0.razor-page", @"/Pages/about.cshtml")]
namespace WebApplication2.Pages
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
#line 1 "E:\Нова папка\ggames\WebApplication2\WebApplication2\Pages\_ViewImports.cshtml"
using WebApplication2;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"895e29e48bb4de3885c8340f6e7e1614f08dd662", @"/Pages/about.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"538f37ef395561d5f352aabc9fc72bce1358fc6b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_about : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <!DOCTYPE html>\r\n    <html>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "895e29e48bb4de3885c8340f6e7e1614f08dd6623057", async() => {
                WriteLiteral(@"
        <meta charset=""utf-8"" />
        <title>About</title>
        <style>
            * {
                margin: 0;
                padding: 0;
                box-sizing: border-box;
                font-family: sans-serif;
            }

            main {
                margin-top: 86px;
            }

            input {
                outline: 0;
                font-family: inherit;
                font-size: inherit;
                vertical-align: middle;
            }

            h2 {
                font-size: 1.8rem;
            }

            .pageHeader {
                position: fixed;
                z-index: 26;
                box-shadow: 0 2px 2px 0 rgb(0 0 0 / 10%);
                border-bottom: 1px solid #ccc;
                top: 0;
                width: 100%;
                height: 56px;
                background: #fff;
                box-sizing: border-box;
                display: block;
            }

            .overLayer {
    ");
                WriteLiteral(@"            top: 0;
                width: 100%;
                height: 56px;
                background: #fff;
                position: absolute;
                left: 0;
                margin: 0;
            }

            .pageWrap {
                display: flex;
                justify-content: space-between;
                align-items: center;
                background: 0 0;
                position: relative;
                max-width: 1212px;
                min-height: 100%;
                margin: 0 auto;
            }

            .logo {
                padding: 11px 0 0;
                margin-right: 40px;
            }

            #logo {
                display: inline-block;
                width: 132px;
                height: 35px;
                background-repeat: no-repeat;
                background-image: url(./TemplateData/ava.jpg);
                background-size: 100% 100%;
            }

            .navContainer {
                position: r");
                WriteLiteral(@"elative;
                margin-right: auto;
            }

            .mainMenu {
                margin: 0;
                line-height: 1.3;
            }

            .expandingMenuList {
                font-size: 0;
            }

            .expandingMenuList > li {
                position: relative;
                font-size: 16px;
            }

            .expandingMenuList > li:before {
                content: '';
                position: absolute;
                left: 0;
                top: 100%;
                width: 100%;
                height: 2px;
                background-color: black;
                transition: all .25s ease;
                transform-origin: top;
                transform: scaleY(0);
            }

            .expandingMenuList > li:hover:before {
                transform: scaleY(1);
            }

            .buttonPlay {
                font-size: 16px;
                display: inline-block;
                list-style: ");
                WriteLiteral(@"none;
                vertical-align: middle;
                margin: 0;
            }

            .textLogo {
                color: #444;
                position: relative;
                z-index: 1;
                display: block;
                cursor: pointer;
                font-style: italic;
            }

            .textLogo > span {
                position: relative;
                z-index: 1;
                display: block;
                box-sizing: border-box;
                -moz-box-sizing: border-box;
                height: 56px;
                background: #fff;
                padding: 1.2em .7em 0;
            }

            .expandingMenuTrigger {
                display: none;
            }

            .section-container-component {
                background-color: #fff;
                border-radius: .3rem;
                overflow: hidden;
            }

            .section-content-component {
                padding: 1.5rem;
          ");
                WriteLiteral(@"  }

            /*.post-preview-list-component {
                padding: 1.5rem;
                display: -webkit-box;
                display: -ms-flexbox;
                display: flex;
                -ms-flex-wrap: wrap;
                flex-wrap: wrap;
                -webkit-box-pack: justify;
                -ms-flex-pack: justify;
                justify-content: space-between;
                padding-bottom: 1.5rem;
            }

            .post-preview-component {
                width: calc(50% - 1.5rem);
                margin-bottom: 3rem;
                width: 100%;
            }

            .post-preview-image {
                background-color: var(--globalGray);
                display: -webkit-box;
                display: -ms-flexbox;
                display: flex;
                margin-bottom: 1.2rem;
                padding-bottom: 56.25%;
                position: relative;
            }

            .post-preview-titlecontainer {
                -");
                WriteLiteral(@"webkit-box-align: center;
                -ms-flex-align: center;
                align-items: center;
                display: -webkit-box;
                display: -ms-flexbox;
                display: flex;
            }

            .post-preview-title {
                font-size: 2.4rem;
                color: #3a729c;
                word-break: break-word;
                -webkit-box-orient: vertical;
                display: -webkit-box;
                -webkit-line-clamp: 2;
                overflow: hidden;
                text-overflow: ellipsis;
            }

            .post-preview-excerpt {
                color: var(--globalColorThemeFullToMid);
                font-size: 1.4rem;
                line-height: 2rem;
                margin-top: .5rem;
            }
*/

            /* Post */

            html {
                font-size: 10px;
                font-family: -apple-system,BlinkMacSystemFont,Segoe UI,Helvetica,Arial,sans-serif;
            }

     ");
                WriteLiteral(@"       main{
                margin: 0 auto;
                max-width: 750px;
                padding: 1.5rem;
            }
            
            a {
                color: #3a729c;
                text-decoration: none;
            }

            .post-container {
                margin-top: 10rem;
                background-color: lightgray;
                border-radius: .3rem;
                overflow: hidden;
                padding: 3rem;
            }

            .post-preview-component {
                width: 100%;
            }

            .post-preview-component:not(:last-child) p{
                margin-bottom: 3rem;
            }

            .post-preview-image {
                position: relative;
                display: flex;
                margin-bottom: 1.2rem;
                padding-bottom: 56.25%;
                background-color: #dbd9d7;
            }

           .post-preview-thumbnail {
                position: absolute;
                w");
                WriteLiteral(@"idth: 100%;
                height: 100%;
                -o-object-fit: cover;
                object-fit: cover;
            }

            .post-preview-titlecontainer {
                display: flex;
                align-items: center;
                font-weight: 600;
                font-size: 1.8rem;
                color: #26211b;
                margin: 0;
                padding: 0;
            }

            .post-preview-title {
                font-size: 2.4rem;
            }

            .post-preview-meta-component {
                align-items: center;
                color: #8b8987;
                display: flex;
                flex-wrap: wrap;
                font-size: 1.3rem;
            }

            .post-preview-meta {
                margin-top: .5rem;
            }

            .post-preview-meta-title {
                background-color: #b33430;
                border-radius: .3rem;
                color: #fff;
                font-size: .9rem;
                WriteLiteral(@"
                font-weight: 600;
                line-height: 1;
                padding: .2rem .3rem;
                margin-right: .3rem;
            }

            .post-preview-meta-username {
                color: #8b8987;
                font-weight: 600;
            }

            .post-preview-meta-time{
                display: flex;
                align-items: center;
            }

            .post-preview-meta-separator {
                padding: 0 .4rem;
            }

            .post-preview-meta-content {
                margin-left: .4rem;
            }

            .post-preview-excerpt {
                display: -webkit-box;
                -webkit-line-clamp: 3;
                overflow: hidden;
                text-overflow: ellipsis;
                max-height: 6rem;
                word-break: break-word;
                font-size: 1.4rem;
                line-height: 2rem;
                margin-top: .5rem;
                color: #312e2b;
      ");
                WriteLiteral("      }\r\n        </style>\r\n    ");
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
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "895e29e48bb4de3885c8340f6e7e1614f08dd66213600", async() => {
                WriteLiteral(@"
        <header class=""pageHeader"">
            <div class=""overLayer""></div>

            <div class=""pageWrap"">
                <div class=""logo"">
                    <a href=""#"" id=""logo""></a>
                </div>

                <div class=""navContainer"">
                    <nav class=""mainMenu "">
                        <ul class=""expandingMenuList"">
                            <li class=""buttonPlay"" onclick=""StartPlay()"">
                                <a class=""textLogo"">
                                    <span>Play</span>
                                </a>
                            </li>
                            <li class=""buttonPlay"">
                                <a class=""textLogo"">
                                    <span>Rules</span>
                                </a>
                            </li>
                            <li class=""buttonPlay"" onclick=""StartAbout()"">
                                <a class=""textLogo"">
                          ");
                WriteLiteral(@"          <span>Info</span>
                                </a>
                            </li>
                            <li class=""buttonPlay"">
                                <a class=""textLogo"">
                                    <span>Pososi</span>
                                </a>
                            </li>
                        </ul>
                    </nav>
                </div>
            </div>
        </header>

        <main>
");
                WriteLiteral(@"
            <div class=""post-container"">
                <acticle class=""post-preview-component"">
                    <a href=""#"" class=""post-preview-image"">
                        <img src=""https://images.chesscomfiles.com/uploads/v1/article/26930.963d7740.630x354o.e2379185b210.png"" class=""post-preview-thumbnail"">
                    </a>
                    <h2 class=""post-preview-titlecontainer"">
                        <a href=""#"" class=""post-preview-title"">Title</a>
                    </h2>
                    <div class=""post-preview-meta"">
                        <div class=""post-preview-meta-component"">
                            <span class=""post-preview-meta-title"">GM</span>
                            <a href=""#"" class=""post-preview-meta-username"">
                                Gserper
                            </a>
                            <div class=""post-preview-meta-time"">
                                <span class=""post-preview-meta-separator"">|</span>
            ");
                WriteLiteral(@"                    <span class=""post-preview-meta-icon""><i class=""fas fa-calendar-alt""></i></span>
                                <span class=""post-preview-meta-content"">
                                    <span class=""post-preview-meta-date"">1 день тому</span>
                                </span>
                            </div>
                        </div>
                    </div>
                    <p class=""post-preview-excerpt"">
                        One of the most famous quotes of Kozma Prutkov states: ""Throwing pebbles into the water, look at the ripples they form on the surface. Otherwise this activity will be an empty amusement."" While it is obviously a humorous phrase, similar to Yogi Be...
                    </p>
                </acticle>
                <acticle class=""post-preview-component"">
                    <a href=""#"" class=""post-preview-image"">
                        <img src=""https://images.chesscomfiles.com/uploads/v1/article/26930.963d7740.630x354o.e23791");
                WriteLiteral(@"85b210.png"" class=""post-preview-thumbnail"">
                    </a>
                    <h2 class=""post-preview-titlecontainer"">
                        <a href=""#"" class=""post-preview-title"">Title</a>
                    </h2>
                    <div class=""post-preview-meta"">
                        <div class=""post-preview-meta-component"">
                            <span class=""post-preview-meta-title"">GM</span>
                            <a href=""#"" class=""post-preview-meta-username"">
                                Gserper
                            </a>
                            <div class=""post-preview-meta-time"">
                                <span class=""post-preview-meta-separator"">|</span>
                                <span class=""post-preview-meta-icon""><i class=""fas fa-calendar-alt""></i></span>
                                <span class=""post-preview-meta-content"">
                                    <span class=""post-preview-meta-date"">1 день тому</span>
           ");
                WriteLiteral(@"                     </span>
                            </div>
                        </div>
                    </div>
                    <p class=""post-preview-excerpt"">
                        One of the most famous quotes of Kozma Prutkov states: ""Throwing pebbles into the water, look at the ripples they form on the surface. Otherwise this activity will be an empty amusement."" While it is obviously a humorous phrase, similar to Yogi Be...
                    </p>
                </acticle>
            </div>
        </main>

        <script>

            function StartAbout() {
                window.location.replace('./about');
            }

            function StartPlay() {
                window.location.replace('./game');
            }

        </script>
        <script src=""https://kit.fontawesome.com/9135621f22.js"" crossorigin=""anonymous""></script>

    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_about> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_about> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_about>)PageContext?.ViewData;
        public Pages_about Model => ViewData.Model;
    }
}
#pragma warning restore 1591