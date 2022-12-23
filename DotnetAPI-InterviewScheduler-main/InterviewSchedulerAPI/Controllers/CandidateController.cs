using InterviewSchedulerAPI.DataLayer;
using InterviewSchedulerAPI.InterviewSchedulerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSchedulerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateDataLayer db = new CandidateDataLayer();


        [HttpGet("GetAllCandidates")]

        public List<Candidate> GetAllCandidates()
        {
            return db.GetAllCandidates();
        }

        [HttpPost("AddCandidate")]

        public int AddCandidate(Candidate a)
        {

            return db.AddCandidate(a);
        }


        [HttpPut("UpdateCandidate")]

        public int UpdateCandidate(int id, Candidate c)
        {
            return db.UpdateCandidate(id, c);
        }


        [HttpDelete("DeleteCandidate")]

        public int DeleteCandidate(int id)
        {
            return db.DeleteCandidate(id);
        }

        [HttpGet("GetCandidateById/{id}")]

        public Candidate GetCandidateById(int id)
        {
            return db.GetCandidateById(id);
        }

    }
}
