using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Attributes
{
	public class ClaimRequirementAttribute : TypeFilterAttribute
	{
		public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(CustomAuthorizationFilter))
		{
			Arguments = new object[] { new Claim(claimType, claimValue) };
		}
	}

	public class CustomAuthorizationFilter : IAuthorizationFilter
	{
		private readonly Claim _claim;

		public CustomAuthorizationFilter(Claim claim)
		{
			_claim = claim;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var hasClaim = context.HttpContext.User.Claims
				.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);

			if (!hasClaim)
			{
				context.Result = new ForbidResult();
			}
		}
	}
}
