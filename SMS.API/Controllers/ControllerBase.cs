using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SMS.Domain.Entities;
using SMS.Infrastructure.Business;
using SMS.Infrastructure.Model;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerBase<TService, TEntity, TModel, TKey> : ControllerBase
        where TService : IServiceBase<TEntity, TModel, TKey>
        where TEntity : EntityBase<TKey>
        where TModel : ModelEntityBase<TKey>
    {
        TService _service;
        LinkGenerator _linkGenerator;
        IMapper _mapper;
        public ControllerBase(TService service, LinkGenerator linkgenerator, IMapper mapper)
        {
            _service = service;
            _linkGenerator = linkgenerator;
            _mapper = mapper;
        }
        [HttpGet]
        public virtual async Task<IActionResult> GetAsync()
        {
            try
            {
                var models = await _service.SelectAsync();
                return Ok(models);
            }
            catch (Exception e)
            {
                var error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure [{error}]");
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsyncById(TKey id)
        {
            try
            {
                var model = await _service.SelectByIdAsync(id);
                return Ok(model);
            }
            catch (Exception e)
            {
                var error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure [{error}]");
            }
        }



        // POST api/<controller>
        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(TModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.AddAsync(model, User.Identity.Name);

                var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
                var location = _linkGenerator.GetPathByAction("Get", controllerName, new { id = result.Id });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("location");
                }

                return Created(location, result);
            }
            catch (Exception e)
            {
                var error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure [{error}]");
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> PutAsync(TKey id, TModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modelToUpdate = await _service.SelectByIdAsync(id);
            if (modelToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(model, modelToUpdate);
                var result = await _service.ModifyAsync(modelToUpdate, User.Identity.Name);

                return Ok(result);
            }
            catch (Exception e)
            {
                var error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure [{error}]");
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(TKey id)
        {
            try
            {
                var result = await _service.RemoveAsync(id);
                if (result)
                {
                    return Ok();
                }

                return BadRequest("Fail to delete");
            }
            catch (Exception e)
            {
                var error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure [{error}]");
            }
        }

    }
}
