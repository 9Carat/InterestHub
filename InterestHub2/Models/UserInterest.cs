namespace InterestHub2.Models
{
    public class UserInterest
    {
        public int Id { get; set; }
        public int FK_UserId { get; set; }
        public User Users { get; set; }
        public int FK_InterestId { get; set; }
        public Interest Interests { get; set; }
    }
}
