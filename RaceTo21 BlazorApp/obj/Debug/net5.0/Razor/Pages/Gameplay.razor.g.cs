#pragma checksum "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6196e845560dfdad7adf5f0a0a66a6bd0517a805"
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
#line 2 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
using RaceTo21_BlazorApp;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Gameplay")]
    public partial class Gameplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n\r\n\tbody {\r\n\t\tfont-family: \'Montserrat\', sans-serif;\r\n\t}\r\n\r\n\t.fixed-bottom {\r\n\t\tjustify-content: center;\r\n\t}\r\n\r\n\t.row {\r\n\t\tdisplay: flex;\r\n\t\tflex-wrap: wrap;\r\n\t\tjustify-content: space-between;\r\n\t\talign-items: center;\r\n\t\twidth: 100%;\r\n\t}\r\n\r\n\t.btn-purple {\r\n\t\tbackground-color: purple;\r\n\t\tcolor: #fff; /* text color */\r\n\t}\r\n\r\n\t.btn-rounded {\r\n\t\tborder-radius: 50px; /* make the button fully rounded */\r\n\t\tpadding: 10px 20px; /* adjust the padding to your preference */\r\n\t\tfont-size: 16px; /* adjust the font size to your preference */\r\n\t\tfont-weight: 500;\r\n\t}\r\n\r\n\t#numberInput {\r\n\t\tbackground-color: #D3D3D3; /* set the background color to grey */\r\n\t\twidth: 200px; /* set the width to your desired size */\r\n\t\tmargin: 20px;\r\n\t\tfont-size: 20px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t}\r\n\r\n\t.form-group {\r\n\t\tmargin: 10px;\r\n\t\tdisplay: inline-block;\r\n\t}\r\n\r\n\t.form-control {\r\n\t\tbackground-color: #D3D3D3; /* set the background color to grey */\r\n\t\twidth: 200px; /* set the width to your desired size */\r\n\t\tfont-size: 20px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t\tpadding: 10px;\r\n\t}\r\n\r\n\tp {\r\n\t\twidth: 70%;\r\n\t\ttext-align: center;\r\n\t\tpadding-bottom: 20px;\r\n\t}\r\n\r\n\t.nav {\r\n\t\tpadding: 30px;\r\n\t\tdisplay: flex;\r\n\t\twidth: 100%;\r\n\t\tmax-width: 100%;\r\n\t}\r\n\r\n\t.container {\r\n\t\tpadding: 0 0 80px 0;\r\n\t\tdisplay: flex;\r\n\t\tflex-direction: column;\r\n\t\talign-items: center;\r\n\t\tjustify-content: center;\r\n\t\tmargin: 5px;\r\n\t}\r\n\r\n\t.greyNav {\r\n\t\tbackground-color: #CBC3E3;\r\n\t}\r\n\r\n\th2 {\r\n\t\tpadding: 10px 10px 10px 10px;\r\n\t\tfont-size: 30px;\r\n\t\tfont-weight: bold;\r\n\t\ttext-align: center;\r\n\t\tmargin-top: 10px;\r\n\t}\r\n\r\n\t.card-container {\r\n\t\tdisplay: flex;\r\n\t\tflex-wrap: wrap;\r\n\t\tjustify-content: flex-start;\r\n\t}\r\n\r\n\t.card-image {\r\n\t\tmax-width: 120%;\r\n\t\tmargin-right: 2px;\r\n\t}\r\n\r\n\t.purple-outline {\r\n\t\tborder-style: solid;\r\n\t\tborder-color: purple;\r\n\t}\r\n\r\n\t.purple-solid {\r\n\t\tbackground-color: purple;\r\n\t}\r\n\r\n\t.green-solid {\r\n\t\tbackground-color: #50C878;\r\n\t}\r\n\r\n\t.grey-solid {\r\n\t\tbackground-color: #D3D3D3;\r\n\t}\r\n\r\n\t.white-text {\r\n\t\tcolor: white;\r\n\t}\r\n</style>\r\n\r\n<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\r\n<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\r\n<link href=\"https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap\" rel=\"stylesheet\">\r\n\r\n\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "container");
#nullable restore
#line 133 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
     switch (Game.nextTask)
	{
		case AllTasks.PlayerTurn:


#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "h2");
            __builder.AddAttribute(4, "class", "mt-4");
            __builder.AddContent(5, "Round ");
#nullable restore
#line 137 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
__builder.AddContent(6, Game.rounds+1);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n\t\t\t");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "container");
#nullable restore
#line 139 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                 foreach (Player player in Game.players)
				{
					

#line default
#line hidden
#nullable disable
#nullable restore
#line 141 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                     if (player.isWinner == true)
					{
						DisableButtons();

#line default
#line hidden
#nullable disable
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col");
            __builder.AddAttribute(12, "style", "display: flex; flex-wrap: wrap; justify-content: flex-start; margin-bottom: 10px;");
            __builder.OpenElement(13, "h4");
            __builder.AddAttribute(14, "style", "font-weight: 400; margin-right: 20px; ");
            __builder.AddMarkupContent(15, "🎊 ~ ");
#nullable restore
#line 145 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
__builder.AddContent(16, player.name);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(17, " wins! ~ 🎊");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(19, "button");
            __builder.AddAttribute(20, "type", "button");
            __builder.AddAttribute(21, "class", "btn btn-purple btn-rounded");
            __builder.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 146 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                               () => { Game.nextTask = AllTasks.ShowOverallScores; GoToOverallScore(); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(23, "View Scores");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 148 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
					}

#line default
#line hidden
#nullable disable
#nullable restore
#line 148 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                     
				}

#line default
#line hidden
#nullable disable
#nullable restore
#line 151 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                 foreach (Player player in Game.players)
				{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "row mt-12");
            __builder.AddAttribute(26, "style", "padding: 5px; width: 100%; flex-direction: row; flex-wrap:nowrap ");
            __builder.OpenElement(27, "div");
            __builder.AddAttribute(28, "class", 
#nullable restore
#line 154 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                     ContainerColor(player)

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(29, "style", "margin-right:10px; width: 1250px; height: 150px; padding: 10px;");
            __builder.OpenElement(30, "label");
            __builder.AddAttribute(31, "class", 
#nullable restore
#line 155 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                            player.isCurrentPlayer || player.isWinner ? "white-text" : " "

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(32, "style", "font-weight: bold; font-size: 20px");
#nullable restore
#line 155 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
__builder.AddContent(33, player.name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "row mt-12 card-container");
            __builder.AddAttribute(37, "style", "padding: 5px");
#nullable restore
#line 157 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                 foreach (Card card in player.cards)
								{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(38, "img");
            __builder.AddAttribute(39, "class", "card-image");
            __builder.AddAttribute(40, "src", "card_assets/" + (
#nullable restore
#line 159 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                              Deck.imageIDs[$"{card.id}"]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(41, "alt", 
#nullable restore
#line 159 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                                 card.id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 160 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
								}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n\r\n\t\t\t\t\t\t");
            __builder.OpenElement(43, "h3");
            __builder.AddAttribute(44, "style", "margin-right: 10px; display: inline-block; border: 2px solid purple; padding: 10px; border-radius: 100px ");
#nullable restore
#line 164 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
__builder.AddContent(45, player.score);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(47, "h4");
            __builder.AddAttribute(48, "style", "margin-right:10px; font-weight: 400");
#nullable restore
#line 165 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
__builder.AddContent(49, PlayerStatusToString(player));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 168 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
				}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "fixed-bottom");
            __builder.OpenElement(52, "div");
            __builder.AddAttribute(53, "class", "nav greyNav");
            __builder.OpenElement(54, "row");
            __builder.AddAttribute(55, "class", "row");
            __builder.OpenElement(56, "div");
            __builder.AddAttribute(57, "class", "col-md-3");
            __builder.OpenElement(58, "label");
            __builder.AddAttribute(59, "for", "playerName");
            __builder.AddAttribute(60, "style", "font-weight: bold; font-size: 20px");
#nullable restore
#line 175 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
__builder.AddContent(61, Game.players[Game.currentPlayer].name);

#line default
#line hidden
#nullable disable
            __builder.AddContent(62, "\'s Turn");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(64, "div");
            __builder.AddAttribute(65, "class", "col-md-6");
            __builder.OpenElement(66, "button");
            __builder.AddAttribute(67, "type", "button");
            __builder.AddAttribute(68, "id", "drawCard1");
            __builder.AddAttribute(69, "class", "btn btn-purple btn-rounded");
            __builder.AddAttribute(70, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 178 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                              () => { Game.DrawCards(1); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(71, "disabled", 
#nullable restore
#line 178 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                                                                       buttonDisabled

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(72, "PICK 1 CARD");
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(74, "button");
            __builder.AddAttribute(75, "type", "button");
            __builder.AddAttribute(76, "id", "drawCard2");
            __builder.AddAttribute(77, "class", "btn btn-purple btn-rounded");
            __builder.AddAttribute(78, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 179 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                              () => { Game.DrawCards(2); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(79, "disabled", 
#nullable restore
#line 179 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                                                                       buttonDisabled

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(80, "PICK 2 CARDS");
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(82, "button");
            __builder.AddAttribute(83, "type", "button");
            __builder.AddAttribute(84, "id", "drawCard3");
            __builder.AddAttribute(85, "class", "btn btn-purple btn-rounded");
            __builder.AddAttribute(86, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 180 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                              () => { Game.DrawCards(3); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(87, "disabled", 
#nullable restore
#line 180 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                                                                       buttonDisabled

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(88, "PICK 3 CARDS");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n\t\t\t\t\t\t");
            __builder.AddMarkupContent(90, "<div class=\"col-md-1\" style=\"text-align: center\"><label>OR</label></div>\r\n\t\t\t\t\t\t");
            __builder.OpenElement(91, "div");
            __builder.AddAttribute(92, "class", "col-md-2");
            __builder.OpenElement(93, "button");
            __builder.AddAttribute(94, "class", "btn btn-purple btn-rounded");
            __builder.AddAttribute(95, "id", "drawCard0");
            __builder.AddAttribute(96, "style", "width: 200px");
            __builder.AddAttribute(97, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 186 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                                     () => { Game.DrawCards(0); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(98, "disabled", 
#nullable restore
#line 186 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
                                                                                                                                                              buttonDisabled

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(99, "PASS");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 191 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"

			break;
	 }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 197 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
       

	bool buttonDisabled = false;

	private void GoToOverallScore()
	{
		NavigationManager.NavigateTo("/OverallScore");
	}

	private void DisableButtons()
	{
		buttonDisabled = true;
	}

	private string ContainerColor(Player player)
	{
		if (player.isWinner == true)
		{
			return "green-solid";
		}
		else if (player.isCurrentPlayer == true)
		{
			return "purple-solid";
		}
		else if (player.status == PlayerStatus.bust)
		{
			return "grey-solid";
		}
		return "purple-outline";
	}

	private string PlayerStatusToString(Player player)
	{
		if (player.status == PlayerStatus.bust)
		{
			return "Busted";
		}
		else if (player.status == PlayerStatus.win)
		{
			return "Winner!";
		}
		else if (player.status == PlayerStatus.stay)
		{
			return "Stayed";
		}
		return "";
	}

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
