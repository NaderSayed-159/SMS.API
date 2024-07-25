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
    public class ProductController : ControllerBase<IProductService, Product, ProductModel, Guid>
    {
        public ProductController(IProductService service, LinkGenerator linkgenerator, IMapper mapper) : base(service, linkgenerator, mapper)
        {

        }
    }
}
