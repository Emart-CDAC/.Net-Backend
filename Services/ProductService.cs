using Emart_DotNet.Models;
using Emart_DotNet.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_DotNet.Services
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.FindByIdAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
           
            return await _productRepository.SaveAsync(product);
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var existing = await _productRepository.FindByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Product not found");

            
            existing.ProductName = product.ProductName;
            existing.ProductImageUrl = product.ProductImageUrl;
            existing.NormalPrice = product.NormalPrice;
            existing.EcardPrice = product.EcardPrice;
            existing.AvailableQuantity = product.AvailableQuantity;
            existing.Description = product.Description;
            existing.StoreId = product.StoreId;
            existing.SubcategoryId = product.SubcategoryId;
            existing.DiscountPercent = product.DiscountPercent;
            
            return await _productRepository.SaveAsync(existing);
        }

        public async Task DeleteProductAsync(int id)
        {
            if (!await _productRepository.ExistsAsync(id))
                 throw new KeyNotFoundException("Product not found");

            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<Product>> SearchProductsAsync(string keyword)
        {
            return await _productRepository.SearchProductsAsync(keyword);
        }
    }
}
