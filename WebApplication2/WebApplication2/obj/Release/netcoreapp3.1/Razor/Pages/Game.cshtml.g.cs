#pragma checksum "E:\Нова папка\ggames\WebApplication2\WebApplication2\Pages\Game.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b97c7f1ff7e018f685edb35b1f6acc41f2c5d86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication2.Pages.Pages_Game), @"mvc.1.0.razor-page", @"/Pages/Game.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b97c7f1ff7e018f685edb35b1f6acc41f2c5d86", @"/Pages/Game.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"538f37ef395561d5f352aabc9fc72bce1358fc6b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Game : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
            WriteLiteral("    <!DOCTYPE html>\r\n<html lang=\"en-us\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b97c7f1ff7e018f685edb35b1f6acc41f2c5d863059", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
    <title>Unity WebGL Player | OuterCall</title>
    <link rel=""shortcut icon"" href=""TemplateData/favicon.ico"">
    <link rel=""stylesheet"" href=""TemplateData/style.css"">
    <script src=""TemplateData/UnityProgress.js""></script>
    <script src=""Build/UnityLoader.js""></script>
    <script>
        var unityInstance = UnityLoader.instantiate(""unityContainer"", ""Build/123.json"", { onProgress: UnityProgress });
    </script>
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

        .pageHeader {
            position: fixed;
            z-index: 26;
            box-shadow: 0 ");
                WriteLiteral(@"2px 2px 0 rgb(0 0 0 / 10%);
            border-bottom: 1px solid #ccc;
            top: 0;
            width: 100%;
            height: 56px;
            background: #fff;
            box-sizing: border-box;
            display: block;
        }

        .overLayer {
            top: 0;
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
            border-radius: 3px;
            overflow: hidden;
        }

        #logo {
            display: inline-block;
            width: 132px;
            h");
                WriteLiteral(@"eight: 35px;
            background-repeat: no-repeat;
            background-image: url(./TemplateData/ava.jpg);
            background-size: 100% 100%;
        }

        .navContainer {
            position: relative;
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

      ");
                WriteLiteral(@"          .expandingMenuList > li:hover:before {
                    transform: scaleY(1);
                }

        .buttonPlay {
            font-size: 16px;
            display: inline-block;
            list-style: none;
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
    </style>
");
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
            WriteLiteral("\r\n  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b97c7f1ff7e018f685edb35b1f6acc41f2c5d868171", async() => {
                WriteLiteral(@"
      <header class=""pageHeader"">
          <div class=""overLayer""></div>

          <div class=""pageWrap"">
              <div class=""logo"">
                  <a onclick=""EbaloGeki()"" id=""logo""></a>
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
                                  <span>Info</span>
  ");
                WriteLiteral(@"                            </a>
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
      <div class=""webgl-content"">
          <div id=""unityContainer"" style=""width: 960px; height: 600px""></div>
          <div class=""footer"">
              <div class=""webgl-logo""></div>
              <div class=""fullscreen"" onclick=""unityInstance.SetFullscreen(1)""></div>
              <div class=""title"">OuterCall</div>
          </div>
      </div>
      <script>
          let token = JSON.parse(localStorage.getItem('token'));
          let userInfo = parseJwt(token);
          let userRating;


          function getRating() {
              return fetch(`https://markianpack.azurewebsites.net/a");
                WriteLiteral(@"pi/rating/${userInfo.id}`, {
                  method: 'GET',
                  headers: {
                      'Content-Type': 'application/json',
                      'Accept': 'application/json',
                      'Authorization': 'Bearer ' + token.toString(),
                      ""Access-Control-Allow-Origin"": ""*""
                  }
              })
                  .then(response => response.json());
          }

          function StartPlay() {
              window.location.replace('./game');
          }


          function EbaloGeki() {
              window.location.replace('./index');
          }

          function parseJwt(token) {
              var base64Url = token.split('.')[1];
              var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
              var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
                  return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
              }).join(''));

       ");
                WriteLiteral(@"       return JSON.parse(jsonPayload);
          };

          getRating()
              .then(data => {
                  userRating = data.rating.toString();
                  Loaded()
              })

          function Loaded() {
              unityInstance.SendMessage('JSManager', 'GetNickname', userInfo.userName);
              unityInstance.SendMessage('JSManager', 'GetScore', userRating);
          }
          
          function GameResult(arg) {
              alert(arg);
              let userID = parseJwt(JSON.parse(localStorage.getItem('token')));
              let ratingInfo = {
                  userId: userID.id,
                  rating: arg,
              }
              fetch('https://markianpack.azurewebsites.net/api/rating/', {
                  method: 'POST',
                  body: JSON.stringify(ratingInfo),
                  headers: {
                      'Content-Type': 'application/json',
                      'Authorization': 'Bearer ' + token.toString(");
                WriteLiteral("),\r\n                      \'Accept\': \'application/json\',\r\n                      \"Access-Control-Allow-Origin\": \"*\"\r\n                  }\r\n              })\r\n          }\r\n\r\n      </script>\r\n  ");
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
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PrivacyModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PrivacyModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PrivacyModel>)PageContext?.ViewData;
        public PrivacyModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
