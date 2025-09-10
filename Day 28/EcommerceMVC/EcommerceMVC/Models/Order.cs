namespace EcommerceMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
