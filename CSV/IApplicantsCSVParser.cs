using CSVEval.Models;
using System.Collections.Generic;

namespace CSVEval.CSV
{
    public interface IApplicantsCSVParser
    {
        IList<Applicant> ParseApplicants(string filePath);
    }

    //public interface ICsvParser<T> where T:class
    //{
    //    IEnumerable<T> Parse(string filePath)
    //}
}
