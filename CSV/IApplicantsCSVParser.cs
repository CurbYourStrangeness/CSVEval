using CSVEval.Models;
using System.Collections.Generic;

namespace CSVEval.CSV
{
    public interface IApplicantsCSVParser
    {
        IList<Applicant> ParseApplicants(string filePath);
    }

   
}
