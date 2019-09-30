using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Portal.Data.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.ContextFactory
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=BlogDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BlogDbContext(optionsBuilder.Options);
        }
    }
}
