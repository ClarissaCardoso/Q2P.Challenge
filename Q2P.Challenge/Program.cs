global using Q2P.Challenge.Data;
using Q2P.Challenge.Application;
using Q2P.Challenge.Application.Services.Interfaces;

namespace Q2P.Challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddOptions();
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICompanyAppService, CompanyService>();
            builder.Services.AddScoped<IEmployeeAppService, EmployeeService>();
            builder.Services.AddDbContext<DataContext>();

            var configuration = builder.Configuration;

            //builder.Services.Configure<ConnectionString>(configuration.GetSection("ConnectionStrings"));

            DependencyInjector.RegisterServices(builder.Services, configuration);


            var app = builder.Build();

                app.UseSwagger();
                app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}