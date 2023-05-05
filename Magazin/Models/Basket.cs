namespace Magazin.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int? Number { get; set; } //номер замовленя
        //public int? Amount { get; set; }

        public ICollection<Product> Products { get; set; }

        public Basket()
        {
            Products = new List<Product>();
        }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
