using CSVEval.Extensions;
using System;
using System.Linq;

namespace CSVEval.Models
{
    public class Applicant
    {
        private static class Constants
        {
            public static int EffectiveDaysLimit => 30;
            public static int AgeLimit => 18;

            public static string[] ValidPlanTypes => new string[] { "HSA", "HRA", "FSA" };

            public static string FailureMessage => "A record in the file failed validation. Processing has stopped.";
        }

        private static class ApplicantStatus
        {
            public static String Accepted => "Accepted";
            public static String Rejected => "Rejected";
        }


        /// <summary>
        /// GetValidationStatus
        /// </summary>
        /// <returns></returns>
        private string GetValidationStatus()
        {
            var additionalRulesValid = true;

            if (this.EffectiveDate > DateTime.Now.AddDays(Constants.EffectiveDaysLimit))
            {
                additionalRulesValid = false;
            }
            else if (this.DOB.GetTotalYears() < Constants.AgeLimit)
            {
                additionalRulesValid = false;
            }

            return additionalRulesValid ? ApplicantStatus.Accepted : ApplicantStatus.Rejected;
        }

        public string Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string PlanType { get; set; }

        public DateTime EffectiveDate { get; set; }

        public Applicant()
        {
        }

        public Applicant(string[] fieldData)
        {
            this.FirstName = fieldData.ReadArrayField(0);
            this.LastName = fieldData.ReadArrayField(1);
            this.DOB = fieldData.ReadArrayField(2).ToDateTime();
            this.PlanType = fieldData.ReadArrayField(3)?.ToUpperInvariant();
            this.EffectiveDate = fieldData.ReadArrayField(4).ToDateTime();
        }

        public string IsValidRecord()
        {
            var result = string.Empty;
            var isValid = true;

            if (string.IsNullOrEmpty(this.FirstName) ||
                string.IsNullOrEmpty(this.LastName) ||
                string.IsNullOrEmpty(this.PlanType) ||
                this.EffectiveDate == DateTime.MinValue ||
                this.DOB == DateTime.MinValue)
            {
                isValid = false;
            }
            else if (!Constants.ValidPlanTypes.Any(x => x.Equals(this.PlanType, StringComparison.OrdinalIgnoreCase)))
            {
                isValid = false;
            }

            if (isValid)
            {
                this.Status = this.GetValidationStatus();
            }
            else
            {
                result = Constants.FailureMessage;
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", this.Status, this.FirstName, this.LastName, this.DOB.ToShortDateString(), this.PlanType, this.EffectiveDate.ToShortDateString());
        }
    }
}
