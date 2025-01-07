using AnimalAdoptionAPI.Models;
using AnimalAdoptionAPI.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using AnimalAdoptionAPI.Controllers;


namespace AnimalAdoptionAPI.Services
{
    public class ProductService : IProductsService
    {
        private readonly AnimalAdoptionDbContext _dbContext;

        public ProductService(AnimalAdoptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Products> GetAllProducts()
        {
            return _dbContext.Products.ToList();

        }

        public Products GetProductById(int product_id)
        {
            return _dbContext.Products.FirstOrDefault(e => e.id == product_id);
        }

        public Products AddProduct(AddProductsDto productsDto)
        {
            var products = new Products
            {
                product_name = productsDto.name,
                price = productsDto.price,
                category = productsDto.category,
                description = productsDto.description
            };
            _dbContext.Products.Add(products);
            _dbContext.SaveChanges();

            return products;
        }

        public Products UpdateProductById(int id, UpdateProductsDto updateProduct)
        {
            var product = _dbContext.Products.FirstOrDefault(e => e.id == id);

            if (product == null)
            {
                return null;
            }

            product.product_name = updateProduct.name;
            product.price = updateProduct.price;
            product.category = updateProduct.category;
            product.description = updateProduct.description;

            _dbContext.SaveChanges();

            return product;
        }

        public bool DeleteProductById(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(e => e.id == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}