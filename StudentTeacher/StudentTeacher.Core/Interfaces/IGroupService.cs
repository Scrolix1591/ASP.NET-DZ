using StudentTeacher.Core.Models;

namespace StudentTeacher.Core.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups(string? name, int skip, int take, CancellationToken cancellationToken = default);
        Task<Group?> GetGroupById(int id, CancellationToken cancellationToken = default);
        Task<Group> AddGroup(Group group, CancellationToken cancellationToken = default);
        Task DeleteGroup(int id, CancellationToken cancellationToken = default);
        Task AddStudentToGroup(int groupId, int studentId, CancellationToken cancellationToken = default);
    }
}
