namespace Magazin.Models
{
    public class Zamovlenay
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Oplata { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

    }
}
