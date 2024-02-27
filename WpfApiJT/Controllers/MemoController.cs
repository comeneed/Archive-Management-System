using ApIShared.Parameters;
using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using WpfApi.Service;
using WpfApiJT.Service;

namespace WpfApiJT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //public class MemoController : ControllerBase

    public class MemoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoService memoService;

        public MemoController(IMemoService memoService, IUnitOfWork unitOfWork)
        {
            this.memoService = memoService;
            _unitOfWork = unitOfWork;
        }




        [HttpGet]
        public async Task<ApiResponse> GetAllPageList([FromQuery] QueryParameter parameter)
        {
            return await memoService.GetPageListAllAsync(parameter);
        }

        [HttpGet]
        public async Task<ApiResponse> GetMemoById(int Id)
        {
            return await memoService.GetSingleAsync(Id);
        }
        [HttpPost]
        public async Task<ApiResponse> AddMemo([FromBody] MemoDto memoDto)
        {
            return await memoService.AddEntityAsync(memoDto);
        }
        [HttpDelete]
        public async Task<ApiResponse> DeleteMemo(int Id)
        {
            return await memoService.DeleteEntityAsync(Id);
        }
        [HttpGet]
        public async Task<ApiResponse> GetAllMemo()
        {
            return await memoService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ApiResponse> UpdateMemo(MemoDto memoDto)
        {
            return await memoService.UpdateEntityAsync(memoDto);
        }
    }
}
