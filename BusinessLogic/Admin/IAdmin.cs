

namespace BusinessLogic.Admin
{

    using DataModel.Models;

    public interface IAdmin
    {
        User Login(User user);
    }
}
