using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Business.client
{
    public interface IMicroserviceRestClient
    {
        public Task<RestResponse> EstablishConnection(string endpoint, Method method, Dictionary<string, string> parameters = null, Dictionary<string, string> urlSegments = null);
        public Task<RestResponse> EstablishConnection<TEntity>(string endpoint, Method method, Dictionary<string, string> parameters = null, Dictionary<string, string> urlSegments = null, TEntity body = null) where TEntity:class;
    }
    public class MicroserviceRestClient : IMicroserviceRestClient
    {
        private readonly IConfiguration _configuration;
        public MicroserviceRestClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RestResponse> EstablishConnection(string endpoint, Method method, Dictionary<string, string> parameters = null, Dictionary<string, string> urlSegments = null)
        {
            var configurationSection = _configuration.GetSection("MicroserviceRestClient");
            var basePath = configurationSection.GetValue<string>("BasePath");
            RestClient restClient = new RestClient();
            var request = new RestRequest(basePath + endpoint, method);
            if (parameters != null)
            {
                foreach (var kvp in parameters)
                {
                    request.AddParameter(kvp.Key, kvp.Value, ParameterType.QueryString);
                }
            }
            if (urlSegments != null)
            {
                foreach (var kvp in urlSegments)
                {
                    request.AddUrlSegment(kvp.Key, kvp.Value);
                }
            }
            var response = await restClient.ExecuteAsync(request);
            return response;
        }
        public async Task<RestResponse> EstablishConnection<TEntity>(string endpoint, Method method, Dictionary<string,string> parameters = null, Dictionary<string,string> urlSegments = null, TEntity body = null) where TEntity : class
        {
            var configurationSection = _configuration.GetSection("MicroserviceRestClient");
            var basePath = configurationSection.GetValue<string>("BasePath");
            RestClient restClient = new RestClient();
            var request = new RestRequest(basePath + endpoint, method);
            if(body!="")
            {
                request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            }
            if(parameters!=null)
            { 
                foreach(var kvp in parameters)
                {
                    request.AddParameter(kvp.Key, kvp.Value, ParameterType.QueryString);
                }
            }
            if (urlSegments != null)
            {
                foreach (var kvp in urlSegments)
                {
                    request.AddUrlSegment(kvp.Key, kvp.Value);
                }
            }
            var response = await restClient.ExecuteAsync(request);
            return response;
        }
    }
}
