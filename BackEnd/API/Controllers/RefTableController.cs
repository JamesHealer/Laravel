using API.DTOs;
using API.DTOs.RefTable;
using API.Helpers;
using API.Models;
using API.Servivces;
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
    public class RefTableController : ControllerBase
    {
        private readonly IRefTableService _refTableService;
        public IMapper _mapper { get; }
        private readonly KUPFDbContext _context;
        public RefTableController(IRefTableService refTableService, IMapper mapper, KUPFDbContext context)
        {
            _mapper = mapper;
            _refTableService = refTableService;
            _context = context;
        }
        /// <summary>
        /// Api to Add RefTable
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRefTable")]
        public async Task<ActionResult<int>> AddRefTable(RefTableDto refTableDto)
        {
            await _refTableService.AddRefTableAsync(refTableDto);
            await _context.SaveChangesAsync();
            return refTableDto.Refid;
        }
        /// <summary>
        /// Api to Update RefTable
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateRefTable")]
        public async Task<ActionResult<int>> UpdateRefTable(RefTableDto refTableDto)
        {
            if (refTableDto != null)
            {
                var result = await _refTableService.UpdatRefTableAsync(refTableDto);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to Delete RefTable
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteRefTable")]
        public async Task<int> DeleteRefTable(int refId)
        {
            int result = 0;
            if (refId != 0)
            {
                result = await _refTableService.DeleteRefTableAsync(refId);
            }
            return result;
        }
        /// <summary>
        /// Api to Get RefTable By Id RefType AndSubType
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRefTableByIdRefTypeAndSubType/{refId}/{refType}/{refSubType}")]
        public async Task<ActionResult<IEnumerable<RefTableDto>>> GetRefTableByIdRefTypeAndSubType(int refId, string refType, string refSubType)
        {
            var result = await _refTableService.GetRefTableByIdAsync(refId,refType, refSubType);
            return Ok(result);
        }
        /// <summary>
        /// Api to Get RefTable Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRefTableData")]
        public async Task<ActionResult<IEnumerable<RefTableDto>>> GetRefTableData()
        {
            var result = await _refTableService.GetRefTableAsync();
            return Ok(result);
        }
        /// <summary>
        /// Api to Get RefTable By RefType And SubType
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRefTableByRefTypeAndSubType/{refType}/{refSubType}")]
        public async Task<RefTableDtoListObj> GetRefTableByRefTypeAndSubType([FromQuery] PaginationParams paginationParams,string refType, string refSubType)
        {
            var result = await _refTableService.GetRefTableByRefTypeAndSubTypeAsync(paginationParams,refType, refSubType);
              return result;
        }

        [HttpGet]
        [Route("GetEmployeeHistoryByFilter")]
        public async Task<EmployeeDetailsWithHistoryDtoObj> GetEmployeeHistoryByFilter([FromQuery] PaginationParams paginationParams, int tenentId, int university, int contractType, int departmentFrom, int departmentTo, int position, int serviceType, int periodFrom, int periodTo)
        {
            var result = await _refTableService.GetRefTableByFilterAsync(paginationParams, tenentId, university, contractType, departmentFrom, departmentTo, position, serviceType, periodFrom, periodTo);
            return result;
        }
    }
}
