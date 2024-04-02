using API.DTOs;
using API.Helpers;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class ServiceSetupService : IServiceSetupService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ServiceSetupService(KUPFDbContext context, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<int> AddServiceSetupAsync(ServiceSetupDto serviceSetupDto)
        {
            int result = 0;

            if (_context != null)
            {
                var maxIdServiceId = (from d in _context.ServiceSetups
                                      where d.TenentId == serviceSetupDto.TenentId
                                      select new
                                      {
                                          ServiceId = d.ServiceId + 1
                                      })
                         .Distinct()
                         .OrderBy(x => 1).Max(c => c.ServiceId);
                var newService = _mapper.Map<ServiceSetup>(serviceSetupDto);
                newService.ServiceId = maxIdServiceId;


                string masterIds = String.Join(",", serviceSetupDto.MasterServiceId);
                newService.MasterServiceId = masterIds;

                //if (serviceSetupDto.File1 != null && serviceSetupDto.File1.Length != 0)
                //{
                //    newService.ElectronicForm1 = serviceSetupDto.File1.FileName;
                //    var path = @"/HostingSpaces/kupf1/kuweb.erp53.com/wwwroot/contents/";
                //    var filePath = Path.Combine(path, serviceSetupDto.File1.FileName);
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        serviceSetupDto.File1.CopyTo(stream);
                //    }
                //}
                //if (serviceSetupDto.File2 != null && serviceSetupDto.File2.Length != 0)
                //{
                //    newService.ElectronicForm2 = serviceSetupDto.File2.FileName;
                //    var path = @"/HostingSpaces/kupf1/kuweb.erp53.com/wwwroot/contents/";
                //    var filePath = Path.Combine(path, serviceSetupDto.File2.FileName);
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        serviceSetupDto.File2.CopyTo(stream);
                //    }
                //}

                await _context.ServiceSetups.AddAsync(newService);
                result = await _context.SaveChangesAsync();
                return result;
            }

            return result;
        }

        public async Task<int> EditServiceSetupAsync(ServiceSetupDto serviceSetupDto)
        {
            int result = 0;
            if (_context != null)
            {
                if (serviceSetupDto != null)
                {
                    var existingService = _context.ServiceSetups.Where(c => c.ServiceId == serviceSetupDto.ServiceId).FirstOrDefault();

                    if(existingService != null)
                    {
                        //if (serviceSetupDto.File1 != null && serviceSetupDto.File1.Length != 0)
                        //{
                        //    existingService.ElectronicForm1 = serviceSetupDto.File1.FileName;
                        //    var path = @"/HostingSpaces/kupf1/kuweb.erp53.com/wwwroot/contents/";
                        //    var filePath = Path.Combine(path, serviceSetupDto.File1.FileName);
                        //    using (var stream = new FileStream(filePath, FileMode.Create))
                        //    {
                        //        serviceSetupDto.File1.CopyTo(stream);
                        //    }
                        //}
                        //if (serviceSetupDto.File2 != null && serviceSetupDto.File2.Length != 0)
                        //{
                        //    existingService.ElectronicForm2 = serviceSetupDto.File2.FileName;
                        //    var path = @"/HostingSpaces/kupf1/kuweb.erp53.com/wwwroot/contents/";
                        //    var filePath = Path.Combine(path, serviceSetupDto.File2.FileName);
                        //    using (var stream = new FileStream(filePath, FileMode.Create))
                        //    {
                        //        serviceSetupDto.File2.CopyTo(stream);
                        //    }
                        //}                        
                        string masterIds = String.Join(",", serviceSetupDto.MasterServiceId);
                        existingService.MasterServiceId = masterIds;
                        _mapper.Map(serviceSetupDto, existingService);
                        _context.ServiceSetups.Update(existingService);
                        result = await _context.SaveChangesAsync();
                    }
                    return result;
                }

            };
            return result;
        }
        public async Task<int> DeleteServiceSetupAsync(int id)
        {
            int result = 0;

            if (_context != null)
            {
                var serviceSetup = await _context.ServiceSetups.FirstOrDefaultAsync(x => x.ServiceId == id);

                if (serviceSetup != null)
                {
                    _context.ServiceSetups.Remove(serviceSetup);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task<ServiceSetupDto> GetServiceSetupByIdAsync(int id)
        {
            var result = await _context.ServiceSetups.Where(c => c.ServiceId == id).FirstOrDefaultAsync();
            var data = _mapper.Map<ServiceSetupDto>(result);
            return data;
        }
        public async Task<PagedList<ServiceSetupDto>> GetServiceSetupAsync(PaginationModel paginationModel)
        {
            var result = (from r in _context.Reftables
                          join s in _context.ServiceSetups
                          on r.Refid equals s.ServiceType
                          where r.Refsubtype == "ServiceType"
                          select new ServiceSetupDto
                          {
                              TenentId = s.TenentId,
                              ServiceId = s.ServiceId,
                              ServiceName1 = s.ServiceName1,
                              ServiceName2 = s.ServiceName2,
                              ServiceType = s.ServiceType,
                              ServiceSubType = s.ServiceSubType,
                              ServiceTypeName = r.Shortname,
                              MinInstallment = s.MinInstallment,
                              MaxInstallment = s.MaxInstallment,
                              AllowDiscountAmount = s.AllowDiscountAmount,
                              AllowedNonEmployes = s.AllowedNonEmployes,
                              OfferImage= s.OfferImage,
                              ServiceIconMob = s.ServiceIconMob,
                              ServiceIconWeb= s.ServiceIconWeb,
                          }).AsQueryable();
            if (!string.IsNullOrEmpty(paginationModel.Query))
            {
                result = result.Where(u =>
                u.ServiceName1.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.ServiceName2.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.ServiceTypeName.ToLower().Contains(paginationModel.Query.ToLower())  
                    );
            }

            return await PagedList<ServiceSetupDto>.CreateAsync(result, paginationModel.PageNumber, paginationModel.PageSize);
        }

        public async Task<ReturnWebContent> GetWebContentByPageNameAsync(string pageName)
        {
            var pageContent = await _context.ServiceSetups.FirstOrDefaultAsync(x => x.EnglishWebPageName == pageName);
            var data = _mapper.Map<ReturnWebContent>(pageContent);
            return data;
        }

        public async Task<int> AddServiceSubscriptionAsync(ServiceSubscriptionDto serviceSubscriptionDto)
        {
            int result = 0;
            if (_context != null)
            {
                if (serviceSubscriptionDto != null)
                {
                    var subscription = _mapper.Map<ServiceSubscription>(serviceSubscriptionDto);
                    await _context.ServiceSubscription.AddAsync(subscription);
                    result = await _context.SaveChangesAsync();                    
                }
            }
            return result;
        }

        public class EnglishJson
        {
            public string para { get; set; }
            public string file1 { get; set; }
            public string file2 { get; set; }
            public string link1 { get; set; }
            public string link2 { get; set; }
        }
        public class ArabicJson
        {
            public string para { get; set; }
            public string file1 { get; set; }
            public string file2 { get; set; }
            public string link1 { get; set; }
            public string link2 { get; set; }
        }

        //List<EnglishJson> _engData = new List<EnglishJson>();
        //EnglishJson eng = new EnglishJson();
        //eng.para = serviceSetupDto.EnglishHTML;

        //if (serviceSetupDto.File1 != null && serviceSetupDto.File1.Length != 0)
        //{
        //    eng.file1 = serviceSetupDto.File1.FileName;
        //}
        //if (serviceSetupDto.File2 != null && serviceSetupDto.File1.Length != 0)
        //{
        //    eng.file2 = serviceSetupDto.File2.FileName;
        //}
        ////
        //eng.link1 = serviceSetupDto.ElectronicForm1URL;
        //eng.link2 = serviceSetupDto.ElectronicForm2URL;
        ////
        //_engData.Add(eng);
        ////
        //string jsonEnglish = JsonConvert.SerializeObject(_engData.ToArray());

        ////write string to file
        //File.WriteAllText(@"/HostingSpaces/kupf1/kuweb.erp53.com/wwwroot/contents/" + serviceSetupDto.EnglishWebPageName + ".json", jsonEnglish);

        //List<ArabicJson> _arabicData = new List<ArabicJson>();
        //ArabicJson ar = new ArabicJson();
        //ar.para = serviceSetupDto.ArabicHTML;

        //if (serviceSetupDto.ElectronicForm1 != null && serviceSetupDto.ElectronicForm1.Length != 0)
        //{
        //    ar.file1 = serviceSetupDto.File1.FileName;
        //}
        //if (serviceSetupDto.ElectronicForm2 != null && serviceSetupDto.ElectronicForm2.Length != 0)
        //{
        //    ar.file2 = serviceSetupDto.File2.FileName;
        //}
        ////
        //ar.link1 = serviceSetupDto.ElectronicForm1URL;
        //ar.link2 = serviceSetupDto.ElectronicForm2URL;

        ////
        //_arabicData.Add(ar);
        ////
        //string jsonArabic = JsonConvert.SerializeObject(_arabicData.ToArray());

        ////write string to file
        //File.WriteAllText(@"/HostingSpaces/kupf1/kuweb.erp53.com/wwwroot/ar/contents/" + serviceSetupDto.ArabicWebPageName + ".json", jsonArabic);

    }
}
