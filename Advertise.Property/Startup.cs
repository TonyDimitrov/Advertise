namespace Advertise.Property
{
    using Advertise.Property.Data;
    using Advertise.Property.Data.Repository;
    using Advertise.Property.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<AdvertDbContext>(
              options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));

            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IAdvertisesService, AdvertisesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IFilesService, FilesService>();

            services.AddControllers();


            //services.AddCors(option =>
            //{
            //    option.AddDefaultPolicy(builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AdvertDbContext>();

                dbContext.Database.Migrate();
            }

            app.UseDeveloperExceptionPage();
            // }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(options => options
            .WithOrigins(new string[] { "http://localhost:3000/" })
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
