using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_INFO.ViewModels;

namespace C_INFO.Interfaces
{
    public interface IJWTManagerRepositorycs
    {
        Tokens Authenicate(LoginViewModel users, bool IsRegister);
    }
}
