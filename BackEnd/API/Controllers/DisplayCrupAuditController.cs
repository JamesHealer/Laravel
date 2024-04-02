using API.DTOs;
using API.Models;
using API.Servivces.Implementation;
using API.Servivces.Interfaces;
using API.Servivces.Interfaces.FinancialServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayCrupAuditController : ControllerBase
    {
        
        private readonly IDisplayCrupAuditService _displayCrupAudit;
        public IMapper _mapper;
        public DisplayCrupAuditController(IDisplayCrupAuditService displayCrupAudit, IMapper mapper )
        {
            _displayCrupAudit = displayCrupAudit;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetEmployeeActivityLog")]
        public async Task<IEnumerable<EmployeeActivityLogDto>> GetEmployeeActivityLog(long crupId, int tenentId, int locationId)
        {
            var result = await _displayCrupAudit.GetEmployeeActivityLog(crupId, tenentId, locationId);
            return result;
        }
    }
}
