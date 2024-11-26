using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.Entity
{
    public class Support
    {
        public int SupportId { get; set; }
        public string SupportCategory { get; set; }
        public string SupportStatus { get; set; }
        public string AccountId { get; set; } // Foreign key to Identity-based Account
        public Account Account { get; set; }
    }
}
