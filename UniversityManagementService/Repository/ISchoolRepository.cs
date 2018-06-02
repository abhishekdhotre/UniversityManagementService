using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Models;

namespace UniversityManagementService.Repository
{
    public interface ISchoolRepository
    {
        Task<School> Find(int key);
        Task Update(int id, School item);
        Task<IEnumerable<School>> GetAll();
    }
}
