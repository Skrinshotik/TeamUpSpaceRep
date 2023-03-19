using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CAMPUSproject.Models;
using Microsoft.AspNetCore.Identity;
using TeamUpSpace.Models;

namespace CAMPUSproject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MyProjectUser class
public class MyProjectUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [ForeignKey("ProjectModel")]
    public int? ProjectModelId { get; set; }
    public ProjectModel? Project { get; set; }
}