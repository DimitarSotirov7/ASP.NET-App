namespace Application.Web
{
    using System.Reflection;
    using Application.Common;
    using Application.Data;
    using Application.Data.Common;
    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Data.Repositories;
    using Application.Data.Seeding;
    using Application.Services;
    using Application.Services.Contracts;
    using Application.Services.Data;
    using Application.Services.Data.Contracts;
    using Application.Services.Mapping;
    using Application.Services.Messaging;
    using Application.Web.Infrastructure;
    using Application.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(option =>
            {
                option.SignIn.RequireConfirmedAccount = false;
                option.User.RequireUniqueEmail = true;

                // option.User.AllowedUserNameCharacters = true;
                option.Password.RequireDigit = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 0;
                option.Password.RequireNonAlphanumeric = false;

                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.DefaultLockoutTimeSpan = new System.TimeSpan(0, 5, 0);
            })
             .AddRoles<ApplicationRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication().AddFacebook(options =>
            {
                // TODO: GET ID and Secret and control claims received
                options.AppId = this.configuration["Authentication:Facebook:AppId"];
                options.AppSecret = this.configuration["Authentication:Facebook:AppSecret"];
            });

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            services.AddAntiforgery(option =>
            {
                option.HeaderName = "X-CSRF-TOKEN";
            });

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(this.configuration["SendGrid:ApiKey"]));
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<IFriendshipsService, FriendshipsService>();
            services.AddTransient<IImagesService, ImagesService>();
            services.AddTransient<IViewRenderService, ViewRenderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.SetCommandTimeout(1800);
                dbContext.Database.Migrate();
                var adminCredentials = new AdminCredentials
                {
                    Email = this.configuration["Admin:Email"],
                    Username = this.configuration["Admin:Username"],
                    Password = this.configuration["Admin:Password"],
                };
                new ApplicationDbContextSeeder(adminCredentials).SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
