using Newtonsoft.Json;
using RestSharp;
using SolutionSphere.Business.client;
using SolutionSphere.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Business.Services
{
    public interface IProjectsService
    {
        public Task<List<Project>> GetAll();
    }
    public class ProjectsService : IProjectsService
    {
        private readonly IMicroserviceRestClient _restClient;
        public ProjectsService(IMicroserviceRestClient restClient) {
            _restClient = restClient;
        }

        public async Task<List<Project>> GetAll()
        {
            var response = await _restClient.EstablishConnection("api/Project/Get", Method.Get);
            return JsonConvert.DeserializeObject<List<Project>>(response.Content);
        }
    }
}
