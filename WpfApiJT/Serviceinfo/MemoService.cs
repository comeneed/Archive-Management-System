using ApIShared.Parameters;
using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Shared.Dtos;
using WpfApi.Models;
using WpfApi.Service;
using WpfApiJT.Service;

namespace WpfApiJT.Serviceinfo
{
    public class MemoService : IMemoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public MemoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// 分页查询所有备忘录
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> GetPageListAllAsync(QueryParameter parameter)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetPagedListAsync(predicate: x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search),
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: y => y.OrderByDescending(t => t.CreateDate));
                if (memo != null)
                {
                    return new ApiResponse(true, memo);
                }
                else
                {
                    return new ApiResponse(false, "查询数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }

        }









        /// <summary>
        /// 新增备忘录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AddEntityAsync(MemoDto model)
        {
            try
            {
                var memo = mapper.Map<Memo>(model);
                await _unitOfWork.GetRepository<Memo>().InsertAsync(memo);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, memo);
                }
                else
                {
                    return new ApiResponse(false, "添加数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
        }

       

        /// <summary>
        /// 删除备忘录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteEntityAsync(int id)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: t => t.Id.Equals(id));
                if (memo != null)
                {
                    repository.Delete(memo);
                }
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, "删除数据成功！");
                }
                else
                {
                    return new ApiResponse(false, "删除数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
        }
        /// <summary>
        /// 查询所有备忘录
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync()
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetAllAsync();
                if (memo != null)
                {
                    return new ApiResponse(true, memo);
                }
                else
                {
                    return new ApiResponse(false, "查询数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }

        }
        /// <summary>
        /// 根据Id查询备忘录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: t => t.Id.Equals(id));
                if (memo != null)
                {
                    return new ApiResponse(true, memo);
                }
                else
                {
                    return new ApiResponse(false, $"查询Id={id}的数据失败！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
        }
        /// <summary>
        /// 更新备忘录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UpdateEntityAsync(MemoDto model)
        {
            try
            {
                var dbmemo = mapper.Map<Memo>(model);
                var repository = _unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: t => t.Id.Equals(dbmemo.Id));
                if (memo != null)
                {
                    memo.Title = dbmemo.Title;
                    memo.Content = dbmemo.Content;
                    memo.UpdateDate = DateTime.Now;
                    repository.Update(memo);
                    if (await _unitOfWork.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse(true, "更新数据成功！");
                    }
                    else
                    {
                        return new ApiResponse(false, "更新数据失败！");
                    }
                }
                else
                {
                    return new ApiResponse(false, $"未查询到Id={dbmemo.Id}的数据！");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
        }

        
    }
}
