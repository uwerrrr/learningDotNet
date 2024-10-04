using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementApi.Data;
using StudentManagementApi.Interfaces;
using StudentManagementApi.Services;

namespace StudentManagementApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // This example does not use the SQL Server database, so the following line is commented out.
            //builder.Services.AddDbContext<StudentManagementApiContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementApiContext") ?? throw new InvalidOperationException("Connection string 'StudentManagementApiContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<IStudentService, StudentService>();

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
