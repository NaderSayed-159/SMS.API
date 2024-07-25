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
    public class PurchaseorderController : ControllerBase<IPurchaseorderService, Purchaseorder, PurchaseorderModel, Guid>
    {
        public PurchaseorderController(IPurchaseorderService service, LinkGenerator linkgenerator, IMapper mapper) : base(service, linkgenerator, mapper)
        {

        }
    }
}
