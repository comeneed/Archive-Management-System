using ApIShared.Parameters;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<WebApiResponse<TEntity>> AddAsync(TEntity entity);
        Task<WebApiResponse<TEntity>> UpdateAsync(TEntity entity);
        Task<WebApiResponse> DeleteAsync(int id);
        Task<WebApiResponse<TEntity>> GetFirstOfDefaultAsync(int id);
        Task<WebApiResponse<PagedList<TEntity>>> GetAllPageListAsync(QueryParameter parameter);
        Task<WebApiResponse<List<TEntity>>> GetAllAsync();
    }
}
