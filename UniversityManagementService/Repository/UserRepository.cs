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
    public class UserRepository: IUserRepository
    {
        UniversityContext _context;

        public UserRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task Add(User item)
        {
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context
                .Users
                .ToListAsync();
        }

        public IEnumerable<RoleUserDto> GetMappings()
        {
            var roleUsersDtos = new List<RoleUserDto>();
            var innerJoinQuery =
            from roleUser in _context.RoleUsers
            join roles in _context.Roles
            on roleUser.RoleId equals roles.Id
            join users in _context.Roles
            on roleUser.UserId equals users.Id
            select new { RoleName = roles.Name, UserName = users.Name };
            foreach (var ln in innerJoinQuery)
            {
                RoleUserDto roleUsersDto = new RoleUserDto();
                roleUsersDto.RoleName = ln.RoleName;
                roleUsersDto.UserName = ln.UserName;
                roleUsersDtos.Add(roleUsersDto);
            }
            return roleUsersDtos.AsEnumerable();
        }

        public async Task<User> Find(int id)
        {
            return await _context.Users
                .Where(r => r.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task<RoleUser> Find(int roleId, int userId)
        {
            return await _context.RoleUsers
                .Where(r => r.RoleId.Equals(roleId))
                .Where(u => u.UserId.Equals(userId))
                .SingleOrDefaultAsync();
        }

        public async Task Remove(int Id)
        {
            try
            {
                var itemToRemove = await _context.Users
                    .SingleOrDefaultAsync(u => u.Id == Id);

                _context.Users.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Update(int id, User item)
        {
            var itemToUpdate = await _context
                .Users
                .SingleOrDefaultAsync(u => u.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddMapping(RoleUser item)
        {
            await _context.RoleUsers.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}
