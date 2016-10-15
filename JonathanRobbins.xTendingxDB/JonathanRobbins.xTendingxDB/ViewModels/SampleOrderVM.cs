using System.ComponentModel.DataAnnotations;
using JonathanRobbins.xTendingxDB.Products.Enums;

namespace JonathanRobbins.xTendingxDB.ViewModels
{
    public class SampleOrderVM
    {
        public string ProductSku { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string EmailAddress { get; set; }
        public ShippingType ShippingType { get; set; }
    }
}
