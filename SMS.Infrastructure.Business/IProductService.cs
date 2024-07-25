using AutoMapper;
using SMS.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
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
    public interface IProductService : IServiceBase<Product, ProductModel, Guid>
    {
    }
    public class ProductService : ServiceBase<Product, ProductModel, Guid>, IProductService
    {
        private readonly SMSDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(SMSDBContext context, IUnitOfWork unitOfWork, IMapper mapper) : base(context, unitOfWork, mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
