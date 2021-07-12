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
        List<Register> GetClients();

        int InsertClients(Register client);

        List<TestimonialsModel> GetTestimonials();

        int InsertTestimonial(TestimonialsModel testimonial);

    }
}
