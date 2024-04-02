using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface IFunctionUserService
    {
        Task<int> AddFunctionUserAsync(FunctionUserDto functionUserDto);
        Task<int> UpdatFunctionUserAsync(FunctionUserDto functionUserDto);
        Task<int> DeletFunctionUserAsync(int id);
        Task<IEnumerable<FunctionUserDto>> GetFunctionUserByMasterIdAsync(int masterId);
        Task<IEnumerable<FunctionUserDto>> GetFunctionUserAsync();

        Task<int> AddFunctionsForUserAsync(FunctionForUserDto functionUserDto);

        Task<IEnumerable<FunctionUserDto>> GetFunctionUserByUserIdAsync(int id);

        Task<int> DeleteFunctionUserByUserIdAsync(int userId,int moduleId);
        Task<IEnumerable<FunctionUserDto>> GetModuleWiseMenuItems();
        Task<IEnumerable<FunctionUserDto>> GetFunctionUserByUserIdAsyncForLogin(int id);

        Task<ResultMDL> CalculateYearlyProcessForMembership(int periodCode, string loginUserName);


    }
}
