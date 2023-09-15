using Microsoft.AspNetCore.Http;

namespace Recore.Service.Helpers;

public static class HttpContextHelper
{
	private static IHttpContextAccessor HttpContextAccessor { get; set; }
    
	private static HttpContext Context = HttpContextAccessor.HttpContext;
	public static long GetUserId => long.Parse(Context?.User?.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
}
