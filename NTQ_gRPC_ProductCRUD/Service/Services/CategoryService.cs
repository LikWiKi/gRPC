using Grpc.Core;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;
using Service.Models;
using Service.Repository.Category;
using Service.Repository.Product;
using System;

namespace Service.Services
{
    public class CategoryService : CategoryCRUD.CategoryCRUDBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public override Task<Categories> GetAll(Empty requestData, ServerCallContext context)
        {
            Categories responseData = new Categories();
            var query = from p in _categoryRepository.GetAll()
                        select new Category()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            TagName = p.TagName,
                            Active = (bool)p.Active,
                            CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.CreatedDate, DateTimeKind.Utc)),
                            UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.UpdatedDate, DateTimeKind.Utc))
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<PageResult> GetPaging(PagingRequest requestData, ServerCallContext context)
        {
            //Categories pageData = new Categories(); 
            var categoryPaging = _categoryRepository.GetAll()
                                    .Skip((requestData.PageIndex - 1) * requestData.PageSize)
                                    .Take(requestData.PageSize)
                                    .Select(p => new Category()
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        TagName = p.TagName,
                                        Active = (bool)p.Active,
                                        CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.CreatedDate, DateTimeKind.Utc)),
                                        UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.UpdatedDate, DateTimeKind.Utc))
                                    }).ToArray();

            int totalRecord = _categoryRepository.GetAll().Count();
            var pageResult = new PageResult()
            {
                TotalRecords = totalRecord,
                PageSize = requestData.PageSize,
                PageIndex = requestData.PageIndex,
                PageCount = (int)Math.Ceiling((double)totalRecord / (requestData.PageSize))
            };
            //pageData.Items.AddRange(categoryPaging);
            //var p = pageResult.ListPaging.Items;
            pageResult.ListPaging.AddRange(categoryPaging);
            return Task.FromResult(pageResult);
        }


        public override Task<Empty> Create(Category requestData, ServerCallContext context)
        {
            _categoryRepository.Create(new Models.Category
            {
                Id = requestData.Id,
                Name = requestData.Name,
                TagName = requestData.TagName,
                Active = requestData.Active,
                CreatedDate = requestData.CreatedDate.ToDateTime(),
                UpdatedDate = requestData.UpdatedDate.ToDateTime()
            });
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Update(Category requestData, ServerCallContext context)
        {
            _categoryRepository.Update(new Models.Category()
            {
                Id = requestData.Id,
                Name = requestData.Name,
                TagName = requestData.TagName,
                Active = requestData.Active,
                CreatedDate = requestData.CreatedDate.ToDateTime(),
                UpdatedDate = requestData.UpdatedDate.ToDateTime()
            });
            return Task.FromResult(new Empty());
        }

        public override Task<Category> GetById(CategoryById requestData, ServerCallContext context)
        {
            var data = _categoryRepository.GetById(requestData.Id);
            if(data == null)
            {
                throw new gRPCException($"Can not find category {requestData.Id}");
            }
            Category emp = new Category()
            {
                Id = data.Id,
                Name = data.Name,
                TagName = data.TagName,
                Active = (bool)data.Active,
                CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.CreatedDate, DateTimeKind.Utc)),
                UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(data.UpdatedDate, DateTimeKind.Utc))
            };
            return Task.FromResult(emp);
        }

        public override Task<Empty> Delete(CategoryById requestData, ServerCallContext context)
        {
            _categoryRepository.Delete(requestData.Id);
            return Task.FromResult(new Empty());
        }

        public override Task<Products> GetAllProductByCategoryId(CategoryById requestData, ServerCallContext context)
        {
            var listOfProduct = _productRepository.GetAll().Where(pr => pr.CategoryId == requestData.Id)
                .Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    TagName = p.TagName,
                    Active = (bool)p.Active,
                    CategoryId = p.CategoryId,
                    CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.CreatedDate, DateTimeKind.Utc)),
                    UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(p.UpdatedDate, DateTimeKind.Utc))
                });
            Products products = new Products();
            products.Items.AddRange(listOfProduct.ToArray());
            return Task.FromResult(products);
        }
    }
}
