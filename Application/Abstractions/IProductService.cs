using Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task InsertAsync(CreateProductDto insertResource);
        Task UpdateAsync(Guid id, UpdateProductDto updateResource);
        Task SoftRemoveAsync(Guid id);
    }
}
