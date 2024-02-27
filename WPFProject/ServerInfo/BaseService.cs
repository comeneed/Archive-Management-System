using ApIShared.Parameters;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProject.Service;

namespace WPFProject.ServerInfo
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly HttpRestClient client;
        private readonly string serviceName;

        public BaseService(HttpRestClient client, string serviceName)
        {
            this.client = client;
            this.serviceName = serviceName;
        }

        public async Task<WebApiResponse<TEntity>> AddAsync(TEntity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.POST;
            request.Route = $"api/{serviceName}/Add";
            request.Parameter = JsonConvert.SerializeObject(entity);
            return await client.ExecuteAsync<TEntity>(request);
        }

        public async Task<WebApiResponse> DeleteAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.DELETE;
            request.Route = $"api/{serviceName}/Delete?Id={id}";
            return await client.ExecuteAsync(request);
        }

        public async Task<WebApiResponse<List<TEntity>>> GetAllAsync()
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.GET;
            request.Route = $"api/{serviceName}/GetAllToDo";
            return await client.ExecuteAsync<List<TEntity>>(request);
        }

        public async Task<WebApiResponse<PagedList<TEntity>>> GetAllPageListAsync(QueryParameter parameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.GET;
            request.Route = $"api/{serviceName}/GetAllPageListToDo?pageIndex={parameter.PageIndex}" + $"&pageSize={parameter.PageSize}" + $"&search={parameter.Search}";
            return await client.ExecuteAsync<PagedList<TEntity>>(request);
        }

        public async Task<WebApiResponse<TEntity>> GetFirstOfDefaultAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.GET;
            request.Route = $"api/{serviceName}/Get?Id={id}";
            return await client.ExecuteAsync<TEntity>(request);
        }

        public async Task<WebApiResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.POST;
            request.Route = $"api/{serviceName}/Update";
            request.Parameter = JsonConvert.SerializeObject(entity); 
            return await client.ExecuteAsync<TEntity>(request);
        }



    }
       
}
