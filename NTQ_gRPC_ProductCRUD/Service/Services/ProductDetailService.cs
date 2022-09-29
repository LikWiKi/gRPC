using Grpc.Core;
using Service.Repository.ProductDetail;
namespace Service.Services
{
    public class ProductDetailService : ProductDetailCRUD.ProductDetailCRUDBase
    {
        private readonly IProductDetailRepository _productDetailRepository;
        public ProductDetailService(IProductDetailRepository productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        public override Task<ProductDetails> GetAll(Empty requestData, ServerCallContext context)
        {
            ProductDetails responseData = new ProductDetails();
            var query = from data in _productDetailRepository.GetAll()
                        select new ProductDetail()
                        {
                            Id = data.Id,
                            Price = data.Price,
                            Color = data.Color,
                            StartingDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)data.StartingDate, DateTimeKind.Utc)),
                            ClosingDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)data.ClosingDate, DateTimeKind.Utc)),
                            MadeBy = data.MadeBy,
                            ProductId = data.ProductId,
                            CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.CreatedDate, DateTimeKind.Utc)),
                            UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.UpdatedDate, DateTimeKind.Utc))
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<Empty> Create(ProductDetail requestData, ServerCallContext context)
        {
            var newProductDetail = new Models.ProductDetail
            {
                Id = requestData.Id,
                Price = requestData.Price,
                Color = requestData.Color,
                StartingDate = requestData.StartingDate.ToDateTime(),
                ClosingDate = requestData.ClosingDate.ToDateTime(),
                MadeBy = requestData.MadeBy,
                ProductId = requestData.ProductId,
                CreatedDate = requestData.CreatedDate.ToDateTime(),
                UpdatedDate = requestData.UpdatedDate.ToDateTime()
            };
            _productDetailRepository.Create(newProductDetail);
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Update(ProductDetail requestData, ServerCallContext context)
        {
            //Models.ProductDetail productDetail = _productDetailRepository.GetById(requestData.Id);
            //DateTime createDate = productDetail.CreatedDate;
            _productDetailRepository.Update(new Models.ProductDetail()
            {
                Id = requestData.Id,
                Price = requestData.Price,
                Color = requestData.Color,
                StartingDate = requestData.StartingDate.ToDateTime(),
                ClosingDate = requestData.ClosingDate.ToDateTime(),
                MadeBy = requestData.MadeBy,
                ProductId = requestData.ProductId,
                CreatedDate = requestData.CreatedDate.ToDateTime(),
                UpdatedDate = requestData.UpdatedDate.ToDateTime()
            });
            return Task.FromResult(new Empty());
        }

        public override Task<ProductDetail> GetById(ProductDetailById requestData, ServerCallContext context)
        {
            var data = _productDetailRepository.GetById(requestData.Id);
            ProductDetail emp = new ProductDetail()
            {
                Id = data.Id,
                Price = data.Price,
                Color = data.Color,
                StartingDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)data.StartingDate, DateTimeKind.Utc)),
                ClosingDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)data.ClosingDate, DateTimeKind.Utc)),
                MadeBy = data.MadeBy,
                ProductId = data.ProductId,
                CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.CreatedDate, DateTimeKind.Utc)),
                UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.UpdatedDate, DateTimeKind.Utc))
            };
            return Task.FromResult(emp);
        }

        public override Task<Empty> Delete(ProductDetailById requestData, ServerCallContext context)
        {
            _productDetailRepository.Delete(requestData.Id);
            return Task.FromResult(new Empty());
        }
    }
}
