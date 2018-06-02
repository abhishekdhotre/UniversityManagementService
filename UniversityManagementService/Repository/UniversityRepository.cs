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
            return await _context
                .Universities
                .Include(s => s.Schools)
                .Include("Schools.Departments").ToListAsync();
        }

        public async Task<University> Find(int id)
        {
            return await _context.Universities
                .Where(u => u.Id.Equals(id))
                .Include(s => s.Schools)
                .Include("Schools.Departments")
                .SingleOrDefaultAsync();
        }

        public async Task Remove(int Id)
        {
            try
            {
                var itemToRemove = await _context.Universities
                    .Include(s => s.Schools)
                    .Include("Schools.Departments")
                    .SingleOrDefaultAsync(u => u.Id == Id);

                _context.Universities.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task Update(int id, University item)
        {
            try
            {
                var itemToUpdate = await _context.Universities.SingleOrDefaultAsync(u => u.Id == id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Name = item.Name;
                    itemToUpdate.Description = item.Description;
                    itemToUpdate.ImagePath = item.ImagePath;
                    if (itemToUpdate.Schools != null)
                    {
                        //Delete Condition
                        if (itemToUpdate.Schools.Count > item.Schools.Count)
                        {
                            foreach (var school in itemToUpdate.Schools)
                            {
                                if(item.Schools
                                    .Where(s => s.Id == school.Id)
                                    .SingleOrDefault() == null)
                                {
                                    _context.Schools.Remove(school);
                                }
                            }
                        }

                        //Update and Add condition
                        foreach (var school in item.Schools)
                        {
                            var schoolItem = itemToUpdate.Schools.Where(s => s.Id == school.Id).SingleOrDefault();
                            if (schoolItem != null)
                            {
                                schoolItem.Name = school.Name;
                                foreach (var department in school.Departments)
                                {
                                    var departmentItem = school.Departments.Where(d => d.Name == department.Name).Single();
                                    departmentItem.Name = department.Name;
                                }
                            }
                            else
                            {
                                var newSchoolItem = new School()
                                {
                                    Name = school.Name,
                                    UniversityId = id
                                };
                                await _context.Schools.AddAsync(newSchoolItem);
                            }
                        }
                    }
                        
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
