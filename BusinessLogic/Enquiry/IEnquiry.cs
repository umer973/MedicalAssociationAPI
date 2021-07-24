using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Enquiry
{
    public interface IEnquiry
    {
        int InsertRegistration(Registration registration);

        Object GetAllRegistrations();

        int InsertDownloads(DownloadModel download);


    }
}
