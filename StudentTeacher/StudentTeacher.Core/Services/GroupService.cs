using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Interfaces;
using StudentTeacher.Core.Models;

namespace StudentTeacher.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IRepository _repository;
        public GroupService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Group> AddGroup(Group group, CancellationToken cancellationToken = default)
        {
            if (group == null)
                throw new ArgumentException("Group must not be null");

            await _repository.AddAsync(group);
            await _repository.SaveChangesAsync();
            return group;
        }
        public async Task AddStudentToGroup(int groupId, int studentId, CancellationToken cancellationToken = default)
        {
            var student = await _repository.GetAll<Student>()
                .FirstOrDefaultAsync(student => student.Id == studentId);
            if (student == null)
                throw new NullReferenceException("Such student doesn't exist");

            var group = await _repository.GetAll<Group>()
                .FirstOrDefaultAsync(group => group.Id == groupId);
            if (group == null)
                throw new NullReferenceException("Such group doesn't exist");

            student.Group = group;
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteGroup(int id, CancellationToken cancellationToken = default)
        {
            var group = await _repository.GetAll<Group>()
                .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            if (group == null)
                throw new ArgumentException("Such group doesn't exist");

            _repository.Delete(group);
            await _repository.SaveChangesAsync();
        }
        public async Task<Group?> GetGroupById(int id, CancellationToken cancellationToken = default)
        {
            var group = await _repository.GetAll<Group>()
                .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            return group;
        }
        public async Task<IEnumerable<Group>> GetGroups(string? name, int skip, int take, CancellationToken cancellationToken = default)
        {
            var groupsQuery = _repository.GetAll<Group>().AsNoTracking();

            if (!string.IsNullOrEmpty(name))
            {
                groupsQuery = groupsQuery.Where(g => g.Name.Contains(name));
            }

            return await groupsQuery.OrderBy(g => g.Name)
               .Skip(skip)
               .Take(take)
               .ToArrayAsync(cancellationToken);
        }
    }
}
