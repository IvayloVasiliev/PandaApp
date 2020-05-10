using Microsoft.EntityFrameworkCore;
using System;

namespace Panda.Data
{
    public class PandaDbContext : DbContext
    {
        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {

        }

    }
}
