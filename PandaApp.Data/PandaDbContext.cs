using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Panda.Domain;

namespace PandaApp.Data
{
    public class PandaDbContext : IdentityDbContext<PandaUser>
    {
     
        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {
            
        }

    }
}
