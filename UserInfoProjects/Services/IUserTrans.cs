using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInfoProjects.Model;

namespace UserInfoProjects.Services
{
    public interface IUserTrans
    {
        List<UserTransActionResult> GetuserTransActionResults();
    }
}
