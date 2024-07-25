using AutoMapper;
using eSealClientSample.Domain.Patterns.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SMS.Domain.Entities;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Business;
using SMS.Infrastructure.Business.AutoMapper;
using SMS.Infrastructure.Data.Contexts;
using SMS.Infrastructure.Model;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

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
				.AddScoped<IWarehouseService, WarehouseService>()
				.AddScoped<IAuthService, AuthService>();

			builder.Services
				.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.
				Configure<JWTConfigurationModel>(builder.Configuration.GetSection("JWT"));

            builder.Services
                .AddAuthentication(options =>
			  {
				  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			  }).AddJwtBearer(o =>
			  {
				  o.RequireHttpsMetadata = false;
				  o.SaveToken = false;
				  o.TokenValidationParameters = new TokenValidationParameters
				  {
					  ValidateIssuerSigningKey = true,
					  ValidateIssuer = true,
					  ValidateAudience = true,
					  ValidateLifetime = true,
					  ValidIssuer = builder.Configuration["JWT:Issuer"],
					  ValidAudience = builder.Configuration["JWT:Audience"],
					  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
				  };
			  });

            builder.Services.AddEndpointsApiExplorer();

			builder.Services.AddSwaggerGen(c => {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });

			builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SMSDBContext>().AddDefaultTokenProviders();

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