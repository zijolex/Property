﻿using Microsoft.EntityFrameworkCore;
using Domain;
namespace Infrastructure.Contexts
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
               public DbSet<Property> Properties => Set<Property>();
             public DbSet<Image> Images => Set<Image>();
    
    }
}
