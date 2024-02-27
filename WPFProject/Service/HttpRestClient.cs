using Newtonsoft.Json;
using RestSharp;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Service
{
    public class HttpRestClient
    {
        public readonly string apiUrl;
        protected readonly RestClient client;

        public HttpRestClient(string apiUrl)
        {
            this.apiUrl = apiUrl;
            client = new RestClient();
        }

        public async Task<WebApiResponse> ExecuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContenType.ToString());

            if (baseRequest.Parameter != null)
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            client.BaseUrl = new Uri(apiUrl + baseRequest.Route);
            var response = await client.ExecuteAsync(request);

            JsonSerializerSettings jsSetting = new JsonSerializerSettings();
            jsSetting.NullValueHandling = NullValueHandling.Ignore;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<WebApiResponse>(response.Content, jsSetting);

            else
                return new WebApiResponse()
                {
                    Status = false,
                    Result = null,
                    Message = response.ErrorMessage
                };

        }

        public async Task<WebApiResponse<T>> ExecuteAsync<T>(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContenType);
            if (baseRequest.Parameter != null)
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            client.BaseUrl = new Uri(apiUrl + baseRequest.Route);
            var response = await client.ExecuteAsync(request);

            JsonSerializerSettings jsSetting = new JsonSerializerSettings();
            jsSetting.NullValueHandling = NullValueHandling.Ignore;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<WebApiResponse<T>>(response.Content, jsSetting);

            else
                return new WebApiResponse<T>()
                {
                    Status = false,
                    Message = response.ErrorMessage
                };
        }
    }
}
