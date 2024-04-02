using API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface ICrupMstServivce
    {
        int InsertCrupMst(CrupMstDto crupMstDto);
        int UpdatCrupMst(CrupMstDto crupMstDto);
        int DeleteCrupMst(int tenantId, int locationId, Int64 crupId);
        CrupMstDto GetCrupMst(int tenantId,int locationId, Int64 crupId);
        Int64 MstSetCellMax(int tenantId, int locationId);
    }
}
