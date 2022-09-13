using GrpcServer.Contracts;
using GrpcServer.Data;
using ProtoBuf.Grpc;
using Shared;
using Shared.Data;
using ProtoBuf.Reflection;

namespace GrpcServer.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<List<ProductRequest>> GetAll()
        {
            return _db.Products.Select(x => new ProductRequest
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToList();
        }
    }
}
