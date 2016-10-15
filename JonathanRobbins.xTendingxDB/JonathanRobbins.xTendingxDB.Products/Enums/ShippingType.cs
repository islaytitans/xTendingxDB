using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanRobbins.xTendingxDB.Products.Enums
{
    public enum ShippingType
    {
        [Display(Name = "Next day delivery")]
        NextDay = 1,
        [Display(Name = "5 working days")]
        FiveWorkingDays
    }
}
