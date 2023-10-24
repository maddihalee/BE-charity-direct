namespace BE_charity_direct.Models;

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string uid { get; set; }
        public List<Charity> Charities { get; set; }
        public List <Subscription> Subscriptions { get; set; }
    }

