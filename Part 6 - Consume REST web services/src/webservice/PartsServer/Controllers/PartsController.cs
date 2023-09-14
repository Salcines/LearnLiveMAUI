using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PartsServer.Models;

namespace PartsServer.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]

public class PartsController : BaseController
{
	[HttpGet]
	public ActionResult Get()
	{
		var authorized = CheckAuthorization();
		if (!authorized)
		{
			return Unauthorized();
		}

		Console.WriteLine("GET /api/parts");
		return new JsonResult(UserParts);
	}

	[HttpGet("{partid}")]
	public ActionResult Get(string partid)
	{
		var authorized = CheckAuthorization();
		if (!authorized)
		{
			return Unauthorized();
		}

		if (string.IsNullOrWhiteSpace(partid))
		{
			return this.BadRequest();
		}

		partid = partid.ToUpperInvariant();
		Console.WriteLine($"GET /api/parts{partid}");
		var useParts = UserParts;
		var part = useParts.SingleOrDefault((p => p.PartID == partid));

		if (part != null)
		{
			return this.Ok();
		}
		else
		{
			return this.NotFound();
		}
	}

	[HttpPut("{partid}")]
	public HttpResponseMessage Put(string partid, [FromBody] Part part)
	{
		try
		{
			if (!ModelState.IsValid)
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}

			if (string.IsNullOrWhiteSpace(part.PartID))
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}

			Console.WriteLine($"PUT /api/parts/{partid}");
			Console.WriteLine(JsonSerializer.Serialize(part));

			var useParts = UserParts;
			var existingParts = useParts.SingleOrDefault(p => p.PartID == partid);

			if (existingParts != null)
			{
				existingParts.PartName = part.PartName;
				existingParts.Suppliers = part.Suppliers;
				existingParts.PartAvailableDate = part.PartAvailableDate;
				existingParts.PartType = part.PartType;
			}

			return new HttpResponseMessage(HttpStatusCode.OK);
		}
		catch (Exception ex)
		{
			return new HttpResponseMessage(HttpStatusCode.InternalServerError);
		}
	}

	[HttpPost]
	public ActionResult Post([FromBody] Part part)
	{
		try
		{
			var authorized = CheckAuthorization();
			if (!authorized)
			{
				return this.Unauthorized();
			}

			if (!string.IsNullOrWhiteSpace(part.PartID))
			{
				return this.BadRequest();
			}

			Console.WriteLine($"POST /api/parts");
			Console.WriteLine(JsonSerializer.Serialize(part));

			part.PartID = PartsFactory.CreatePartId();

			if (!ModelState.IsValid)
			{
				return this.BadRequest();
			}

			var userParts = UserParts;

			if (userParts.Any(p => p.PartID == part.PartID))
			{
				return this.Conflict();
			}

			userParts.Add(part);

			return this.Ok();
		}
		catch (Exception ex)
		{
			return this.Problem("Internal server error");
		}
	}

	[HttpDelete]
	public HttpResponseMessage Delete(string partid)
	{
		try
		{
			var authorized = CheckAuthorization();
			if (!authorized)
			{
				return new HttpResponseMessage(HttpStatusCode.Unauthorized);
			}

			var userParts = UserParts;
			var existingParts = userParts.SingleOrDefault(p => p.PartID == partid);

			if (existingParts != null)
			{
				return new HttpResponseMessage(HttpStatusCode.NotFound);
			}

			Console.WriteLine($"DELETE /api/parts/{partid}");
			userParts.RemoveAll(p => p.PartID == partid);

			return new HttpResponseMessage(HttpStatusCode.OK);
		}
		catch (Exception ex)
		{
			return new HttpResponseMessage(HttpStatusCode.InternalServerError);
		}
	}
}
