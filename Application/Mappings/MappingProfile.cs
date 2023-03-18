using Application.Dtos.Category;
using Application.Dtos.Product;
using Application.Dtos.Token;
using Application.Features.Commands.Category.CreateCategory;
using Application.Features.Commands.Product.CreateProduct;
using Application.Features.Commands.Product.UpdateProduct;
using Application.Features.Commands.Token.GetToken;
using Application.Features.Queries.Category.GetCategoryById;
using Application.Features.Queries.Product.GetProductById;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CategoryDto, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<CreateProductDto, CreateProductCommandRequest>().ReverseMap();
            CreateMap<UpdateProductDto, UpdateProductCommandRequest>().ReverseMap();

            CreateMap<CategoryDto, GetCategoryByIdQueryResponse>();
            CreateMap<ProductDto, GetProductByIdQueryResponse>();
            CreateMap<UpdateProductDto, UpdateProductCommandResponse>();
            CreateMap<CreateProductDto, CreateProductCommandResponse>();

            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();

            //Token mapping
            CreateMap<TokenDto, GetTokenCommandResponse>();
        }
    }
}
