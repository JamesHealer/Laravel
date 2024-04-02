using API.Common;
using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces
{
    public class LoginService : ILoginService
    {
        private readonly KUPFDbContext _context;
        public LoginService(KUPFDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(LoginDto loginDto)
        {
            bool isSuccess = false;
            if (!String.IsNullOrWhiteSpace(loginDto.username) && !String.IsNullOrWhiteSpace(loginDto.password))
            {
                string decodedPass = CommonMethods.EncodePass(loginDto.password);
                var result = await _context.DetailedEmployees.Where(c => c.EmployeeLoginId == loginDto.username && c.EmployeePassword == decodedPass).FirstOrDefaultAsync();
                if(result != null)
                {
                    isSuccess = true;
                }
                
            }
            return isSuccess;
        }
    }
}
