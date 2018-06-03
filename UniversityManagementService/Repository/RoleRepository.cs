using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Contexts;
using UniversityManagementService.Dto;
using UniversityManagementService.Models;

namespace UniversityManagementService.Repository
{
    public class RoleRepository: IRoleRepository
    {
        UniversityContext _context;

        public RoleRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task Add(Role item)
        {
            await _context.Roles.AddAsync(item);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context
                .Roles
                .ToListAsync();
        }

        public IEnumerable<UniversityRoleDto> GetMappings()
        {
            var universityRoleDtos = new List<UniversityRoleDto>();
            var innerJoinQuery =
            from universityRole in _context.UniversityRoles
            join university in _context.Universities
            on universityRole.UniversityId equals university.Id
            join role in _context.Roles
            on universityRole.RoleId equals role.Id
            select new { UniversityName = university.Name, RoleName = role.Name };
            foreach (var ln in innerJoinQuery)
            {
                UniversityRoleDto universityRoleDto = new UniversityRoleDto();
                universityRoleDto.UniversityName = ln.UniversityName;
                universityRoleDto.RoleName = ln.RoleName;
                universityRoleDtos.Add(universityRoleDto);
            }
            return universityRoleDtos.AsEnumerable();
        }

        public async Task<Role> Find(int id)
        {
            return await _context.Roles
                .Where(r => r.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task<UniversityRole> Find(int universityId, int roleId)
        {
            return await _context.UniversityRoles
                .Where(u => u.UniversityId.Equals(universityId))
                .Where(r => r.RoleId.Equals(roleId))
                .SingleOrDefaultAsync();
        }

        public async Task Remove(int Id)
        {
            try
            {
                var itemToRemove = await _context.Roles
                    .SingleOrDefaultAsync(r => r.Id == Id);

                _context.Roles.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Update(int id, Role item)
        {
            var itemToUpdate = await _context.Roles.SingleOrDefaultAsync(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddMapping(UniversityRole item)
        {
            await _context.UniversityRoles.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int universityId, int roleId)
        {
            try
            {
                var itemToRemove = await _context.UniversityRoles
                .Where(u => u.UniversityId.Equals(universityId))
                .Where(r => r.RoleId.Equals(roleId))
                .SingleOrDefaultAsync();

                _context.UniversityRoles.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
