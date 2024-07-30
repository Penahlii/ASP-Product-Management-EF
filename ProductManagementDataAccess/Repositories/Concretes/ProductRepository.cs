using ProductManagementDataAccess.Contexts;
using ProductManagementDataAccess.Repositories.Abstracts;
using ProductManagementDomainLayer.Entities.Concretes;

namespace ProductManagementDataAccess.Repositories.Concretes
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementContext context) : base(context)
        {
        }
    }
}
