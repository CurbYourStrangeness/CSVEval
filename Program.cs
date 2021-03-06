﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSVEval.CSV;
using CSVEval.Models;

namespace CSVEval
{
    public class Program
    {
        private static IApplicantsCSVParser CSVParser => new ApplicantsCSVParser();

        private static List<Applicant> StatusStorage = new List<Applicant>();
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

            var errorMessage = string.Empty;

            if (!string.IsNullOrEmpty(csvFilePath))
            {
                try
                {
                   
                    var applicants = CSVParser.ParseApplicants(csvFilePath);
                    PrintApplicants(applicants);
                    StatusStorage.AddRange(applicants);
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
