using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.Entity
{
    public class Account : IdentityUser
    {
        public string AccountType { get; set; } // Custom property
        public ICollection<Support> Supports { get; set; }
        public ICollection<Learner> Learners { get; set; }
    }
}
