using Microsoft.AspNetCore.Mvc;
using PartsServer.Models;

namespace PartsServer.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class LoginController : BaseController
{
	[HttpGet]
	public ActionResult Get()
	{
		try
		{
			var authorizationToken = Guid.NewGuid().ToString();

			PartsFactory.Initialize(authorizationToken);

			return new JsonResult(authorizationToken);
		}
		catch (Exception ex)
		{
			return new JsonResult(ex.Message);
		}
	}
}
