using API.DTOs;
using API.DTOs.EmployeeDto;
using API.Models;
using API.ViewModels.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface IFormHeaderService 
    {

        Task<int> AddFormHeaderAsync(FormTitleHDLanguagedto formTitleDTLanguaged);
    }
}
