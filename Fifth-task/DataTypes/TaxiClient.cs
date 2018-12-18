using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDriverServiceWPF.DataTypes
{
    /// <summary>
    /// Taxi client class
    /// </summary>
    [Table("Clients")]
    public class TaxiClient
    {
        /// <summary>
        /// Id of client
        /// </summary>
        [Key]
        public int ClientId { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Phone number of client
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxiClient"/> class
        /// </summary>
        public TaxiClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxiClient"/> class
        /// </summary>
        /// <param name="_name">Name of client</param>
        /// <param name="_phoneNumber">Phone number of client</param>
        public TaxiClient(string _name, string _phoneNumber)
        {
            Name = _name;
            PhoneNumber = _phoneNumber;
        }

        /// <summary>
        /// Generates the string representing a client
        /// </summary>
        /// <returns>String representing a client</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", ClientId, Name, PhoneNumber);
        }
    }
}
