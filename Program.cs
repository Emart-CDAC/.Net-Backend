
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

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            // Configure the HTTP request pipeline.
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
