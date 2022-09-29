using Grpc.Core;
using Service.Repository.Product;

namespace Service.Services
{
    public class ProductService : ProductCRUD.ProductCRUDBase
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override Task<Products> GetAll(Empty requestData, ServerCallContext context)
        {
            Products responseData = new Products();
            var query = from p in _productRepository.GetAll()
                        select new Product()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            TagName = p.TagName,
                            Active = (bool)p.Active,
                            CategoryId = p.CategoryId,
                            CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.CreatedDate, DateTimeKind.Utc)),
                            UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.UpdatedDate, DateTimeKind.Utc))
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }


        public override Task<Empty> Create(Product requestData, ServerCallContext context)
        {
            var newProduct = new Models.Product
            {
                Id = requestData.Id,
                Name = requestData.Name,
                TagName = requestData.TagName,
                Active = requestData.Active,
                CategoryId= requestData.CategoryId,
                CreatedDate = requestData.CreatedDate.ToDateTime(),
                UpdatedDate = requestData.UpdatedDate.ToDateTime()
            };
            _productRepository.Create(newProduct);
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Update(Product requestData, ServerCallContext context)
        {
            _productRepository.Update(new Models.Product()
            {
                Id = requestData.Id,
                Name = requestData.Name,
                TagName = requestData.TagName,
                Active = requestData.Active,
                CategoryId = requestData.CategoryId,
                CreatedDate = requestData.CreatedDate.ToDateTime(),
                UpdatedDate = requestData.UpdatedDate.ToDateTime()
            });
            return Task.FromResult(new Empty());
        }

        public override Task<Product> GetById(ProductById requestData, ServerCallContext context)
        {
            var data = _productRepository.GetById(requestData.Id);
            Product emp = new Product()
            {
                Id = data.Id,
                Name = data.Name,
                TagName = data.TagName,
                Active = (bool)data.Active,
                CategoryId = data.CategoryId,
                CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.CreatedDate, DateTimeKind.Utc)),
                UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.UpdatedDate, DateTimeKind.Utc))
            };
            return Task.FromResult(emp);
        }

        public override Task<Empty> Delete(ProductById requestData, ServerCallContext context)
        {
            _productRepository.Delete(requestData.Id);
            return Task.FromResult(new Empty());
        }
    }
}
