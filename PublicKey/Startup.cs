using lda_PublicKey.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using util_Common.Extensions;
using util_Common.Middleware;
using utils_AwsInstances;

namespace lda_PublicKey
{
    public class Startup
    {
        #region Properties
        public static IConfiguration Configuration { get; private set; }
        #endregion

        #region Builders
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Methods

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddControllers();
            services.ConfigureSwagger();
            DependencyInjeccionProfile.AddDependencyInjeccion(services, Configuration);
            services.AddServicesForAchIntegration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
                    .UseDeveloperExceptionPage()
                    .UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UsePathBase(new PathString("/eprepaidpk"));
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }
        #endregion
    }
}
