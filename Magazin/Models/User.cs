using System.Data;

namespace Magazin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
        public ICollection<Zamovlenay> Zamovlenays { get; set; }

        public User()
        {
            Zamovlenays = new List<Zamovlenay>();
        }
       
    }
}
