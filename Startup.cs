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
<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Al_Delal.Api.Models;
=======
using System.IO;
using Microsoft.AspNetCore.Http;
>>>>>>> [update]

namespace Al_Delala.Api
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

<<<<<<< HEAD
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
=======
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<Seed>();
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
>>>>>>> [update]

         builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
         builder.AddEntityFrameworkStores<DataContext>();
         builder.AddRoleValidator<RoleValidator<Role>>();
         builder.AddRoleManager<RoleManager<Role>>();
         builder.AddSignInManager<SignInManager<User>>();

<<<<<<< HEAD
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
         app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
=======
            // app.UseHttpsRedirection();
            //seeder.SeedUsers();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
>>>>>>> [update]
}
