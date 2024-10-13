using Microsoft.JSInterop;

namespace MovieTicket.BlazorServer.Helper
{
	public static class IJSRuntimeExtension
	{
		public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
		{
			await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
		}
		public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
		{
			await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
		}
	}
}
