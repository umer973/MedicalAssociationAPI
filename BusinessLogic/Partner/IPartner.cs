using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Partner
{
    public interface IPartner
    {
        List<PartnerModel> GetPartners();

        int InsertPartners(PartnerModel Partner);
    }
}
