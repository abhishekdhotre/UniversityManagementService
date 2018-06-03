using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Dto;
using UniversityManagementService.Models;

namespace UniversityManagementService.Repository
{
    public interface IRoleRepository
    {
        Task Add(Role item);
        Task<IEnumerable<Role>> GetAll();
        Task<Role> Find(int key);
        Task Remove(int Id);
        Task Update(int id, Role item);
        Task AddMapping(UniversityRole item);
        Task<UniversityRole> Find(int universityId, int roleId);
        Task Remove(int universityId, int roleId);
        IEnumerable<UniversityRoleDto> GetMappings();
    }
}
