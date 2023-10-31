namespace Rebar.Models
{
    public class ShakeOrder
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Name { get; set; }
        public int size { get; set; }

        public ShakeOrder(string name, int size)
        {
            this.Name = name;
            this.size = size;
        }
    }
}
