namespace BE_charity_direct.Models;

    public class Subscription
    {
        public int Id { get; set; }
        public int charityId { get; set; }
        public int userId { get; set; }

        public Charity Charity { get; set; }
        public User User { get; set; }
    }

