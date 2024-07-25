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
    public class PurchasingExpensesController : ControllerBase<IPurchasingExpensesService, PurchasingExpenses, PurchasingExpensesModel, Guid>
    {
        public PurchasingExpensesController(IPurchasingExpensesService service, LinkGenerator linkgenerator, IMapper mapper) : base(service, linkgenerator, mapper)
        {

        }
    }
}
