using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS.Infrastructure.Data.Contexts;
using SMS.Domain.Entities;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Business
{
    public interface IPurchaseorderService : IServiceBase<Purchaseorder, PurchaseorderModel, Guid>
    {
    }
    public class PurchaseorderService : ServiceBase<Purchaseorder, PurchaseorderModel, Guid>, IPurchaseorderService
    {
        private readonly SMSDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PurchaseorderService(SMSDBContext context, IUnitOfWork unitOfWork, IMapper mapper) : base(context, unitOfWork, mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
