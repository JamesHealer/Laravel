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
    public class UserMstController : ControllerBase
    {
        private readonly IUserMstService _userMstServiceService;
        public IMapper _mapper { get; }
        private readonly KUPFDbContext _context;
        public UserMstController(IUserMstService userMstServiceService, IMapper mapper, KUPFDbContext context)
        {
            _mapper = mapper;
            _userMstServiceService = userMstServiceService;
            _context = context;
        }
        /// <summary>
        /// Api to add new user master
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUserMst")]
        public async Task<ActionResult<int>> AddUserMst(UserMstDto userMstDto)
        {
            await _userMstServiceService.AddUserMstAsync(userMstDto);
            await _context.SaveChangesAsync();
            return userMstDto.UserId;
        }
        /// <summary>
        /// Api to update user master by Id
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUserMst")]
        public async Task<ActionResult<int>> UpdateUserMst(UserMstDto userMstDto)
        {
            if (userMstDto != null)
            {
                var result = await _userMstServiceService.UpdatUserMstAsync(userMstDto);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to delete user master by UserId
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUserMst")]
        public async Task<int> DeleteUserMst(int userId)
        {
            int result = 0;
            if (userId != 0)
            {
                result = await _userMstServiceService.DeleteUserMstAsync(userId);
            }

            return result;
        }
        /// <summary>
        /// Api to Get User Master By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserMstById/{userId}")]
        public async Task<ActionResult<IEnumerable<UserMstDto>>> GetUserMstByIdAsync(int userId)        
        {
            var result = await _userMstServiceService.GetUserMstByIdAsync(userId);
            return Ok(result);
        }
        /// <summary>
        /// Api to Get All Users 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserMst")]
        public async Task<UserMstDtoObj> GetUserMst([FromQuery] PaginationParams paginationParams)
        {
            var result = await _userMstServiceService.GetUserMstAsync(paginationParams);
            return  result;
        }
        /// <summary>
        /// Api to Update user password...
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpatePassword")]
        public async Task<ActionResult<UserMstDto>> UpatePassword(UpdatePasswordDto userMstDto)
        {
            var result = await _userMstServiceService.UpatePasswordAsync(userMstDto);
            return Ok(result);
        }  
    }
}
