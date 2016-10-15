using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Entities
{
    public class ContactModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string EmailAddress { get; set; }
        public string Number { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }
}
