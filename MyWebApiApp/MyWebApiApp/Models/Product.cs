namespace MyWebApiApp.Models
{
    public class ProductVM
    {
        public string NameHH { get; set; }
        public double Price { get; set; }   
    }

    public class Product: ProductVM
    {
        public Guid id { get; set; }
    }
}
