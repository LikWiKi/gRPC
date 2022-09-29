using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Repository.Category
{
    public class CategoryRepository : GenericRepository<Models.Category>, ICategoryRepository
    {
        public CategoryRepository(NTQTRAININGContext context) : base(context)
        {
        }
    }
}
