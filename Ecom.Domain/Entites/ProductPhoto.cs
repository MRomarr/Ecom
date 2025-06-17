using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Domain.Entites
{
    public class ProductPhoto 
    {
        public Guid Id { get; set; } 
        public string FileName { get; set; }


        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
