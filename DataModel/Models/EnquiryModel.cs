using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{ 
    public class Registration
    {
        public PersonalDetails PersonalDetails { get; set; }
        
        public AddressDetails AddressDetails { get; set; }

        public ContactDetails ContactDetails { get; set; }
    }

    public class PersonalDetails
    {
        public string RegistrationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FatherName { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName { get; set; }
        public int CompanyId { get; set; }
        public int DivisionId { get; set; }
        public int DesignationId { get; set; }
        public string EmpCode { get; set; }
        public DateTime DateofJoining { get; set; }
        public string ProfilePic { get; set; }

    }

    public class AddressDetails
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string PoliceStation { get; set; }
        public string Street { get; set; }
        public string Lane { get; set; }
        public string HouseNo { get; set; }

    }

    public class ContactDetails
    {
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string LandlineNo { get; set; }

    }

}
