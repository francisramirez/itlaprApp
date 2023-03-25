using itlapr.Web.Models.Request;
using itlapr.Web.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace itlapr.Web.Controllers
{
    public class StudentController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<StudentController> logger;
        private readonly IConfiguration configuration;

        public StudentController(ILogger<StudentController> logger,
                                 IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            StudentListResponse studentListResponse = new StudentListResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var response = await httpClient.GetAsync("http://localhost:51810/api/Student");

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

                return View(studentListResponse.data);

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los estudiantes", ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> Details(int id)
        {

            StudentResponse studentResponse = new StudentResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                var response = await httpClient.GetAsync($"http://localhost:51810/api/Student/" + id);

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

            return View(studentResponse.data);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentCreateRequest studentCreate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                studentCreate.creationDate = DateTime.Now;
                studentCreate.creationUser = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(studentCreate), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:51810/api/Student/SaveStudent", content);

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = baseResponse.Message;
                        return View();
                    }

                }


            }
            catch
            {
                return View();
            }
        }

        // GET: StudnetController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            StudentResponse studentResponse = new StudentResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                var response = await httpClient.GetAsync($"http://localhost:51810/api/Student/" + id);

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
            return View(studentResponse.data);
            
        }

        // POST: StudnetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentUpdateRequest studentUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                studentUpdate.modifyDate = DateTime.Now;
                studentUpdate.modifyUser = 1;
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(studentUpdate), Encoding.UTF8, "application/json");

                   var response = await httpClient.PostAsync("http://localhost:51810/api/Student/UpdateStudent", content);
                   
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = baseResponse.Message;
                        return View();
                    }

                }

               
            }
            catch
            {
                return View();
            }
        }


    }
}
