using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Infrastructure.Auth;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Interactors;

namespace ProjectVideo.Web
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ProjectVideoDbContext>(options =>
            {
				//builder.Configuration.GetConnectionString("ProjectVideoDatabase"
				options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectVideo;")
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            });

			builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                });
            builder.Services.AddAuthorization();
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, AppPolicyProvider>();
            builder.Services.AddScoped<IClaimsTransformation, AppClaimsTransformer>();

			// Application Services
            builder.Services.AddScoped<IAuthFetchInteractor, AuthFetchInteractor>();
			builder.Services.AddScoped<IProposalUpdateInteractor, ProposalUpdateInteractor>();
            builder.Services.AddScoped<IProposalFetchInteractor, ProposalFetchInteractor>();

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
