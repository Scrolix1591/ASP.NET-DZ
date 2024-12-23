using AutoMapper;
using StudentTeacher.Core.Models;
using StudentTeacher.Core.DTOs;

namespace StudentTeacher.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Group, CreateGroupDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
