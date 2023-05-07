using System.ComponentModel.DataAnnotations;

namespace InterestHub2.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }
        [StringLength(13)]
        public string PhoneNumber { get; set; }
        public ICollection<UserInterest> UserInterests { get; set; }
        public ICollection<UserInterestLink> UserInterestLinks { get; set; }
    }
}
