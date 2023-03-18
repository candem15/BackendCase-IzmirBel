using Application.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task InsertAsync(CategoryDto insertResource);
        Task UpdateAsync(CategoryDto updateResource);
        Task SoftRemoveAsync(Guid id);
    }
}
