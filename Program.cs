using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CSVEval.CSV;
using CSVEval.Models;

namespace CSVEval
{
    public class Program
    {
        private static IApplicantsCSVParser CSVParser => new ApplicantsCSVParser();
        
        static void Main(string[] args)
        {
            var csvFilePath = GetFilePath(args);
            ParseApplicantsCSV(csvFilePath);
        }

        private static void PrintApplicants(IList<Applicant> applicants)
        {
            foreach (var a in applicants)
            {
                Console.WriteLine(a.ToString());
            }
        }

        private static void ParseApplicantsCSV(string csvFilePath)
        {
            var mapper = new ApplicantToEnrollmentMapper();

            var errorMessage = string.Empty;

            if (!string.IsNullOrEmpty(csvFilePath))
            {
                try
                {
                    //var reader = new ApplicantCSVReader();
                    //var records = reader.Read(csvFilePath);
                    var applicants = CSVParser.ParseApplicants(csvFilePath);
                    //var enrollments = mapper.Map(applicants);
                    //var jsonEnrollments = Newtonsoft.Json.JsonConvert.SerializeObject(enrollments);
                    PrintApplicants(applicants);
                }
                catch (Exception exp)
                {
                    errorMessage = exp.Message;
                }
            }
            else
            {
                errorMessage = "Feed CSV not found. Please use a valid CSV file.";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine(errorMessage);
            }

            Console.ReadLine();
        }

        private static string GetFilePath(string[] args)
        {
            string csvFilePath = string.Empty;

            if (args.Length > 0)
            {
                csvFilePath = args[0];
            }

            if (!File.Exists(csvFilePath))
            {
                csvFilePath = Assembly.GetEntryAssembly().Location + csvFilePath;
            }

            if (!File.Exists(csvFilePath))
            {
                csvFilePath = string.Empty;
            }

            return csvFilePath;
        }
    }
}
