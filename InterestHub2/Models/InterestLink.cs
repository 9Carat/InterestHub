namespace InterestHub2.Models
{
    public class InterestLink
    {
        public int Id { get; set; }
        public int FK_InterestId { get; set; }
        public Interest Interests { get; set; }
        public int FK_LinkId { get; set; }
        public Link Links { get; set; }
    }
}
