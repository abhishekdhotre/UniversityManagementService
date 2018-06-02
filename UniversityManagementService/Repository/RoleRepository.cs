using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Contexts;
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
                .Include(r => r.Users)
                .ToListAsync();
        }

        public async Task<Role> Find(int id)
        {
            return await _context.Roles
                .Where(r => r.Id.Equals(id))
                .Include(u => u.Users)
                .SingleOrDefaultAsync();
        }

        public async Task Remove(int Id)
        {
            try
            {
                var itemToRemove = await _context.Roles
                    .Include(u => u.Users)
                    .SingleOrDefaultAsync(r => r.Id == Id);

                _context.Roles.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task Update(int id, Role item)
        {
            throw new NotImplementedException();
        }
    }
}
