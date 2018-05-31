using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Contexts;
using UniversityManagementService.Models;

namespace UniversityManagementService.Repository
{
    public class UniversityRepository: IUniversityRepository
    {
        UniversityContext _context;

        public UniversityRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task Add(University item)
        {
            await _context.Universities.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<University>> GetAll()
        {
            //return await _context.Universities.ToListAsync();
            return await _context
                .Universities
                .Include(s => s.Schools)
                .Include("Schools.Departments").ToListAsync();
        }

        public async Task<University> Find(int id)
        {
            return await _context.Universities
                .Where(u => u.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task Remove(int Id)
        {
            var itemToRemove = await _context.Universities.
                SingleOrDefaultAsync(u => u.Id == Id);
            if (itemToRemove != null)
            {
                _context.Universities.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(University item)
        {
            var itemToUpdate = await _context.Universities.SingleOrDefaultAsync(u => u.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Description = item.Description;
                itemToUpdate.ImagePath = item.ImagePath;
                await _context.SaveChangesAsync();
            }
        }
    }
}
