using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Client
{
    public interface IClient
    {
        List<ClientModel> GetClients(int productId);

        List<TestimonialsModel> GetTestimonials();

        int InsertTestimonial(TestimonialsModel testimonial);
    }
}
