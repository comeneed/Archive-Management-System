using ApIShared.Parameters;
using Shared.Dtos;
using WpfApi.Service;

namespace WpfApiJT.Service
{
    public interface IMemoService : IBaseService<MemoDto>
    {
        Task<ApiResponse> GetPageListAllAsync(QueryParameter parameter);

        
    }
}
