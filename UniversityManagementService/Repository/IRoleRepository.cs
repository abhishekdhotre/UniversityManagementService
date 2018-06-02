﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}