using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Register
    {
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string Logo { get; set; }

        public string ContactNo { get; set; }

        public bool IsActive { get; set; }
    }
}
