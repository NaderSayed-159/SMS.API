using AutoMapper;
using eSealClientSample.Domain.Patterns.Repositories;
using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Data.Contexts;
using SMS.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Business
{
    public interface ICustomerService:IServiceBase<Customer, CustomerModel, Guid>
    {
        public Task UpdateCustomer(CustomerModel customemodel);
    }
    public class CustomerService:ServiceBase<Customer, CustomerModel, Guid>, ICustomerService
    {
        private readonly SMSDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(SMSDBContext context, IUnitOfWork unitOfWork, IMapper mapper):base(context, unitOfWork, mapper) 
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task UpdateCustomer(CustomerModel customemodel)
        {
            try
            {
             
                var result = await base.ModifyAsync(customemodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
