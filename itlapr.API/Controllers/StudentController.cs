using itlapr.BLL.Contract;
using itlapr.BLL.Dtos.Student;
using itlapr.DAL.Interfaces;
using itlapr.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace itlapr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.studentService.GetAll();

            if (result.Success)
                return Ok(result);
            else 
                return BadRequest(result);

            
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.studentService.GetById(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<StudentController>
        [HttpPost("SaveStudent")]
        public IActionResult Post([FromBody] StudentSaveDto studentSaveDto)
        {
            var result = this.studentService.SaveStudent(studentSaveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<StudentController>
        [HttpPost("UpdateStudent")]
        public IActionResult Put([FromBody] StudentUpdateDto studentUpdateDto)
        {
            var result = this.studentService.UpdateStudent(studentUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);  
        }
        // POST api/<StudentController>
        [HttpPost("RemoveStudent")]
        public IActionResult Remove([FromBody] StudentRemoveDto studentRemoveDto)
        {
            var result = this.studentService.RemoveStudent(studentRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
