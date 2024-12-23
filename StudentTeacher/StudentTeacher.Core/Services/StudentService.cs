using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Interfaces;
using StudentTeacher.Core.Models;

namespace StudentTeacher.Core.Services
{
    public class StudentService : IStudentService
    {
        private const int MinStudentAgeintears = 4;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<ICollection<StudentDTO>> GetStudents(int skip, int take, CancellationToken cancellationToken = default)
        {
            var studentsQuery = _repository.GetAll<Student>().AsNoTracking();

            var groups = await studentsQuery.OrderBy(s => s.LastName)
                .Skip(skip)
                .Take(take)
                .ToArrayAsync(cancellationToken);

            return _mapper.Map<ICollection<StudentDTO>>(groups);
        }

        public async Task<StudentDTO?> GetStudentById(int id, CancellationToken cancellationToken = default)
        {
            var group = await _repository.GetAll<Student>()
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);

            return _mapper.Map<StudentDTO>(group);
        }

        public async Task<StudentDTO> AddStudent(CreateStudentDTO newStudent, CancellationToken cancellationToken = default)
        {
            var student = _mapper.Map<Student>(newStudent);
            ValidateStudent(student);

            // Add student to the repository
            await _repository.AddAsync(student);
            await _repository.SaveChangesAsync();

            return _mapper.Map<StudentDTO>(student);
        }

        private void ValidateStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.FirstName))
            {
                throw new ArgumentException("FirstName must have value", nameof(student.FirstName));
            }
            if (string.IsNullOrEmpty(student.LastName))
            {
                throw new ArgumentException("LastName must have value", nameof(student.LastName));
            }
            if (student.DateOfBirth >= DateTime.Now.AddYears(-MinStudentAgeintears))
            {
                throw new ArgumentException("Date of birth must be greater than 14 years ago", nameof(student.DateOfBirth));
            }
        }

        public async Task<StudentDTO> UpdateStudent(int id, UpdateStudentDTO student, CancellationToken cancellationToken = default)
        {
            var existingStudent = await _repository.GetAll<Student>()
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            if (existingStudent == null)
            {
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }

            _mapper.Map(student, existingStudent);
            await _repository.SaveChangesAsync();

            return _mapper.Map<StudentDTO>(existingStudent);
        }

        public async Task<StudentDTO> DeleteStudent(int id, CancellationToken cancellationToken = default)
        {
            var student = await _repository.GetAll<Student>()
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }

            _repository.Delete(student);
            await _repository.SaveChangesAsync();

            return _mapper.Map<StudentDTO>(student);
        }

    }
}
