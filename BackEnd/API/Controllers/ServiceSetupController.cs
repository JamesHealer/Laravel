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
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceSetupController : ControllerBase
    {
        private readonly IServiceSetupService _serviceSetupService;
        public IMapper _mapper { get; }
        private readonly KUPFDbContext _context;
        public ServiceSetupController(IServiceSetupService serviceSetupService, IMapper mapper, KUPFDbContext context)
        {
            _mapper = mapper;
            _serviceSetupService = serviceSetupService;
            _context = context;
        }
        /// <summary>
        /// Api to Add Service Setup
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddServiceSetup")]
        public async Task<ActionResult<int>> AddServiceSetup(ServiceSetupDto serviceSetupDto)
        {
            await _serviceSetupService.AddServiceSetupAsync(serviceSetupDto);
            await _context.SaveChangesAsync();
            return serviceSetupDto.ServiceId;
        }
        /// <summary>
        /// Api to Update Service Setup
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("EditServiceSetup")]
        public async Task<ActionResult<int>> EditServiceSetup(ServiceSetupDto serviceSetupDto)
        {
            if (serviceSetupDto != null)
            {
                var result = await _serviceSetupService.EditServiceSetupAsync(serviceSetupDto);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to delete Service Setup
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteServiceSetup")]
        public async Task<int> DeleteRefTable(int id)
        {
            int result = 0;
            if (id != 0)
            {
                result = await _serviceSetupService.DeleteServiceSetupAsync(id);
            }
            return result;
        }
        /// <summary>
        /// Api to Get Service Setup By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceSetupById/{id}")]
        public async Task<ActionResult<ServiceSetupDto>> GetServiceSetupById(int id)
        {
            var result = await _serviceSetupService.GetServiceSetupByIdAsync(id);
            return Ok(result);
        }
        /// <summary>
        /// Api to Get Service Setup
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceSetup")]
        public async Task<PagedList<ServiceSetupDto>> GetServiceSetup([FromQuery] PaginationModel paginationModel)
        {
            var result = await _serviceSetupService.GetServiceSetupAsync(paginationModel);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }
        /// <summary>
        /// Api to Get Web Conten tByPageName for website.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWebContentByPageNameAsync/{pageName}")]
        public async Task<ActionResult<ReturnWebContent>> GetWebContentByPageNameAsync(string pageName)
        {
            var result = await _serviceSetupService.GetWebContentByPageNameAsync(pageName);
            return Ok(result);
        }
        /// <summary>
        /// Api to Add Subscription
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddSubscription")]
        public async Task<ActionResult<int>> AddSubscription(ServiceSubscriptionDto serviceSubscriptionDto)
        {
            await _serviceSetupService.AddServiceSubscriptionAsync(serviceSubscriptionDto);
            int result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
