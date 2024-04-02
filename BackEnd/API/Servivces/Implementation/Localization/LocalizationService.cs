using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Common;
using API.DTOs;
using API.DTOs.GetEntityDto;
using API.DTOs.LocalizationDto;
using API.Helpers;
using API.Models;
using API.Servivces.Interfaces;
using API.ViewModels.Localization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace API.Servivces.Implementation.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;
        public LocalizationService(KUPFDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<TestCompaniesDto>> GetCompanyAndEmployees()
        {
            return await _context.TestCompanies
                        .ProjectTo<TestCompaniesDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
        }

        public async Task<IEnumerable<FormTitleHDLanguageDto>> GetFormHeaderLabelsByFormName(string formId, int languageId)
        {
            //var result = await _context.FormTitleHDLanguage.OrderBy(x=>x.OrderBy).Include(o=>o.FormTitleDTLanguage.OrderBy(x=>x.OrderBy)).ToListAsync();
            var result = await _context.FormTitleHDLanguage.Where(c => c.FormID == formId && c.Language == languageId).ToListAsync();
            var data = _mapper.Map<IEnumerable<FormTitleHDLanguageDto>>(result);
            return data;
        }


        public async Task<IEnumerable<FormTitleDTLanguageDto>> GetFormBodyLabelsByFormName(string formId, int languageId)
        {
            var result = await _context.FormTitleDTLanguage.Where(c => c.FormID == formId && c.Language == languageId).ToListAsync();
            var data = _mapper.Map<IEnumerable<FormTitleDTLanguageDto>>(result);
            return data;
        }

        public async Task<IEnumerable<FormTitleHDLanguageDto>> GetAll(string formId, int langId)
        {
            var result = await _context.FormTitleHDLanguage.Where(x => x.FormID == formId && x.Language == langId).Include(c => c.FormTitleDTLanguage).OrderBy(o => o.OrderBy).ToListAsync();

            var data = _mapper.Map<IEnumerable<FormTitleHDLanguageDto>>(result);
            return data;
        }

        public async Task<IEnumerable<FormTitleHDLanguageDto>> GetAllAppLabels()
        {
            var result = await _context.FormTitleHDLanguage.Include(o => o.FormTitleDTLanguage.OrderBy(x => x.OrderBy)).ToListAsync();
            var data = _mapper.Map<IEnumerable<FormTitleHDLanguageDto>>(result);
            return data;
        }
        /// <summary>
        /// Get all form header labels.
        /// </summary>
        /// <returns></returns>
        public async Task<FormTitleHDLanguageDtoObj> GetAllFormHeaderLabels([FromQuery] PaginationModel paginationModel)
        {
            var result =  await _context.FormTitleHDLanguage.OrderBy(c => c.FormID).ToListAsync();
            var data = _mapper.Map<IEnumerable<FormTitleHDLanguageDto>>(result);
            var filterData = new FormTitleHDLanguageDtoObj();
            if (!string.IsNullOrEmpty(paginationModel.Query))
            {
                data = data.Where(u => 
                  u.HeaderName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                  u.SubHeaderName.ToLower().Contains(paginationModel.Query.ToLower()) || 
                u.FormName.ToLower().Contains(paginationModel.Query.ToLower())
                    );
            }
            filterData.TotalRecords = data.Count();
            filterData.FormTitleHDLanguageDto = data.Skip((paginationModel.PageNumber - 1) * paginationModel.PageSize).Take(paginationModel.PageSize).ToList();
            return filterData;

        }
        /// <summary>
        /// Get form header labels by form Id.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FormTitleHDLanguageDto>> GetFormHeaderLabelsByFormId(string formId)
        {
            var result = await _context.FormTitleHDLanguage.Where(c => c.FormID == formId).ToListAsync();
            var data = _mapper.Map<IEnumerable<FormTitleHDLanguageDto>>(result);
            return data;
        }

        /// <summary>
        /// Get form body labels by form Id.
        /// </summary>
        /// <returns></returns>
        public async Task<FormTitleDTLanguageDtoObj> GetFormBodyLabelsByFormId([FromQuery] PaginationModel paginationModel, string formId)
        {
            var result = await _context.FormTitleDTLanguage.Where(c => c.FormID == formId).ToListAsync();
            var data = _mapper.Map<IEnumerable<FormTitleDTLanguageDto>>(result);
            var filterData = new FormTitleDTLanguageDtoObj();
            if (!string.IsNullOrEmpty(paginationModel.Query))
            {
                data = data.Where(u =>
                  u.ArabicTitle.ToLower().Contains(paginationModel.Query.ToLower()) ||
                  u.Title.ToLower().Contains(paginationModel.Query.ToLower())  
                    );
            }
            filterData.TotalRecords = data.Count();
            filterData.FormTitleDTLanguageDto = data.Skip((paginationModel.PageNumber - 1) * paginationModel.PageSize).Take(paginationModel.PageSize).ToList();
            return filterData;
        }

        public async Task<FormTitleHDLanguage> GetFormHeaderById(Guid id)
        {
            var result = await _context.FormTitleHDLanguage.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                //var data = _mapper.Map<FormTitleHDLanguage>(result);
                return result;
            }
            return null;

        }
        /// <summary>
        /// Edit form header labels by Id.
        /// </summary>
        /// <returns></returns>
        public Task<FormTitleDTLanguageDto> EditFormBodyLabels(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<FormTitleDTLanguageDto>> EditFormHeaderLabels(string formId)
        {
            throw new NotImplementedException();
        }

        public void EditFormHeaderLabels(FormTitleHDLanguage formHeader)
        {
            _context.Entry(formHeader).State = EntityState.Modified;
        }

        public void EditFormBodyLabels(FormTitleDTLanguage formTitleDTLanguage)
        {
            _context.Entry(formTitleDTLanguage).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<FormTitleDTLanguage> GetFormBodyById(int id)
        {
            var result = await _context.FormTitleDTLanguage.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }
        // public void Update(AppUser user)
        // {
        //     _context.Entry(user).State = EntityState.Modified;
        // }
    }
}