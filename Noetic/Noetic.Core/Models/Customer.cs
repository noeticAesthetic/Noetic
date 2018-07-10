using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noetic.Core.Models
{
    public class Customer : BaseEntity
    {
        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        //[RegularExpression(@ "[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect email format.")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [MaxLength(100), MinLength(5)]
        [StringLength(100, MinimumLength = 5)]
        public string StreetBilling { get; set; }

        [MaxLength(100), MinLength(5)]
        [StringLength(100, MinimumLength = 5)]
        public string CityBilling { get; set; }
        public string StateBilling { get; set; }

        [DataType(DataType.PostalCode)]
        public string ZipCodeBilling { get; set; }

        [MaxLength(100), MinLength(5)]
        [StringLength(100, MinimumLength = 5)]
        public string StreetShipping { get; set; }

        [MaxLength(100), MinLength(5)]
        [StringLength(100, MinimumLength = 5)]
        public string CityShipping { get; set; }
        public string StateShipping {  get; set; }

        [DataType(DataType.PostalCode)]
        public string ZipCodeShipping { get; set; }

        [NotMapped]
        public string NothingBurger { get; set; }
    }
}
