using API.DTOs.EmployeeDto;
using API.Servivces.Implementation;
using API.Servivces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using API.Models;
using API.ViewModels.Localization;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FormHeaderController : ControllerBase
    {

        private readonly IFormHeaderService _headerService;

        public FormHeaderController(IFormHeaderService  fhService)
        {
            _headerService = fhService;
        }
        /// <summary>
        /// This method is using for adding form header  in english and arabic language
        /// </summary>
        /// <param name="formTitleDTLanguaged"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("AddFormHeader")]
        public async Task<ActionResult<int>> AddFormHeader(FormTitleHDLanguagedto formTitleDTLanguaged)
        {
            try
            {
                var response = await _headerService.AddFormHeaderAsync(formTitleDTLanguaged);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
