using System.Collections.Generic;
using System.Reflection;
using Application.Core;
using Application.Core.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController:ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if(result==null)
                return NotFound();
            if(result.IsSuccess && result.Value!=null)
                return Ok(result);
            if(result.IsSuccess && result.Value==null)
                return NotFound();
            return BadRequest(result.Error);
        }

        protected void LogAuditEvent()
        {
            // Step 1, extrapolate data from httpContext
            string auditLogEvent = MethodBase.GetCurrentMethod().Name;
            string auditLogUrl = HttpContext.Request.Path.ToString();
            string auditLogHttpMethod = HttpContext.Request.Method;
            string requestPayload = HttpContext.Request.Body.ToString();

            // Dodati recimo kakav je response, statusCode i responseText

            // preko stack-a doci do funkcije koja je trigerovala HandleResult i celu audit logiku
            // ubaciti u HandleResult preko atributa


            // Step 2: Write to AuditLog table
        }

        protected ActionResult HandleResultForLists<T>(Result<List<T>> result)
        {
            if(result.IsSuccess && result.Value.Count!=0)
                return Ok(result);
            if(result.IsSuccess && result.Value.Count==0)
                return NotFound();
            return BadRequest(result.Error);
        }

        protected ActionResult HandlePagedListResult<T>(PagedResult<List<T>> result)
        {
            if (result.IsSuccess && result.Value.Count != 0)
                return Ok(result);
            if (result.IsSuccess && result.Value.Count == 0)
                return NotFound();
            return BadRequest(result.Error);
        }

        protected ActionResult HandleResultForCollections<T>(Result<ICollection<T>> result)
        {
            return Ok(result);
            // if(result.IsSuccess && result.Value.Count!=0)
            //     return Ok(result);
            // if(result.IsSuccess && result.Value.Count==0)
            //     return NotFound();
            // return BadRequest(result.Error);
        }
    }
}