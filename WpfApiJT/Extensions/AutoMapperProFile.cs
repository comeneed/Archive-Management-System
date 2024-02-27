using AutoMapper;
using Shared.Dtos;
using WpfApi.Models;

namespace WpfApiJT.Extensions
{
    public class AutoMapperProFile : Profile
    {
        public AutoMapperProFile()
        {
            CreateMap<ToDo, TodoDto>().ReverseMap();
            CreateMap<Memo, MemoDto>().ReverseMap();
        }
    }
}
