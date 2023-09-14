using System.Net;
using Microsoft.AspNetCore.Mvc;
using PartsServer.Models;

namespace PartsServer.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
	protected List<Part> UserParts
	{
		get
		{
			if (string.IsNullOrWhiteSpace(this.AuthorizationToken))
			{
				return null;
			}

			if (!PartsFactory.Parts.ContainsKey(this.AuthorizationToken))
			{
				return null;
			}

			var result = PartsFactory.Parts[this.AuthorizationToken];

			return result.Item2;

		}
	}

	protected bool CheckAuthorization()
	{
		PartsFactory.ClearStaleDate();

		try
		{
			var context = HttpContext;
			
			if (!string.IsNullOrWhiteSpace(this.AuthorizationToken))
				return PartsFactory.Parts.ContainsKey(this.AuthorizationToken);
			context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
			return false;

		}
		catch
		{
		}

		return false;
	}

	protected string AuthorizationToken
	{
		get
		{
			string authorizationToken = string.Empty;

			var context = HttpContext;
			if (context != null)
			{
				authorizationToken = context.Request.Headers["Authorization"].ToString();
			}

			return authorizationToken;
		}
	}
}
