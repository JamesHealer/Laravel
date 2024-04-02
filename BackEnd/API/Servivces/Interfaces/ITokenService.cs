using API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(string username);
        string GetTokenValueByUserName(string userName);
        bool IsTokenValid(string token);
        int UpdateTokenDetailsByUserName(string userName);
    }
}
