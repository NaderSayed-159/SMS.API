using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Model;
using System;
using System.Collections.Generic;
using SMS.Infrastructure.Data.Contexts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Business
{
    public interface IWarehouseService : IServiceBase<Warehouse, WarehouseModel, Guid>
    {
    }
    public class WarehouseService : ServiceBase<Warehouse, WarehouseModel, Guid>, IWarehouseService
    {
        private readonly SMSDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WarehouseService(SMSDBContext context, IUnitOfWork unitOfWork, IMapper mapper) : base(context, unitOfWork, mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
