using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Dto;
using UniversityManagementService.Models;

namespace UniversityManagementService.Repository
{
    public interface IUserRepository
    {
        Task Add(User item);
        Task<IEnumerable<User>> GetAll();
        Task<User> Find(int key);
        Task Remove(int Id);
        Task Update(int id, User item);
        Task AddMapping(RoleUser item);
        Task<RoleUser> Find(int roleId, int userId);
        IEnumerable<RoleUserDto> GetMappings();
    }
}
