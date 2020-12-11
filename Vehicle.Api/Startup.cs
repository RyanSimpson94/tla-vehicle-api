using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Vehicle.Entities.Options;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Vehicle.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
		public IOptions<AuthenticationOptions> AuthenticationOptions { get; }

		public Startup(IConfiguration configuration, IOptions<AuthenticationOptions> authenticationOptions)
        {
            Configuration = configuration;
			AuthenticationOptions = authenticationOptions;
		}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            services.AddTransient<Vehicle.Business.Managers.VehicleManager>();
			services.AddSingleton<Data.Repositories.IVehicleRepository, Data.Repositories.MockVehicleRepository>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Vehicle API", Version = "v1" });
				c.DescribeAllParametersInCamelCase();
				c.DescribeAllEnumsAsStrings();
				//c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddOptions();
			services.Configure<AuthenticationOptions>(Configuration.GetSection("Authentication"));

			ConfigureJwt(services);
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors("SiteCorsPolicy");
            app.UseMvc();
        }

        private void ConfigureJwt(IServiceCollection services)
        {
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(j =>
            {
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthenticationOptions.Value.SharedSecret)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
					ValidIssuer = AuthenticationOptions.Value.Issuer,
					ValidAudience = AuthenticationOptions.Value.Audience
                };
            });
        }
    }
}
