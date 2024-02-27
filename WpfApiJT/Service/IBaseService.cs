namespace WpfApi.Service
{
    public interface IBaseService<T>
    {
        //这个就是CURD的基础功能返回值
        Task<ApiResponse> GetAllAsync();
        Task<ApiResponse> GetSingleAsync(int id);
        Task<ApiResponse> AddEntityAsync(T model);
        Task<ApiResponse> UpdateEntityAsync(T model);
        Task<ApiResponse> DeleteEntityAsync(int id);

    }
}
