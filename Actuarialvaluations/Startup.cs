using Actuarialvaluations.API;
using Actuarialvaluations.Models.AIValuations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Actuarialvaluations
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
      services.Configure<Settings.ActuarialClientSettings>(this.Configuration.GetSection("Actuarialvaluations.ClientSettings"));
      services.AddDbContext<AIValuationsContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("ActuarialValuations")));
      services.AddScoped<APIManager>();
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });


      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
        .AddJsonOptions(options =>
        {
          options.SerializerSettings.ContractResolver = new DefaultContractResolver();
          options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
          options.SerializerSettings.Formatting = Formatting.Indented;
          options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

      services.AddCors();

      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "clientapp/dist";
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

      if (env.IsDevelopment())
      {
        app.UseCors(builder =>
          builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseSpaStaticFiles();
      app.UseMvc();

      // app.UseMvc(routes =>
      // {
      //  routes.MapRoute(
      //            name: "default",
      //            template: "{controller=Home}/{action=Index}/{id?}");
      // });

      app.UseSpa(config =>
      {
        config.Options.SourcePath = "clientapp";
      });
    }
  }
}
