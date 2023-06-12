using AutoMapper;
using ErpaHolding.Business.DTOs.BrandDto;
using ErpaHolding.Business.DTOs.CategoryDto;
using ErpaHolding.Business.DTOs.ModelDto;
using ErpaHolding.Business.DTOs.ProductDto;
using ErpaHolding.Business.DTOs.ProductImagesDto;
using ErpaHolding.Business.DTOs.UserDto;
using ErpaHolding.Business.Helpers;
using ErpaHolding.Business.Manager;
using ErpaHolding.Business.Mappings.AutoMapper;
using ErpaHolding.Business.Services;
using ErpaHolding.Business.Validations.BrandValidation;
using ErpaHolding.Business.Validations.CategoryValidation;
using ErpaHolding.Business.Validations.ModelValidation;
using ErpaHolding.Business.Validations.ProductImageValidation;
using ErpaHolding.Business.Validations.ProductValidation;
using ErpaHolding.Business.Validations.UserValidation;
using ErpaHolding.DataAccess.Contexts;
using ErpaHolding.DataAccess.Interfaces;
using ErpaHolding.DataAccess.Repositories;
using ErpaHolding.DataAccess.UnitOfWorks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.Business.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ErpaHoldingDBContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IProdutImagesService, ProductImagesManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IUserRoleService, UserRoleManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IModelService, ModelManager>();
            services.AddScoped<ICartDetailService, CartDetailManager>();


            services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidation>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidation>();

            services.AddTransient<IValidator<ProductCreateDto>, ProductCreateDtoValidation>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidation>();

            services.AddTransient<IValidator<BrandCreateDto>, BrandCreateValidation>();
            services.AddTransient<IValidator<BrandUpdateDto>, BrandUpdateValidation>();

            services.AddTransient<IValidator<ProductImagesCreateDto>, ProductImagesCreateDtoValidation>();
            services.AddTransient<IValidator<ProductImagesUpdateDto>, ProductImagesUpdateDtoValidation>();

            services.AddTransient<IValidator<UserCreateDto>, UserCretateValidation>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateValidation>();

            services.AddTransient<IValidator<ModelCreateDto>, ModelCreateValidation>();
            services.AddTransient<IValidator<ModelUpdateDto>, ModelUpdateValidation>();

            var profiles = ProfileHelper.GetProfiles();


       
            var configurationMapper = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });

            var mapper = configurationMapper.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
