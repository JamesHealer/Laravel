using API.DTOs;
using API.Helpers;
using API.Models;
using API.Servivces.Implementation;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
        public IMapper _mapper { get; }
        private readonly KUPFDbContext _context;
        public OffersController(IOfferService offerService, IMapper mapper, KUPFDbContext context)
        {
            _mapper = mapper;
            _offerService = offerService;
            _context = context;
        }
        /// <summary>
        /// Add new offer
        /// </summary>
        /// <param name="serviceSetupDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddOffer")]
        public async Task<ActionResult<int>> AddOffer([FromForm] OffersDto offersDto)
        {
            await _offerService.AddOffer(offersDto);
            await _context.SaveChangesAsync();
            return offersDto.ServiceId;
        }
        /// <summary>
        /// Update existing offers
        /// </summary>
        /// <param name="serviceSetupDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditOffer")]
        public async Task<ActionResult<int>> EditOffer([FromForm] OffersDto offersDto)
        {
            if (offersDto != null)
            {
                var result = await _offerService.EditOffer(offersDto);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Delete offer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteOffer")]
        public async Task<int> DeleteOffer(int id)
        {
            int result = 0;
            if (id != 0)
            {
                result = await _offerService.DeleteOffer(id);
            }
            return result;
        }
        /// <summary>
        /// Get offer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOfferById/{id}")]
        public async Task<ActionResult<ServiceSetupDto>> GetOfferById(int id)
        {
            var result = await _offerService.GetOfferById(id);
            return Ok(result);
        }
        /// <summary>
        /// Get all offers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOffers")]
        public async Task<ServiceSetupDtoObj> GetOffers([FromQuery] PaginationParams paginationParams)
        {
            var result = await _offerService.GetOffers(paginationParams);
            return result;
        }

    }
}
