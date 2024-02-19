using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Range(0, double.MaxValue)]
        public double price { get; set; }
        public byte decretion { get; set; }

    }
}
