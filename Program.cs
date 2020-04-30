using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enrollment;

namespace CSVEval
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string csv_file_path = @"C:/Users/Owner/Desktop/Job Applications/Sample Projects/CSVs/feed.csv";

            DataTable csvData = GetDataTabletFromCSVFile(csv_file_path);

            Console.WriteLine("Rows count:" + csvData.Rows.Count);

            Console.ReadLine();
           
        }

            private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
            {
                DataTable csvData = new DataTable();

                try
                {

                    using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }

                        while (!csvReader.EndOfData)
                        {
                        DateTime ofAge = ;
                            string[] fieldData = csvReader.ReadFields();
                            //Making empty value as null
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                                //if date of birth is less than 18, cancel processing
                                if(fieldData[2] )
                            {

                            }
                            }

                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
                catch (Exception ex)
                {
                Console.WriteLine(ex);
                }
                return csvData;
            }
    }
}
