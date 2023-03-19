using CAMPUSproject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUpSpace.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        [Required]
        public string? ProjectName { get; set; }
        [Required]
        public string? ShortDescription { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Category { get; set; }
        [ForeignKey("MyProjectUser")]
        public string? UserId { get; set; }
        public ICollection<MyProjectUser>? Users { get; set; } = new List<MyProjectUser>();

    }
}
