using CSVEval.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace CSVEval.CSV
{
    public class ApplicantsCSVParser : IApplicantsCSVParser
    {
        public IList<Applicant> ParseApplicants(string filePath)
        {
            var applicants = new List<Applicant>();

            try
            {
                using (var csvReader = new TextFieldParser(filePath))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    while (!csvReader.EndOfData)
                    {
                        var fieldData = csvReader.ReadFields();
                        var applicant = new Applicant(fieldData);
                        var validationMessage = applicant.IsValidRecord();

                        if (!string.IsNullOrEmpty(validationMessage))
                        {
                            throw new System.ArgumentException(validationMessage);
                        }

                        applicants.Add(applicant);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return applicants;
        }
    }
}
