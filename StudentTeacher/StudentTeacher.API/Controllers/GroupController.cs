using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Core.Interfaces;
using StudentTeacher.Core.Models;
using StudentTeacher.Core.DTOs;
using StudentTeacher.API.Filters;
using Group = StudentTeacher.Core.Models.Group;

namespace StudentTeacher.API.Controllers
{
    [Route("groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;
        private readonly IMapper _mapper;
        public GroupController(IGroupService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [LogFilter]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups([FromQuery] string? name = null, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                var groups = await _service.GetGroups(name, skip, take);
                return Ok(_mapper.Map<IEnumerable<GroupDTO>>(groups));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroupById([FromRoute] int id)
        {
            try
            {
                var group = await _service.GetGroupById(id);
                if (group == null)
                    throw new ArgumentException("Such group doesn't exist");
                return Ok(_mapper.Map<GroupDTO>(group));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup([FromRoute] int id)
        {
            try
            {
                await _service.DeleteGroup(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<GroupDTO>> AddGroup([FromBody] CreateGroupDTO createGroupDto)
        {
            try
            {
                var group = await _service.AddGroup(_mapper.Map<Group>(createGroupDto));
                return Created($"groups/{group.Id}", _mapper.Map<GroupDTO>(group));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("add_student/{studentId}/to_group/{groupId}")]
        public async Task<ActionResult> AddStudentToGroup([FromRoute] int groupId, [FromRoute] int studentId)
        {
            try
            {
                await _service.AddStudentToGroup(groupId, studentId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}