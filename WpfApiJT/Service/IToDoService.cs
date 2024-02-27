using ApIShared.Parameters;
using Shared.Dtos;
using WpfApi.Models;

namespace WpfApi.Service
{
    public interface IToDoService : IBaseService<TodoDto>
    {
        Task<ApiResponse> GetPageListAllAsync(QueryParameter parameter);

        //public interface IToDoService : IBaseService<ToDo>
        // 这里一开始传入的直接就是我们的数据库实体类
        //但是现在传入的这个TodoDto,是给数据库实体类ToDo进行一层封装的名称
        //意思就是本来是直接传入数据库实体类的，但是一般来说这样不好，我们先给数据库实体类封装一层之后 引入封装的那层

       

    }
}
