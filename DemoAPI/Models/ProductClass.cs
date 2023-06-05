namespace DemoAPI.Models
{
    public class ProductClass
    {
        public Guid Id { get;  }
        public string? product_name { get;  }
        public string? product_description { get; }
        public string? product_image { get; }

        public decimal product_price { get; }
        public int product_quantity { get; }
        public DateTime added_date { get;  }
        
        public ProductClass(Guid id, string? product_name, string? product_description, string? product_image, decimal product_price, int product_quantity, DateTime added_date)
        {
            Id = id;
            this.product_name = product_name;
            this.product_description = product_description;
            this.product_image = product_image;
            this.product_price = product_price;
            this.product_quantity = product_quantity;
            this.added_date = added_date;
        }
    }
}
