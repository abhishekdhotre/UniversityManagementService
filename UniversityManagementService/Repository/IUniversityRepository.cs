using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Models;

namespace UniversityManagementService.Repository
{
    public interface IUniversityRepository
    {
        Task Add(University item);
        Task<IEnumerable<University>> GetAll();
        Task<University> Find(int key);
        Task Remove(int Id);
        Task Update(University item);
    }
}
