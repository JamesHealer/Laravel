using API.DTOs;
using API.Helpers;
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
    public class FunctionMstController : ControllerBase
    {
        private readonly IFunctionMstService _functionMstService;
        public IMapper _mapper { get; }
        private readonly KUPFDbContext _context;
        public FunctionMstController(IFunctionMstService functionMstService, IMapper mapper, KUPFDbContext context)
        {
            _mapper = mapper;
            _functionMstService = functionMstService;
            _context = context;
        }
        /// <summary>
        /// Api to Add Function Mst
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddFunctionMst")]
        public async Task<ActionResult<int>> AddFunctionMst(FunctionMstDto functionMstDto)
        {
            await _functionMstService.AddFunctionMstAsync(functionMstDto);
            await _context.SaveChangesAsync();
            return functionMstDto.MENU_ID;
        }
        /// <summary>
        /// Api to Update Function Mst
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateFunctionMst")]
        public async Task<ActionResult<int>> UpdateFunctionMst(FunctionMstDto functionMstDto)
        {
            if (functionMstDto != null)
            {
                var result = await _functionMstService.UpdatFunctionMstAsync(functionMstDto);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to Delete Function Mst
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteFunctionMst")]
        public async Task<int> DeleteFunctionMst(int id)
        {
            int result = 0;
            if (id != 0)
            {
                result = await _functionMstService.DeleteFunctionMstAsync(id);
            }
            return result;
        }
        /// <summary>
        /// Api to Get Function Mst By Id Async
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFunctionMstByIdAsync/{id}")]
        public async Task<ActionResult<IEnumerable<FunctionMstDto>>> GetFunctionMstByIdAsync(int id)
        {
            var result = await _functionMstService.GetFunctionMstByIdAsync(id);
            return Ok(result);
        }
        /// <summary>
        /// Api to Get Function Mst
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFunctionMst")]
        public async Task<ActionResult<PagedList<FunctionMstDto>>> GetFunctionMst([FromQuery] PaginationModel paginationModel)
        {
            var result = await _functionMstService.GetFunctionMstDataAsync(paginationModel);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            //   _functionMstService.CrupMSTSelMAX(2, 3);
            return Ok(result);
        }
    }
}
