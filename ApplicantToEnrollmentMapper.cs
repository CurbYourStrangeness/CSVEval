using CSVEval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVEval
{
    public class ApplicantToEnrollmentMapper : IApplicantToEnrollmentMapper
    {
        public IList<Enrollment> Map(IList<Applicant> applicants)
        {
            var result = new List<Enrollment>();
            foreach (var applicant in applicants)
            {
                result.Add(new Enrollment() { FirstName = applicant.FirstName });
            }
            return result;
        }
    }

    public interface IApplicantToEnrollmentMapper
    {
        IList<Enrollment> Map(IList<Applicant> applicants);

    }
}
