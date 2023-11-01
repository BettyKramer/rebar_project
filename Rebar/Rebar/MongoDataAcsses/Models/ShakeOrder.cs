using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataAcsses.Models
{
    public class ShakeOrder
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Name { get; set; }
        public char size { get; set; }

        public ShakeOrder(string name, char size)
        {
            this.Name = name;
            this.size = size;
        }
    }
}
