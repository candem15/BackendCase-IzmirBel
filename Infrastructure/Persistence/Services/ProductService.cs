using Application.Abstractions;
using Application.Dtos.Product;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await dbContext.Products.AsNoTracking().Include(x => x.Category).ToListAsync();

            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await dbContext.Products.AsNoTracking().Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);

            if (product == null)
                throw new Exception("Product not exists!");

            return mapper.Map<ProductDto>(product);
        }

        public async Task InsertAsync(CreateProductDto insertResource)
        {
            Product productToCreate = mapper.Map<Product>(insertResource);

            await dbContext.Products.AddAsync(productToCreate);

            await dbContext.SaveChangesAsync();
        }

        public async Task SoftRemoveAsync(Guid id)
        {
            var productToSoftRemove = await dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (productToSoftRemove == null)
                throw new Exception("Product to delete not exists!");

            productToSoftRemove.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, UpdateProductDto updateResource)
        {
            var productToUpdate = await dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (productToUpdate == null)
                throw new Exception("Product to update not exists!");

            productToUpdate.UpdatedAt = DateTime.Now;
            productToUpdate.Description = updateResource.Description;
            productToUpdate.Price = updateResource.Price;
            productToUpdate.Unit = updateResource.Unit;
            productToUpdate.Quantity = updateResource.Quantity;
            productToUpdate.Name = updateResource.Name;

            dbContext.Products.Update(productToUpdate);

            await dbContext.SaveChangesAsync();
        }
    }
}
