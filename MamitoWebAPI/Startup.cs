using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EFCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using DataAccess.EFCore.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MamitoWebAPI.Models;
using MamitoWebAPI.Services;

namespace MamitoWebAPI
{
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
            services.AddControllersWithViews();
            /*       services.AddDbContext<ApplicationContext>(options =>
            options.UseMySql(
           Configuration.GetConnectionString("DefaultConnection"),
           b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName))
            );*/
            var connectionString = Configuration.GetConnectionString("Server=127.0.0.1;Port=3307;Database=mamitodb2;user=root;password=;");
            services.AddEntityFrameworkMySql();
            services.AddDbContext<ApplicationContext>(
                            options => options.UseMySql("Server=127.0.0.1;Port=3307;Database=mamitodb2;user=root;password=;", ServerVersion.AutoDetect("Server=localhost;Port=3307;Database=mamitodb2;user=root;password=;")));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
/*                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],*/
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            /*options => options.UseMySql(Configuration.GetConnectionString("Data:ConnectionString"),
                mysqlOptions => mysqlOptions.MaxBatchSize(EfBatchSize)),
            ServiceLifetime.Scoped*/
            /// );
            /*            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
                        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));*/
            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUserInfoRepository, UserInfoRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IJWTManagerRepository, JWTManagerRepository>();
            services.AddTransient<IMailServiceRepository, Services.MailServiceRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
