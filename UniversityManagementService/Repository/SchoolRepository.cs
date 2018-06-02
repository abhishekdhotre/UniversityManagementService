using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Contexts;
using UniversityManagementService.Models;

namespace UniversityManagementService.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        UniversityContext _context;

        public SchoolRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<School>> GetAll()
        {
            try
            {
                return await _context
               .Schools
               .Include(d => d.Departments)
               .ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<School> Find(int id)
        {
            try
            {
                return await _context.Schools
                .Where(u => u.Id.Equals(id))
                .Include(s => s.Departments)
                .SingleOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }      
        }

        public async Task Update(int id, School item)
        {
            try
            {
                var itemToUpdate = await _context.Schools.SingleOrDefaultAsync(s => s.Id == id);
                if (itemToUpdate != null)
                {
                    if (itemToUpdate.Departments != null)
                    {
                        //Delete Condition
                        if (itemToUpdate.Departments.Count > item.Departments.Count)
                        {
                            foreach (var department in itemToUpdate.Departments)
                            {
                                if (item.Departments
                                    .Where(s => s.Id == department.Id)
                                    .SingleOrDefault() == null)
                                {
                                    _context.Departments.Remove(department);
                                }
                            }
                        }

                        //Update and Add condition
                        foreach (var department in item.Departments)
                        {
                            var departmentId = itemToUpdate.Departments.Where(d => d.Id == department.Id).SingleOrDefault();
                            if (departmentId != null)
                            {
                                departmentId.Name = department.Name;
                            }
                            else
                            {
                                var newDepartmentItem = new Department()
                                {
                                    Name = department.Name,
                                    SchoolId = id
                                };
                                await _context.Departments.AddAsync(newDepartmentItem);
                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
