using ExerciseSolutionAPI.Helpers;
using ExerciseSolutionAPI.Middlewares;
using ExerciseSolutionAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace ExerciseSolutionAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExerciseSolutionAPI", Version = "v1" });
            });

            // setting the cors configuration
            var angularDeployedDomainUrls = Configuration["AngularDeployedDomainUrl"].Split(';').ToArray();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "ApplicationCorsPolicy",
                                  builder =>
                                  {
                                      builder.WithOrigins(angularDeployedDomainUrls).AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            // to ignore case in json options
            services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.PropertyNameCaseInsensitive = false;
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionString"]));

            // to resolve the service dependency for the middleware
            services.AddTransient<AuthenticationMiddleware>();

            // to inject all the servies
            DependencyMapper.SetDependencies(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExerciseSolutionAPI v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            //to enable the cors policy
            app.UseCors("ApplicationCorsPolicy");
            //to add the authentication middleware
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
