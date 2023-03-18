using CAMPUSproject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUSproject.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public ICollection<MyProjectUser?>? Users { get; set; }

    }
}
