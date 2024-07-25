using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Infrastructure.Data.Contexts;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Business
{
    public interface IPurchasingExpensesService : IServiceBase<PurchasingExpenses, PurchasingExpensesModel, Guid>
    {
    }
    public class PurchasingExpensesService : ServiceBase<PurchasingExpenses, PurchasingExpensesModel, Guid>, IPurchasingExpensesService
    {
        private readonly SMSDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PurchasingExpensesService(SMSDBContext context, IUnitOfWork unitOfWork, IMapper mapper) : base(context, unitOfWork, mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
