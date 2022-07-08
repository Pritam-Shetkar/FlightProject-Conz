using LoginAPIService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPIService.Interface
{
   public interface IJWTMangerRepository
    {
        Tokens Authenticate(LoginViewModel users, bool IsRegister);
    }
}
