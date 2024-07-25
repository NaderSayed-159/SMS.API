using AutoMapper;
using eSealClientSample.Domain.Patterns.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMS.Domain.Entities;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Business;
using SMS.Infrastructure.Business.AutoMapper;
using SMS.Infrastructure.Data.Contexts;

namespace SMS.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<SMSDBContext>();

			builder.Services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ICustomerService, CustomerService>()
				.AddScoped<ICustomerPaymentService, CustomerPaymentService>()
				.AddScoped<IInvoiceLineService, InvoiceLineService>()
				.AddScoped<IInvoiceService, InvoiceService>()
				.AddScoped<IProductService, ProductService>()
				.AddScoped<IPurchaseorderService, PurchaseorderService>()
				.AddScoped<IPurchasingExpensesService, PurchasingExpensesService>()
				.AddScoped<IVendorService, VendorService>()
				.AddScoped<IWarehouseService, WarehouseService>();

			builder.Services
				.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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