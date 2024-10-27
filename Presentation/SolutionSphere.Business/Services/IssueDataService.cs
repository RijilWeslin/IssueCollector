using Newtonsoft.Json;
using RestSharp;
using SolutionSphere.Business.client;
using SolutionSphere.Core.Entities;

namespace SolutionSphere.Business.Services
{
    public interface IIssueDataService
    {
        public Task<Pagination<IssueData>> GetAll(int page = 1, int pageSize = 8);
        public Task<Pagination<IssueData>> GetAllUnDeleted(int page = 1, int pageSize = 8);
        public Task Add(IssueData issue);
        public Task Delete(int issueId);
    }
    public class IssueDataService : IIssueDataService
    {
        private readonly IMicroserviceRestClient _restClient;
        public IssueDataService(IMicroserviceRestClient restClient) 
        {
            _restClient = restClient;
        }

        public async Task<Pagination<IssueData>> GetAll(int page = 1, int pageSize = 8)
        {
            var urlSegment = new Dictionary<string, string>()
            {
                { "page", page.ToString()},
                {"pageSize", pageSize.ToString()}
            };
            var response = await _restClient.EstablishConnection("api/IssueData/GetAll/{page}/{pageSize}", Method.Get, urlSegments:urlSegment);            
            return JsonConvert.DeserializeObject<Pagination<IssueData>>(response.Content);
        }

        public async Task<Pagination<IssueData>> GetAllUnDeleted(int page = 1, int pageSize = 8)
        {
            var urlSegment = new Dictionary<string, string>()
            {
                { "page", page.ToString()},
                {"pageSize", pageSize.ToString()}
            };
            var response = await _restClient.EstablishConnection("api/IssueData/GetAllUnDeleted/{page}/{pageSize}", Method.Get, urlSegments: urlSegment);         
            return JsonConvert.DeserializeObject<Pagination<IssueData>>(response.Content);
        }

        public async Task Add(IssueData issue)
        {           
            var response = await _restClient.EstablishConnection<IssueData>("api/IssueData/Add", Method.Post, body:issue);
        }

        public async Task Delete(int issueId)
        {
            var urlSegment = new Dictionary<string, string>()
            {
                { "issueId",issueId.ToString()}
            };
            await _restClient.EstablishConnection<IssueData>("api/IssueData/SoftDelete/{issueId}", Method.Get, urlSegments: urlSegment);
        }
    }
}
