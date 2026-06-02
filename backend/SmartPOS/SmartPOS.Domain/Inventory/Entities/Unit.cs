using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Inventory.Entities
{
    public class Unit : BaseEntity
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}