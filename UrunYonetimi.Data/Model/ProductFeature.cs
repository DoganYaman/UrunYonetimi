
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace UrunYonetimi.Data.Model
{
    public class ProductFeature
    {
        [Key]
        public int ProductFeatureId { get; set; }

        [Required(ErrorMessage = "{0} boş geçilemez")]
        [DisplayName("Özellik Adı")]
        public string FeatureName { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [DisplayName("Özellik Değeri")]
        public string FeatureValue { get; set; }

        [Required]
        public int ProductId { get; set; } // Foreign key baglanti..
        public virtual Product Product { get; set; } // Navigation prop.
    }
}
