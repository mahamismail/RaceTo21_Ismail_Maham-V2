// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
        }
        #pragma warning restore 1998
#nullable restore
#line 203 "D:\NEU\Intermediate Programming\Week 5\RaceTo21_Ismail_Maham-V2\RaceTo21 BlazorApp\Pages\Gameplay.razor"
       

	bool buttonDisabled = false;

	private void GoToOverallScore()
	{
		NavigationManager.NavigateTo("/OverallScore");
	}

	private void DisableButtons()
	{
		buttonDisabled = true;
	}

	private void UpdatePlayerList()
	{
		foreach (Player player in Game.players)
		{
			if (player.isCurrentPlayer == true)
			{
				StateHasChanged();
			}
		}

		JSRuntime.InvokeVoidAsync("scrollToPlayerList");
	}

	private async Task ScrollToPlayerList()
	{
		await JSRuntime.InvokeVoidAsync("scrollToElement", "playerList");
	}

	private string ContainerColor(Player player)
	{
		if (player.isWinner == true)
		{
			return "green-solid";
		}
		else if (player.status == PlayerStatus.bust)
		{
			return "grey-solid";
		}
		else if (player.isCurrentPlayer == true && player.status == PlayerStatus.active)
		{
			return "purple-solid";
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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
