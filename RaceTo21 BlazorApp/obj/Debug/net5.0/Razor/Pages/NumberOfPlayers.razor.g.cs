#pragma checksum "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b87ff7a7f017996a6a204e483e20440288d70702"
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
#line 2 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
using RaceTo21_BlazorApp;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/NumberOfPlayers")]
    public partial class NumberOfPlayers : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n\r\n\tbody {\r\n\t\tfont-family: \'Montserrat\', sans-serif;\r\n\t}\r\n\r\n\t.btn-purple {\r\n\t\tbackground-color: purple;\r\n\t\tcolor: #fff; /* text color */\r\n\t}\r\n\r\n\t.btn-rounded {\r\n\t\tborder-radius: 50px; /* make the button fully rounded */\r\n\t\tpadding: 10px 20px; /* adjust the padding to your preference */\r\n\t\tfont-size: 16px; /* adjust the font size to your preference */\r\n\t\tfont-weight: 500;\r\n\t}\r\n\r\n\t#numberInput {\r\n\t\tbackground-color: #D3D3D3; /* set the background color to grey */\r\n\t\twidth: 200px; /* set the width to your desired size */\r\n\t\tmargin: 20px;\r\n\t\tfont-size: 20px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t}\r\n\r\n\t.form-group {\r\n\t\tmargin: 10px;\r\n\t\tdisplay: inline-block;\r\n\t}\r\n\r\n\t.form-control {\r\n\t\tbackground-color: #D3D3D3; /* set the background color to grey */\r\n\t\twidth: 200px; /* set the width to your desired size */\r\n\t\tfont-size: 20px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t\tpadding: 10px;\r\n\t}\r\n\r\n\tp {\r\n\t\twidth: 70%;\r\n\t\ttext-align: center;\r\n\t\tpadding-bottom: 20px;\r\n\t}\r\n\r\n\t.container {\r\n\t\tpadding: 80px 0 0 0;\r\n\t\tdisplay: flex;\r\n\t\tflex-direction: column;\r\n\t\talign-items: center;\r\n\t\tjustify-content: center;\r\n\t\tmargin: 5px;\r\n\t}\r\n\r\n\th1 {\r\n\t\tpadding: 10px 10px 10px 10px;\r\n\t\tfont-size: 45px;\r\n\t\tfont-weight: bold;\r\n\t\tcolor: purple;\r\n\t\ttext-align: center;\r\n\t\tmargin-top: 10px;\r\n\t}\r\n\r\n\th2 {\r\n\t\tpadding: 10px 10px 10px 10px;\r\n\t\tfont-size: 25px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t\tmargin-top: 10px;\r\n\t}\r\n\r\n\timg {\r\n\t\twidth: 30%;\r\n\t}\r\n</style>\r\n\r\n<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\r\n<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\r\n<link href=\"https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap\" rel=\"stylesheet\">\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "container");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container");
            __builder.AddMarkupContent(5, "<h2 class=\"text-center\">How many players?</h2>\r\n\t\t");
            __builder.OpenElement(6, "input");
            __builder.AddAttribute(7, "type", "number");
            __builder.AddAttribute(8, "class", "form-control");
            __builder.AddAttribute(9, "id", "numberInput");
            __builder.AddAttribute(10, "min", "2");
            __builder.AddAttribute(11, "max", "8");
            __builder.AddAttribute(12, "step", "1");
            __builder.AddAttribute(13, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 91 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                                   numberOfPlayers

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(14, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => numberOfPlayers = __value, numberOfPlayers, culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 93 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
         if (numberOfPlayers > 0)
		{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "row mt-4");
#nullable restore
#line 96 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                 for (var i = 0; i < 4 && i < numberOfPlayers; i++)
				{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "col-md-3 mb-4");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "form-group");
            __builder.OpenElement(21, "label");
            __builder.AddAttribute(22, "for", "playerName" + (
#nullable restore
#line 100 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                    i+1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(23, "Player ");
#nullable restore
#line 100 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
__builder.AddContent(24, i+1);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(26, "input");
            __builder.AddAttribute(27, "type", "text");
            __builder.AddAttribute(28, "class", "form-control");
            __builder.AddAttribute(29, "id", "playerName" + (
#nullable restore
#line 101 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                    i+1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(30, "name", "playername");
            __builder.AddAttribute(31, "style", "width: 200px");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 104 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
				}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 107 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
             if (numberOfPlayers > 4)
			{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "row mt-4");
#nullable restore
#line 110 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                     for (var i = 4; i < 8 && i < numberOfPlayers; i++)
					{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "col-md-3 mb-4");
            __builder.OpenElement(36, "div");
            __builder.AddAttribute(37, "class", "form-group");
            __builder.OpenElement(38, "label");
            __builder.AddAttribute(39, "for", "playerName" + (
#nullable restore
#line 114 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                        i+1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(40, "Player ");
#nullable restore
#line 114 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
__builder.AddContent(41, i+1);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(43, "input");
            __builder.AddAttribute(44, "type", "text");
            __builder.AddAttribute(45, "class", "form-control");
            __builder.AddAttribute(46, "id", "playerName" + (
#nullable restore
#line 115 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                        i+1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(47, "name", "playername");
            __builder.AddAttribute(48, "style", "width: 200px");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 118 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
					}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 120 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
			}

#line default
#line hidden
#nullable disable
#nullable restore
#line 120 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
             
		}

#line default
#line hidden
#nullable disable
            __builder.OpenElement(49, "button");
            __builder.AddAttribute(50, "class", "btn btn-purple btn-rounded mt-4");
            __builder.AddAttribute(51, "type", "button");
            __builder.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 123 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                GenerateNameFields

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(53, "PLAY");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 129 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
       


	int numberOfPlayers = 2; // number of players in current game

	private void GenerateNameFields()
	{

	}

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591