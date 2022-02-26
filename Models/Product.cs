namespace rest_api.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Type { get; set; }//ie. keyboard, mouse....
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }//how many is available to sell
    }
}
