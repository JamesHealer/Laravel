using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class FunctionMstService : IFunctionMstService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;

        public FunctionMstService(KUPFDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddFunctionMstAsync(FunctionMstDto functionMstDto)
        {
            int result = 0;
            if (_context != null)
            {
                var newFunctionMst = _mapper.Map<FUNCTION_MST>(functionMstDto);
                await _context.FUNCTION_MST.AddAsync(newFunctionMst);
                result = await _context.SaveChangesAsync();
                return result;
            }
            return result;
        }
        public async Task<int> UpdatFunctionMstAsync(FunctionMstDto functionMstDto)
        {
            int result = 0;
            if (_context != null)
            {
                var existingFunctionMst = _mapper.Map<FUNCTION_MST>(functionMstDto);

                _context.FUNCTION_MST.Update(existingFunctionMst);

                result = await _context.SaveChangesAsync();

                return result;
            };
            return result;
        }
        public async Task<int> DeleteFunctionMstAsync(int id)
        {
            int result = 0;

            if (_context != null)
            {
                var userMst = await _context.FUNCTION_MST.FirstOrDefaultAsync(x => x.MENU_ID == id);

                if (userMst != null)
                {
                    _context.FUNCTION_MST.Remove(userMst);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task<FunctionMstDto> GetFunctionMstByIdAsync(int id)
        {
            var result = await _context.FUNCTION_MST.Where(c => c.MENU_ID == id).FirstOrDefaultAsync();
            var data = _mapper.Map<FunctionMstDto>(result);
            return data;
        }
        //public async Task<IEnumerable<FunctionMstDto>> GetFunctionMstDataAsync()
        //{
        //    try
        //    {
        //    var result = await _context.FUNCTION_MST.Where(x => x.ACTIVE_FLAG ==1).ToListAsync();
        //    var data = _mapper.Map<IEnumerable<FunctionMstDto>>(result);
        //    return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Enumerable.Empty<FunctionMstDto>();
        //    }
        //}

        public async Task<Helpers.PagedList<FunctionMstDto>> GetFunctionMstDataAsync(PaginationModel paginationModel)
        {
            try
            {
                var data = (from e in _context.FUNCTION_MST.Where(x => x.ACTIVE_FLAG == 1)
                              select new FunctionMstDto
                              {
                                  TenentID = e.TenentID,
                                  MENU_ID = e.MENU_ID,
                                  MASTER_ID = e.MASTER_ID,
                                  MODULE_ID = e.MODULE_ID,
                                  MENU_TYPE = e.MENU_TYPE,
                                  MENU_NAMEEnglish = e.MENU_NAMEEnglish,
                                  MENU_NAMEArabic = e.MENU_NAMEArabic,
                                  FULL_NAME = e.FULL_NAME,
                                  LINK = e.LINK,
                                  Urloption = e.Urloption,
                                  URLREWRITE = e.URLREWRITE,
                                  MENU_LOCATION = e.MENU_LOCATION,
                                  MENU_ORDER = e.MENU_ORDER,
                                  DOC_PARENT = e.DOC_PARENT,
                                  CRUP_ID = e.CRUP_ID,
                                  ADDFLAGE = e.ADDFLAGE,
                                  EDITFLAGE = e.EDITFLAGE,
                                  DELFLAGE = e.DELFLAGE,
                                  PRINTFLAGE = e.PRINTFLAGE,
                                  AMIGLOBALE = e.AMIGLOBALE,
                                  MYPERSONAL = e.MYPERSONAL,
                                  SMALLTEXT = e.SMALLTEXT,
                                  ACTIVETILLDATE = e.ACTIVETILLDATE,
                                  ICONPATH = e.ICONPATH,
                                  COMMANLINE = e.COMMANLINE,
                                  ACTIVE_FLAG = e.ACTIVE_FLAG,
                                  METATITLE = e.METATITLE,
                                  METAKEYWORD = e.METAKEYWORD,
                                  METADESCRIPTION = e.METADESCRIPTION,
                                  HEADERVISIBLEDATA = e.HEADERVISIBLEDATA,
                                  HEADERINVISIBLEDATA = e.HEADERINVISIBLEDATA,
                                  FOOTERVISIBLEDATA = e.FOOTERVISIBLEDATA,
                                  FOOTERINVISIBLEDATA = e.FOOTERINVISIBLEDATA,
                                  REFID = e.REFID,
                                  MYBUSID = e.MYBUSID,
                                  LABLEFLAG = e.LABLEFLAG,
                                  SP1 = e.SP1,
                                  SP2 = e.SP2,
                                  SP3 = e.SP3,
                                  SP4 = e.SP4,
                                  SP5 = e.SP5,
                                  SP1Name = e.SP1Name,
                                  SP2Name = e.SP2Name,
                                  SP3Name = e.SP3Name,
                                  SP4Name = e.SP4Name,
                                  SP5Name = e.SP5Name,
                                  ACTIVEMENU = e.ACTIVEMENU,
                                  MENUDATE = e.MENUDATE,
                                  Menu_Level = e.Menu_Level,
                              });
                // var data = _mapper.Map<IEnumerable<FunctionMstDto>>(result).AsQueryable();

                if (!string.IsNullOrEmpty(paginationModel.Query))
                {
                    data = data.Where(u =>
                    u.MENU_NAMEEnglish.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.MENU_NAMEArabic.ToLower().Contains(paginationModel.Query.ToLower()));
                }
                return await Helpers.PagedList<FunctionMstDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);
                ///  return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void CrupMSTSelMAX(int tenantId, int locationId)
        {
            _context.Database.ExecuteSqlRawAsync("spName @TENANT_ID, @LocationID", parameters: new[] { tenantId, locationId });

        }
        public void CrupAuditSelMAXSerial(int tenantId, int locationId, int crupId)
        {
            _context.Database.ExecuteSqlRawAsync("spName @TENANT_ID, @LocationID,@CRUP_ID", parameters: new[] { tenantId, locationId, crupId });

        }
    }
}
