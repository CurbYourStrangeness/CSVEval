using System;

namespace CSVEval.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetTotalYears(this DateTime date)
        {
            var zeroTime = new DateTime(1, 1, 1);
            var span = DateTime.Now - date;

            return (zeroTime + span).Year - 1;
        }
    }
}
