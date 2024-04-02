using API.Common;
using API.DTOs;
using API.DTOs.Common.Enums;
using API.DTOs.EmployeeDto;
using API.Helpers;
using API.Models;
using API.Servivces.Interfaces.DetailedEmployee;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using API.Servivces.Interfaces;
using API.DTOs.LocalizationDto;

namespace API.Servivces.Implementation
{
    public class FormHeaderService : IFormHeaderService
    {

        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;
        public FormHeaderService(KUPFDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddFormHeaderAsync(FormTitleHDLanguagedto formTitleDTLanguaged)
        {
            var result = 0;
            try
            {
                //var newFormHeader = _mapper.Map<Models.FormTitleHDLanguage>(formTitleDTLanguaged);
                var newFormHeader = new FormTitleHDLanguage();
                newFormHeader.Id = new Guid();
                newFormHeader.Status = "Active";
                newFormHeader.TenentId = formTitleDTLanguaged.TenentId;
                newFormHeader.Language = formTitleDTLanguaged.Language;
                newFormHeader.FormID = formTitleDTLanguaged.FormID;
                newFormHeader.FormName = formTitleDTLanguaged.FormID;
                newFormHeader.HeaderName = formTitleDTLanguaged.HeaderName;
                newFormHeader.SubHeaderName = formTitleDTLanguaged.SubHeaderName;
                newFormHeader.Remarks = "OK";
                newFormHeader.FormTitleDTLanguage = new List<FormTitleDTLanguage>();
                foreach (var item in formTitleDTLanguaged.FormTitleDTLanguagedto)
                {
                    var obj = new FormTitleDTLanguage();
                    obj.FormTitleHDLanguageId = newFormHeader.Id;
                    obj.TenentId = item.TenentId;
                    obj.FormID = item.FormID;
                    obj.Language = item.Language;
                    obj.LabelId = item.LabelId;
                    obj.Title = item.Title;
                    obj.ArabicTitle = item.ArabicTitle;
                    obj.RL = item.RL;   ///////  LEFT TO RIGHT OR RIGHT TO LEFT
                    obj.Remarks = item.Remarks;
                    obj.OrderBy = 0;
                    obj.Status = "Active";
                    newFormHeader.FormTitleDTLanguage.Add(obj);
                }

                await _context.FormTitleHDLanguage.AddAsync(newFormHeader);
                result = await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
