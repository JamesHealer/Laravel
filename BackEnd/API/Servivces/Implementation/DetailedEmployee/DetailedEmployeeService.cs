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
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Data;

namespace API.Servivces.Implementation.DetailedEmployee
{
    public class DetailedEmployeeService : IDetailedEmployeeService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;
        public DetailedEmployeeService(KUPFDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DetailedEmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var result = await _context.DetailedEmployees.Where(c => c.EmployeeId == id).FirstOrDefaultAsync();
            var data = _mapper.Map<DetailedEmployeeDto>(result);
            return data;
        }



        public async Task<PagedList<DetailedEmployeeDto>> GetEmployeesAsync(PaginationModel paginationModel)
        {
            var data = (from e in _context.DetailedEmployees
                        join r in _context.Reftables
                     on e.Department equals r.Refid
                        where r.Reftype == "KUPF" && r.Refsubtype == "Department"
                        select new DetailedEmployeeDto
                        {
                            EmpCidNum = e.EmpCidNum,
                            Pfid = e.Pfid,
                            EmployeeId = e.EmployeeId,
                            MobileNumber = e.MobileNumber,
                            EnglishName = e.EnglishName,
                            ArabicName = e.ArabicName,
                            RefName1 = r.Refname1,
                            RefName2 = r.Refname2,
                            CreatedDate = e.DateTime
                        }).OrderByDescending(c => c.CreatedDate)
                        .AsQueryable();
            if (!string.IsNullOrEmpty(paginationModel.Query))
            {
                data = data.Where(u => u.RefName1.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.RefName2.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.MobileNumber.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.Pfid.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.EmpCidNum.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.EmployeeId.ToString().Contains(paginationModel.Query.ToLower())
                    );
            }

            return await PagedList<DetailedEmployeeDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);
        }

        public async Task<ResultMDL> ImportEmployeeData(ImportEmpDataModel data)
        {
            var result = new ResultMDL();
            try
            {
                if(_context != null)
                {
                    var crupSerialNo = 0;
                    var crupAuditNo = 0;
                    var employeeId = 0;
                    var crupId = _context.CrupMsts.Max(c => c.CrupId);
                    var auditInfo = _context.Reftables.FirstOrDefault(c => c.Reftype == "Audit" && c.Refsubtype == "Employee");

                    if (_context.Crupaudits.Count() > 0)
                    {
                        crupSerialNo = _context.Crupaudits.Max(c => c.MySerial);
                        crupAuditNo = _context.Crupaudits.Max(c => c.AuditNo);
                    }

                    foreach (var row in data.EmployeeData)
                    {
                        crupId++;
                        crupSerialNo++;
                        crupAuditNo++;

                        // To check whether or not the same employee already exists.
                        var employee = _context.DetailedEmployees.FirstOrDefault(e => e.EmployeeId == row.EmployeeUnivNo);
                        if(employee == null)
                        {
                            employee = new Models.DetailedEmployee
                            {
                                TenentId = data.TenantId,
                                LocationId = data.LocationId,
                                UserId = data.UserId.ToString(),
                                EmployeeId = row.EmployeeUnivNo,
                                EnglishName = row.EnglishNAme,
                                ArabicName = row.ArabicNAme,
                                JoinedDate = row.JoinedDate,
                                Pfid = row.PFNo.ToString(),
                                SubscribedDate = row.SubscribedDate,
                                AgreedSubAmount = row.AgreedSubmt,
                                Department = row.Department,
                                DepartmentName = row.DepartmentName,
                                Salary = row.LastSalary,
                                TerminationDate = row.TerminationDate,
                                EmpGender = (short)row.Gender,
                                MobileNumber = row.Mobile,
                                EmpBirthday = row.Birthday,
                                ContractType = row.ContractType.ToString(),
                                EmpWorkEmail = row.Email,
                                EmpPaciNum = row.EmpPaciNo.ToString(),
                                NationCode = row.Nationality,
                                NationName = row.NationalityName,
                                Next2KinName = row.NextToKin,
                                JobTitleName = row.JobTitleName,
                                JobTitleCode = row.JobTitleCode,
                                // row.EmploymentDate
                                // AmountReceivedTillNow
                                // Occupation
                                // CivilID
                                IsMemberOfFund = false,
                                IsOnSickLeave = false,
                                EmpStatus = row.MemStatus,
                                Subscription_status = null,
                                EmployeeLoginId = row.Mobile,
                                EmployeePassword = CommonMethods.EncodePass(row.Mobile),
                                Active = true,
                                SynId=9999
                            };
                            await _context.DetailedEmployees.AddAsync(employee);
                            await _context.SaveChangesAsync();

                            #region Save Into CrupAudit
                            //
                            var crupAudit = new Crupaudit
                            {
                                TenantId = data.TenantId,
                                LocationId = data.LocationId,
                                CrupId = crupId,
                                MySerial = crupSerialNo,
                                AuditNo = crupAuditNo,
                                AuditType = auditInfo.Shortname,
                                TableName = string.Format("{0}-{1} by Import", DbTableEnums.DetailedEmployee.ToString(), row.EmployeeUnivNo),
                                FieldName = $"",
                                OldValue = "Non",
                                NewValue = "Inserted",
                                CreatedDate = DateTime.Now,
                                CreatedUserName = data.UserName,
                                UserId = Convert.ToInt32(data.UserId),
                                CrudType = CrudTypeEnums.Insert.ToString(),
                                Severity = SeverityEnums.High.ToString()
                            };
                            await _context.Crupaudits.AddAsync(crupAudit);
                            #endregion
                        }
                        else
                        {
                            employee.TenentId = data.TenantId;
                            employee.LocationId = data.LocationId;
                            employee.UserId = data.UserId.ToString();
                            employee.EnglishName = row.EnglishNAme;
                            employee.ArabicName = row.ArabicNAme;
                            employee.JoinedDate = row.JoinedDate;
                            employee.Pfid = row.PFNo.ToString();
                            employee.SubscribedDate = row.SubscribedDate;
                            employee.AgreedSubAmount = row.AgreedSubmt;
                            employee.Department = row.Department;
                            employee.DepartmentName = row.DepartmentName;
                            employee.Salary = row.LastSalary;
                            employee.TerminationDate = row.TerminationDate;
                            employee.EmpGender = (short)row.Gender;
                            employee.MobileNumber = row.Mobile;
                            employee.EmpBirthday = row.Birthday;
                            employee.ContractType = row.ContractType.ToString();
                            employee.EmpWorkEmail = row.Email;
                            employee.EmpPaciNum = row.EmpPaciNo.ToString();
                            employee.NationCode = row.Nationality;
                            employee.NationName = row.NationalityName;
                            employee.Next2KinName = row.NextToKin;
                            employee.SynId = 9999;
                            employee.JobTitleName = row.JobTitleName;
                            employee.JobTitleCode = row.JobTitleCode;
                            // row.EmploymentDate
                            // AmountReceivedTillNow
                            // Occupation
                            // CivilID
                            _context.Update(employee);
                            await _context.SaveChangesAsync();

                            #region Save Into CrupAudit
                            var crupAudit = new Crupaudit
                            {
                                TenantId = data.TenantId,
                                LocationId = data.LocationId,
                                CrupId = crupId,
                                MySerial = crupSerialNo,
                                AuditNo = crupAuditNo,
                                AuditType = auditInfo.Shortname,
                                TableName = string.Format("{0}-{1} by Import", DbTableEnums.DetailedEmployee.ToString(), row.EmployeeUnivNo),
                                FieldName = $"imported fields",
                                OldValue = "",
                                NewValue = "imported",
                                UpdateDate = DateTime.Now,
                                UpdateUserName = data.UserName,
                                UserId = Convert.ToInt32(data.UserId),
                                CrudType = CrudTypeEnums.Edit.ToString(),
                                Severity = SeverityEnums.High.ToString()
                            };
                            await _context.Crupaudits.AddAsync(crupAudit);
                            #endregion
                        }
                    }

                    await _context.SaveChangesAsync();

                    result.Result = 0;
                    result.Message = "Operation Successful";
                }
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ex.HResult;
            }
            return result;
        }

        public async Task<int> AddEmployeeAsync(DetailedEmployeeDto detailedEmployeeDto)
        {
            int result = 0;
            try
            {
                if (_context != null)
                {
                    var crupId = _context.CrupMsts.Max(c => c.CrupId);
                    var maxCrupId = crupId + 1;
                    var newEmployee = _mapper.Map<Models.DetailedEmployee>(detailedEmployeeDto);
                    //newEmployee.LocationId = 1;
                    newEmployee.CRUP_ID = maxCrupId;
                    if (detailedEmployeeDto.IsMemberOfFund == null)
                        newEmployee.IsMemberOfFund = false;

                    if (detailedEmployeeDto.IsOnSickLeave == null)
                        newEmployee.IsOnSickLeave = false;

                    newEmployee.EmpStatus = 1;
                    newEmployee.Subscription_status = null;

                    newEmployee.EmployeeLoginId = detailedEmployeeDto.MobileNumber;
                    newEmployee.EmployeePassword = CommonMethods.EncodePass(detailedEmployeeDto.MobileNumber);
                    newEmployee.Active = true;
                    await _context.DetailedEmployees.AddAsync(newEmployee);
                    await _context.SaveChangesAsync();
                    #region Save Into CrupAudit
                    //
                    var auditInfo = _context.Reftables.FirstOrDefault(c => c.Reftype == "Audit" && c.Refsubtype == "Employee");
                    var mySerialNo = _context.Crupaudits.Max(c => c.MySerial) + 1;
                    var auditNo = _context.Crupaudits.Max(c => c.AuditNo) + 1;
                    var crupAudit = new Crupaudit
                    {
                        TenantId = detailedEmployeeDto.TenentId,
                        LocationId = detailedEmployeeDto.LocationId,
                        CrupId = maxCrupId,
                        MySerial = mySerialNo,
                        AuditNo = auditNo,
                        AuditType = auditInfo.Shortname,
                        TableName = DbTableEnums.DetailedEmployee.ToString(),
                        FieldName = $"",
                        OldValue = "Non",
                        NewValue = "Inserted",
                        CreatedDate = DateTime.Now,
                        CreatedUserName = detailedEmployeeDto.Username,
                        UserId = Convert.ToInt32(detailedEmployeeDto.UserId),
                        CrudType = CrudTypeEnums.Insert.ToString(),
                        Severity = SeverityEnums.Normal.ToString()
                    };
                    await _context.Crupaudits.AddAsync(crupAudit);
                    result = await _context.SaveChangesAsync();
                    return result;
                    #endregion


                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;
        }

        public async Task<int> UpdateEmployeeAsync(DetailedEmployeeDto detailedEmployeeDto)
        {
            int result = 0;
            if (_context != null)
            {

                var existingEmployee = _context.DetailedEmployees
                    .Where(c => c.EmployeeId == detailedEmployeeDto.EmployeeId).FirstOrDefault();

                if (existingEmployee != null)
                {
                    var crupId = _context.CrupMsts.Max(c => c.CrupId);
                    var maxCrupId = crupId + 1;
                    if (existingEmployee.CRUP_ID == 0 || existingEmployee.CRUP_ID == null)
                    {
                        detailedEmployeeDto.EmpStatus = existingEmployee.EmpStatus;
                        detailedEmployeeDto.LoanOPNotPaidAmount = existingEmployee.LoanOPNotPaidAmount;
                        detailedEmployeeDto.LoanOPAmount = existingEmployee.LoanOPAmount;
                        detailedEmployeeDto.SubOPNotPaidAmount = existingEmployee.SubOPNotPaidAmount;
                        detailedEmployeeDto.SubOPAmount = existingEmployee.SubOPAmount;
                        detailedEmployeeDto.Subscription_status = existingEmployee.Subscription_status;
                        _mapper.Map(detailedEmployeeDto, existingEmployee);
                        existingEmployee.LocationId = detailedEmployeeDto.LocationId;
                        existingEmployee.CRUP_ID = maxCrupId;
                        existingEmployee.DateTime = DateTime.Now;
                        _context.DetailedEmployees.Update(existingEmployee);
                        result = await _context.SaveChangesAsync();
                    }
                    else
                    {
                        detailedEmployeeDto.EmpStatus = existingEmployee.EmpStatus;
                        detailedEmployeeDto.Subscription_status = existingEmployee.Subscription_status;
                        _mapper.Map(detailedEmployeeDto, existingEmployee);
                        existingEmployee.LocationId = detailedEmployeeDto.LocationId;
                        existingEmployee.DateTime = DateTime.Now;
                        _context.DetailedEmployees.Update(existingEmployee);
                        result = await _context.SaveChangesAsync();
                    }
                    ////                    
                    //var auditInfo = _context.Reftables.FirstOrDefault(c => c.Reftype == "Audit" && c.Refsubtype == "Employee");
                    //var mySerialNo = _context.TblAudits.Max(c => c.MySerial) +1;
                    //var auditNo = _context.Crupaudits.Max(c => c.AuditNo) + 1;
                    //var crupAudit = new Crupaudit
                    //{
                    //    TenantId = detailedEmployeeDto.TenentId,
                    //    LocationId = detailedEmployeeDto.LocationId,
                    //    CrupId = maxCrupId,
                    //    MySerial = mySerialNo,
                    //    AuditNo = auditNo,
                    //    AuditType = auditInfo.Shortname,
                    //    TableName = DbTableEnums.DetailedEmployee.ToString(),
                    //    FieldName = $"",
                    //    OldValue = $"",
                    //    NewValue = $"",
                    //    CreatedDate = DateTime.Now,
                    //    CreatedUserName = detailedEmployeeDto.Username,
                    //    UserId = Convert.ToInt32(detailedEmployeeDto.UserId),
                    //    CrudType = CrudTypeEnums.Edit.ToString(),
                    //    Severity = SeverityEnums.High.ToString()
                    //};
                    //await _context.Crupaudits.AddAsync(crupAudit);
                    //result = await _context.SaveChangesAsync();

                }

                return result;
            };
            return result;
        }

        public async Task<TransData> DeleteEmployeeAsync(DetailedEmployeeDto detailedEmployeeDto)
        {
            TransData result = null;

            if (_context != null)
            {
                var transactions = await _context.TransactionHds.FirstOrDefaultAsync(x => x.EmployeeId == detailedEmployeeDto.EmployeeId);
                if (transactions != null)
                {
                    result = new TransData();
                    result.Id = transactions.Mytransid;
                    result.Date = transactions.Transdate;
                    return result;
                }
                else 
                {
                    var employee = await _context.DetailedEmployees.FirstOrDefaultAsync(x => x.EmployeeId == detailedEmployeeDto.EmployeeId);

                    if (employee != null)
                    {
                        var data = await CheckPendingTransaction(employee);
                        if (data != null)
                        {
                            return data;
                        }
                        _context.DetailedEmployees.Remove(employee);
                        int count = await _context.SaveChangesAsync();
                        //  
                        var crupId = _context.CrupMsts.Max(c => c.CrupId);
                        var maxCrupId = crupId + 1;
                        //
                        var auditInfo = _context.Reftables.FirstOrDefault(c => c.Reftype == "Audit" && c.Refsubtype == "Employee");
                        var mySerialNo = _context.Crupaudits.Max(c => c.MySerial) + 1;
                        var auditNo = _context.Crupaudits.Max(c => c.AuditNo) + 1;
                        var crupAudit = new Crupaudit
                        {
                            TenantId = detailedEmployeeDto.TenentId,
                            LocationId = detailedEmployeeDto.LocationId,
                            CrupId = maxCrupId,
                            MySerial = mySerialNo,
                            AuditNo = auditNo, // auditInfo.Refid,// (Change this accordingly)	Select Max(AuditNo+1) From CrupAudit Where TENANT_ID = 21 and LocationID = 1 and Crup_Id = 2 and MySerial = 2
                            AuditType = auditInfo.Shortname,
                            TableName = DbTableEnums.DetailedEmployee.ToString(),
                            FieldName = $"",
                            OldValue = "Non",
                            NewValue = "Deleted",
                            CreatedDate = DateTime.Now,
                            CreatedUserName = detailedEmployeeDto.Username,
                            UserId = Convert.ToInt32(detailedEmployeeDto.UserId),
                            CrudType = CrudTypeEnums.Delete.ToString(),
                            Severity = SeverityEnums.High.ToString()

                        };
                        await _context.Crupaudits.AddAsync(crupAudit);
                        await _context.SaveChangesAsync();
                        return count > 0 ? new TransData() : null;
                    }
                    return null;
                }
            }
            return null;
        }

    

        public async Task<string> ValidateEmployeeData(DetailedEmployeeDto detailedEmployeeDto)
        {
            string response = string.Empty;
            if (_context != null)
            {
                // Validate Civil Id
                if (detailedEmployeeDto.EmpCidNum != null && !string.IsNullOrWhiteSpace(detailedEmployeeDto.EmpCidNum))
                {
                    var checkDuplicateCID = _context.DetailedEmployees.Where(c => c.TenentId == detailedEmployeeDto.TenentId
                    && c.LocationId == detailedEmployeeDto.LocationId && c.EmpCidNum == detailedEmployeeDto.EmpCidNum).FirstOrDefault();
                    if (checkDuplicateCID != null)
                    {
                        return response = "1"; // duplicate Civil Id
                    }
                }
                if (detailedEmployeeDto.MobileNumber != null && !string.IsNullOrWhiteSpace(detailedEmployeeDto.MobileNumber))
                {
                    var checkMobileNumber = _context.DetailedEmployees.Where(c => c.TenentId == detailedEmployeeDto.TenentId
                    && c.LocationId == detailedEmployeeDto.LocationId && c.MobileNumber == detailedEmployeeDto.MobileNumber).FirstOrDefault();
                    if (checkMobileNumber != null)
                    {
                        return response = "2"; // duplicate mobile number
                    }
                }
                if (detailedEmployeeDto.EmpWorkEmail != null && !string.IsNullOrWhiteSpace(detailedEmployeeDto.EmpWorkEmail))
                {
                    var checkEmpWorkEmail = _context.DetailedEmployees.Where(c => c.TenentId == detailedEmployeeDto.TenentId
                    && c.LocationId == detailedEmployeeDto.LocationId && c.EmpWorkEmail == detailedEmployeeDto.EmpWorkEmail).FirstOrDefault();
                    if (checkEmpWorkEmail != null)
                    {
                        return response = "3"; // duplicate email
                    }
                }
                if (detailedEmployeeDto.EmployeeId != null && detailedEmployeeDto.EmployeeId != 0)
                {
                    var existingEmployee = _context.DetailedEmployees.Where(c => c.TenentId == detailedEmployeeDto.TenentId
                    && c.LocationId == detailedEmployeeDto.LocationId && c.EmployeeId == detailedEmployeeDto.EmployeeId).FirstOrDefault();
                    if (existingEmployee != null)
                    {
                        return response = "4"; // duplicate employee Id
                    }
                }
                return response = "0";
            }
            return response;
        }

        public async Task<PagedList<DetailedEmployeeDto>> FilterEmployeeListAsync(PaginationParams paginationParams, int filterVal)
        {
            if (filterVal == 1 || filterVal == 2)
            {
                var data = (from e in _context.DetailedEmployees
                            join r in _context.Reftables
                            on e.Department equals r.Refid
                            where r.Reftype == "KUPF" && r.Refsubtype == "Department" &&
                            e.Subscription_status == filterVal
                            select new DetailedEmployeeDto
                            {
                                EmpCidNum = e.EmpCidNum,
                                Pfid = e.Pfid,
                                EmployeeId = e.EmployeeId,
                                MobileNumber = e.MobileNumber,
                                EnglishName = e.EnglishName,
                                ArabicName = e.ArabicName,
                                EmployeeLoginId = e.EmployeeLoginId,
                                EmpWorkEmail = e.EmpWorkEmail,
                                RefName1 = r.Refname1,
                                RefName2 = r.Refname2,
                                CreatedDate = e.DateTime,
                                DepartmentName = e.DepartmentName,
                                SubscriptionDate = e.SubscriptionDate

                            }).OrderByDescending(c => c.CreatedDate)
                        .AsQueryable();
                if (!string.IsNullOrEmpty(paginationParams.Query))
                {
                    data = data.Where(u => u.RefName1.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.RefName2.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.MobileNumber.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.Pfid.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EmpCidNum.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EnglishName.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.ArabicName.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EmployeeId.ToString().Contains(paginationParams.Query.ToLower())
                        );
                }
                return await PagedList<DetailedEmployeeDto>.CreateAsync(data, paginationParams.PageNumber, paginationParams.PageSize);
            }
            else if (filterVal == 3)
            {
                var data = (from e in _context.DetailedEmployees
                            join r in _context.Reftables
                            on e.Department equals r.Refid
                            where r.Reftype == "KUPF" && r.Refsubtype == "Department" &&
                            e.TerminationDate != null //&& e.Termination == "Termination"
                            select new DetailedEmployeeDto
                            {
                                EmpCidNum = e.EmpCidNum,
                                Pfid = e.Pfid,
                                EmployeeId = e.EmployeeId,
                                MobileNumber = e.MobileNumber,
                                EnglishName = e.EnglishName,
                                ArabicName = e.ArabicName,
                                EmployeeLoginId = e.EmployeeLoginId,
                                EmpWorkEmail = e.EmpWorkEmail,
                                RefName1 = r.Refname1,
                                RefName2 = r.Refname2,
                                CreatedDate = e.DateTime
                            }).OrderByDescending(c => c.CreatedDate)
                        .AsQueryable();
                if (!string.IsNullOrEmpty(paginationParams.Query))
                {
                    data = data.Where(u => u.RefName1.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.RefName2.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.MobileNumber.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.Pfid.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EmpCidNum.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EnglishName.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.ArabicName.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EmployeeId.ToString().Contains(paginationParams.Query.ToLower())
                        );
                }
                return await PagedList<DetailedEmployeeDto>.CreateAsync(data, paginationParams.PageNumber, paginationParams.PageSize);
            }
            else
            {
                var data = (from e in _context.DetailedEmployees
                            join r in _context.Reftables
                         on e.Department equals r.Refid
                            where r.Reftype == "KUPF" && r.Refsubtype == "Department"
                            select new DetailedEmployeeDto
                            {
                                EmpCidNum = e.EmpCidNum,
                                Pfid = e.Pfid,
                                EmployeeId = e.EmployeeId,
                                MobileNumber = e.MobileNumber,
                                EnglishName = e.EnglishName,
                                ArabicName = e.ArabicName,
                                EmployeeLoginId = e.EmployeeLoginId,
                                EmpWorkEmail = e.EmpWorkEmail,
                                RefName1 = r.Refname1,
                                RefName2 = r.Refname2,
                                CreatedDate = e.DateTime
                            }).OrderByDescending(c => c.CreatedDate)
                     .AsQueryable();
                if (!string.IsNullOrEmpty(paginationParams.Query))
                {
                    data = data.Where(u => u.RefName1.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.RefName2.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.MobileNumber.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.Pfid.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EmpCidNum.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EnglishName.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.ArabicName.ToLower().Contains(paginationParams.Query.ToLower()) ||
                    u.EmployeeId.ToString().Contains(paginationParams.Query.ToLower())
                        );
                }

                return await PagedList<DetailedEmployeeDto>.CreateAsync(data, paginationParams.PageNumber, paginationParams.PageSize);
            }
        }

        public async Task<ResultMDL> ImportMonthlyData(ImportMonthlyDataModel data)
        {
            var result = new ResultMDL();
            try
            {
                if (_context != null)
                {
                    var crupSerialNo = 0;
                    var crupAuditNo = 0;
                    var crupId = _context.CrupMsts.Max(c => c.CrupId);
                    var auditInfo = _context.Reftables.FirstOrDefault(c => c.Reftype == "Audit" && c.Refsubtype == "Employee");
                    var seqId = _context.TransDTSubMonthlies.Count() > 0 ? _context.TransDTSubMonthlies.Max(t => t.SeqId) : 0;

                    if (_context.Crupaudits.Count() > 0)
                    {
                        crupSerialNo = _context.Crupaudits.Max(c => c.MySerial);
                        crupAuditNo = _context.Crupaudits.Max(c => c.AuditNo);
                    }

                    if (data.UploadType == "1")          // subscription
                    {
                        foreach (var row in data.MonthlyData)
                        {
                            // To update transaction
                            var transaction = await _context.TransactionDts.FirstOrDefaultAsync(t => (t.EmployeeId == row.EmployeeId) && (t.PeriodCode == int.Parse(row.YearMonth)));
                            if (transaction != null)
                            {
                                var diff = transaction.PendingAmount - transaction.ReceivedAmount;
                                transaction.UniversityBatchNo = row.Reference;
                                transaction.ReceivedAmount += row.Amount;
                                transaction.PendingAmount -= row.Amount;
                                transaction.ReceivedDate = DateTime.UtcNow;
                                _context.Update(transaction);

                                if (diff != 0)
                                {
                                    var nextTransaction = await _context.TransactionDts.FirstOrDefaultAsync(t => (t.EmployeeId == row.EmployeeId) && (t.PeriodCode == int.Parse(data.NextPeriodCode)));
                                    if (nextTransaction != null)
                                    {
                                        nextTransaction.PendingAmount = nextTransaction.InstallmentAmount + diff;
                                        _context.Update(nextTransaction);
                                    }
                                }

                                // To update transactionHD
                                var transactionHD = await _context.TransactionHds.FirstOrDefaultAsync(t => t.Mytransid == transaction.Mytransid);
                                if (transactionHD != null)
                                {
                                    if (transactionHD.PaidSubscriptionAmount == null) transactionHD.PaidSubscriptionAmount = row.Amount;
                                    else transactionHD.PaidSubscriptionAmount += row.Amount;
                                    _context.Update(transactionHD);
                                }

                                // To insert transDTSubMonthly
                                var tsm = _context.TransDTSubMonthlies.FirstOrDefault(t => t.EmployeeId == row.EmployeeId);
                                decimal totRecAmount = tsm != null ? _context.TransDTSubMonthlies.Where(t => t.EmployeeId == row.EmployeeId).Max(t => t.TotRecAmount) : 0;

                                var newTransDTSubMonthly = _mapper.Map<TransDTSubMonthly>(transaction);
                                newTransDTSubMonthly.SeqId = seqId++;
                                newTransDTSubMonthly.TotRecAmount = totRecAmount + row.Amount;
                                await _context.TransDTSubMonthlies.AddAsync(newTransDTSubMonthly);
                            }
                        }
                    }
                    else if(data.UploadType == "2")     // loan data
                    {
                        foreach (var row in data.MonthlyData)
                        {
                            // To update transaction
                            var transaction = await _context.TransactionDts.FirstOrDefaultAsync(t => (t.EmployeeId == row.EmployeeId) && (t.PeriodCode == int.Parse(row.YearMonth)));
                            if (transaction != null)
                            {
                                var diff = transaction.PendingAmount - transaction.ReceivedAmount;
                                transaction.UniversityBatchNo = row.Reference;
                                transaction.ReceivedAmount += row.Amount;
                                transaction.PendingAmount -= row.Amount;
                                transaction.ReceivedDate = DateTime.UtcNow;
                                _context.Update(transaction);

                                if (diff != 0)
                                {
                                    var nextTransaction = await _context.TransactionDts.FirstOrDefaultAsync(t => (t.EmployeeId == row.EmployeeId) && (t.PeriodCode == int.Parse(data.NextPeriodCode)));
                                    if (nextTransaction != null)
                                    {
                                        nextTransaction.PendingAmount = nextTransaction.InstallmentAmount + diff;
                                        _context.Update(nextTransaction);
                                    }
                                }

                                // To insert transDTSubMonthly
                                var tsm = _context.TransDTSubMonthlies.FirstOrDefault(t => t.EmployeeId == row.EmployeeId);
                                decimal totRecAmount = tsm != null ? _context.TransDTSubMonthlies.Where(t => t.EmployeeId == row.EmployeeId).Max(t => t.TotRecAmount) : 0;

                                var newTransDTSubMonthly = _mapper.Map<TransDTSubMonthly>(transaction);
                                newTransDTSubMonthly.SeqId = seqId++;
                                newTransDTSubMonthly.TotRecAmount = totRecAmount + row.Amount;
                                await _context.TransDTSubMonthlies.AddAsync(newTransDTSubMonthly);
                            }
                        }
                    }
                    else if(data.UploadType == "3")             // salary change
                    {
                        foreach(var row in data.MonthlyData)
                        {
                            var employee = await _context.DetailedEmployees.FirstOrDefaultAsync(e => e.EmployeeId == row.EmployeeId);
                            if(employee != null)
                            {
                                var oldSalary = employee.Salary;
                                employee.Salary = row.Salary;
                                _context.DetailedEmployees.Update(employee);

                                #region Save Into CrupAudit
                                crupId++;
                                crupAuditNo++;
                                crupSerialNo++;
                                var crupAudit = new Crupaudit
                                {
                                    TenantId = data.TenantId,
                                    LocationId = data.LocationId,
                                    CrupId = crupId,
                                    MySerial = crupSerialNo,
                                    AuditNo = crupAuditNo,
                                    AuditType = auditInfo.Shortname,
                                    TableName = string.Format("{0}-{1}", DbTableEnums.DetailedEmployee.ToString(), row.EmployeeId),
                                    FieldName = "Salary",
                                    OldValue = oldSalary.ToString(),
                                    NewValue = row.Salary.ToString(),
                                    UpdateDate = DateTime.Now,
                                    CreatedUserName = data.UserName,
                                    UserId = Convert.ToInt32(data.UserId),
                                    CrudType = CrudTypeEnums.Edit.ToString(),
                                    Severity = SeverityEnums.High.ToString()
                                };
                                await _context.Crupaudits.AddAsync(crupAudit);
                                #endregion
                            }
                        }
                    }

                    await _context.SaveChangesAsync();

                    result.Result = 0;
                    result.Message = "Operation Successful";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = 1;
            }

            return result;
        }

        public async Task<List<CheckMonthlyDataMDL>> CheckMonthlyData(ImportMonthlyDataModel data)
        {
            var result = new List<CheckMonthlyDataMDL>();
            try
            {
                if(_context != null)
                {
                    if(data.UploadType == "1" || data.UploadType == "2")
                    {
                        foreach (var row in data.MonthlyData)
                        {
                            CheckMonthlyDataMDL r = new CheckMonthlyDataMDL();
                            r.YearMonth = row.YearMonth;
                            r.EmployeeId = row.EmployeeId;
                            r.Exceptions = new List<string>();
                            r.Warnings = new List<string>();

                            var transaction = await _context.TransactionDts.FirstOrDefaultAsync(t => (t.EmployeeId == row.EmployeeId) && (t.PeriodCode == int.Parse(row.YearMonth)));
                            if (transaction == null)
                            {
                                r.Exceptions.Add("Not found");
                                result.Add(r);
                                continue;
                            }

                            var transDtSubMonthly = await _context.TransDTSubMonthlies.FirstOrDefaultAsync(t => (t.EmployeeId == row.EmployeeId && t.PeriodCode == int.Parse(row.YearMonth) && t.UniversityBatchNo == row.Reference));
                            if (transDtSubMonthly != null)
                            {
                                r.Exceptions.Add(string.Format("Record Imported on {0}", transDtSubMonthly.ReceivedDate?.ToString("MM/dd/yyyy")));
                                result.Add(r);
                                continue;
                            }

                            var nextT = await _context.TransactionDts.FirstOrDefaultAsync(t => (t.EmployeeId == row.EmployeeId) && (t.PeriodCode == int.Parse(data.NextPeriodCode)));
                            if (nextT == null)
                            {
                                r.Exceptions.Add("Not found");
                                result.Add(r);
                                continue;
                            }

                            var diff = transaction.InstallmentAmount - transaction.ReceivedAmount;
                            if (row.Amount > diff) r.Warnings.Add("More paid");
                            else if (row.Amount < diff) r.Warnings.Add("Less paid");
                            result.Add(r);
                        }
                    }
                    else if(data.UploadType == "3")
                    {
                        foreach(var row in data.MonthlyData)
                        {
                            CheckMonthlyDataMDL r = new CheckMonthlyDataMDL();
                            r.YearMonth = row.YearMonth;
                            r.EmployeeId = row.EmployeeId;
                            r.Exceptions = new List<string>();
                            r.Warnings = new List<string>();

                            var employee = await _context.DetailedEmployees.FirstOrDefaultAsync(e => e.EmployeeId == row.EmployeeId);
                            if(employee == null)
                            {
                                r.Exceptions.Add("Not found");
                                result.Add(r);
                                continue;
                            }

                            var transDtSubMonthly = await _context.TransDTSubMonthlies.FirstOrDefaultAsync(t => (t.EmployeeId == row.EmployeeId && t.PeriodCode == int.Parse(row.YearMonth) && t.UniversityBatchNo == row.Reference));
                            if (transDtSubMonthly != null)
                            {
                                r.Exceptions.Add(string.Format("Record Imported on {0}", transDtSubMonthly.ReceivedDate?.ToString("MM/dd/yyyy")));
                                result.Add(r);
                                continue;
                            }

                            if(employee.Salary == row.Salary)
                            {
                                r.Warnings.Add(string.Format("No change"));
                                result.Add(r);
                                continue;
                            }

                            result.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return result;
        }
        public async Task<PagedList<DetailedEmployeeDto>> SixMonthSubcriptionDateFilterEmployeeListAsync(PaginationParams paginationParams, int filterVal)
        {

            var data = (from e in _context.DetailedEmployees
                        join r in _context.Reftables
                     on e.Department equals r.Refid
                        where r.Reftype == "KUPF" && r.Refsubtype == "Department"
                        && e.Subscription_status == 1
                        && e.SubscriptionDate.HasValue
                        && e.SubscriptionDate.Value.Month > DateTime.Today.AddMonths(-6).Month
                        select new DetailedEmployeeDto
                        {
                            EmpCidNum = e.EmpCidNum,
                            Pfid = e.Pfid,
                            EmployeeId = e.EmployeeId,
                            MobileNumber = e.MobileNumber,
                            EnglishName = e.EnglishName,
                            ArabicName = e.ArabicName,
                            EmployeeLoginId = e.EmployeeLoginId,
                            EmpWorkEmail = e.EmpWorkEmail,
                            RefName1 = r.Refname1,
                            RefName2 = r.Refname2,
                            CreatedDate = e.DateTime,
                            DepartmentName = e.DepartmentName,
                            SubscriptionDate = e.SubscriptionDate,
                            EmpStreet1 = e.EmpStreet1,
                            IsChecked=false,
                        }).OrderByDescending(c => c.CreatedDate)
                 .AsQueryable();
            if (!string.IsNullOrEmpty(paginationParams.Query))
            {
                data = data.Where(u => u.RefName1.ToLower().Contains(paginationParams.Query.ToLower()) ||
                u.RefName2.ToLower().Contains(paginationParams.Query.ToLower()) ||
                u.MobileNumber.ToLower().Contains(paginationParams.Query.ToLower()) ||
                u.Pfid.ToLower().Contains(paginationParams.Query.ToLower()) ||
                u.EmpCidNum.ToLower().Contains(paginationParams.Query.ToLower()) ||
                u.EnglishName.ToLower().Contains(paginationParams.Query.ToLower()) ||
                u.ArabicName.ToLower().Contains(paginationParams.Query.ToLower()) ||
                u.EmployeeId.ToString().Contains(paginationParams.Query.ToLower())
                    );
            }

            return await PagedList<DetailedEmployeeDto>.CreateAsync(data, paginationParams.PageNumber, paginationParams.PageSize);

        }




        public async Task<ResultMDL> UploadEmployeeExcelFile(string xmlDocumentWithoutNs, int tenantId, string username, string UploaderName, int PeriodCode)
        {
            var result = new ResultMDL();
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("tenentId", tenantId);
                hashTable.Add("LoginUserName", username);
                hashTable.Add("UploaderName", UploaderName);
                hashTable.Add("PeriodCode", PeriodCode);
                hashTable.Add("xmlData", xmlDocumentWithoutNs);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spImportEmployeeData]", CommandType.StoredProcedure, hashTable);
                if (objDataset != null)
                {
                    result.Result = Convert.ToInt32(objDataset.Tables[0].Rows[0][0]);
                    result.Message = Convert.ToString(objDataset.Tables[0].Rows[0][1]);
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = 4;
            }
            return result;
        }

        public async Task<List<ImportEmployeeServiceMDL>> GetEmployeeImportServiceData(int tenantId, int periodCode, int DataImportFilterValue, string UploaderType)
        {
            var result = new List<ImportEmployeeServiceMDL>();
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("tenentId", tenantId);
                hashTable.Add("periodCode", periodCode);
                hashTable.Add("DataImportFilterValue", DataImportFilterValue);
                hashTable.Add("UploaderType", UploaderType);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spGetImportEmployeeData]", CommandType.StoredProcedure, hashTable);
                if (objDataset != null)
                {
                    result = this.AutoMapToObject<ImportEmployeeServiceMDL>(objDataset.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                var exMessage = ex.Message;

            }
            return result;
        }
        public async Task<ResultMDL> AddEmployeeServiceDataFinalSubmit(EmployeeServiceTransList employeeServiceTransList)
        {
            var dataList = employeeServiceTransList.importEmployeeServiceMDLs;
            //XDocument xmlElements = new XDocument(new XElement("EmployeeServices", new XElement("EmployeeService", dataList.Select(i => CommonMethods.ConvertObjToXML(i)))));
            XDocument xmlElements = new XDocument(new XElement("EmployeeServices", from valueObj in dataList
                                                                                   select new XElement("EmployeeService",
                new XElement("PeriodCode", valueObj.YearMonth), new XElement("UploadType", valueObj.UploadType), new XElement("EmployeeId", valueObj.EmployeeId),
                 new XElement("Reference", valueObj.Reference), new XElement("Previous_Amount", valueObj.Previous_Amount), new XElement("Amount", valueObj.Amount))));
            System.Xml.Linq.XElement xmlDocumentWithoutNs = CommonMethods.RemoveAllNamespaces(System.Xml.Linq.XElement.Parse(xmlElements.ToString()));
            var result = new ResultMDL();
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("tenentId", employeeServiceTransList.tenantId);
                hashTable.Add("loginUserName", employeeServiceTransList.loginUserName);
                hashTable.Add("xmlData", Convert.ToString(xmlDocumentWithoutNs));
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spInsertEmployeeServiceData]", CommandType.StoredProcedure, hashTable);
                if (objDataset != null)
                {
                    result.Result = Convert.ToInt32(objDataset.Tables[0].Rows[0][0]);
                    result.Message = Convert.ToString(objDataset.Tables[0].Rows[0][1]);
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = 4;

            }
            return result;
        }


        public async Task<ResultMDL> EmployeeServiceDataDraftSubmit(EmployeeServiceTransList employeeServiceTransList)
        {
            var dataList = employeeServiceTransList.importEmployeeServiceMDLs;
            XDocument xmlElements = new XDocument(new XElement("EmployeeServices", from valueObj in dataList
                                                                                   select new XElement("EmployeeService",
                new XElement("PeriodCode", valueObj.YearMonth), new XElement("UploadType", valueObj.UploadType), new XElement("EmployeeId", valueObj.EmployeeId),
                 new XElement("Reference", valueObj.Reference), new XElement("Previous_Amount", valueObj.Previous_Amount), new XElement("Amount", valueObj.Amount))));
            System.Xml.Linq.XElement xmlDocumentWithoutNs = CommonMethods.RemoveAllNamespaces(System.Xml.Linq.XElement.Parse(xmlElements.ToString()));
            var result = new ResultMDL();
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("tenentId", employeeServiceTransList.tenantId);
                hashTable.Add("loginUserName", employeeServiceTransList.loginUserName);
                hashTable.Add("xmlData", Convert.ToString(xmlDocumentWithoutNs));
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spInsertEmployeeServiceDraftData]", CommandType.StoredProcedure, hashTable);
                if (objDataset != null)
                {
                    result.Result = Convert.ToInt32(objDataset.Tables[0].Rows[0][0]);
                    result.Message = Convert.ToString(objDataset.Tables[0].Rows[0][1]);
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = 4;

            }
            return result;
        }

        public async Task<ResultMDL> DeletEmployeeImportServiceData(EmployeeServiceTransList employeeServiceTransList)
        {
            var dataList = employeeServiceTransList.importEmployeeServiceMDLs;
            XDocument xmlElements = new XDocument(new XElement("EmployeeServices", from valueObj in dataList
                                                                                   select new XElement("EmployeeService",
                new XElement("PeriodCode", valueObj.YearMonth), new XElement("UploadType", valueObj.UploadType), new XElement("EmployeeId", valueObj.EmployeeId))));
            System.Xml.Linq.XElement xmlDocumentWithoutNs = CommonMethods.RemoveAllNamespaces(System.Xml.Linq.XElement.Parse(xmlElements.ToString()));
            var result = new ResultMDL();
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("tenentId", employeeServiceTransList.tenantId);
                hashTable.Add("loginUserName", employeeServiceTransList.loginUserName);
                hashTable.Add("xmlData", Convert.ToString(xmlDocumentWithoutNs));
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spDeleteEmployeeImportServiceData]", CommandType.StoredProcedure, hashTable);
                if (objDataset != null)
                {
                    result.Result = Convert.ToInt32(objDataset.Tables[0].Rows[0][0]);
                    result.Message = Convert.ToString(objDataset.Tables[0].Rows[0][1]);
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = 4;

            }
            return result;
        }

        public async Task<IEnumerable<EmployeeDetailsWithAllServiceData>> GetEmployeeDataByEmpId(long employeeId)
        {

            var result = (from e in _context.DetailedEmployees
                          join t in _context.TransactionHds
                          on Convert.ToInt32(e.EmployeeId) equals t.EmployeeId
                          where t.Mytransid == employeeId
                          select new EmployeeDetailsWithAllServiceData
                          {
                              Mytransid = t.Mytransid,
                              EmployeeId = e.EmployeeId.ToString(),
                              PFID = e.Pfid,
                              EmpCidNum = e.EmpCidNum,
                              EnglishName = e.EnglishName,
                              ArabicName = e.ArabicName,
                              EmpBirthday = e.EmpBirthday,
                              EmpGender = e.EmpGender,
                              JoinedDate = e.JoinedDate,
                              EmpMaritalStatus = e.EmpMaritalStatus,
                              NationName = e.NationName,
                              ContractType = e.ContractType,
                              Department = e.Department,
                              DepartmentName = e.DepartmentName,
                              Salary = e.Salary,
                              MobileNumber = e.MobileNumber,
                              EmpWorkTelephone = e.EmpWorkTelephone,
                              Remarks = e.Remarks,
                              ServiceType = t.ServiceType,
                              ServiceSubType = t.ServiceSubType,
                              ServiceTypeId = t.ServiceTypeId,
                              ServiceSubTypeId = t.ServiceSubTypeId,
                              Totamt = t.Totamt,
                              Totinstallments = t.Totinstallments,
                              InstallmentAmount = t.EachInstallmentsAmt,
                              LoanAct = t.LoanAct,
                              HajjAct = t.HajjAct,
                              PersLoanAct = t.PersLoanAct,
                              ConsumerLoanAct = t.ConsumerLoanAct,
                              OtherAct1 = t.OtherAct1,
                              OtherAct2 = t.OtherAct2,
                              OtherAct3 = t.OtherAct3,
                              OtherAct4 = t.OtherAct4,
                              OtherAct5 = t.OtherAct5,

                              SerApproval1 = t.SerApproval1,
                              ApprovalBy1 = t.ApprovalBy1,
                              ApprovedDate1 = t.ApprovedDate1,

                              SerApproval2 = t.SerApproval2,
                              ApprovalBy2 = t.ApprovalBy2,
                              ApprovedDate2 = t.ApprovedDate2,

                              SerApproval3 = t.SerApproval3,
                              ApprovalBy3 = t.ApprovalBy3,
                              ApprovedDate3 = t.ApprovedDate3,

                              SerApproval4 = t.SerApproval4,
                              ApprovalBy4 = t.ApprovalBy4,
                              ApprovedDate4 = t.ApprovedDate4,

                              SerApproval5 = t.SerApproval5,
                              ApprovalBy5 = t.ApprovalBy5,
                              ApprovedDate5 = t.ApprovedDate5,
                              InstallmentsBegDate = (DateTime)t.InstallmentsBegDate,
                              UntilMonth = t.UntilMonth,
                              DownPayment = t.DownPayment,
                              DiscountType = t.DiscountType,
                              AllowDiscountAmount = t.DiscountedGiftAmount,
                              AllowDiscountDefault = t.AllowDiscountDefault,
                              KinMobile = e.Next2KinMobNumber,
                              KinName = e.Next2KinName,
                              // SubscriptionStatus = e.Subscription_status.ToString(),
                              //  EmployeeStatus = e.EmpStatus.ToString(),
                              EndDate = e.EndDate,
                              TerminationDate = e.TerminationDate,
                              SubscriptionAmount = t.Totamt,
                              SubscriptionDueAmount = t.SubscriptionDueAmount,
                              LastSubscriptionPaid = t.PaidSubscriptionAmount,
                              PaidSubscriptionAmount = t.PaidSubscriptionAmount,
                              EmployeeStatus = e.EmpStatus != null ? _context.Reftables.Where(p => p.Refid == e.EmpStatus && p.Reftype == "KUPF" && p.Refsubtype == "EmpStatus").Select(c => c.Shortname).FirstOrDefault() : "",
                              SubscriptionStatus = e.Subscription_status != null ? _context.Reftables.Where(p => p.Refid == e.Subscription_status && p.Reftype == "KUPF" && p.Refsubtype == "SubscriptionStatus").Select(c => c.Shortname).FirstOrDefault() : "",
                              TransactionDt = _context.TransactionDts.Where(x => x.EmployeeId == t.EmployeeId && x.Mytransid == t.Mytransid).ToList(),
                          }).ToList();

            return result;
        }

        public async Task<bool> ValidateEmployeeId(long tenantId, int locationId, long employeeId)
        {
            var existingEmployee = await _context.DetailedEmployees.Where(c => c.TenentId == tenantId
                    && c.LocationId == locationId && c.EmployeeId == employeeId).AnyAsync();
            return !existingEmployee;
        }

        private async Task<TransData> CheckPendingTransaction(Models.DetailedEmployee employee)
        {
            var data = await _context.TransactionHds
                        .Join(
                            _context.DetailedEmployees,
                            a => new { x = a.TenentId, y = a.EmployeeId.Value, z = a.LocationId.Value },
                            b => new { x = b.TenentId, y = b.EmployeeId, z = b.LocationId },
                            (a, b) => new { A = a, B = b })
                        .Join(
                            _context.TransactionHddapprovalDetails,
                            ab => new { x = ab.A.TenentId, y = ab.A.LocationId.Value, z = ab.A.Mytransid },
                            c => new { x = c.TenentId, y = c.LocationId, z = c.Mytransid },
                            (ab, c) => new { ab.A, ab.B, C = c })
                        .Where(joined => joined.A.TenentId == employee.TenentId
                                        && joined.A.EmployeeId == employee.EmployeeId
                                        && joined.C.SerApproval == "1"
                                        && joined.C.Status == "ManagerApproved")
                        .Select(joined => new TransData
                        {
                            Id = joined.A.Mytransid,
                            Date = joined.A.Transdate
                            // Count(*) is simulated using 1 for each matched record
                        }).FirstOrDefaultAsync()
                        ;

            return data;
        }

    }
}


