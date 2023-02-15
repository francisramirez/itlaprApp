using itlapr.DAL.Entities;
using itlapr.DAL.Interfaces;
using itlapr.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace itlapr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public IActionResult Get()
        {
            var deparments = _departmentRepository.GetAll();
            return Ok(deparments);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var deparment = _departmentRepository.Get(id);

            return Ok(deparment);
        }

        // POST api/<DepartmentController>
        [HttpPost("SaveDeparment")]
        public IActionResult Post([FromBody] Department department)
        {
            _departmentRepository.Save(department);
            return Ok();
        }

        // POST api/<DepartmentController>
        [HttpPost("UpdateDepartment")]
        public IActionResult Put([FromBody] Department department)
        {
            _departmentRepository.Update(department);
            return Ok();
        }


        [HttpPost("RemoveDepartment")]
        public IActionResult Remove([FromBody] Department department)
        {
            _departmentRepository.Remove(department);
            return Ok();
        }
    }
}
