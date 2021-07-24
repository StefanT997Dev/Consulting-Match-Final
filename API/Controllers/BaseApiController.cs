using System.Collections.Generic;
using Application.Core;
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

        protected ActionResult HandleResultForLists<T>(Result<List<T>> result)
        {
            if(result.IsSuccess && result.Value.Count!=0)
                return Ok(result);
            if(result.IsSuccess && result.Value.Count==0)
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