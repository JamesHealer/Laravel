using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashBoardService;
        public IMapper _mapper { get; }
        private readonly KUPFDbContext _context;
        public DashBoardController(IDashBoardService dashBoardService, IMapper mapper, KUPFDbContext context)
        {
            _mapper = mapper;
            _dashBoardService = dashBoardService;
            _context = context;
        }

        [HttpGet]
        [Route("GetDashBoardData")]
        public async Task<DashBoardModel> GetDashBoardData(int tenentId, int locationId)
        {
            var result = await _dashBoardService.GetDashBoardData(tenentId);
            return  result;
        }
    }
}
