using ApIShared.Parameters;
using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using WpfApi.Models;
using WpfApi.Service;

namespace WpfApiJT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
     public class ToDoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IToDoService toDoService;

        public ToDoController(IUnitOfWork unitOfWork, IToDoService toDoService)
        {
            this.unitOfWork = unitOfWork;
            this.toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ApiResponse> GetAllPageList([FromQuery] QueryParameter parameter)
        {
            return await toDoService.GetPageListAllAsync(parameter);
        }


        [HttpGet]
        public async Task<ApiResponse> Get(int Id)
        {
            return await toDoService.GetSingleAsync(Id);

        }
        [HttpGet]
        public async Task<ApiResponse> GetAllToDo()
        {
            return await toDoService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ApiResponse> AddToDo([FromBody] TodoDto toDo)
        {
            return await toDoService.AddEntityAsync(toDo);
        }

        [HttpDelete]
        public async Task<ApiResponse> DeleteToDo(int id)
        {
            return await toDoService.DeleteEntityAsync(id);
        }

        [HttpPost]
        public async Task<ApiResponse> UpdateToDo(TodoDto toDo)
        {
            return await toDoService.UpdateEntityAsync(toDo);
        }
    }
}
