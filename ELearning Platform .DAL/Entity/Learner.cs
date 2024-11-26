using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.Entity
{
    public class Learner
    {
        public int LearnerId { get; set; }
        public string LearnerName { get; set; }
        public string AccountId { get; set; } // Foreign key to Identity-based Account
        public Account Account { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
    }
}
