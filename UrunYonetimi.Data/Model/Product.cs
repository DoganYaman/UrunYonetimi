using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UrunYonetimi.Data.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }


        public virtual ICollection<ProductImage> ProductImages { get; set; } // Navigation prop.
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; } // Navigation prop.

        [Required]
        public int CategoryId { get; set; } // Foreign key baglanti..
        [DisplayName("Kategori Adı")]
        public virtual Category Category { get; set; } // Navigation prop.

    }
}
