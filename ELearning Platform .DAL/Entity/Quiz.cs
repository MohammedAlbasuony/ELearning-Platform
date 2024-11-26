using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.Entity
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizStatus { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
