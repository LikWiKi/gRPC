using Grpc.Core;
using GrpcServiceApp.Data;
using Microsoft.EntityFrameworkCore;

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

        public override Task<Empty> Update(Product requestData, ServerCallContext context)
        {
            _db.Products.Update(new Data.Product()
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

        public override Task<Product> GetById(ProductFilter requestData, ServerCallContext context)
        {
            var data = _db.Products.Find(requestData.Id);
            Product emp = new Product()
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price,
                Stock = data.Stock,
                Description = data.Description,
                Color = data.Color,
                Size = data.Size,
                DateCreated = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.DateCreated, DateTimeKind.Utc))
            };
            return Task.FromResult(emp);
        }

        public override Task<Empty> Delete(ProductFilter requestData, ServerCallContext context)
        {
            var data = _db.Products.Find(requestData.Id);
            _db.Entry(data).State = EntityState.Detached;
    
            _db.Products.Remove(new Data.Product()
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price,
                Stock = data.Stock,
                Description = data.Description,
                Color = data.Color,
                Size = data.Size,
                DateCreated = data.DateCreated
            });
            _db.SaveChanges();
            return Task.FromResult(new Empty());
        }
    }
}
