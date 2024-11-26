using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.Entity
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Learner> Learners { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
