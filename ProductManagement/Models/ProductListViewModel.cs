using ProductManagementDomainLayer.Entities.Concretes;
using System.Collections.Generic;

namespace ProductManagement.Models
{
    public class ProductListViewModel
    {
        public ICollection<Product> Products { get; set; }
    }
}
