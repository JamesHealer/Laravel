using API.DTOs;
using API.DTOs.EmployeeDto;
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
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        private readonly KUPFDbContext _context;
        private readonly ICommonService _commonServiceService;
        private readonly IServiceSetupService _serviceSetupService;
        public IMapper _mapper;

        public WebsiteController(KUPFDbContext context, ICommonService commonServiceService, IMapper mapper, IServiceSetupService serviceSetupService)
        {
            _context = context;
            _mapper = mapper;
            _serviceSetupService = serviceSetupService;
            _commonServiceService = commonServiceService;
        }
        /// <summary>
        /// This api will get all active services from service setup for web menu...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServicesForWebMenu")]
        public async Task<IEnumerable<ServiceSetupServicesDto>> GetServicesForWebMenu()
        {
            var result = await _commonServiceService.GetServicesForWebMenu();
            return result;
        }
        /// <summary>
        /// it is using to add new subscription from website
        /// </summary>
        /// <param name="detailedEmployeeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNewSubscription")]
        public async Task<ActionResult<int>> AddNewSubscription(NewSubscriptionModel newSubscriptionModel)
        {
            var result = await _commonServiceService.AddNewSubscription(newSubscriptionModel);
            await _context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// This api will get all active services from service setup for web menu...
        /// </summary>
        /// <returns></returns>
         [Authorize]
        [HttpGet]
        [Route("GetNewSubscription")]
        public async Task<NewSubscriberDto> GetNewSubscription([FromQuery] PaginationParams paginationParams, int tenentId, int locationId)
        {
            var result = await _commonServiceService.GetNewSubscription(paginationParams,tenentId,locationId);
            return result;
        }

        /// <summary>
        /// This api is used to Add Recieved Offers By Website...
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [Route("AddRecievedOffersByWebsite")]
        public async Task<ActionResult<int>> AddRecievedOffersByWebsite(RecievedOffersModel recievedOffersModel)
        {
            var result = await _commonServiceService.AddRecievedOffersByWebsite(recievedOffersModel);
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
        /// this api is using for english and arabic labels name in FormTitleDTLanguage table
        /// </summary>
        /// <param name="formLabelsLanguageModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddFormLabelsInEnglishAndArabic")]
        public async Task<ActionResult<ResultMDL>> AddFormLabelsInEnglishAndArabic(FormLabelsLanguageModel formLabelsLanguageModel)
        {
            var result = await _commonServiceService.AddFormLabelsInEnglishAndArabic(formLabelsLanguageModel);
            return result;
        }

        [HttpGet]
        [Route("GetOffersForWebsite")]
        public async Task<IEnumerable<ServiceSetupDto>> GetOffersForWebsite()
        {
            var result = await _commonServiceService.GetOffersForWebsite();
            return result;
        }

        /// <summary>
        /// This api will use to  get all recieved offers  from website to show in kupf control panel system...
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetRecievedOffersByWebsite")]
        public async Task<OffersRecievedDto> GetRecievedOffersByWebsite([FromQuery] PaginationParams paginationParams, int tenentId, int locationId)
        {
            var result = await _commonServiceService.GetRecievedOffersByWebsite(paginationParams, tenentId, locationId);
            return result;
        }
    }
}
