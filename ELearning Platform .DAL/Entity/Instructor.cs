using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.Entity
{
    public class Instructor : IdentityUser
    {
        public string InstructorName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

}
