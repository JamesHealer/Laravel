using API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Login(LoginDto loginDto);
    }
}
