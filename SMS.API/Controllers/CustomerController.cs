using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Entities;
using SMS.Infrastructure.Business;
using SMS.Infrastructure.Model;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase<ICustomerService,Customer,CustomerModel,Guid>
    {
        private ICustomerService _service;
        public CustomerController(ICustomerService service, LinkGenerator linkgenerator, IMapper mapper):base(service,linkgenerator, mapper)
        {
            _service = service;
        }

        [HttpPut("UpdateCustomer")]
        public virtual async Task<IActionResult> UpdateCustomer(CustomerModel customermodel)
        {
            try
            {
                _service.UpdateCustomer(customermodel);
                return Ok();
            }
            catch (Exception e)
            {
                var error = e.InnerException is not null ? e.InnerException.Message:e.Message ;
                return StatusCode(500,error);
            }
        }
    }
}
