using API.Common;
using API.DTOs;
using API.DTOs.Common.Enums;
using API.DTOs.EmployeeDto;
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
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class CommunicationService : ICommunicationService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;

        public CommunicationService(KUPFDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddIncomingLetter(LettersHdDto lettersHdDto)
        {
            int result = 0;
            if (_context != null)
            {
                var attachId = _context.TransactionHddms.FromSqlRaw("select isnull(Max(AttachID+1),1) as attachId from  [TransactionHDDMS ] where TenentID='" + lettersHdDto.TenentId + "'").Select(p => p.AttachId).FirstOrDefault();
                var serialNo = _context.TransactionHddms.FromSqlRaw("select isnull(Max(Serialno+1),1) as serialNo from  [TransactionHDDMS ] where tenentId='" + lettersHdDto.TenentId + "' and attachid=1").Select(c => c.Serialno).FirstOrDefault();
                // Server Path for LetterAttachments.
               // var serverPath = @"/kupf1/kupfapi.erp53.com/New/LetterAttachments/";
                var serverPath = @"D:\Offers\";
                var lettersHd = _mapper.Map<LettersHd>(lettersHdDto);
                var crupId = _context.CrupMsts.Max(c => c.CrupId);
                var maxCrupId = crupId + 1;

                lettersHd.Mytransid = CommonMethods.CreateMyTransId();
                lettersHd.CrupId = maxCrupId;
                lettersHd.Active = true;
                lettersHd.Entrydate = DateTime.Now;
                lettersHd.Entrytime = DateTime.Now;

                #region Save Docs
                //
                var attachmentsData = new TransactionHddm
                {
                    TenentId = (int)lettersHdDto.TenentId,
                    Mytransid = lettersHd.Mytransid,
                    AttachId = attachId,
                    Remarks = lettersHdDto.Remarks,
                    Subject = lettersHdDto.Subject,
                    MetaTags = lettersHdDto.MetaTags,
                    Actived = true,
                    CrupId = maxCrupId,
                    CreatedBy = Convert.ToInt32(lettersHdDto.Userid),
                    CreatedDate = DateTime.Now,
                };

                var filePath = string.Empty;
                var fileExtension = string.Empty;
                var fileName = string.Empty;
                var newFileName = string.Empty;
                //if (attachment != null && attachment.Length != 0)
                if (lettersHdDto.appplicationFileDocument.Length != 0 && lettersHdDto.appplicationFileDocument.FileName != null)
                {
                    // Getting old filename without extension...
                    fileName = Path.GetFileNameWithoutExtension(lettersHdDto.appplicationFileDocument.FileName);

                    // Getting file extension...
                    fileExtension = Path.GetExtension(lettersHdDto.appplicationFileDocument.FileName);

                    // Creating new filename and appending unique code....
                    newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                    //
                    filePath = Path.Combine(serverPath, newFileName);

                    attachmentsData.AttachmentPath = filePath;
                    attachmentsData.DocumentType = lettersHdDto.appplicationFileDocType;
                    attachmentsData.AttachmentByName = newFileName;
                    attachmentsData.Serialno = serialNo;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        lettersHdDto.appplicationFileDocument.CopyTo(stream);
                    }
                    await _context.TransactionHddms.AddAsync(attachmentsData);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();
                }
                if (lettersHdDto.civilIdDocument.Length != 0 && lettersHdDto.civilIdDocument.FileName != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(lettersHdDto.civilIdDocument.FileName);
                    fileExtension = Path.GetExtension(lettersHdDto.civilIdDocument.FileName);

                    // Creating new filename and appending unique code....
                    newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                    filePath = Path.Combine(serverPath, newFileName);

                    attachmentsData.AttachmentPath = filePath;
                    attachmentsData.DocumentType = lettersHdDto.civilIdDocType;
                    attachmentsData.AttachmentByName = newFileName;
                    attachmentsData.Serialno = attachmentsData.Serialno + 1;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        lettersHdDto.civilIdDocument.CopyTo(stream);
                    }
                    await _context.TransactionHddms.AddAsync(attachmentsData);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();
                }
                if (lettersHdDto.personalPhotoDocument.Length > 0 || lettersHdDto.personalPhotoDocument != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(lettersHdDto.personalPhotoDocument.FileName);
                    fileExtension = Path.GetExtension(lettersHdDto.personalPhotoDocument.FileName);

                    // Creating new filename and appending unique code....
                    newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                    filePath = Path.Combine(serverPath, newFileName);

                    attachmentsData.AttachmentPath = filePath;
                    attachmentsData.DocumentType = lettersHdDto.personalPhotoDocType;
                    attachmentsData.AttachmentByName = newFileName;
                    attachmentsData.Serialno = attachmentsData.Serialno + 1;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        lettersHdDto.personalPhotoDocument.CopyTo(stream);
                    }
                    await _context.TransactionHddms.AddAsync(attachmentsData);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();
                }
                if (lettersHdDto.workIdDocument.Length > 0 || lettersHdDto.workIdDocument != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(lettersHdDto.workIdDocument.FileName);
                    fileExtension = Path.GetExtension(lettersHdDto.workIdDocument.FileName);

                    // Creating new filename and appending unique code....
                    newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                    filePath = Path.Combine(serverPath, newFileName);

                    attachmentsData.AttachmentPath = filePath;
                    attachmentsData.DocumentType = lettersHdDto.workIdDocType;
                    attachmentsData.AttachmentByName = newFileName;
                    attachmentsData.Serialno = attachmentsData.Serialno + 1;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        lettersHdDto.workIdDocument.CopyTo(stream);
                    }
                    await _context.TransactionHddms.AddAsync(attachmentsData);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();
                }
                if (lettersHdDto.salaryDataDocument.Length > 0 || lettersHdDto.salaryDataDocument != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(lettersHdDto.salaryDataDocument.FileName);
                    fileExtension = Path.GetExtension(lettersHdDto.salaryDataDocument.FileName);

                    // Creating new filename and appending unique code....
                    newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                    filePath = Path.Combine(serverPath, newFileName);

                    attachmentsData.AttachmentPath = filePath;
                    attachmentsData.DocumentType = lettersHdDto.salaryDataDocType;
                    attachmentsData.AttachmentByName = newFileName;
                    attachmentsData.Serialno = attachmentsData.Serialno + 1;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        lettersHdDto.salaryDataDocument.CopyTo(stream);
                    }
                    await _context.TransactionHddms.AddAsync(attachmentsData);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();
                }

                _context.LettersHds.Add(lettersHd);
                result = await _context.SaveChangesAsync();
                #endregion

                #region Save Into CrupAudit
                //
                var auditInfo = _context.Reftables.FirstOrDefault(c => c.Reftype == "Audit" && c.Refsubtype == "Employee");
                var mySerialNo = _context.TblAudits.Count()>0? _context.TblAudits.Max(c => c.MySerial) + 1:1;
                var auditNo = _context.Crupaudits.Max(c => c.AuditNo) + 1;
                var crupAudit = new Crupaudit
                {
                    TenantId = lettersHdDto.TenentId,
                    LocationId = (int)lettersHdDto.LocationId,
                    CrupId = maxCrupId,
                    MySerial = int.Parse(mySerialNo.ToString()),
                    AuditNo = auditNo,
                    AuditType = auditInfo.Shortname,
                    TableName = DbTableEnums.LettersHD.ToString(),
                    FieldName = $"",
                    OldValue = "Non",
                    NewValue = "Inserted",
                    CreatedDate = DateTime.Now,
                    CreatedUserName = lettersHdDto.Username,
                    UserId = Convert.ToInt32(lettersHdDto.Userid),
                    CrudType = CrudTypeEnums.Insert.ToString(),
                    Severity = SeverityEnums.Normal.ToString()
                };
                await _context.Crupaudits.AddAsync(crupAudit);
                await _context.SaveChangesAsync();

                #endregion
            }

            return result;
        }

        public async Task<int> UpdateIncomingLetter(LettersHdDto lettersHdDto)
        {
            int result = 0;
            if (_context != null)
            {
                var existingLetterHd = _context.LettersHds
                    .Where(c => c.Mytransid == lettersHdDto.Mytransid).FirstOrDefault();

                var existingDoc = _context.TransactionHddms.Where(x => x.Mytransid == lettersHdDto.Mytransid).ToList();

                if (existingLetterHd != null)
                {
                    var crupId = _context.CrupMsts.Max(c => c.CrupId);
                    var maxCrupId = crupId + 1;
                   // var serverPath = @"/kupf1/kupfapi.erp53.com/New/LetterAttachments/";
                    var serverPath = @"D:\Offers\";


                    existingLetterHd.Updttime = DateTime.Now;
                    _mapper.Map(lettersHdDto, existingLetterHd);
                    _context.LettersHds.Update(existingLetterHd);
                    result = await _context.SaveChangesAsync();

                    if (existingDoc.Count > 0)
                    {

                        foreach (var item in existingDoc)
                        {
                            #region Save Docs
                            item.Remarks = lettersHdDto.Remarks;
                            item.Subject = lettersHdDto.Subject;
                            item.MetaTags = lettersHdDto.MetaTags;


                            var filePath = string.Empty;
                            var fileExtension = string.Empty;
                            var fileName = string.Empty;
                            var newFileName = string.Empty;
                            //if (attachment != null && attachment.Length != 0)
                            if (lettersHdDto.appplicationFileDocument?.Length != 0 && lettersHdDto.appplicationFileDocument?.FileName != null)
                            {
                                // Getting old filename without extension...
                                fileName = Path.GetFileNameWithoutExtension(lettersHdDto.appplicationFileDocument.FileName);

                                // Getting file extension...
                                fileExtension = Path.GetExtension(lettersHdDto.appplicationFileDocument.FileName);

                                // Creating new filename and appending unique code....
                                newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                                //
                                filePath = Path.Combine(serverPath, newFileName);

                                item.AttachmentPath = filePath;
                                item.DocumentType = lettersHdDto.appplicationFileDocType;
                                item.AttachmentByName = newFileName;
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    lettersHdDto.appplicationFileDocument.CopyTo(stream);
                                }
                                await _context.TransactionHddms.AddAsync(item);
                                await _context.SaveChangesAsync();
                                _context.ChangeTracker.Clear();
                            }
                            if (lettersHdDto.civilIdDocument?.Length != 0 && lettersHdDto.civilIdDocument?.FileName != null)
                            {
                                fileName = Path.GetFileNameWithoutExtension(lettersHdDto.civilIdDocument.FileName);
                                fileExtension = Path.GetExtension(lettersHdDto.civilIdDocument.FileName);

                                // Creating new filename and appending unique code....
                                newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                                filePath = Path.Combine(serverPath, newFileName);

                                item.AttachmentPath = filePath;
                                item.DocumentType = lettersHdDto.civilIdDocType;
                                item.AttachmentByName = newFileName;
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    lettersHdDto.civilIdDocument.CopyTo(stream);
                                }
                                await _context.TransactionHddms.AddAsync(item);
                                await _context.SaveChangesAsync();
                                _context.ChangeTracker.Clear();
                            }
                            if (lettersHdDto.personalPhotoDocument?.Length > 0 || lettersHdDto.personalPhotoDocument != null)
                            {
                                fileName = Path.GetFileNameWithoutExtension(lettersHdDto.personalPhotoDocument.FileName);
                                fileExtension = Path.GetExtension(lettersHdDto.personalPhotoDocument.FileName);

                                // Creating new filename and appending unique code....
                                newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                                filePath = Path.Combine(serverPath, newFileName);

                                item.AttachmentPath = filePath;
                                item.DocumentType = lettersHdDto.personalPhotoDocType;
                                item.AttachmentByName = newFileName;
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    lettersHdDto.personalPhotoDocument.CopyTo(stream);
                                }
                                await _context.TransactionHddms.AddAsync(item);
                                await _context.SaveChangesAsync();
                                _context.ChangeTracker.Clear();
                            }
                            if (lettersHdDto.workIdDocument?.Length > 0 || lettersHdDto.workIdDocument != null)
                            {
                                fileName = Path.GetFileNameWithoutExtension(lettersHdDto.workIdDocument.FileName);
                                fileExtension = Path.GetExtension(lettersHdDto.workIdDocument.FileName);

                                // Creating new filename and appending unique code....
                                newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                                filePath = Path.Combine(serverPath, newFileName);

                                item.AttachmentPath = filePath;
                                item.DocumentType = lettersHdDto.workIdDocType;
                                item.AttachmentByName = newFileName;
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    lettersHdDto.workIdDocument.CopyTo(stream);
                                }
                                await _context.TransactionHddms.AddAsync(item);
                                await _context.SaveChangesAsync();
                                _context.ChangeTracker.Clear();
                            }
                            if (lettersHdDto.salaryDataDocument?.Length > 0 || lettersHdDto.salaryDataDocument != null)
                            {
                                fileName = Path.GetFileNameWithoutExtension(lettersHdDto.salaryDataDocument.FileName);
                                fileExtension = Path.GetExtension(lettersHdDto.salaryDataDocument.FileName);

                                // Creating new filename and appending unique code....
                                newFileName = fileName + "_" + CommonMethods.GenerateFileName() + fileExtension;

                                filePath = Path.Combine(serverPath, newFileName);

                                item.AttachmentPath = filePath;
                                item.DocumentType = lettersHdDto.salaryDataDocType;
                                item.AttachmentByName = newFileName;
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    lettersHdDto.salaryDataDocument.CopyTo(stream);
                                }
                                await _context.TransactionHddms.AddAsync(item);
                                await _context.SaveChangesAsync();
                                _context.ChangeTracker.Clear();
                            }

                            #endregion
                        }

                    }

                    #region Save Into CrupAudit
                    //
                    var auditInfo = _context.Reftables.FirstOrDefault(c => c.Reftype == "Audit" && c.Refsubtype == "Employee");
                    var mySerialNo = _context.TblAudits.Count()>0? _context.TblAudits.Max(c => c.MySerial) + 1:1;
                    var auditNo = _context.Crupaudits.Count()>0? _context.Crupaudits.Max(c => c.AuditNo) + 1:1;
                    var crupAudit = new Crupaudit
                    {
                        TenantId = lettersHdDto.TenentId,
                        LocationId = (int)lettersHdDto.LocationId,
                        CrupId = maxCrupId,
                        MySerial = mySerialNo,
                        AuditNo = auditNo,
                        AuditType = auditInfo.Shortname,
                        TableName = DbTableEnums.LettersHD.ToString(),
                        FieldName = $"",
                        OldValue = "Non",
                        NewValue = "Updated",
                        CreatedDate = DateTime.Now,
                        CreatedUserName = lettersHdDto.Username,
                        UserId = Convert.ToInt32(lettersHdDto.Userid),
                        CrudType = CrudTypeEnums.Edit.ToString(),
                        Severity = SeverityEnums.Normal.ToString()
                    };
                    await _context.Crupaudits.AddAsync(crupAudit);
                    await _context.SaveChangesAsync();

                    #endregion

                }
            }
            return result;
        }

        public async Task<int> DeleteIncomingCommunication(int id)
        {
            int result = 0;

            if (_context != null)
            {
                var letterhd = await _context.LettersHds.FirstOrDefaultAsync(x => x.Mytransid == id);

                if (letterhd != null)
                {
                    _context.LettersHds.Remove(letterhd);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<ReturnSingleLettersHdDto> GetIncomingLetter(int id)
        {
            var lettersHd = await _context.LettersHds.Where(c => c.Mytransid == id).FirstOrDefaultAsync();
            var transactionHddms = await _context.TransactionHddms.Where(c => c.Mytransid == id).ToListAsync();
            //var hddms = _mapper.Map<List<TransactionHDDMSDto>>(transactionHddms);
            var data = new ReturnSingleLettersHdDto
            {
                LetterType = lettersHd.LetterType,
                Mytransid = lettersHd.Mytransid,
                TenentId = lettersHd.TenentId,
                LocationId = lettersHd.LocationId,
                LetterDated = lettersHd.LetterDated,
                SenderReceiverParty = lettersHd.SenderReceiverParty,
                FilledAt = lettersHd.FilledAt,
                EmployeeId = lettersHd.EmployeeId,
                Representative = lettersHd.Representative,
                ReceivedSentDate = lettersHd.ReceivedSentDate,
                Description = lettersHd.Description,
                SearchTag = lettersHd.SearchTag,
                UserDocumentNo = lettersHd.UserDocumentNo,
                approvedBy=lettersHd.approvedBy
            };
            //data.TransactionHDDMSDtos = hddms;
            List<TransactionHDDMSDto> list = new List<TransactionHDDMSDto>();

            foreach (var item in transactionHddms)
            {
                var hddms = new TransactionHDDMSDto()
                {
                    AttachId = item.AttachId,
                    Attachment = File.Exists(item.AttachmentPath)?CommonMethods.GetFileFromFolder(item.AttachmentPath):null,
                    AttachmentByName = item.AttachmentByName,
                    AttachmentPath = item.AttachmentPath,
                    DocumentType = item.DocumentType,
                    MetaTags = item.MetaTags,
                    Mytransid = item.Mytransid,
                    Remarks = item.Remarks,
                    Serialno = item.Serialno,
                    Subject = item.Subject,
                    TenentId = item.TenentId
                };
                list.Add(hddms);
            }
            data.TransactionHDDMSDtos = list;
            return data;
        }

        public Task<List<IncommingCommunicationDto>> GetIncomingLetters()
        {
            var result = (from r in _context.Reftables
                          join s in _context.LettersHds on r.Refid equals s.LetterType
                          join a in _context.Reftables on s.FilledAt equals a.Refid
                          where r.Refsubtype == "Communication" && a.Refsubtype == "Party"
                          && r.Reftype == "KUPF" && a.Reftype == "KUPF" && r.Refid == 1
                          select new IncommingCommunicationDto
                          {
                              searchtag = s.SearchTag,
                              description = s.Description,
                              filledat = a.Refname1,
                              letterdated = s.LetterDated.ToString(),
                              lettertype = r.Shortname,
                              mytransid = s.Mytransid,
                              UserDocumentNo = s.UserDocumentNo,
                              approvedBy=s.approvedBy
                          }).ToListAsync();
            return result;
        }

        public Task<List<IncommingCommunicationDto>> GetOutgoingLetters()
        {
            var result = (from r in _context.Reftables
                          join s in _context.LettersHds on r.Refid equals s.LetterType
                          join a in _context.Reftables on s.FilledAt equals a.Refid
                          where r.Refsubtype == "Communication" && a.Refsubtype == "Party"
                          && r.Reftype == "KUPF" && a.Reftype == "KUPF" && r.Refid==2
                          select new IncommingCommunicationDto
                          {
                              searchtag = s.SearchTag,
                              description = s.Description,
                              filledat = a.Refname1,
                              letterdated = s.LetterDated.ToString(),
                              lettertype = r.Shortname,
                              mytransid = s.Mytransid,
                              UserDocumentNo = s.UserDocumentNo,
                              approvedBy = s.approvedBy
                          }).ToListAsync();
            return result;
        }
    }
}
