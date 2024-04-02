using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class DisplayCrupAuditService : IDisplayCrupAuditService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;
        public DisplayCrupAuditService(KUPFDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeActivityLogDto>> GetEmployeeActivityLog(long crupId, int tenentId, int locationId)
        {
            var result = _context.Crupaudits.Where(c => c.CrupId == crupId && c.TenantId == tenentId && c.LocationId == locationId).ToList();
            var data = _mapper.Map<IEnumerable<EmployeeActivityLogDto>>(result);
            return data;
        }
    }
}
