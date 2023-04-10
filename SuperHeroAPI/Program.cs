using SuperHeroAPI.Middleware;
using SuperHeroAPI.Services;

namespace SuperHeroAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

            builder.Services.AddSingleton<ISuperHeroService ,SuperHeroService>(); // registering/Injecting the Dependency ISuperHeroService 

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

            app.UseExceptionHandler("/");

            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}