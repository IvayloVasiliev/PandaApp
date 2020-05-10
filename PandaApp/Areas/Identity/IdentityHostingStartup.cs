using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PandaApp.Data;

[assembly: HostingStartup(typeof(PandaApp.Areas.Identity.IdentityHostingStartup))]
namespace PandaApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PandaAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PandaAppContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<PandaAppContext>();
            });
        }
    }
}