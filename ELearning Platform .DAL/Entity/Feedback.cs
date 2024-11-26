using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.Entity
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string FeedbackText { get; set; }
        public int LearnerId { get; set; }
        public Learner Learner { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
