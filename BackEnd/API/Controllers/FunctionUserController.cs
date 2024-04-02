using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionUserController : ControllerBase
    {
        private readonly IFunctionUserService _functionUserService;
        public IMapper _mapper { get; }
        private readonly KUPFDbContext _context;
        public FunctionUserController(IFunctionUserService functionUserService, IMapper mapper, KUPFDbContext context)
        {
            _mapper = mapper;
            _functionUserService = functionUserService;
            _context = context;
        }
        /// <summary>
        /// Api to Add Function User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddFunctionUser")]
        public async Task<ActionResult<int>> AddFunctionUser(FunctionUserDto functionUserDto)
        {
            await _functionUserService.AddFunctionUserAsync(functionUserDto);
            await _context.SaveChangesAsync();
            return functionUserDto.MODULE_ID;
        }
        /// <summary>
        /// Api to Update Function User
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateFunctionUser")]
        public async Task<ActionResult<int>> UpdateFunctionUser(FunctionUserDto functionUserDto)
        {
            if (functionUserDto != null)
            {
                var result = await _functionUserService.UpdatFunctionUserAsync(functionUserDto);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to Delete Function User
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteFunctionUser")]
        public async Task<int> DeleteFunctionUser(int id)
        {
            int result = 0;
            if (id != 0)
            {
                result = await _functionUserService.DeletFunctionUserAsync(id);
            }

            return result;
        }
        /// <summary>
        /// Api to Get Function User By Master Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFunctionUserByMasterIdAsync")]
        public async Task<ActionResult<IEnumerable<FunctionUserDto>>> GetFunctionUserByMasterIdAsync(int masterId)
        {
            var result = await _functionUserService.GetFunctionUserByMasterIdAsync(masterId);
            return Ok(result);
        }
        /// <summary>
        /// Api to Get Function User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFunctionUser")]
        public async Task<ActionResult<FunctionUserDto>> GetFunctionUser()
        {
            var result = await _functionUserService.GetFunctionUserAsync();
            return Ok(result);
        }
        /// <summary>
        /// Api to Add Function For User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddFunctionForUser")]
        public async Task<ActionResult<int>> AddFunctionForUser([FromBody] FunctionForUserDto[] functionForUserDto)
        {
            try
            {
                var userExistingUserRights = _context.FUNCTION_USER
                    .Where(c => c.USER_ID == functionForUserDto.FirstOrDefault().USER_ID && c.MODULE_ID ==
                    functionForUserDto.FirstOrDefault().MODULE_ID).ToList();

                if (userExistingUserRights.Count > 0)
                {
                    await _functionUserService.DeleteFunctionUserByUserIdAsync(functionForUserDto.FirstOrDefault().USER_ID, functionForUserDto.FirstOrDefault().MODULE_ID);
                }

                for (int i = 0; i < functionForUserDto.Length; i++)
                {
                    _context.ChangeTracker.Clear();
                    await _functionUserService.AddFunctionsForUserAsync(functionForUserDto[i]);
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Api to Get Function User By User Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFunctionUserByUserIdAsync")]
        public async Task<ActionResult<IEnumerable<FunctionUserDto>>> GetFunctionUserByUserIdAsync(int id)
        {
            var result = await _functionUserService.GetFunctionUserByUserIdAsync(id);
            //if (!result.Any())
            //{
            //    return RedirectToAction("GetFunctionMst", "FunctionMst");
            //}
            return Ok(result);
        }
        /// <summary>
        /// Api to Get Module Wise Menu Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetModuleWiseMenuItems")]
        public async Task<ActionResult<IEnumerable<FunctionUserDto>>> GetModuleWiseMenuItems()
        {
            var result = await _functionUserService.GetModuleWiseMenuItems();
            return Ok(result);
        }

        /// <summary>
        /// Api to Calculate Yearly Process For Membership
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CalculateYearlyProcessForMembership")]
        public async Task<ActionResult<ResultMDL>> CalculateYearlyProcessForMembership(int periodCode, string loginUserName)
        {
            var result = await _functionUserService.CalculateYearlyProcessForMembership(periodCode, loginUserName);
            return Ok(result);
        }

    }
}
