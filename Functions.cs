using Amazon.Lambda.Core;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HelloLambdaAnnotations
{
    /// <summary>
    /// Sample Lambda functions that perform date functions.
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Functions()
        {
        }

        /// <summary>
        /// Compute the difference in days between two dates, from and to.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>number of days between from and to.</returns>
        [LambdaFunction()]
        [HttpApi(LambdaHttpMethod.Get, "/datediff/{from}/{to}")]
        public int DateDifferenceInDays(string from, string to)
        {
            int days = Convert.ToInt16((DateTime.Parse(to) - DateTime.Parse(from)).TotalDays);
            return days;
        }

        /// <summary>
        /// Add a day count to a date and return the new date.
        /// </summary>
        /// <param name="date">starting date</param>
        /// <param name="days">number of days to add</param>
        /// <returns>resulting date</returns>
        [LambdaFunction()]
        [HttpApi(LambdaHttpMethod.Get, "/dateadd/{date}/{days}")]
        public string DateAdd(string date, int days)
        {
            return (DateTime.Parse(date).AddDays(days)).ToShortDateString();
        }
    }
}
