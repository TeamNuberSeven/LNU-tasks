using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDriverServiceWPF.DataTypes
{
    /// <summary>
    /// Taxi driver class
    /// </summary>
    [Table("Drivers")]
    public class TaxiDriver
    {
        /// <summary>
        /// Driver id
        /// </summary>
        [Key]
        public int DriverId { get; set; }

        /// <summary>
        /// Driver's surname
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Driver's name
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Driver's age
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Driver's car number
        /// </summary>
        [Required]
        public string CarNumber { get; set; }

        /// <summary>
        /// Years of experience
        /// </summary>
        [Required]
        public int Experience { get; set; }

        /// <summary>
        /// Cost of minute of travel
        /// </summary>
        [Required]
        public int CostPerMinute { get; set; }

        /// <summary>
        /// Pay check
        /// </summary>
        [Required]
        public double PayCheck { get; set; }

        /// <summary>
        /// Initializes a new instanse of the <see cref="TaxiDriver"/> class
        /// </summary>
        public TaxiDriver()
        {
            PayCheck = 0;
        }

        /// <summary>
        /// Initializes a new instanse of the <see cref="TaxiDriver"/> class
        /// </summary>
        /// <param name="_surname">Surname</param>
        /// <param name="_name">Name</param>
        /// <param name="_age">Age</param>
        /// <param name="_carNumber">Car number</param>
        /// <param name="_experience">Experience</param>
        /// <param name="_cost">Cost</param>
        /// <param name="_pay">Pay check</param>
        public TaxiDriver(string _surname, string _name, int _age, string _carNumber, int _experience, int _cost, double _pay = 0)
        {
            Surname = _surname;
            Name = _name;
            Age = _age;
            CarNumber = _carNumber;
            Experience = _experience;
            CostPerMinute = _cost;
            PayCheck = _pay;
        }

        /// <summary>
        /// Generates string representing taxi driver
        /// </summary>
        /// <returns>String representing taxi driver</returns>
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", DriverId, Surname, Name, Age, CarNumber, Experience, CostPerMinute, PayCheck);
        }
    }
}
