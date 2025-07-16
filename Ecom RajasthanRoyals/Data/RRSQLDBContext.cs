using Ecom_RajasthanRoyals.Models.SQL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Ecom_RajasthanRoyals.Data
{
    public class RRSQLDBContext :DbContext
    {
        public RRSQLDBContext(DbContextOptions<RRSQLDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
