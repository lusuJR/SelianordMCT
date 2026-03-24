using Microsoft.EntityFrameworkCore;
using SelianordMCT.API.Entities;

namespace SelianordMCT.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Enquiry> Enquiries => Set<Enquiry>();
    }
}