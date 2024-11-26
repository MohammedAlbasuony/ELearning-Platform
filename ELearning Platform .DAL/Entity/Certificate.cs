using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.Entity
{
    public class Certificate
    {
        public int CertificateId { get; set; }
        public DateTime CertificateDate { get; set; }
        public int LearnerId { get; set; }
        public Learner Learner { get; set; }
    }
}
