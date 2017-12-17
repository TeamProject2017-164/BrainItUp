using DatabaseModels.Contracts;
using DatabaseModels.Models;
using System.Linq;

namespace DatabaseModels.Extensions
{
    public static class UserAnswersExtensions
    {
        /// <summary>
        /// Get percentage rating for the user based on ratio between the correct answers and total answers
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IQueryable<UserRating> GetUserRating(this IQueryable<UserAnswer> collection)
        {
            return collection
                    .GroupBy(x => x.User)
                        .Select(x => 
                            new UserRating {
                                User = x.Key,
                                Rate = 100 * x.Sum(u => u.Answer.IsCorrect ? 1 : 0) / x.Sum(u => 1)
                            });
        }
    }
}
