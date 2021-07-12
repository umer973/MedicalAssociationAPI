using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{ 
    public class Registration
    {
        public ContactDetails ContactDetails { get; set; }

        public AddressDetails AddressDetails { get; set; }

        public PersonalDetails PersonalDetails { get; set; }
    }

    public class ContactDetails
    {
        public string ContactNo { get; set; }
        public string LandlineNo { get; set; }

    }

    public class AddressDetails
    {
        public string address { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public string policestation { get; set; }
        public string street { get; set; }
        public string houseno { get; set; }
        public string Laneno { get; set; }

    }

    public class PersonalDetails
    {
        public int RegistrationId { get; set; }
        public string Logo { get; set; }
        public string UserName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string FUserName { get; set; }
        public string FMiddleName { get; set; }
        public string FLastName { get; set; }
        public string company { get; set; }
        public string division { get; set; }
        public string designation { get; set; }
        public string employeecode { get; set; }
        public string joining { get; set; }
        public string Email { get; set; }

    }

}
