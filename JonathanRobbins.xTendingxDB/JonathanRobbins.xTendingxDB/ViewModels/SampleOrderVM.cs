using System.ComponentModel.DataAnnotations;
using JonathanRobbins.xTendingxDB.Products.Enums;

namespace JonathanRobbins.xTendingxDB.ViewModels
{
    public class SampleOrderVM
    {
        public string ProductId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Role { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string EmailAddress { get; set; }
        public string Number { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostCode { get; set; }
        public ShippingType ShippingType { get; set; }
    }
}
