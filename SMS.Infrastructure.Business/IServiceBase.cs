using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS.Infrastructure.Data.Contexts;
using SMS.Domain.Entities;
using SMS.Domain.Patterns.Interfaces;
using SMS.Domain.Patterns.Repositories;
using SMS.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Business
{
    public interface IServiceBase<TEntity, TModel, in TKey> : IRepository<TEntity>
        where TEntity : EntityBase<TKey>
        where TModel : ModelEntityBase<TKey>
    {
        Task<TModel> AddAsync(TModel model, string modifiedBy = null);
        Task<TModel> ModifyAsync(TModel model, string modifiedBy = null);

        Task<bool> RemoveAsync(TKey id);

        Task<IEnumerable<TModel>> SelectAsync();
        Task<TModel> SelectByIdAsync(TKey id);
        Task<bool> CanConnectAsync();
    }

    public class ServiceBase<TEntity, TModel, TKey> : RepositoryBase<TEntity>, IServiceBase<TEntity, TModel, TKey>
        where TEntity : EntityBase<TKey>
        where TModel : ModelEntityBase<TKey>
    {
        private readonly SMSDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceBase(SMSDBContext context, IUnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public virtual async Task<TModel> AddAsync(TModel model, string modifiedBy = null)
        {
            var entity = _mapper.Map<TEntity>(model);

            try
            {
                base.Insert(entity);
                
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<TModel>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CanConnectAsync()
        {
            return await base.CanConnectAsync();
        }

        public virtual async Task<TModel> ModifyAsync(TModel model, string modifiedBy = null)
        {

            var entity = _mapper.Map<TEntity>(model);

            try
            {
                base.Update(entity);

                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<TModel>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> RemoveAsync(TKey id)
        {
            try
            {
                var result = await base.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TModel>> SelectAsync()
        {
            var entities = await base.FindAllAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public virtual async Task<TModel> SelectByIdAsync(TKey id)
        {
            var entity = await base.FindAsync(id);
            return _mapper.Map<TModel>(entity);
        }

    }

}


