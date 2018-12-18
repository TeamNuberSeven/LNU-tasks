using TaxiDriverServiceWPF.DataTypes;
using TaxiDriverServiceWPF.Repository;

namespace TaxiDriverServiceWPF.UnitOfWorkNS
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets repository of clients
        /// </summary>
        GenericRepository<TaxiClient> Clients { get; }

        /// <summary>
        /// Gets repository of drivers
        /// </summary>
        GenericRepository<TaxiDriver> Drivers { get; }

        /// <summary>
        /// Gets repository of orders
        /// </summary>
        GenericRepository<TaxiOrder> Orders { get; }
    }
}
