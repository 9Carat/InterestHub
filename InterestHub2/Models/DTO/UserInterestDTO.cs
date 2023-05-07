using System.ComponentModel.DataAnnotations;

namespace InterestHub2.Models.DTO
{
    public class UserInterestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Interest { get; set; }
        public string Description { get; set; }
    }
}
