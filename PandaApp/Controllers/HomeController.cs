using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PandaApp.Data;
using PandaApp.Models.Package;
using System.Collections.Generic;
using System.Linq;

namespace PandaApp.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly PandaDbContext context;

        public HomeController(PandaDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                List<PackageHomeViewModel> userPackages = this.context.Packages
                    .Where(package => package.Recipient.UserName == this.User.Identity.Name)
                    .Include(package => package.Status)
                    .Select(package => new PackageHomeViewModel
                    { 
                        Id = package.Id,
                        Description = package.Description,
                        Status = package.Status.Name
                    })
                    .ToList();

                return this.View(userPackages);
            }

            return this.View();
        }

    }
}
