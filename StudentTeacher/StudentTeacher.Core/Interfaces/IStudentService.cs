using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Models;

namespace StudentTeacher.Core.Interfaces
{
    public interface IStudentService
    {
        Task<ICollection<StudentDTO>> GetStudents(int skip, int take, CancellationToken cancellationToken = default);
        Task<StudentDTO?> GetStudentById(int id, CancellationToken cancellationToken = default);
        Task<StudentDTO> AddStudent(CreateStudentDTO newStudent, CancellationToken cancellationToken = default);
        Task<StudentDTO> UpdateStudent(int id, UpdateStudentDTO student, CancellationToken cancellationToken = default);
        Task<StudentDTO> DeleteStudent(int id, CancellationToken cancellationToken = default);
    }
}
