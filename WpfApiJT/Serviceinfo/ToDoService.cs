using ApIShared.Parameters;
using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Shared.Dtos;
using WpfApi.Models;
using WpfApi.Service;

namespace WpfApi.Serviceinfo
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        /// <summary>
        /// 分页查询所有数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> GetPageListAllAsync(QueryParameter parameter)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetPagedListAsync(predicate: x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search),
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: y => y.OrderByDescending(t => t.CreateDate));
                if (todo != null)
                {
                    return new ApiResponse(true, todo);
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



        public async Task<ApiResponse> AddEntityAsync(TodoDto model)
        {
            try
            {
                var todo = mapper.Map<ToDo>(model);
                await unitOfWork.GetRepository<ToDo>().InsertAsync(todo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, model);
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
        /// 删除待办事项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteEntityAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: t => t.Id.Equals(id));
                repository.Delete(todo);
                if (await unitOfWork.SaveChangesAsync() > 0)
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
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync()
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetAllAsync();
                if (todo != null)
                {
                    return new ApiResponse(true, todo);
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
        /// 根据Id查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: t => t.Id.Equals(id));
                if (todo != null)
                {
                    return new ApiResponse(true, todo);
                }
                else
                {
                    return new ApiResponse(false, $"未查询到Id={id}的数据！");
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse(false, ex.Message);
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> UpdateEntityAsync(TodoDto model)
        {
            try
            {
                var dbTodo = mapper.Map<ToDo>(model);
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: t => t.Id.Equals(dbTodo.Id));
                if (todo != null)
                {
                    todo.Title = dbTodo.Title;
                    todo.Content = dbTodo.Content;
                    todo.Status = dbTodo.Status;
                    todo.UpdateDate = DateTime.Now;
                    repository.Update(todo);
                    if (await unitOfWork.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse(true, "更新数据成功！");
                    }
                    else
                    {
                        return new ApiResponse(true, "更新数据失败！");
                    }
                }
                else
                {
                    return new ApiResponse(false, $"未查询到Id={model.Id}的数据！");
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse(false, ex.Message);
            }
        }
    }
}
