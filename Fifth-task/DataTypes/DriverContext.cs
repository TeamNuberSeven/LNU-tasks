using System.Data.Entity;

namespace TaxiDriverServiceWPF.DataTypes
{
    /// <summary>
    /// Db context
    /// </summary>
    public class DriverContext : DbContext
    {
        /// <summary>
        /// Gets or sets DbSet of drivers
        /// </summary>
        public DbSet<TaxiDriver> Drivers { get; set; }

        /// <summary>
        /// Gets or sets DbSet of clients
        /// </summary>
        public DbSet<TaxiClient> Clients { get; set; }

        /// <summary>
        /// Gets or sets DbSet of orders
        /// </summary>
        public DbSet<TaxiOrder> Orders { get; set; }

        /// <summary>
        /// Initializes a new instance of DriverContext class
        /// </summary>
        public DriverContext() : base("name=DriverContext")
        {
        }
    }
}