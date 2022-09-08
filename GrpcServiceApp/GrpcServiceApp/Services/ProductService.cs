using Grpc.Core;
using GrpcServiceApp.Data;

namespace GrpcServiceApp.Services
{
    public class ProductService : ProductCRUD.ProductCRUDBase
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public override Task<Products> GetAll(Empty requestData, ServerCallContext context)
        {
            Products responseData = new Products();
            var query = from p in _db.Products
                        select new Product()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price,
                            Stock = p.Stock,
                            Description = p.Description,
                            Color = p.Color,
                            Size = p.Size,
                            DateCreated = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.DateCreated, DateTimeKind.Utc))
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<Empty> Create(Product requestData, ServerCallContext context)
        {
            _db.Products.Add(new Data.Product
            {
                Id = requestData.Id,
                Name = requestData.Name,
                Price = requestData.Price,
                Stock = requestData.Stock,
                Description = requestData.Description,
                Color = requestData.Color,
                Size = requestData.Size,
                DateCreated = requestData.DateCreated.ToDateTime()
            });
            _db.SaveChanges();
            return Task.FromResult(new Empty());
        }
    }
}
