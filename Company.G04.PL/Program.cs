using Company.G04.BLL;
using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAL.Data.Configuration;
using Company.G04.DAL.Models;
using Company.G04.PL.Mapping;
using Company.G04.PL.Services;
using Company.G04.PL.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Company.G04.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();//Register Built-In MVC Services
            
            //builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>(); //Allow DI for DepartmentRepository
           
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(); //Allow DI for EmployeeRepository

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddDbContext<CompanyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            
            }); //Allow DI for CompanyDbContext

            //builder.Services.AddAutoMapper(typeof(EmployeeProfile));
            builder.Services.AddAutoMapper(M=>M.AddProfile(new EmployeeProfile()));

            //Life time
            //builder.Services.AddScoped();    //Create Object Life Time Per Request - UnReachable Object
            //builder.Services.AddTransient(); //Create Object Life Time Per Operation
            //builder.Services.AddSingleton(); //Create Object Life Time Per App

            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
            builder.Services.AddScoped<IScopedServices, ScopedServices>(); //Per Request
            builder.Services.AddTransient<ITransentServices, TransentServices>();//Per Operation
            builder.Services.AddSingleton<ISingletonServices, SingletonServices>();//Per App

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                             .AddEntityFrameworkStores<CompanyDbContext>()
                             .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/SignIn";
            });
             



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
