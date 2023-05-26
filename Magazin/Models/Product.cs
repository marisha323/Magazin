namespace Magazin.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public int Price { get; set; }
        public string Number { get; set; }
        public string? PathLong { get; set; }
      
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? BasketsProductId { get; set; }
        public virtual BasketsProduct BasketsProduct { get; set; }

        public ICollection<Imeg> Imegs { get; set; }
        public Product()
        {
            Imegs = new List<Imeg>();
        }
    }
}
