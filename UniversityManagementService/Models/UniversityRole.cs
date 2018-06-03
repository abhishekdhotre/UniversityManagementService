using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementService.Models
{
    public class UniversityRole
    {

        [Required]
        [Key]
        public int UniversityId { get; set; }

        [Required]
        [Key]
        public int RoleId { get; set; }
    }
}
