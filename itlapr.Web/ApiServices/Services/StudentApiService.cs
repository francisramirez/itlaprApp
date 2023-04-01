using itlapr.Web.ApiServices.Interfaces;
using itlapr.Web.Models;
using itlapr.Web.Models.Request;
using itlapr.Web.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace itlapr.Web.ApiServices.Services
{
    public class StudentApiService : IStudentApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<StudentApiService> logger;
        private readonly string baseUrl;
        public StudentApiService(IHttpClientFactory  httpClientFactory, 
                                 IConfiguration configuration, 
                                 ILogger<StudentApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];
        }
        public async Task<StudentResponse> GetStudent(int Id)
        {
            StudentResponse studentResponse = new StudentResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Student/" + Id))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            studentResponse = JsonConvert.DeserializeObject<StudentResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //       
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                studentResponse.message = "Error obteniendo los estudiantes";
                studentResponse.success = false;
                this.logger.LogError(studentResponse.message, ex.ToString());
            }

            return studentResponse;
        }
        public async Task<StudentListResponse> GetStudents()
        {
            StudentListResponse studentListResponse = new StudentListResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/Student"))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            studentListResponse = JsonConvert.DeserializeObject<StudentListResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //       
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                studentListResponse.message = "Error obteniendo los estudiantes";
                studentListResponse.success = false;
                this.logger.LogError(studentListResponse.message, ex.ToString());
            }

            return studentListResponse;
        }
        public Task<BaseResponse> Save(StudentCreateRequest studentModel)
        {
            throw new System.NotImplementedException();
        }
        public Task<BaseResponse> Update(StudentUpdateRequest studentModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
