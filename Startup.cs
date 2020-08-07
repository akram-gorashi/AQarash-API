using Al_Delal.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Al_Delal.Api.Repositories.Users;
using AutoMapper;
using Al_Delal.Api.Repositories.Vehicles;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Al_Delal.Api.Models;

namespace Al_Delala.Api
{
   public class Startup
   {
      readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
         {
            opt.Password.RequireDigit = false;
            opt.Password.RequiredLength = 4;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireUppercase = false;
         });

         builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
         builder.AddEntityFrameworkStores<DataContext>();
         builder.AddRoleValidator<RoleValidator<Role>>();
         builder.AddRoleManager<RoleManager<Role>>();
         builder.AddSignInManager<SignInManager<User>>();

         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                           .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                   ValidateIssuer = false,
                   ValidateAudience = false
                };
             });

         services.AddAuthorization(options =>
         {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("Stuff", policy => policy.RequireRole("Stuff"));
            options.AddPolicy("User", policy => policy.RequireRole("User"));
         });
         services.AddAutoMapper(typeof(Startup));
         services.AddTransient<Seed>();
         services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
         services.AddControllers();
         services.AddCors();
         services.AddMvc();
         services.AddScoped<IUsersRepository, UsersRepository>();
         services.AddScoped<IVehicleRepository, VehicleRepository>();

         services.AddControllers().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
         );

         services.AddCors(options =>
    {
       options.AddPolicy(MyAllowSpecificOrigins,
                         builder =>
                         {
                            builder.WithOrigins("http://localhost:4200")
                                                 .AllowAnyHeader()
                                                 .AllowAnyMethod()
                                                 .WithExposedHeaders("X-Pagination");
                         });
    });
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seed seeder,
                            UserManager<User> userManager, RoleManager<Role> roleManager)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         // app.UseHttpsRedirection();
         //seeder.SeedUsers();
         app.UseStaticFiles();
          app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders());
        // app.UseCors(MyAllowSpecificOrigins);
         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
