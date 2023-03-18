using Application.Abstractions;
using Application.Dtos.Category;
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
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await dbContext.Categories.AsNoTracking().ToListAsync();

            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var category = await dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (category == null)
                throw new Exception("Category not exists!");

            return mapper.Map<CategoryDto>(category);
        }

        public async Task InsertAsync(CategoryDto insertResource)
        {
            Category categoryToCreate = mapper.Map<Category>(insertResource);

            await dbContext.Categories.AddAsync(categoryToCreate);

            await dbContext.SaveChangesAsync();
        }

        public async Task SoftRemoveAsync(Guid id)
        {
            var categoryToSoftRemove = await dbContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (categoryToSoftRemove == null)
                throw new Exception("Category to delete not exists!");

            categoryToSoftRemove.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryDto updateResource)
        {
            var categoryToUpdate = await dbContext.Categories.SingleOrDefaultAsync(x => x.Id == updateResource.Id);

            if (categoryToUpdate == null)
                throw new Exception("Category to update not exists!");

            categoryToUpdate.UpdatedAt = DateTime.Now;
            categoryToUpdate.Name = updateResource.Name;
            categoryToUpdate.Description = updateResource.Description;

            dbContext.Categories.Update(categoryToUpdate);

            await dbContext.SaveChangesAsync();
        }
    }
}
