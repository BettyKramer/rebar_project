namespace Rebar.Models
{
    public class Bill
    {
        public List<Order> orders { get; set; }
        public int sum { get; set; }
    }
}
