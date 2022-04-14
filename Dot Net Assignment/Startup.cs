using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Dot_Net_Assignment.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Dot_Net_Assignment.Interfaces;
using Dot_Net_Assignment.Data;


namespace Dot_Net_Assignment
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
            // Add Authentication service
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
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });
            //Add an InMemory Database service
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
            //Add the object that handles authorization as a service
            services.AddTransient<IJWTManagerRepository, JWTManagerRepository>();            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Get the DBContext
            var context = serviceProvider.GetService<ApiContext>();
            //Add dummy data
            AddTestData(context);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Adds dummy data to the database
        /// </summary>
        /// <param name="context">The database to add dummy data to</param>
        private static void AddTestData(ApiContext context)
        {
            //Add 3 TodoItems
            var Todo1 = new TodoItem
            {
                Date = DateTimeOffset.UtcNow,
                 Title = "Visit Grandma",
                 Discrbtion = "It's grandma birthday"
            };

            context.TodoItems.Add(Todo1);

            var Todo2 = new TodoItem
            {
                Date = DateTimeOffset.UtcNow,
                Title = "Clean the chimny",
                Discrbtion = "It's damn dirty"
            };

            context.TodoItems.Add(Todo2);

            var Todo3 = new TodoItem
            {
                Date = DateTimeOffset.UtcNow,
                Title = "Get a new laptop",
                Discrbtion = "mine is broke"
            };

            context.TodoItems.Add(Todo3);

            //Add 3 Users
            var user1 = new Users
            {
                FirstName = "first1",
                LastName = "last1",
                Email = "first1@last1.com",
                IsActive = true,
                Roles = "Admin",
                Username = "user1",
                Password = "pass1"
            };
            context.Users.Add(user1);

            var user2 = new Users
            {
                FirstName = "first2",
                LastName = "last2",
                Email = "first2@last2.com",
                IsActive = true,
                Roles = "User",
                Username = "user2",
                Password = "pass2"
            };
            context.Users.Add(user2);

            var user3 = new Users
            {
                FirstName = "first3",
                LastName = "last3",
                Email = "first3@last3.com",
                IsActive = false,
                Roles = "User",
                Username = "user3",
                Password = "pass3"
            };
            context.Users.Add(user3);

            //Save changes to the database
            context.SaveChanges();
        }
    }
}
