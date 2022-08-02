using AutoMapper;
using INEED.WebAPI.Models;
using INEED.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI;
public class Startup
{
    static MapperConfiguration configuration = new MapperConfiguration(cfg =>
       {
           cfg.CreateMap<Customer, CustomerDto>();
           cfg.CreateMap<CustomerDto, Customer>();
       });
    public static IMapper mapper = configuration.CreateMapper();

    WebApplicationBuilder builder = WebApplication.CreateBuilder();

    string MyApplicationSpecificCors = nameof(MyApplicationSpecificCors);
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy(MyApplicationSpecificCors,
        policy =>
            {
                policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            })
        );

        services.AddControllers();
        services.AddSwaggerGen();
        services.AddScoped<ICustomerRepo, CustomerRepo>();
        services.AddScoped<UnitOfWork>();
        services.AddSingleton(mapper);
        services.AddDbContext<IneedContext>(options =>
        {
            string connectionString = builder.Configuration.GetConnectionString("ineed");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger(options =>
            {

            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
        else
        {
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseRouting();


        app.UseEndpoints(endPoints => endPoints.MapControllers());
    }

}