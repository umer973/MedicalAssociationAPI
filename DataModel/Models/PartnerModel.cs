using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class PartnerModel
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }

        //public string Logo { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }
    }
}
