using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsAppDB.Models;

namespace NewsAppDB
{
  public class Startup
  {
    private IConfiguration configuration;
    public Startup(IConfiguration configuration)/////////////DB
    {
      this.configuration = configuration;///////////////DB
    }





    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();//////////////////////////////

      services.AddDbContext<NewsAppDBContext>(opt =>///////////////////////////////DB
        opt.UseSqlServer(configuration.GetConnectionString("Database"))/////////////////////////////////DB
      );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();/////////////////////////

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(///////////////////////
          name: "default",///////////////////////
          pattern: "{controller=Home}/{action=Index}/{id?}");/////////////////////////////
      });
    }
  }
}
