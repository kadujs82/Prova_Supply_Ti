using API_Supply_TI.Data;
using API_Supply_TI.Repositorios;
using API_Supply_TI.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API_Supply_TI
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

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<Suply_DBContext>(
                Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DBConection"))
                );
            builder.Services.AddScoped<IClientes, ClienteRepositorio>(); // Injeção e dependência

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

   



