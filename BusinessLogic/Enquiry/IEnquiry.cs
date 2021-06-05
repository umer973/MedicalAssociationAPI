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
        int InsertEnquiry(EnquiryModel enquiry);

        List<EnquiryModel> GetEnquiry();

        int InsertDownloads(DownloadModel download);


    }
}
