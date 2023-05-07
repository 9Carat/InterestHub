namespace InterestHub2.Models
{
    public class UserInterestLink
    {
        public int Id { get; set; }
        public int FK_UserId { get; set; }
        public User Users { get; set; }
        public int FK_InterestId { get; set; }
        public Interest Interests { get; set; }
        public int FK_LinkId { get; set; }
        public Link Links { get; set; }
    }
}
