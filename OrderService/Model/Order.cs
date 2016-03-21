namespace OrderService.Model
{
    public class Order
    {
        public string Id { get; set; }
        //public Address Address { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
    }
}
