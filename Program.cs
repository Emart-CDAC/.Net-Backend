using Microsoft.EntityFrameworkCore;
using Emart_DotNet.Models;
using Emart_DotNet.Repositories;

using Emart_DotNet.Models;
using Emart_DotNet.Repositories;
using Emart_DotNet.Services;

namespace Emart_DotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
  
            builder.Services.AddDbContext<Emart_DotNet.Models.AppDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql")
                ));

            builder.Services.AddScoped<ICartRepository,CartRepository>();
            builder.Services.AddScoped<ICartItemRepository,CartItemRepository>();
            
            builder.Services.AddScoped<IProductRepository,ProductRepository>();
            
            builder.Services.AddScoped<IOrderRepository,OrderRepository>();
            builder.Services.AddScoped<IOrderItemRepository,OrderItemRepository>();
            
            builder.Services.AddScoped<IAddressRepository,AddressRepository>();
            builder.Services.AddScoped<IStoreRepository,StoreRepository>();

            builder.Services.AddScoped<ICartService,CartService>();
            builder.Services.AddScoped<IOrderService,OrderService>();
            //builder.Services.AddScoped<IPaymentService,PaymentService>();
            builder.Services.AddScoped<IProductService,ProductService>();

            // Register DbContext
            builder.Services.AddDbContext<AppDbContext>();

            // Register Repositories
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

            // Register Services
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
