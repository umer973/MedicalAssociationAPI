using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class EnquiryModel
    {
        public string FullName { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }

        public string Comments { get; set; }

        public bool ExistingUser { get; set; }

        public string Trade { get; set; }
    }
}
