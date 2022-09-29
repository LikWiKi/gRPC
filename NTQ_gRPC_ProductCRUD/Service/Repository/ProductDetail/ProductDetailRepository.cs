using Service.Models;
using Service.Repository.Product;

namespace Service.Repository.ProductDetail
{
    public class ProductDetailRepository : GenericRepository<Models.ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(NTQTRAININGContext context) : base(context)
        {
        }
    }
}
