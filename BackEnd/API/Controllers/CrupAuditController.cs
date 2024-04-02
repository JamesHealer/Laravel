using API.DTOs;
using API.Servivces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CrupAuditController : ControllerBase
    {
        private readonly ICrupAuditService _crupAuditService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="crupAuditService"></param>
        public CrupAuditController(ICrupAuditService crupAuditService)
        {
            _crupAuditService = crupAuditService;
        }
        /// <summary>
        /// Api to Add new CrupAudit  
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCrupAudit")]
        public ActionResult<int> AddCrupAudit(CrupAuditDto crupAuditDto)
        {
            int result = _crupAuditService.InsertCrupAudit(crupAuditDto);
            return result;
        }
        /// <summary>
        /// Api to UPdate existing CrupAudit   
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateCrupAudit")]
        public ActionResult<int> UpdateCrupAudit(CrupAuditDto crupAuditDto)
        {
            int result = _crupAuditService.UpdatCrupAudit(crupAuditDto);
            return result;
        }
        /// <summary>
        /// Api to Delete CrupAudit  
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteCrupAudit")]
        public ActionResult<int> DeleteCrupAudit(int tenantId, int locationId, Int64 crupId, int mySerial,int auditNo)
        {
            int result = _crupAuditService.DeleteCrupMst(tenantId, locationId, crupId,mySerial,auditNo);
            return result;
        }
        /// <summary>
        /// Api to select CrupAudit  
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("SelectCrupAudit")]
        public async Task<ActionResult<CrupAuditDto>> SelectCrupAudit(int tenantId, int locationId, long crupId, int mySerial, int auditNo)
        {
            var result = _crupAuditService.GetCrupAudit(tenantId, locationId, crupId,mySerial,auditNo);
            return result;
        }
        /// <summary>
        /// Api to Crup Set Cell Max Audit 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CrupSetCellMaxAudit")]
        public ActionResult<Int64> CrupSetCellMaxAudit(Int64 tenantId, int locationId, Int64 crupId, int mySerial)
        {
            Int64 result = _crupAuditService.CrupSetCellMaxAudit(tenantId, locationId,crupId,mySerial);
            return result;
        }
        /// <summary>
        /// Api to Crup Set Cell Max Serial
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CrupSetCellMaxSerial")]
        public ActionResult<ReturnCrupCellMaxSerial> CrupSetCellMaxSerial(Int64 tenantId, int locationId, Int64 crupId)
        {
            ReturnCrupCellMaxSerial result = new ReturnCrupCellMaxSerial();
            result = _crupAuditService.CrupSetCellMaxSerial(tenantId, locationId, crupId);
            return result;
        }
    }
}
