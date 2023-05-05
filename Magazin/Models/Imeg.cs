namespace Magazin.Models
{
    public class Imeg
    {
        public int Id { get; set; }
        public string Pass { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
