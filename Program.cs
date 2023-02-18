
using Aula3.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Aula3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
                builder.Services.AddDbContext<EncurtaUrlDbContext>(o => o.UseInMemoryDatabase("EncurtaDb"));

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "EncurtaUrl.API",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Thiago Scotelaro",
                            Url = new Uri("https://www.linkedin.com/in/thiago-scotelaro/")
                        }
                    });

                    var xmlFile = "EncurtaUrl.API.XML";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });

            

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseCors();

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();

            
           
        }
    }
}