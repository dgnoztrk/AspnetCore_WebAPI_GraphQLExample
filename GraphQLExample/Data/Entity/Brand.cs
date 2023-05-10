using System.ComponentModel.DataAnnotations;

namespace GraphQLExample.Data.Entity
{
    public class Brand
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
