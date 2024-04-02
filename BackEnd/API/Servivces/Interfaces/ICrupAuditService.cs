using API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface ICrupAuditService
    {
        int InsertCrupAudit(CrupAuditDto crupAuditDto);
        int UpdatCrupAudit(CrupAuditDto crupAuditDto);
        int DeleteCrupMst(int tenantId, int locationId, Int64 crupId,int mySerial,int auditNo);
        CrupAuditDto GetCrupAudit(int tenantId, int locationId, Int64 crupId, int mySerial, int auditNo);
        int CrupSetCellMaxAudit(Int64 tenantId, int locationId, Int64 crupId, int mySerial);
        ReturnCrupCellMaxSerial CrupSetCellMaxSerial(Int64 tenantId, int locationId, Int64 crupId);
    }
}
