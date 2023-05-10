using System.ComponentModel.DataAnnotations;

namespace GraphQLExample.Data.Entity
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescr { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; }
        public bool IsShowCase { get; set; }
        public decimal Price { get; set; }
        public decimal PaidPrice { get; set; }
        public int Stock { get; set; }
        public string? Barcode { get; set; }
        public virtual long BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
