using System.ComponentModel.DataAnnotations;

namespace InterestHub2.Models.DTO
{
    public class UserLinkDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LinkTitle { get; set; }
        public string Url { get; set; }
    }
}
