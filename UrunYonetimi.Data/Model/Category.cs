using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UrunYonetimi.Data.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="{0} boş geçilemez")]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
