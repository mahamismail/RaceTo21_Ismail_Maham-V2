#pragma checksum "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\RoundScore.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5f6eb19b9e96cac9cfff07d8c151e0553073649"
// <auto-generated/>
#pragma warning disable 1591
namespace RaceTo21_BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\_Imports.razor"
using RaceTo21_BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\RoundScore.razor"
using RaceTo21_BlazorApp;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/RoundScore")]
    public partial class RoundScore : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n\r\n\tbody {\r\n\t\tfont-family: \'Montserrat\', sans-serif;\r\n\t}\r\n\r\n\t.btn-purple {\r\n\t\tbackground-color: purple;\r\n\t\tcolor: #fff; /* text color */\r\n\t}\r\n\r\n\t.btn-rounded {\r\n\t\tborder-radius: 50px; /* make the button fully rounded */\r\n\t\tpadding: 10px 20px; /* adjust the padding to your preference */\r\n\t\tfont-size: 16px; /* adjust the font size to your preference */\r\n\t\tfont-weight: 500;\r\n\t}\r\n\r\n\t#numberInput {\r\n\t\tbackground-color: #D3D3D3; /* set the background color to grey */\r\n\t\twidth: 200px; /* set the width to your desired size */\r\n\t\tmargin: 20px;\r\n\t\tfont-size: 20px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t}\r\n\r\n\t.form-group {\r\n\t\tmargin: 10px;\r\n\t\tdisplay: inline-block;\r\n\t}\r\n\r\n\t.form-control {\r\n\t\tbackground-color: #D3D3D3; /* set the background color to grey */\r\n\t\twidth: 200px; /* set the width to your desired size */\r\n\t\tfont-size: 20px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t\tpadding: 10px;\r\n\t}\r\n\r\n\tp {\r\n\t\twidth: 70%;\r\n\t\ttext-align: center;\r\n\t\tpadding-bottom: 20px;\r\n\t}\r\n\r\n\t.container {\r\n\t\tpadding: 80px 0 0 0;\r\n\t\tdisplay: flex;\r\n\t\tflex-direction: column;\r\n\t\talign-items: center;\r\n\t\tjustify-content: center;\r\n\t\tmargin: 5px;\r\n\t}\r\n\r\n\th1 {\r\n\t\tpadding: 10px 10px 10px 10px;\r\n\t\tfont-size: 45px;\r\n\t\tfont-weight: bold;\r\n\t\tcolor: purple;\r\n\t\ttext-align: center;\r\n\t\tmargin-top: 10px;\r\n\t}\r\n\r\n\th2 {\r\n\t\tpadding: 10px 10px 10px 10px;\r\n\t\tfont-size: 25px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t\tmargin-top: 10px;\r\n\t}\r\n\r\n\timg {\r\n\t\twidth: 30%;\r\n\t}\r\n</style>\r\n\r\n<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\r\n<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\r\n<link href=\"https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap\" rel=\"stylesheet\">");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
