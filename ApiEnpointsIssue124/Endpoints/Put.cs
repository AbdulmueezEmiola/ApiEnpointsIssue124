using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using Microsoft.AspNetCore.Mvc;

namespace ApiEnpointsIssue124.Endpoints
{
	public class Put : Ardalis.ApiEndpoints.BaseAsyncEndpoint.WithRequest<RequestType>.WithoutResponse
	{
		[HttpPut("/put/{Id}")]
		public override async Task<ActionResult> HandleAsync([FromRoute] RequestType request, CancellationToken cancellationToken = default)
		{
			Debug.Assert(request.Id != Guid.Empty);

			await Task.Delay(0, cancellationToken);

			return Ok();
		}
	}

	public class RequestType
{
		[FromRoute(Name = "Id")] public Guid Id { get; set; }
		[FromBody] public byte[] Version { get; set; }
		[FromBody] public string FromBody1 { get; set; }
		[FromBody] public string FromBody2 { get; set; }
	}
}
