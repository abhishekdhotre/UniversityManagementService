using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementService.Models
{
    public class RoleUser
    {
        [Required]
        [Key]
        public int RoleId { get; set; }

        [Required]
        [Key]
        public int UserId { get; set; }
    }
}
