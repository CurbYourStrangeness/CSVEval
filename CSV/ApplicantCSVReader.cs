using CSVEval.Models;
using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVEval.CSV
{
    public class ApplicantCSVReader
    {
        public IEnumerable<ReadApplicantModel> Read(string filePath)
        {
            string csvText = "Mayrun";

            using (var reader = new StringReader(csvText))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    var records = csv.GetRecords<ReadApplicantModel>();
                    return records;
                }
            }
        }
    }


}
