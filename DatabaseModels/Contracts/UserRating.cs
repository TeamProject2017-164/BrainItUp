using DatabaseModels.Models;

namespace DatabaseModels.Contracts
{
    public class UserRating
    {
        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Percentage Rate 
        /// </summary>
        public int Rate { get; set; }
    }
}
