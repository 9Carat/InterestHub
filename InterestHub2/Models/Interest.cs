using System.ComponentModel.DataAnnotations;

namespace InterestHub2.Models
{
    public class Interest
    {
        public int InterestId { get; set; }
        [StringLength(15)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public ICollection<UserInterest> UserInterests { get; set; }
        public ICollection<InterestLink> InterestLinks { get; set; }
        public ICollection<UserInterestLink> UserInterestLinks { get; set; }
    }
}
