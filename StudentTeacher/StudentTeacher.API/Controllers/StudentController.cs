using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Core.Interfaces;
using StudentTeacher.Core.Models;
using StudentTeacher.Core.DTOs;
namespace StudentTeacher.API.Controllers
{
    [Route("students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;
        public StudentController(IStudentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> AddStudent(CreateStudentDTO createStudentDto)
        {
            var student = await _service.AddStudent(createStudentDto);
            return Created($"students/{student.Id}", _mapper.Map<StudentDTO>(student));
        }
    }
}