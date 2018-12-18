using System;
using TaxiDriverServiceWPF.DataTypes;
using TaxiDriverServiceWPF.Repository;

namespace TaxiDriverServiceWPF.UnitOfWorkNS
{
    /// <summary>
    /// The class that represents Unit Of Work pattern object
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DriverContext context = new DriverContext();
        private GenericRepository<TaxiClient> clients;
        private GenericRepository<TaxiDriver> drivers;
        private GenericRepository<TaxiOrder> orders;

        /// <summary>
        /// Gets repository of clients
        /// </summary>
        public GenericRepository<TaxiClient> Clients
        {
            get
            {
                if (clients == null)
                {
                    clients = new GenericRepository<TaxiClient>(context);
                }
                return clients;
            }
        }

        /// <summary>
        /// Gets repository of drivers
        /// </summary>
        public GenericRepository<TaxiDriver> Drivers
        {
            get
            {
                if (drivers == null)
                {
                    drivers = new GenericRepository<TaxiDriver>(context);
                }
                return drivers;
            }
        }

        /// <summary>
        /// Gets repository of orders
        /// </summary>
        public GenericRepository<TaxiOrder> Orders
        {
            get
            {
                if (orders == null)
                {
                    orders = new GenericRepository<TaxiOrder>(context);
                }
                return orders;
            }
        }

        /// <summary>
        /// Saves changes in DB context
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }


        #region Dispose pattern

        private bool disposed = false;

        /// <summary>
        /// Protected dispose method
        /// </summary>
        /// <param name="disposing">Checking parameter</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
