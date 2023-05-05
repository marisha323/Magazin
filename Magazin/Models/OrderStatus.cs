namespace Magazin.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Basket> Baskets { get; set; }

        public OrderStatus()
        {
            Baskets = new List<Basket>();
        }
    }
}
