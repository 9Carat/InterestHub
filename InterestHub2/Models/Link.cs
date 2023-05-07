using System.ComponentModel.DataAnnotations;

namespace InterestHub2.Models
{
    public class Link
    {
        public int LinkId { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Url { get; set; }
        public ICollection<InterestLink> InterestLinks { get; set; }
        public ICollection<UserInterestLink> UserInterestLinks { get; set; }
    }
}
