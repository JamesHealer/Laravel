using API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface IDisplayCrupAuditService
    {
        Task<IEnumerable<EmployeeActivityLogDto>> GetEmployeeActivityLog(long crupId, int tenentId, int locationId);
    }
}
