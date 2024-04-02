using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
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
    public class CrupMstController : ControllerBase
    {
        private readonly ICrupMstServivce _crupMstService;
        public IMapper _mapper { get; }
        private readonly KUPFDbContext _context;
        public CrupMstController(ICrupMstServivce crupMstService, IMapper mapper, KUPFDbContext context)
        {
            _mapper = mapper;
            _crupMstService = crupMstService;
            _context = context;
        }
        /// <summary>
        /// Api to add Crup master
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCrupMst")]
        public ActionResult<int> AddCrupMst(CrupMstDto crupMstDto)
        {
            int result = _crupMstService.InsertCrupMst(crupMstDto);           
            return result;
        }
        /// <summary>
        /// Api to update existing Crup master
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateCrupMst")]
        public ActionResult<int> UpdateCrupMst(CrupMstDto crupMstDto)
        {
            int result = _crupMstService.UpdatCrupMst(crupMstDto);
            return result;
        }
        /// <summary>
        /// Api to delete existing Crup master
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteCrupMst")]
        public ActionResult<int> DeleteCrupMst(int tenantId, int locationId, Int64 crupId)
        {
            int result = _crupMstService.DeleteCrupMst(tenantId, locationId, crupId);
            return result;
        }
        /// <summary>
        /// Api to Select Crup Mst
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("SelectCrupMst")]
        public async Task<ActionResult<CrupMstDto>> SelectCrupMst(int tenantId, int locationId, Int64 crupId)
        {
            var result = _crupMstService.GetCrupMst(tenantId, locationId, crupId);
            return result;
        }
        /// <summary>
        /// Api to Mst Set Cell Max
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("MstSetCellMax")]
        public ActionResult<Int64> MstSetCellMax(int tenantId, int locationId)
        {
            Int64 result = _crupMstService.MstSetCellMax(tenantId, locationId);
            return result;
        }
    }
}
