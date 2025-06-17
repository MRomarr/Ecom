using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Domain.Entites
{
    public class Product 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();
    }
}
