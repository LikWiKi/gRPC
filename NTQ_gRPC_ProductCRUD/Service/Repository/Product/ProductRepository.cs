using Service.Models;
using Service.Repository.Category;

namespace Service.Repository.Product
{
    public class ProductRepository : GenericRepository<Models.Product>, IProductRepository
    {
        public ProductRepository(NTQTRAININGContext context) : base(context)
        {
        }
    }
}
