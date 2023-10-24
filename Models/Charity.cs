namespace BE_charity_direct.Models;

    public class Charity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string imgUrl { get; set; }
        public List<User> Users { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }

