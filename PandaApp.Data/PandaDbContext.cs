
using Microsoft.EntityFrameworkCore;
using System;

namespace PandaApp.Data
{
    public class PandaDbContext : DbContext
    {
        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {

        }

    }
}
