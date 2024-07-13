using BS.Application.Services;
using BS.DataAccess;
using BS.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;


namespace BooksStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BooksStoreDbContext>(
                options =>
                    {
                        options.UseNpgsql(
                            builder.Configuration.GetConnectionString(nameof(BooksStoreDbContext))
                            );
                    }
                );

            builder.Services.AddScoped<IBooksService, BooksService>();
            builder.Services.AddScoped<IBooksRepository, BooksRepository>();            

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
