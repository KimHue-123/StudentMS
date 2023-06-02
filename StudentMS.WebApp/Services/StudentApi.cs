using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StudentMS.ViewModel.Catalog.Students;
using StudentMS.ViewModel.Common;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentMS.WebApp.Services
{
    public class StudentApi : IStudentApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public StudentApi(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<int> CreateStudent(StudentRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var jsonContent = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Student",httpContent);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(result);
        }

        public async Task<int> DeleteStudent(int studentId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.DeleteAsync($"Student/{studentId}/Delete");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(result);
        }

        public async Task<int> EditStudent(int studentId, StudentRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var jsonContent = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"Student/{studentId}/Edit", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(result);
        }

        public async Task<StudentVM> GetStudentById(int studentId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"Student/{studentId}");
            var student = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StudentVM>(student);
        }

        public async Task<PageResultBase<StudentVM>> GetStudentPaging(PagingRequestBase request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"Student?KeyWord={request.KeyWord}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PageResultBase<StudentVM>>(body);
        }
    }
}
