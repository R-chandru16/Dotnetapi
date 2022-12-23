using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewSchedulerAPI.InterviewSchedulerModel
{
    public partial class InterviewLevel
    {
        public InterviewLevel()
        {
            Candidates = new HashSet<Candidate>();
        }

        public int Id { get; set; }
        public string Level { get; set; }
        public string LevelDes { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
