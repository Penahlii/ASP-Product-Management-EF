using ProductManagementDomainLayer.Entities.Abstracts;

namespace ProductManagementDomainLayer.Entities.Concretes
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public string ImageLink { get; set; }
    }
}
