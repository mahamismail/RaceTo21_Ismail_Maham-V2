#pragma checksum "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "634c95af3eda05496b9d1d4c827c73ba35f06ab3"
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
            __builder.AddMarkupContent(0, "<style>\r\n\r\n\tbody {\r\n\t\tfont-family: \'Montserrat\', sans-serif;\r\n\t}\r\n\r\n\t.btn-purple {\r\n\t\tbackground-color: purple;\r\n\t\tcolor: #fff; /* text color */\r\n\t}\r\n\r\n\t.btn-rounded {\r\n\t\tborder-radius: 50px; /* make the button fully rounded */\r\n\t\tpadding: 10px 20px; /* adjust the padding to your preference */\r\n\t\tfont-size: 16px; /* adjust the font size to your preference */\r\n\t\tfont-weight: 500;\r\n\t}\r\n\r\n\t.btn-white {\r\n\t\tcolor: purple;\r\n\t}\r\n\r\n\t#numberInput {\r\n\t\tbackground-color: #D3D3D3; /* set the background color to grey */\r\n\t\twidth: 200px; /* set the width to your desired size */\r\n\t\tmargin: 20px;\r\n\t\tfont-size: 20px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t}\r\n\r\n\t.row {\r\n\t\tjustify-content: center\r\n\t}\r\n\r\n\t.form-group {\r\n\t\theight: 100%;\r\n\t\twidth: 100%;\r\n\t\tmargin: 10px;\r\n\t\tdisplay: inline-block;\r\n\t}\r\n\r\n\t.form-control {\r\n\t\tbackground-color: #D3D3D3; /* set the background color to grey */\r\n\t\twidth: 200px; /* set the width to your desired size */\r\n\t\tfont-size: 20px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t\tpadding: 10px;\r\n\t}\r\n\r\n\tp {\r\n\t\twidth: 70%;\r\n\t\ttext-align: center;\r\n\t\tpadding-bottom: 20px;\r\n\t}\r\n\r\n\t.container {\r\n\t\tpadding: 80px 0 0 0;\r\n\t\tdisplay: flex;\r\n\t\tflex-direction: column;\r\n\t\talign-items: center;\r\n\t\tjustify-content: center;\r\n\t}\r\n\r\n\th1 {\r\n\t\tpadding: 10px 10px 10px 10px;\r\n\t\tfont-size: 45px;\r\n\t\tfont-weight: bold;\r\n\t\tcolor: purple;\r\n\t\ttext-align: center;\r\n\t\tmargin-top: 10px;\r\n\t}\r\n\r\n\th2 {\r\n\t\tpadding: 10px 10px 10px 10px;\r\n\t\tfont-size: 25px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t\tmargin-top: 10px;\r\n\t}\r\n\r\n\timg {\r\n\t\twidth: 30%;\r\n\t}\r\n</style>\r\n\r\n<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\r\n<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\r\n<link href=\"https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap\" rel=\"stylesheet\">\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "container");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container");
#nullable restore
#line 99 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
         switch (Game.nextTask)
		{
			case AllTasks.GetNumberOfPlayers:


#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "type", "button");
            __builder.AddAttribute(7, "class", "btn btn-white btn-rounded mt-2");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 103 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                       ReturnToMain

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(9, "\r\n\t\t\t\t\t← Back\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n\t\t\t\t");
            __builder.AddMarkupContent(11, "<h2 class=\"text-center md-4\">How many players?</h2>\r\n\t\t\t\t");
            __builder.OpenElement(12, "input");
            __builder.AddAttribute(13, "type", "number");
            __builder.AddAttribute(14, "class", "form-control");
            __builder.AddAttribute(15, "id", "numberInput");
            __builder.AddAttribute(16, "min", "2");
            __builder.AddAttribute(17, "max", "8");
            __builder.AddAttribute(18, "step", "1");
            __builder.AddAttribute(19, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 107 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                                                 Game.numberOfPlayers

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(20, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Game.numberOfPlayers = __value, Game.numberOfPlayers, culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n\t\t\t\t");
            __builder.OpenElement(22, "button");
            __builder.AddAttribute(23, "class", "btn btn-purple btn-rounded mt-4");
            __builder.AddAttribute(24, "type", "button");
            __builder.AddAttribute(25, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 108 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                        () => { Game.nextTask = AllTasks.GetNames; }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(26, "PLAY");
            __builder.CloseElement();
#nullable restore
#line 109 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
				break;

			case AllTasks.GetNames:


#line default
#line hidden
#nullable disable
            __builder.OpenElement(27, "button");
            __builder.AddAttribute(28, "type", "button");
            __builder.AddAttribute(29, "class", "btn btn-white btn-rounded mt-2");
            __builder.AddAttribute(30, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 113 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                       () => { Game.nextTask = AllTasks.GetNumberOfPlayers; }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(31, "\r\n\t\t\t\t\t← Back\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n\t\t\t\t");
            __builder.AddMarkupContent(33, "<h2 class=\"text-center mt-4\">Player Names</h2>");
#nullable restore
#line 118 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                 if (Game.numberOfPlayers > 0)
				{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "row mt-12");
            __builder.AddAttribute(36, "style", "padding: 5px; display: flex; flex-direction: row;");
#nullable restore
#line 121 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                         for (var i = 0; i < Game.numberOfPlayers; i++)
						{
							int playerNumber = i;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(37, "div");
            __builder.AddAttribute(38, "class", "col md-3");
            __builder.OpenElement(39, "div");
            __builder.AddAttribute(40, "class", "form-group");
            __builder.OpenElement(41, "label");
            __builder.AddAttribute(42, "for", "playerInput" + (
#nullable restore
#line 126 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                             playerNumber

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(43, "Player ");
#nullable restore
#line 126 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
__builder.AddContent(44, playerNumber + 1);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(46, "input");
            __builder.AddAttribute(47, "type", "text");
            __builder.AddAttribute(48, "class", "form-control");
            __builder.AddAttribute(49, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 127 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                         Game.tempNames[playerNumber]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(50, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Game.tempNames[playerNumber] = __value, Game.tempNames[playerNumber]));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 129 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                     if (string.IsNullOrEmpty(Game.tempNames[playerNumber]))
									{
										isNameEmpty = true;
									}
									else
									{
										isNameEmpty = false;
									}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 140 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
						}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 142 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
				}

#line default
#line hidden
#nullable disable
            __builder.OpenElement(51, "button");
            __builder.AddAttribute(52, "class", "btn btn-purple btn-rounded mt-4");
            __builder.AddAttribute(53, "type", "button");
            __builder.AddAttribute(54, "disabled", 
#nullable restore
#line 144 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                          isNameEmpty

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(55, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 144 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
                                                                                                                  () => { Game.nextTask = AllTasks.ShowOverallScores; GoToScorePage(); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(56, "     PLAY     ");
            __builder.CloseElement();
#nullable restore
#line 145 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
				break;
		}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 152 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\NumberOfPlayers.razor"
       

	bool isNameEmpty = true;

	private void GoToScorePage()
	{

		for (var i = 0; i < Game.numberOfPlayers; i++)
		{
			Game.AddPlayer(Game.tempNames[i]);
			Console.WriteLine($"Player {Game.tempNames[i]} added!");
		}

		NavigationManager.NavigateTo("/OverallScore");
	}

	private void ReturnToMain()
	{

		NavigationManager.NavigateTo("/");
	}

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
