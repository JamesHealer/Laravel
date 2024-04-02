using API.Common;
using API.DTOs;
using API.DTOs.EmployeeDto;
using API.DTOs.LocalizationDto;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly KUPFDbContext _context;
        private readonly IFunctionUserService _functionUserService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        const string TokenValue = "_TokenValue";
        public LoginController(KUPFDbContext context, IFunctionUserService functionUserService, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _functionUserService = functionUserService;
            _mapper = mapper;
            _tokenService = tokenService;
            _tokenService = tokenService;
        }
        /// <summary>
        /// Api to Employee Login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("EmployeeLogin")]
        public async Task<ActionResult<IEnumerable<LoginDto>>> EmployeeLogin(LoginDto loginDto)
        {
            try
            {
                string decodedPass = CommonMethods.EncodePass(loginDto.password);
                var user = await _context.UserMsts
                    .Where(c => c.LoginId == loginDto.username && c.Password == decodedPass && c.TenentId == loginDto.tenentId)
                    .ToListAsync();

                Console.WriteLine(user);
                // Get period code.
                var periodCode = _context.Tblperiods.Where(c => c.PrdStartDate <= DateTime.Now && c.PrdEndDate >= DateTime.Now).FirstOrDefault().PeriodCode;

                // Get the previous code...
                var now = DateTime.Now;
                var firstDayCurrentMonth = new DateTime(now.Year, now.Month, 1);
                var firstDayLastMonth = firstDayCurrentMonth.AddDays(-30);
                var lastDayLastMonth = firstDayCurrentMonth.AddDays(-1);
                var firstDayNextMonth = firstDayCurrentMonth.AddMonths(1);
                var lastDayNextMonth = firstDayNextMonth.AddDays(30);

                var prePeriodCode = _context.Tblperiods.Where(c => c.PrdStartDate <= lastDayLastMonth && c.PrdEndDate >= firstDayLastMonth).FirstOrDefault().PeriodCode;
                //
                var nextPeriodCode = _context.Tblperiods.Where(c => c.PrdStartDate <= lastDayNextMonth && c.PrdEndDate >= firstDayNextMonth).FirstOrDefault().PeriodCode;

                var tokenNo = _tokenService.GetTokenValueByUserName(user[0].LoginId);

                if (tokenNo == null)
                    tokenNo = Convert.ToString(_tokenService.CreateToken(user[0].LoginId));
                else
                {
                    var result = _tokenService.UpdateTokenDetailsByUserName(user[0].LoginId);
                }

                List<LoginDto> userList = new List<LoginDto>();
                if (user.Count() >= 1)
                {
                    for (int i = 0; i < user.Count(); i++)
                    {
                        var dto = new LoginDto
                        {
                            username = user[i].LoginId,
                            LocationId = user[i].LocationId,
                            TenantId = user[i].TenentId,
                            UserId = user[i].UserId,
                            RoleId = user[i].ROLEID,
                            PeriodCode = Convert.ToString(periodCode),
                            PrevPeriodCode = Convert.ToString(prePeriodCode),
                            NextPeriodCode = Convert.ToString(nextPeriodCode),
                            Token = tokenNo
                        };
                        userList.Add(dto);
                    }
                }
                return userList;
            }
            catch (Exception ex)
            {
                String query = _context.UserMsts.ToQueryString();
                
                return BadRequest();
            }

        }
        /// <summary>
        /// Api to Get User Functions By User Id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetUserFunctionsByUserId12")]
        public async Task<ActionResult<IEnumerable<MenuHeadingDto>>> GetUserFunctionsByUserId12(int id)
        {
            try
            {
                List<MenuHeadingDto> menuHeader = new List<MenuHeadingDto>();
                // Get menu data by UserId...
                var result = await _functionUserService.GetFunctionUserByUserIdAsyncForLogin(id);

                if (result.Count() > 0)
                {
                    // If has dashboard access...
                    var dasboard = result.FirstOrDefault(o => o.MENU_ID == 1);
                    if (dasboard != null)
                    {
                        menuHeader.Add(new MenuHeadingDto
                        {
                            HeadingNameEnglish = dasboard.MENU_NAMEEnglish,
                            HeadingNameArabic = dasboard.MENU_NAMEArabic,
                            HeadingIconPath = dasboard.ICONPATH,
                            HeadingSmallText = dasboard.SMALLTEXT,
                            HeadingFullName = dasboard.FULL_NAME,
                            HeadingLink = dasboard.LINK,
                            HeadingURLOption = dasboard.Urloption,
                            HeadingURLRewrite = dasboard.URLREWRITE,
                            HeadingMenuLocation = dasboard.MENU_LOCATION,
                            HeadingMenuOrder = dasboard.MENU_ORDER,
                            HeadingDocParent = dasboard.DOC_PARENT,
                            HeadingAddFlage = dasboard.ADDFLAGE,
                            HeadingEditFlage = dasboard.EDITFLAGE,
                            HeadingDelFlage = dasboard.DELFLAGE,
                            HeadingPrintFlage = dasboard.PRINTFLAGE,
                            HeadingAmIGlobale = dasboard.AMIGLOBALE,
                            HeadingMyPersonal = dasboard.MYPERSONAL,
                            HeadingSp1 = dasboard.SP1,
                            HeadingSp2 = dasboard.SP2,
                            HeadingSp3 = dasboard.SP3,
                            HeadingSp4 = dasboard.SP4,
                            HeadingSp5 = dasboard.SP5,
                            HeadingSpName1 = dasboard.SP1Name,
                            HeadingSpName2 = dasboard.SP2Name,
                            HeadingSpName3 = dasboard.SP3Name,
                            HeadingSpName4 = dasboard.SP4Name,
                            HeadingSpName5 = dasboard.SP5Name

                        });
                    }
                    // Get menu items
                    var menuItems = result.Where(c => c.MENU_TYPE == "1").ToArray();
                    if (menuItems.Length > 0)
                    {
                        for (int x = 0; x <= menuItems.Count() - 1; x++)
                        {
                            menuHeader.Add(new MenuHeadingDto
                            {
                                HeadingNameEnglish = menuItems[x].MENU_NAMEEnglish,
                                HeadingNameArabic = menuItems[x].MENU_NAMEArabic,
                                HeadingMenuId = menuItems[x].MENU_ID,
                                HeadingIconPath = menuItems[x].ICONPATH,
                                HeadingSmallText = menuItems[x].SMALLTEXT,
                                HeadingFullName = menuItems[x].FULL_NAME,
                                HeadingLink = menuItems[x].LINK,
                                HeadingURLOption = menuItems[x].Urloption,
                                HeadingURLRewrite = menuItems[x].URLREWRITE,
                                HeadingMenuLocation = menuItems[x].MENU_LOCATION,
                                HeadingMenuOrder = menuItems[x].MENU_ORDER,
                                HeadingDocParent = menuItems[x].DOC_PARENT,
                                HeadingAddFlage = menuItems[x].ADDFLAGE,
                                HeadingEditFlage = menuItems[x].EDITFLAGE,
                                HeadingDelFlage = menuItems[x].DELFLAGE,
                                HeadingPrintFlage = menuItems[x].PRINTFLAGE,
                                HeadingAmIGlobale = menuItems[x].AMIGLOBALE,
                                HeadingMyPersonal = menuItems[x].MYPERSONAL,
                                HeadingSp1 = menuItems[x].SP1,
                                HeadingSp2 = menuItems[x].SP2,
                                HeadingSp3 = menuItems[x].SP3,
                                HeadingSp4 = menuItems[x].SP4,
                                HeadingSp5 = menuItems[x].SP5,
                                HeadingSpName1 = menuItems[x].SP1Name,
                                HeadingSpName2 = menuItems[x].SP2Name,
                                HeadingSpName3 = menuItems[x].SP3Name,
                                HeadingSpName4 = menuItems[x].SP4Name,
                                HeadingSpName5 = menuItems[x].SP5Name

                            });
                            // To Get Childres of Menu Items...
                            var menuItemsChildrens = result.Where(c => c.MODULE_ID == menuItems[x].MODULE_ID && c.MASTER_ID == menuItems[x].MASTER_ID && c.MENU_NAMEEnglish != menuItems[x].MENU_NAMEEnglish).ToArray();
                            for (int i = 0; i <= menuItemsChildrens.Count() - 1; i++)
                            {
                                menuHeader[x].MenuItems.Add(new MenuItemsDto()
                                {
                                    MenuItemNameEnglish = menuItemsChildrens[i].MENU_NAMEEnglish,
                                    MenuItemNameArabic = menuItemsChildrens[i].MENU_NAMEArabic,
                                    MenuItemIconPath = menuItemsChildrens[i].ICONPATH,
                                    MenuItemSmallText = menuItemsChildrens[i].SMALLTEXT,
                                    MenuItemFullName = menuItemsChildrens[i].FULL_NAME,
                                    MenuItemLink = menuItemsChildrens[i].LINK,
                                    MenuItemURLOption = menuItemsChildrens[i].Urloption,
                                    MenuItemURLRewrite = menuItemsChildrens[i].URLREWRITE,
                                    MenuItemMenuLocation = menuItemsChildrens[i].MENU_LOCATION,
                                    MenuItemMenuOrder = menuItemsChildrens[i].MENU_ORDER,
                                    MenuItemDocParent = menuItemsChildrens[i].DOC_PARENT,
                                    MenuItemAddFlage = menuItemsChildrens[i].ADDFLAGE,
                                    MenuItemEditFlage = menuItemsChildrens[i].EDITFLAGE,
                                    MenuItemDelFlage = menuItemsChildrens[i].DELFLAGE,
                                    MenuItemPrintFlage = menuItemsChildrens[i].PRINTFLAGE,
                                    MenuItemAmIGlobale = menuItemsChildrens[i].AMIGLOBALE,
                                    MenuItemMyPersonal = menuItemsChildrens[i].MYPERSONAL,
                                    MenuItemSp1 = menuItemsChildrens[i].SP1,
                                    MenuItemSp2 = menuItemsChildrens[i].SP2,
                                    MenuItemSp3 = menuItemsChildrens[i].SP3,
                                    MenuItemSp4 = menuItemsChildrens[i].SP4,
                                    MenuItemSp5 = menuItemsChildrens[i].SP5,
                                    MenuItemSpName1 = menuItemsChildrens[i].SP1Name,
                                    MenuItemSpName2 = menuItemsChildrens[i].SP2Name,
                                    MenuItemSpName3 = menuItemsChildrens[i].SP3Name,
                                    MenuItemSpName4 = menuItemsChildrens[i].SP4Name,
                                    MenuItemSpName5 = menuItemsChildrens[i].SP5Name
                                });
                                // var menuItemsGrandChildrens = result.Where(c => c.MODULE_ID == menuItemsChildrens[i].MODULE_ID && c.MENU_TYPE == "3" ).ToArray();
                                if (menuItemsChildrens[i].MENU_TYPE == "3")
                                {
                                    var menuItemsGrandChildrens = result.Where(c => c.MODULE_ID == menuItemsChildrens[i].MODULE_ID && c.MASTER_ID == menuItemsChildrens[i].MENU_ID).ToArray();
                                    for (int z = 0; z < menuItemsGrandChildrens.Count(); z++)
                                    {
                                        menuHeader[x].MenuItems[i].MenuItems.Add(new MenuItemsDto()
                                        {
                                            MENU_ID = menuItemsGrandChildrens[z].MENU_ID,
                                            MASTER_ID = menuItemsGrandChildrens[z].MASTER_ID,
                                            MODULE_ID = menuItemsGrandChildrens[z].MODULE_ID,
                                            MenuItemNameEnglish = menuItemsGrandChildrens[z].MENU_NAMEEnglish,
                                            MenuItemNameArabic = menuItemsGrandChildrens[z].MENU_NAMEArabic,
                                            MenuItemIconPath = menuItemsGrandChildrens[z].ICONPATH,
                                            MenuItemSmallText = menuItemsGrandChildrens[z].SMALLTEXT,
                                            MenuItemFullName = menuItemsGrandChildrens[z].FULL_NAME,
                                            MenuItemLink = menuItemsGrandChildrens[z].LINK,
                                            MenuItemURLOption = menuItemsGrandChildrens[z].Urloption,
                                            MenuItemURLRewrite = menuItemsGrandChildrens[z].URLREWRITE,
                                            MenuItemMenuLocation = menuItemsGrandChildrens[z].MENU_LOCATION,
                                            MenuItemMenuOrder = menuItemsGrandChildrens[z].MENU_ORDER,
                                            MenuItemDocParent = menuItemsGrandChildrens[z].DOC_PARENT,
                                            MenuItemAddFlage = menuItemsGrandChildrens[z].ADDFLAGE,
                                            MenuItemEditFlage = menuItemsGrandChildrens[z].EDITFLAGE,
                                            MenuItemDelFlage = menuItemsGrandChildrens[z].DELFLAGE,
                                            MenuItemPrintFlage = menuItemsGrandChildrens[z].PRINTFLAGE,
                                            MenuItemAmIGlobale = menuItemsGrandChildrens[z].AMIGLOBALE,
                                            MenuItemMyPersonal = menuItemsGrandChildrens[z].MYPERSONAL,
                                            MenuItemSp1 = menuItemsGrandChildrens[z].SP1,
                                            MenuItemSp2 = menuItemsGrandChildrens[z].SP2,
                                            MenuItemSp3 = menuItemsGrandChildrens[z].SP3,
                                            MenuItemSp4 = menuItemsGrandChildrens[z].SP4,
                                            MenuItemSp5 = menuItemsGrandChildrens[z].SP5,
                                            MenuItemSpName1 = menuItemsGrandChildrens[z].SP1Name,
                                            MenuItemSpName2 = menuItemsGrandChildrens[z].SP2Name,
                                            MenuItemSpName3 = menuItemsGrandChildrens[z].SP3Name,
                                            MenuItemSpName4 = menuItemsGrandChildrens[z].SP4Name,
                                            MenuItemSpName5 = menuItemsGrandChildrens[z].SP5Name
                                        });
                                    }
                                }
                            }
                        }
                    }
                    menuHeader[0].listMenuHighLightHeading = new List<FormTitleDTLanguageDto>();
                    var result1 = await _context.FormTitleDTLanguage.Where(c => c.FormID == "MenuHighlightedKeyword").ToListAsync();
                    var data1 = _mapper.Map<IEnumerable<FormTitleDTLanguageDto>>(result1);
                    menuHeader[0].listMenuHighLightHeading.AddRange(data1);
                }
                return Ok(menuHeader);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Api to Employee Login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("MobileLogin")]
        public async Task<ActionResult<DetailedEmployeeDto>> MobileLogin(MobileLoginDto mobileLoginDto)
        {

           // string DecodePass = CommonMethods.DecodePass(mobileLoginDto.password);
           string encryptedPassword  = CommonMethods.EncodePass(mobileLoginDto.password);
            var employee = await _context.DetailedEmployees.
                Where(c => c.EmployeeLoginId == mobileLoginDto.username && c.EmployeePassword == encryptedPassword)
                .FirstOrDefaultAsync();

            var user = _mapper.Map<DetailedEmployeeDto>(employee);
            var tokenNo = _tokenService.GetTokenValueByUserName(user.EmployeeLoginId);

            if (tokenNo == null)
                tokenNo = Convert.ToString(_tokenService.CreateToken(user.EmployeeLoginId));
            user.Token = tokenNo;

            return Ok(user);
        }


        /// <summary>
        /// Api to Get User Functions By User Id
        /// </summary>
        /// <returns></returns>
          [Authorize]
        [HttpGet]
        [Route("GetUserFunctionsByUserId")]
        public async Task<ActionResult<IEnumerable<MenuHeadingDto>>> GetUserFunctionsByUserId(int id)
        {
            try
            {
                List<MenuHeadingDto> menuHeader = new List<MenuHeadingDto>();
                // Get menu data by UserId...
                var result = await _functionUserService.GetFunctionUserByUserIdAsyncForLogin(id);

                if (result.Count() > 0)
                {
                    // If has dashboard access...
                    var dasboard = result.FirstOrDefault(o => o.MENU_ID == 1);
                    if (dasboard != null)
                    {
                        menuHeader.Add(new MenuHeadingDto
                        {
                            HeadingNameEnglish = dasboard.MENU_NAMEEnglish,
                            HeadingNameArabic = dasboard.MENU_NAMEArabic,
                            HeadingIconPath = dasboard.ICONPATH,
                            HeadingSmallText = dasboard.SMALLTEXT,
                            HeadingFullName = dasboard.FULL_NAME,
                            HeadingLink = dasboard.LINK,
                            HeadingURLOption = dasboard.Urloption,
                            HeadingURLRewrite = dasboard.URLREWRITE,
                            HeadingMenuLocation = dasboard.MENU_LOCATION,
                            HeadingMenuOrder = dasboard.MENU_ORDER,
                            HeadingDocParent = dasboard.DOC_PARENT,
                            HeadingAddFlage = dasboard.ADDFLAGE,
                            HeadingEditFlage = dasboard.EDITFLAGE,
                            HeadingDelFlage = dasboard.DELFLAGE,
                            HeadingPrintFlage = dasboard.PRINTFLAGE,
                            HeadingAmIGlobale = dasboard.AMIGLOBALE,
                            HeadingMyPersonal = dasboard.MYPERSONAL,
                            HeadingSp1 = dasboard.SP1,
                            HeadingSp2 = dasboard.SP2,
                            HeadingSp3 = dasboard.SP3,
                            HeadingSp4 = dasboard.SP4,
                            HeadingSp5 = dasboard.SP5,
                            HeadingSpName1 = dasboard.SP1Name,
                            HeadingSpName2 = dasboard.SP2Name,
                            HeadingSpName3 = dasboard.SP3Name,
                            HeadingSpName4 = dasboard.SP4Name,
                            HeadingSpName5 = dasboard.SP5Name

                        });
                    }
                    // Get menu items
                    var menuItems = result.Where(c => c.MASTER_ID == 0).ToArray();
                    if (menuItems.Length > 0)
                    {
                        for (int x = 0; x <= menuItems.Count() - 1; x++)
                        {
                            menuHeader.Add(new MenuHeadingDto
                            {
                                HeadingNameEnglish = menuItems[x].MENU_NAMEEnglish,
                                HeadingNameArabic = menuItems[x].MENU_NAMEArabic,
                                HeadingMenuId = menuItems[x].MENU_ID,
                                HeadingIconPath = menuItems[x].ICONPATH,
                                HeadingSmallText = menuItems[x].SMALLTEXT,
                                HeadingFullName = menuItems[x].FULL_NAME,
                                HeadingLink = menuItems[x].LINK,
                                HeadingURLOption = menuItems[x].Urloption,
                                HeadingURLRewrite = menuItems[x].URLREWRITE,
                                HeadingMenuLocation = menuItems[x].MENU_LOCATION,
                                HeadingMenuOrder = menuItems[x].MENU_ORDER,
                                HeadingDocParent = menuItems[x].DOC_PARENT,
                                HeadingAddFlage = menuItems[x].ADDFLAGE,
                                HeadingEditFlage = menuItems[x].EDITFLAGE,
                                HeadingDelFlage = menuItems[x].DELFLAGE,
                                HeadingPrintFlage = menuItems[x].PRINTFLAGE,
                                HeadingAmIGlobale = menuItems[x].AMIGLOBALE,
                                HeadingMyPersonal = menuItems[x].MYPERSONAL,
                                HeadingSp1 = menuItems[x].SP1,
                                HeadingSp2 = menuItems[x].SP2,
                                HeadingSp3 = menuItems[x].SP3,
                                HeadingSp4 = menuItems[x].SP4,
                                HeadingSp5 = menuItems[x].SP5,
                                HeadingSpName1 = menuItems[x].SP1Name,
                                HeadingSpName2 = menuItems[x].SP2Name,
                                HeadingSpName3 = menuItems[x].SP3Name,
                                HeadingSpName4 = menuItems[x].SP4Name,
                                HeadingSpName5 = menuItems[x].SP5Name

                            });
                            // To Get Childres of Menu Items...
                            var menuItemsChildrens = result.Where(c => c.MASTER_ID == menuItems[x].MENU_ID && c.MENU_NAMEEnglish != menuItems[x].MENU_NAMEEnglish).ToArray();
                            for (int i = 0; i <= menuItemsChildrens.Count() - 1; i++)
                            {
                                menuHeader[x].MenuItems.Add(new MenuItemsDto()
                                {
                                    MenuItemNameEnglish = menuItemsChildrens[i].MENU_NAMEEnglish,
                                    MenuItemNameArabic = menuItemsChildrens[i].MENU_NAMEArabic,
                                    MenuItemIconPath = menuItemsChildrens[i].ICONPATH,
                                    MenuItemSmallText = menuItemsChildrens[i].SMALLTEXT,
                                    MenuItemFullName = menuItemsChildrens[i].FULL_NAME,
                                    MenuItemLink = menuItemsChildrens[i].LINK,
                                    MenuItemURLOption = menuItemsChildrens[i].Urloption,
                                    MenuItemURLRewrite = menuItemsChildrens[i].URLREWRITE,
                                    MenuItemMenuLocation = menuItemsChildrens[i].MENU_LOCATION,
                                    MenuItemMenuOrder = menuItemsChildrens[i].MENU_ORDER,
                                    MenuItemDocParent = menuItemsChildrens[i].DOC_PARENT,
                                    MenuItemAddFlage = menuItemsChildrens[i].ADDFLAGE,
                                    MenuItemEditFlage = menuItemsChildrens[i].EDITFLAGE,
                                    MenuItemDelFlage = menuItemsChildrens[i].DELFLAGE,
                                    MenuItemPrintFlage = menuItemsChildrens[i].PRINTFLAGE,
                                    MenuItemAmIGlobale = menuItemsChildrens[i].AMIGLOBALE,
                                    MenuItemMyPersonal = menuItemsChildrens[i].MYPERSONAL,
                                    MenuItemSp1 = menuItemsChildrens[i].SP1,
                                    MenuItemSp2 = menuItemsChildrens[i].SP2,
                                    MenuItemSp3 = menuItemsChildrens[i].SP3,
                                    MenuItemSp4 = menuItemsChildrens[i].SP4,
                                    MenuItemSp5 = menuItemsChildrens[i].SP5,
                                    MenuItemSpName1 = menuItemsChildrens[i].SP1Name,
                                    MenuItemSpName2 = menuItemsChildrens[i].SP2Name,
                                    MenuItemSpName3 = menuItemsChildrens[i].SP3Name,
                                    MenuItemSpName4 = menuItemsChildrens[i].SP4Name,
                                    MenuItemSpName5 = menuItemsChildrens[i].SP5Name,
                                    MenuLevel = menuItemsChildrens[i].Menu_Level,
                                    MODULE_ID = menuItemsChildrens[i].MODULE_ID,
                                    MASTER_ID = menuItemsChildrens[i].MASTER_ID,
                                    MENU_ID = menuItemsChildrens[i].MENU_ID,
                                });
                                // var menuItemsGrandChildrens = result.Where(c => c.MODULE_ID == menuItemsChildrens[i].MODULE_ID && c.MENU_TYPE == "3" ).ToArray();
                                if (menuItemsChildrens[i].Menu_Level == 2)
                                {
                                    var menuItemsGrandChildrens = result.Where(c => c.MASTER_ID == menuItemsChildrens[i].MENU_ID).ToArray();
                                    for (int z = 0; z < menuItemsGrandChildrens.Count(); z++)
                                    {
                                        menuHeader[x].MenuItems[i].MenuItems.Add(new MenuItemsDto()
                                        {
                                            MENU_ID = menuItemsGrandChildrens[z].MENU_ID,
                                            MASTER_ID = menuItemsGrandChildrens[z].MASTER_ID,
                                            MODULE_ID = menuItemsGrandChildrens[z].MODULE_ID,
                                            MenuItemNameEnglish = menuItemsGrandChildrens[z].MENU_NAMEEnglish,
                                            MenuItemNameArabic = menuItemsGrandChildrens[z].MENU_NAMEArabic,
                                            MenuItemIconPath = menuItemsGrandChildrens[z].ICONPATH,
                                            MenuItemSmallText = menuItemsGrandChildrens[z].SMALLTEXT,
                                            MenuItemFullName = menuItemsGrandChildrens[z].FULL_NAME,
                                            MenuItemLink = menuItemsGrandChildrens[z].LINK,
                                            MenuItemURLOption = menuItemsGrandChildrens[z].Urloption,
                                            MenuItemURLRewrite = menuItemsGrandChildrens[z].URLREWRITE,
                                            MenuItemMenuLocation = menuItemsGrandChildrens[z].MENU_LOCATION,
                                            MenuItemMenuOrder = menuItemsGrandChildrens[z].MENU_ORDER,
                                            MenuItemDocParent = menuItemsGrandChildrens[z].DOC_PARENT,
                                            MenuItemAddFlage = menuItemsGrandChildrens[z].ADDFLAGE,
                                            MenuItemEditFlage = menuItemsGrandChildrens[z].EDITFLAGE,
                                            MenuItemDelFlage = menuItemsGrandChildrens[z].DELFLAGE,
                                            MenuItemPrintFlage = menuItemsGrandChildrens[z].PRINTFLAGE,
                                            MenuItemAmIGlobale = menuItemsGrandChildrens[z].AMIGLOBALE,
                                            MenuItemMyPersonal = menuItemsGrandChildrens[z].MYPERSONAL,
                                            MenuItemSp1 = menuItemsGrandChildrens[z].SP1,
                                            MenuItemSp2 = menuItemsGrandChildrens[z].SP2,
                                            MenuItemSp3 = menuItemsGrandChildrens[z].SP3,
                                            MenuItemSp4 = menuItemsGrandChildrens[z].SP4,
                                            MenuItemSp5 = menuItemsGrandChildrens[z].SP5,
                                            MenuItemSpName1 = menuItemsGrandChildrens[z].SP1Name,
                                            MenuItemSpName2 = menuItemsGrandChildrens[z].SP2Name,
                                            MenuItemSpName3 = menuItemsGrandChildrens[z].SP3Name,
                                            MenuItemSpName4 = menuItemsGrandChildrens[z].SP4Name,
                                            MenuItemSpName5 = menuItemsGrandChildrens[z].SP5Name
                                        });
                                        if (menuItemsGrandChildrens[z].Menu_Level == 3)
                                        {
                                            var menuItemsGrandChildrens3 = result.Where(c => c.MASTER_ID == menuItemsGrandChildrens[z].MENU_ID).ToArray();
                                            for (int z1 = 0; z1 < menuItemsGrandChildrens3.Count(); z1++)
                                            {
                                                menuHeader[x].MenuItems[i].MenuItems[z].MenuItems.Add(new MenuItemsDto()
                                                {
                                                    MENU_ID = menuItemsGrandChildrens3[z1].MENU_ID,
                                                    MASTER_ID = menuItemsGrandChildrens3[z1].MASTER_ID,
                                                    MODULE_ID = menuItemsGrandChildrens3[z1].MODULE_ID,
                                                    MenuItemNameEnglish = menuItemsGrandChildrens3[z1].MENU_NAMEEnglish,
                                                    MenuItemNameArabic = menuItemsGrandChildrens3[z1].MENU_NAMEArabic,
                                                    MenuItemIconPath = menuItemsGrandChildrens3[z1].ICONPATH,
                                                    MenuItemSmallText = menuItemsGrandChildrens3[z1].SMALLTEXT,
                                                    MenuItemFullName = menuItemsGrandChildrens3[z1].FULL_NAME,
                                                    MenuItemLink = menuItemsGrandChildrens3[z1].LINK,
                                                    MenuItemURLOption = menuItemsGrandChildrens3[z1].Urloption,
                                                    MenuItemURLRewrite = menuItemsGrandChildrens3[z1].URLREWRITE,
                                                    MenuItemMenuLocation = menuItemsGrandChildrens3[z1].MENU_LOCATION,
                                                    MenuItemMenuOrder = menuItemsGrandChildrens3[z1].MENU_ORDER,
                                                    MenuItemDocParent = menuItemsGrandChildrens3[z1].DOC_PARENT,
                                                    MenuItemAddFlage = menuItemsGrandChildrens3[z1].ADDFLAGE,
                                                    MenuItemEditFlage = menuItemsGrandChildrens3[z1].EDITFLAGE,
                                                    MenuItemDelFlage = menuItemsGrandChildrens3[z1].DELFLAGE,
                                                    MenuItemPrintFlage = menuItemsGrandChildrens3[z1].PRINTFLAGE,
                                                    MenuItemAmIGlobale = menuItemsGrandChildrens3[z1].AMIGLOBALE,
                                                    MenuItemMyPersonal = menuItemsGrandChildrens3[z1].MYPERSONAL,
                                                    MenuItemSp1 = menuItemsGrandChildrens3[z1].SP1,
                                                    MenuItemSp2 = menuItemsGrandChildrens3[z1].SP2,
                                                    MenuItemSp3 = menuItemsGrandChildrens3[z1].SP3,
                                                    MenuItemSp4 = menuItemsGrandChildrens3[z1].SP4,
                                                    MenuItemSp5 = menuItemsGrandChildrens3[z1].SP5,
                                                    MenuItemSpName1 = menuItemsGrandChildrens3[z1].SP1Name,
                                                    MenuItemSpName2 = menuItemsGrandChildrens3[z1].SP2Name,
                                                    MenuItemSpName3 = menuItemsGrandChildrens3[z1].SP3Name,
                                                    MenuItemSpName4 = menuItemsGrandChildrens3[z1].SP4Name,
                                                    MenuItemSpName5 = menuItemsGrandChildrens3[z1].SP5Name
                                                });
                                                if (menuItemsGrandChildrens3[z1].Menu_Level == 4)
                                                {
                                                    var menuItemsGrandChildrens4 = result.Where(c => c.MASTER_ID == menuItemsGrandChildrens3[z1].MENU_ID).ToArray();
                                                    for (int z2 = 0; z2 < menuItemsGrandChildrens4.Count(); z2++)
                                                    {
                                                        menuHeader[x].MenuItems[i].MenuItems[z].MenuItems[z1].MenuItems.Add(new MenuItemsDto()
                                                        {
                                                            MENU_ID = menuItemsGrandChildrens4[z2].MENU_ID,
                                                            MASTER_ID = menuItemsGrandChildrens4[z2].MASTER_ID,
                                                            MODULE_ID = menuItemsGrandChildrens4[z2].MODULE_ID,
                                                            MenuItemNameEnglish = menuItemsGrandChildrens4[z2].MENU_NAMEEnglish,
                                                            MenuItemNameArabic = menuItemsGrandChildrens4[z2].MENU_NAMEArabic,
                                                            MenuItemIconPath = menuItemsGrandChildrens4[z2].ICONPATH,
                                                            MenuItemSmallText = menuItemsGrandChildrens4[z2].SMALLTEXT,
                                                            MenuItemFullName = menuItemsGrandChildrens4[z2].FULL_NAME,
                                                            MenuItemLink = menuItemsGrandChildrens4[z2].LINK,
                                                            MenuItemURLOption = menuItemsGrandChildrens4[z2].Urloption,
                                                            MenuItemURLRewrite = menuItemsGrandChildrens4[z2].URLREWRITE,
                                                            MenuItemMenuLocation = menuItemsGrandChildrens4[z2].MENU_LOCATION,
                                                            MenuItemMenuOrder = menuItemsGrandChildrens4[z2].MENU_ORDER,
                                                            MenuItemDocParent = menuItemsGrandChildrens4[z2].DOC_PARENT,
                                                            MenuItemAddFlage = menuItemsGrandChildrens4[z2].ADDFLAGE,
                                                            MenuItemEditFlage = menuItemsGrandChildrens4[z2].EDITFLAGE,
                                                            MenuItemDelFlage = menuItemsGrandChildrens4[z2].DELFLAGE,
                                                            MenuItemPrintFlage = menuItemsGrandChildrens4[z2].PRINTFLAGE,
                                                            MenuItemAmIGlobale = menuItemsGrandChildrens4[z2].AMIGLOBALE,
                                                            MenuItemMyPersonal = menuItemsGrandChildrens4[z2].MYPERSONAL,
                                                            MenuItemSp1 = menuItemsGrandChildrens4[z2].SP1,
                                                            MenuItemSp2 = menuItemsGrandChildrens4[z2].SP2,
                                                            MenuItemSp3 = menuItemsGrandChildrens4[z2].SP3,
                                                            MenuItemSp4 = menuItemsGrandChildrens4[z2].SP4,
                                                            MenuItemSp5 = menuItemsGrandChildrens4[z2].SP5,
                                                            MenuItemSpName1 = menuItemsGrandChildrens4[z2].SP1Name,
                                                            MenuItemSpName2 = menuItemsGrandChildrens4[z2].SP2Name,
                                                            MenuItemSpName3 = menuItemsGrandChildrens4[z2].SP3Name,
                                                            MenuItemSpName4 = menuItemsGrandChildrens4[z2].SP4Name,
                                                            MenuItemSpName5 = menuItemsGrandChildrens4[z2].SP5Name
                                                        });
                                                        if (menuItemsGrandChildrens4[z2].Menu_Level == 5)
                                                        {
                                                            var menuItemsGrandChildrens5 = result.Where(c => c.MASTER_ID == menuItemsGrandChildrens4[z2].MENU_ID).ToArray();
                                                            for (int z3 = 0; z3 < menuItemsGrandChildrens5.Count(); z3++)
                                                            {
                                                                menuHeader[x].MenuItems[i].MenuItems[z].MenuItems[z1].MenuItems[z2].MenuItems.Add(new MenuItemsDto()
                                                                {
                                                                    MENU_ID = menuItemsGrandChildrens5[z3].MENU_ID,
                                                                    MASTER_ID = menuItemsGrandChildrens5[z3].MASTER_ID,
                                                                    MODULE_ID = menuItemsGrandChildrens5[z3].MODULE_ID,
                                                                    MenuItemNameEnglish = menuItemsGrandChildrens5[z3].MENU_NAMEEnglish,
                                                                    MenuItemNameArabic = menuItemsGrandChildrens5[z3].MENU_NAMEArabic,
                                                                    MenuItemIconPath = menuItemsGrandChildrens5[z3].ICONPATH,
                                                                    MenuItemSmallText = menuItemsGrandChildrens5[z3].SMALLTEXT,
                                                                    MenuItemFullName = menuItemsGrandChildrens5[z3].FULL_NAME,
                                                                    MenuItemLink = menuItemsGrandChildrens5[z3].LINK,
                                                                    MenuItemURLOption = menuItemsGrandChildrens5[z3].Urloption,
                                                                    MenuItemURLRewrite = menuItemsGrandChildrens5[z3].URLREWRITE,
                                                                    MenuItemMenuLocation = menuItemsGrandChildrens5[z3].MENU_LOCATION,
                                                                    MenuItemMenuOrder = menuItemsGrandChildrens5[z3].MENU_ORDER,
                                                                    MenuItemDocParent = menuItemsGrandChildrens5[z3].DOC_PARENT,
                                                                    MenuItemAddFlage = menuItemsGrandChildrens5[z3].ADDFLAGE,
                                                                    MenuItemEditFlage = menuItemsGrandChildrens5[z3].EDITFLAGE,
                                                                    MenuItemDelFlage = menuItemsGrandChildrens5[z3].DELFLAGE,
                                                                    MenuItemPrintFlage = menuItemsGrandChildrens5[z3].PRINTFLAGE,
                                                                    MenuItemAmIGlobale = menuItemsGrandChildrens5[z3].AMIGLOBALE,
                                                                    MenuItemMyPersonal = menuItemsGrandChildrens5[z3].MYPERSONAL,
                                                                    MenuItemSp1 = menuItemsGrandChildrens5[z3].SP1,
                                                                    MenuItemSp2 = menuItemsGrandChildrens5[z3].SP2,
                                                                    MenuItemSp3 = menuItemsGrandChildrens5[z3].SP3,
                                                                    MenuItemSp4 = menuItemsGrandChildrens5[z3].SP4,
                                                                    MenuItemSp5 = menuItemsGrandChildrens5[z3].SP5,
                                                                    MenuItemSpName1 = menuItemsGrandChildrens5[z3].SP1Name,
                                                                    MenuItemSpName2 = menuItemsGrandChildrens5[z3].SP2Name,
                                                                    MenuItemSpName3 = menuItemsGrandChildrens5[z3].SP3Name,
                                                                    MenuItemSpName4 = menuItemsGrandChildrens5[z3].SP4Name,
                                                                    MenuItemSpName5 = menuItemsGrandChildrens5[z3].SP5Name
                                                                });
                                                                if (menuItemsGrandChildrens5[z3].Menu_Level == 6)
                                                                {
                                                                    var menuItemsGrandChildrens6 = result.Where(c => c.MASTER_ID == menuItemsGrandChildrens5[z3].MENU_ID).ToArray();
                                                                    for (int z4 = 0; z4 < menuItemsGrandChildrens6.Count(); z4++)
                                                                    {
                                                                        menuHeader[x].MenuItems[i].MenuItems[z].MenuItems[z1].MenuItems[z2].MenuItems[z3].MenuItems.Add(new MenuItemsDto()
                                                                        {
                                                                            MENU_ID = menuItemsGrandChildrens6[z4].MENU_ID,
                                                                            MASTER_ID = menuItemsGrandChildrens6[z4].MASTER_ID,
                                                                            MODULE_ID = menuItemsGrandChildrens6[z4].MODULE_ID,
                                                                            MenuItemNameEnglish = menuItemsGrandChildrens6[z4].MENU_NAMEEnglish,
                                                                            MenuItemNameArabic = menuItemsGrandChildrens6[z4].MENU_NAMEArabic,
                                                                            MenuItemIconPath = menuItemsGrandChildrens6[z4].ICONPATH,
                                                                            MenuItemSmallText = menuItemsGrandChildrens6[z4].SMALLTEXT,
                                                                            MenuItemFullName = menuItemsGrandChildrens6[z4].FULL_NAME,
                                                                            MenuItemLink = menuItemsGrandChildrens6[z4].LINK,
                                                                            MenuItemURLOption = menuItemsGrandChildrens6[z4].Urloption,
                                                                            MenuItemURLRewrite = menuItemsGrandChildrens6[z4].URLREWRITE,
                                                                            MenuItemMenuLocation = menuItemsGrandChildrens6[z4].MENU_LOCATION,
                                                                            MenuItemMenuOrder = menuItemsGrandChildrens6[z4].MENU_ORDER,
                                                                            MenuItemDocParent = menuItemsGrandChildrens6[z4].DOC_PARENT,
                                                                            MenuItemAddFlage = menuItemsGrandChildrens6[z4].ADDFLAGE,
                                                                            MenuItemEditFlage = menuItemsGrandChildrens6[z4].EDITFLAGE,
                                                                            MenuItemDelFlage = menuItemsGrandChildrens6[z4].DELFLAGE,
                                                                            MenuItemPrintFlage = menuItemsGrandChildrens6[z4].PRINTFLAGE,
                                                                            MenuItemAmIGlobale = menuItemsGrandChildrens6[z4].AMIGLOBALE,
                                                                            MenuItemMyPersonal = menuItemsGrandChildrens6[z4].MYPERSONAL,
                                                                            MenuItemSp1 = menuItemsGrandChildrens6[z4].SP1,
                                                                            MenuItemSp2 = menuItemsGrandChildrens6[z4].SP2,
                                                                            MenuItemSp3 = menuItemsGrandChildrens6[z4].SP3,
                                                                            MenuItemSp4 = menuItemsGrandChildrens6[z4].SP4,
                                                                            MenuItemSp5 = menuItemsGrandChildrens6[z4].SP5,
                                                                            MenuItemSpName1 = menuItemsGrandChildrens6[z4].SP1Name,
                                                                            MenuItemSpName2 = menuItemsGrandChildrens6[z4].SP2Name,
                                                                            MenuItemSpName3 = menuItemsGrandChildrens6[z4].SP3Name,
                                                                            MenuItemSpName4 = menuItemsGrandChildrens6[z4].SP4Name,
                                                                            MenuItemSpName5 = menuItemsGrandChildrens6[z4].SP5Name
                                                                        });
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    menuHeader[0].listMenuHighLightHeading = new List<FormTitleDTLanguageDto>();
                    var result1 = await _context.FormTitleDTLanguage.Where(c => c.FormID == "MenuHighlightedKeyword").ToListAsync();
                    var data1 = _mapper.Map<IEnumerable<FormTitleDTLanguageDto>>(result1);
                    menuHeader[0].listMenuHighLightHeading.AddRange(data1);
                }
                return Ok(menuHeader);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("ResetEmployeePassword")]
        public async Task<ActionResult<int>> ResetEmployeePassword(int employeeId, string Password, string MobileNo, string Emailid, string EmployeeLoginId)
        {
            try
            {
                int result = 0;
                var existingEmployee = _context.DetailedEmployees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
                if (existingEmployee == null)
                {
                    return result;
                }
                else
                {
                    string encryptedPassword = CommonMethods.EncodePass(Password);
                    existingEmployee.EmployeePassword = encryptedPassword;
                    _context.DetailedEmployees.Update(existingEmployee);
                    result = await _context.SaveChangesAsync();
                    return result;
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

