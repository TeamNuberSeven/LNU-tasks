using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDriverServiceWPF.DataTypes
{
    /// <summary>
    /// Class representing order object
    /// </summary>
    [Table("Orders")]
    public class TaxiOrder
    {
        /// <summary>
        /// Order id
        /// </summary>
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// Client assigned to the order
        /// </summary>
        public TaxiClient Client { get; set; }

        /// <summary>
        /// Driver assigned to the order
        /// </summary>
        public TaxiDriver Driver { get; set; }

        /// <summary>
        /// Arriving time
        /// </summary>
        [Required]
        public DateTime ArriveTime { get; set; }

        /// <summary>
        /// Dispatch
        /// </summary>
        [MaxLength(200)]
        [Required]
        public string Dispatch { get; set; }

        /// <summary>
        /// Destination point
        /// </summary>
        [MaxLength(200)]
        [Required]
        public string Destination { get; set; }

        /// <summary>
        /// Time of the travel
        /// </summary>
        [Required]
        public int RoadTime { get; set; }

        /// <summary>
        /// Sum to pay for
        /// </summary>
        [Required]
        public int Cost { get; set; }

        /// <summary>
        /// Label of checking if order is done
        /// </summary>
        [Required]
        public bool IsDone { get; set; }

        /// <summary>
        /// Status string
        /// </summary>
        public string Status
        {
            get
            {
                return IsDone ? "Виконано" : "Не виконано";
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxiOrder"/> class
        /// </summary>
        public TaxiOrder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxiOrder"/> class
        /// </summary>
        /// <param name="_client">Client</param>
        /// <param name="_driver">Driver</param>
        /// <param name="_arrive">Arrives at</param>
        /// <param name="_dispatch">Dispatch</param>
        /// <param name="_destination">Destination</param>
        /// <param name="_roadTime">Road time</param>
        /// <param name="_cost">Cost to pay</param>
        /// <param name="_isDone">Is done</param>
        public TaxiOrder(TaxiClient _client, TaxiDriver _driver, DateTime _arrive, string _dispatch, string _destination, int _roadTime, int _cost = 0, bool _isDone = false)
        {
            Client = _client;
            Driver = _driver;
            ArriveTime = _arrive;
            Dispatch = _dispatch;
            Destination = _destination;
            RoadTime = _roadTime;
            Cost = _cost;
            IsDone = _isDone;
        }

        /// <summary>
        /// Generates string representing taxi order instance
        /// </summary>
        /// <returns>String representing taxi order instance</returns>
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", OrderId, Client, Driver, ArriveTime.ToString("yyyy-MM-dd_HH:mm"), Dispatch, Destination, RoadTime, Cost, IsDone);
        }
    }
}
