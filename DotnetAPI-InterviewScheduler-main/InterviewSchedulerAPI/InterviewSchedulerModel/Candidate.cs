using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewSchedulerAPI.InterviewSchedulerModel
{
    public partial class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Mobileno { get; set; }
        public string Qualification { get; set; }
        public string Email { get; set; }
        public int LevelId { get; set; }
        public int JobId { get; set; }
        public string Resume { get; set; }

        public virtual Job Job { get; set; }
        public virtual InterviewLevel Level { get; set; }
    }
}
