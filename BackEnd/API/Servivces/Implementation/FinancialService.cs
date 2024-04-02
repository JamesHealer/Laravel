using API.Common;
using API.DTOs;
using API.DTOs.DropDown;
using API.DTOs.EmployeeDto;
using API.DTOs.FinancialTransaction;
using API.DTOs.RefTable;
using API.Helpers;
using API.Models;
using API.Servivces.Interfaces;
using API.Servivces.Interfaces.FinancialServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.Servivces.Implementation
{
    public class FinancialService : IFinancialService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFinancialTransactionService _IFinancialTransactionService;
        private readonly ICrupMstServivce _crupMstServivce;
        private readonly ICommonService _commonService;
        public FinancialService(KUPFDbContext context, IMapper mapper,
            IFinancialTransactionService IFinancialTransactionService,
            ICrupMstServivce crupMstServivce, ICommonService commonService)
        {
            _context = context;
            _mapper = mapper;
            _IFinancialTransactionService = IFinancialTransactionService;
            _crupMstServivce = crupMstServivce;
            _commonService = commonService;
        }

        public async Task<FinancialServiceResponse> AddFinancialServiceAsync(TransactionHdDto transactionHdDto)
        {
            try
            {
                if (_context != null)
                {
                    FinancialServiceResponse response = new FinancialServiceResponse();
                    var newTransaction = _mapper.Map<TransactionHd>(transactionHdDto);
                    string pfid = string.Empty;
                    if (transactionHdDto.IsKUEmployee != true)
                    {
                        return new FinancialServiceResponse
                        {
                            IsSuccess = false,
                            Message = "Subscription apply only to the KU Employees"
                        };
                    }
                    else if (transactionHdDto.IsOnSickLeave == true)
                    {
                        return new FinancialServiceResponse
                        {
                            IsSuccess = false,
                            Message = "A KU Employee on the Sick Leave Cannot apply for the Membership"
                        };
                    }
                    else if (transactionHdDto.IsMemberOfFund == true)
                    {
                        return new FinancialServiceResponse
                        {
                            IsSuccess = false,
                            Message = "Employee is Member of a KUPF Fund Committee"
                        };
                    }
                    else if (transactionHdDto.TerminationId != null)
                    {
                        return new FinancialServiceResponse
                        {
                            IsSuccess = false,
                            Message = "Employee Was Terminated Earlier"
                        };
                    }
                    else
                    {
                        //for the Scenario #1
                        //select ISNull(ServiceSerialNo, 1)  from servicesetup where ServiceType = 1 and ServiceSubType = 1
                        //Scenario #2
                        //select ISNULL(max(ServiceID), 0) + 1 from TransactionHD where TenentID = 21
                        int myId = 1;
                        var attachId = _context.TransactionHddms.FromSqlRaw("select isnull(Max(AttachID+1),1) as attachId from  [TransactionHDDMS ] where TenentID='" + transactionHdDto.TenentId + "'").Select(p => p.AttachId).FirstOrDefault();
                       // var serialNo = _context.TransactionHddms.FromSqlRaw("select isnull(Max(Serialno+1),1) as serialNo from  [TransactionHDDMS ] where tenentId='" + transactionHdDto.TenentId + "' and attachid=1").Select(c => c.Serialno).FirstOrDefault();
                        int maxSwitch = (int)_context.TransactionHds.FromSqlRaw("select ISNULL(max(ServiceID), 0) + 1 as ServiceId from TransactionHD where TenentID ='" + transactionHdDto.TenentId + "'").Select(c => c.ServiceId).FirstOrDefault();

                        // Create Unique TransationId...
                        int mytransid = Convert.ToInt32( _commonService.CreateMyTransIdForTransactionHD());
                        newTransaction.Mytransid = _commonService.CreateMyTransIdForTransactionHD();

                        #region Save into TransactionHddm
                        //var attachmentsData = new TransactionHddm
                        //{
                        //    TenentId = (int)transactionHdDto.TenentId,
                        //    Mytransid = newTransaction.Mytransid,
                        //    AttachId = attachId,
                        //    Remarks = transactionHdDto.AttachmentRemarks,
                        //    Subject = transactionHdDto.Subject,
                        //    MetaTags = transactionHdDto.MetaTags
                        //};

                        //var path = "E:\\";
                        ////var path = @"/HostingSpaces/kupf1/kupfapi.erp53.com/New/ServiceAttachments/";

                        //if (transactionHdDto.personalPhotoDocument.Length != 0 &&
                        //    transactionHdDto.personalPhotoDocument != null)
                        //{
                        //    var personalDocFileExtension = Path.GetExtension(transactionHdDto.personalPhotoDocument.FileName);
                        //    var filePath = Path.Combine(path, Guid.NewGuid() + personalDocFileExtension);
                        //    using (var stream = new FileStream(filePath, FileMode.Create))
                        //    {
                        //        transactionHdDto.personalPhotoDocument.CopyTo(stream);
                        //    }
                        //    attachmentsData.Serialno = serialNo;
                        //    attachmentsData.DocumentType = transactionHdDto.personalPhotoDocType;
                        //    attachmentsData.AttachmentPath = filePath;
                        //    attachmentsData.AttachmentByName = Guid.NewGuid() + personalDocFileExtension;
                        //    attachmentsData.AttachmentsDetail = null;
                        //    await _context.TransactionHddms.AddAsync(attachmentsData);
                        //    await _context.SaveChangesAsync();
                        //    _context.ChangeTracker.Clear();
                        //}
                        //if (transactionHdDto.appplicationFileDocument.Length != 0 &&
                        //    transactionHdDto.appplicationFileDocument != null)
                        //{
                        //    var appplicationFileExtension = Path.GetExtension(transactionHdDto.appplicationFileDocument.FileName);
                        //    var filePath = Path.Combine(path, Guid.NewGuid() + appplicationFileExtension);
                        //    using (var stream = new FileStream(filePath, FileMode.Create))
                        //    {
                        //        transactionHdDto.appplicationFileDocument.CopyTo(stream);
                        //    }
                        //    attachmentsData.Serialno = attachmentsData.Serialno + 1;
                        //    attachmentsData.DocumentType = transactionHdDto.appplicationFileDocType;
                        //    attachmentsData.AttachmentPath = filePath;
                        //    attachmentsData.AttachmentByName = Guid.NewGuid() + appplicationFileExtension;
                        //    attachmentsData.AttachmentsDetail = null;
                        //    await _context.TransactionHddms.AddAsync(attachmentsData);
                        //    await _context.SaveChangesAsync();
                        //    _context.ChangeTracker.Clear();
                        //}
                        //if (transactionHdDto.workIdDocument.Length != 0 &&
                        //    transactionHdDto.workIdDocument != null)
                        //{
                        //    var workIdFileExtension = Path.GetExtension(transactionHdDto.workIdDocument.FileName);
                        //    var filePath = Path.Combine(path, Guid.NewGuid() + workIdFileExtension);
                        //    using (var stream = new FileStream(filePath, FileMode.Create))
                        //    {
                        //        transactionHdDto.workIdDocument.CopyTo(stream);
                        //    }
                        //    attachmentsData.Serialno = attachmentsData.Serialno + 1;
                        //    attachmentsData.DocumentType = transactionHdDto.workIdDocType;
                        //    attachmentsData.AttachmentPath = filePath;
                        //    attachmentsData.AttachmentByName = Guid.NewGuid() + workIdFileExtension;
                        //    attachmentsData.AttachmentsDetail = null;
                        //    await _context.TransactionHddms.AddAsync(attachmentsData);
                        //    await _context.SaveChangesAsync();
                        //    _context.ChangeTracker.Clear();
                        //}
                        //if (transactionHdDto.civilIdDocument.Length != 0 &&
                        //    transactionHdDto.civilIdDocument != null)
                        //{
                        //    var civilIdFileExtension = Path.GetExtension(transactionHdDto.civilIdDocument.FileName);
                        //    var filePath = Path.Combine(path, Guid.NewGuid() + civilIdFileExtension);
                        //    using (var stream = new FileStream(filePath, FileMode.Create))
                        //    {
                        //        transactionHdDto.civilIdDocument.CopyTo(stream);
                        //    }
                        //    attachmentsData.Serialno = attachmentsData.Serialno + 1;
                        //    attachmentsData.DocumentType = transactionHdDto.workIdDocType;
                        //    attachmentsData.AttachmentPath = filePath;
                        //    attachmentsData.AttachmentByName = Guid.NewGuid() + civilIdFileExtension;
                        //    attachmentsData.AttachmentsDetail = null;
                        //    await _context.TransactionHddms.AddAsync(attachmentsData);
                        //    await _context.SaveChangesAsync();
                        //    _context.ChangeTracker.Clear();
                        //}
                        //if (transactionHdDto.salaryDataDocument.Length != 0 &&
                        //    transactionHdDto.salaryDataDocument != null)
                        //{
                        //    var salaryDataFileExtension = Path.GetExtension(transactionHdDto.salaryDataDocument.FileName);
                        //    var filePath = Path.Combine(path, Guid.NewGuid() + salaryDataFileExtension);
                        //    using (var stream = new FileStream(filePath, FileMode.Create))
                        //    {
                        //        transactionHdDto.salaryDataDocument.CopyTo(stream);
                        //    }
                        //    attachmentsData.Serialno = attachmentsData.Serialno + 1;
                        //    attachmentsData.DocumentType = transactionHdDto.salaryDataDocType;
                        //    attachmentsData.AttachmentPath = filePath;
                        //    attachmentsData.AttachmentByName = Guid.NewGuid() + salaryDataFileExtension;
                        //    attachmentsData.AttachmentsDetail = null;
                        //    await _context.TransactionHddms.AddAsync(attachmentsData);
                        //    await _context.SaveChangesAsync();
                        //    _context.ChangeTracker.Clear();
                        //}
                        #endregion


                        // check Employee membership  subscription
                        var employeeMembership = _context.DetailedEmployees.FirstOrDefault(c => c.EmployeeId == transactionHdDto.EmployeeId);
                        ////    check service approvals
                        var serviceApprovals = _context.ServiceSetups.Where(p => p.ServiceType == newTransaction.ServiceTypeId && p.ServiceSubType == newTransaction.ServiceSubTypeId).FirstOrDefault();
                      
                        // Get termination info
                     //   var termination = _context.Reftables.Where(c => c.Reftype == "KUPF" && c.Refsubtype == "Termination").FirstOrDefault();
                        // Get employee status
                     //   var empStatus = _context.Reftables.Where(c => c.Refid == 9 && c.Reftype == "KUPF" && c.Refsubtype == "EmpStatus").FirstOrDefault();
                        // Get Subscription Status
                       // var subscriptionStatus = _context.Reftables.Where(c => c.Refid == 1 && c.Reftype == "KUPF" && c.Refsubtype == "SubscriptionStatus").FirstOrDefault();

                        #region check pending loan amount
                        // To make sure Employee dont have any due Loan amount
                        var dueLoanamount = (from hd in _context.TransactionHds
                                             join dt in _context.TransactionDts
                                             on hd.Mytransid equals dt.Mytransid
                                             where hd.EmployeeId == transactionHdDto.EmployeeId &&
                                             hd.TenentId == transactionHdDto.TenentId &&
                                             hd.LocationId == transactionHdDto.LocationId &&
                                             hd.ServiceTypeId == transactionHdDto.ServiceTypeId && hd.ServiceSubTypeId == transactionHdDto.ServiceSubTypeId
                                             select new { hd, dt }).Count();
                        // To make sure Employee is not sponsored for the pending Loan Amount
                        var pendingLoanAmount = (from hd in _context.TransactionHds
                                                 join dt in _context.TransactionDts
                                                 on hd.Mytransid equals dt.Mytransid
                                                 where hd.SponserProvidentID == transactionHdDto.EmployeeId &&
                                                 hd.TenentId == transactionHdDto.TenentId &&
                                                 hd.LocationId == transactionHdDto.LocationId &&
                                                 hd.ServiceTypeId == transactionHdDto.ServiceSubTypeId && hd.ServiceSubTypeId == transactionHdDto.ServiceSubTypeId
                                                 select new { hd, dt }).Count();
                        if (dueLoanamount != 0)
                        {
                            return new FinancialServiceResponse
                            {
                                IsSuccess = false,
                                Message = "Employee have due Loan amount"
                            };
                        }
                        else if (pendingLoanAmount != 0)
                        {
                            return new FinancialServiceResponse
                            {
                                IsSuccess = false,
                                Message = "Employee is sponsored for the pending Loan Amount"
                            };
                        }
                        #endregion

                        if (transactionHdDto.ServiceTypeId == 1 && (transactionHdDto.ServiceSubTypeId == 1 || transactionHdDto.ServiceSubTypeId == 2)) // Membership Subscribe - اشتراك العضوية  
                        {
                            #region Membership Subscriber ...
                            // check if membership rejeced / terminated..
                            var existingSubscriber = _context.TransactionHds.Where(c => c.EmployeeId == newTransaction.EmployeeId).FirstOrDefault();
                            if (existingSubscriber != null)
                            {
                                return new FinancialServiceResponse
                                {
                                    IsSuccess = false,
                                    Message = "Duplicate subscriber"
                                };
                            }
                            newTransaction.MasterServiceId = maxSwitch;
                            newTransaction.Active = false;
                            newTransaction.AttachId = attachId;
                            newTransaction.AllowDiscountDefault = transactionHdDto.AllowDiscountDefault;
                            newTransaction.PeriodBegin = (int)transactionHdDto.PeriodCode;
                            newTransaction.ServiceId = (int)newTransaction.Mytransid;
                            if (serviceApprovals != null)
                            {
                                newTransaction.SerApproval1 = serviceApprovals.SerApproval1;
                                newTransaction.ApprovalBy1 = serviceApprovals.ApprovalBy1;
                                newTransaction.ApprovedDate1 = serviceApprovals.ApprovedDate1;
                                newTransaction.SerApproval2 = serviceApprovals.SerApproval2;
                                newTransaction.ApprovalBy2 = serviceApprovals.ApprovalBy2;
                                newTransaction.ApprovedDate2 = serviceApprovals.ApprovedDate2;
                                newTransaction.SerApproval3 = serviceApprovals.SerApproval3;
                                newTransaction.ApprovalBy3 = serviceApprovals.ApprovalBy3;
                                newTransaction.ApprovedDate3 = serviceApprovals.ApprovedDate3;
                                newTransaction.SerApproval4 = serviceApprovals.SerApproval4;
                                newTransaction.ApprovalBy4 = serviceApprovals.ApprovalBy4;
                                newTransaction.ApprovedDate4 = serviceApprovals.ApprovedDate4;
                                newTransaction.SerApproval5 = serviceApprovals.SerApproval5;
                                newTransaction.ApprovalBy5 = serviceApprovals.ApprovalBy5;
                                newTransaction.ApprovedDate5 = serviceApprovals.ApprovedDate5;
                                newTransaction.SerApproval6 = serviceApprovals.SerApproval6;
                                newTransaction.ApprovalBy6 = serviceApprovals.ApprovalBy6;
                                newTransaction.ApprovedDate6 = serviceApprovals.ApprovedDate6;
                            }

                            await _context.TransactionHds.AddAsync(newTransaction);
                            var periodCode = CommonMethods.CreateMemberShipPeriodCode();
                            foreach (var item in periodCode)
                            {
                                var data = new TransactionDtDto
                                {
                                    TenentId = transactionHdDto.TenentId,
                                    LocationId = transactionHdDto.LocationId,
                                    Mytransid = newTransaction.Mytransid,
                                    Myid = myId,
                                    EmployeeId = transactionHdDto.EmployeeId,
                                    InstallmentNumber = myId,
                                    AttachId = attachId,
                                    PeriodCode = Convert.ToInt64(item),
                                    InstallmentAmount = transactionHdDto.Totamt,
                                    ReceivedAmount = 0,
                                    PendingAmount = transactionHdDto.InstallmentAmount,
                                    DiscountAmount = newTransaction.Discount,
                                    DiscountReference = null,
                                    UniversityBatchNo = null,
                                    ReceivedDate = null,
                                    EffectedAccount = null,
                                    OtherReference = null,
                                    Activityid = null,
                                    InstallmentsBegDate = transactionHdDto.InstallmentsBegDate,
                                    UntilMonth = transactionHdDto.UntilMonth,
                                    Userid = newTransaction.Userid,
                                    Entrydate = DateTime.Now,

                                };
                                var transactionDt = _mapper.Map<TransactionDt>(data);
                                transactionDt.PendingAmount = 0;
                                transactionDt.DiscountAmount = 0;
                                await _context.TransactionDts.AddAsync(transactionDt);
                                myId++;
                            }
                            // Update detailedEmployee  
                            employeeMembership.MembershipJoiningDate = newTransaction.InstallmentsBegDate;
                            employeeMembership.SubscribedDate = newTransaction.InstallmentsBegDate;
                            employeeMembership.AgreedSubAmount = newTransaction.Totamt;
                            employeeMembership.Subscription_status = 1;
                            employeeMembership.EmpStatus = 1;
                            employeeMembership.Pfid = _commonService.CreateEmployeePFId(newTransaction.TenentId, (int)newTransaction.LocationId).ToString();
                            pfid = employeeMembership.Pfid;
                            employeeMembership.SubscriptionDate = DateTime.Now;
                            _context.DetailedEmployees.Update(employeeMembership);
                            await _context.SaveChangesAsync();
                            #endregion
                        }
                        else if (transactionHdDto.ServiceTypeId == 2 || transactionHdDto.ServiceTypeId == 3)
                        {
                            int totalMonths = CommonMethods.CalculateMembershipDuration((DateTime)employeeMembership.SubscribedDate);
                            #region Financial Loan General, Consumption Loan, Medical Loan, Hajj Loan
                            if (transactionHdDto.ServiceSubTypeId == 205)  //// Hajj Loan
                            {
                                if (totalMonths < 6)
                                {
                                    return new FinancialServiceResponse
                                    {
                                        IsSuccess = false,
                                        Message = "Minimum 6 months"
                                    };
                                }
                            }
                            // Next Due Date for payment...
                            DateTime nextDueDate = DateTime.Now;

                            // Add record to TransactionHD
                            newTransaction.MasterServiceId = maxSwitch;
                            newTransaction.Active = false;
                            newTransaction.AllowDiscountDefault = transactionHdDto.AllowDiscountDefault;
                            newTransaction.ServiceId = (int)newTransaction.Mytransid;
                            await _context.TransactionHds.AddAsync(newTransaction);

                            // Add record to TransactionDT
                            var totalInstallements = Convert.ToInt32(transactionHdDto.Totinstallments);
                            var periodCode = GetPeriodCode();
                            for (int i = 0; i < totalInstallements; i++)
                            {
                                
                                var data = new TransactionDtDto
                                {
                                    TenentId = transactionHdDto.TenentId,
                                    LocationId = transactionHdDto.LocationId,
                                    Mytransid = newTransaction.Mytransid,
                                    Myid = i+1,
                                    EmployeeId = transactionHdDto.EmployeeId,
                                    InstallmentNumber = i+1,//Create a method to create subscription and this should be starts from currnet month + next year....
                                    AttachId = 0,
                                    PeriodCode = periodCode,// comes from TBLPeriods table.
                                    InstallmentAmount = newTransaction.InstallmentAmount,
                                    ReceivedAmount = 0,
                                    PendingAmount = transactionHdDto.InstallmentAmount,
                                    DiscountAmount = 0,
                                    DiscountReference = string.Empty,
                                    UniversityBatchNo = string.Empty,
                                    ReceivedDate = null,
                                    EffectedAccount = null,
                                    OtherReference = null,
                                    Activityid = null,
                                    InstallmentsBegDate = transactionHdDto.InstallmentsBegDate,
                                    UntilMonth = transactionHdDto.UntilMonth,
                                    Userid = newTransaction.Userid,
                                    Entrydate = DateTime.Now
                                };
                                periodCode = CommonMethods.NextMonth(Convert.ToInt32(periodCode));
                                var transactionDt = _mapper.Map<TransactionDt>(data);
                                await _context.TransactionDts.AddAsync(transactionDt);
                                
                            }
                            await _context.SaveChangesAsync();

                            pfid = employeeMembership.Pfid;

                            _context.ChangeTracker.Clear();
                            #endregion
                        }

                        else if (transactionHdDto.ServiceTypeId == 1 && (transactionHdDto.ServiceSubTypeId == 3 || transactionHdDto.ServiceSubTypeId == 4 || transactionHdDto.ServiceSubTypeId == 5 || transactionHdDto.ServiceSubTypeId == 6)) // Membership Cessation  -    Membership Withdrawal
                        {
                            #region Membership-Withdrawls
                            ///// membership duration period
                            int totalMonths = CommonMethods.CalculateMembershipDuration((DateTime)employeeMembership.SubscribedDate);
                            if (totalMonths < 49)  // for  Membership Withdrawal service , employee service time should be 4 years
                            {
                                return new FinancialServiceResponse
                                {
                                    IsSuccess = false,
                                    Message = "Employee service time should be minimum 4 years"
                                };
                            }

                            var discountValues = _context.Reftables.Where(c => c.Reftype == "KUPF" && c.Refsubtype == "Withdrawals").ToList();

                            // Next Due Date for payment...
                            DateTime nextDueDate = DateTime.Now.AddYears(1);
                            //
                            decimal payableAmount = 0M;
                            //
                            decimal payableAmountAfterOneYear = 0M;

                            for (int i = 0; i < discountValues.Count; i++)
                            {
                                if (totalMonths >= Convert.ToInt32(discountValues[i].Switch3)
                                    && totalMonths <= discountValues[i].Switch4)
                                {
                                    // Add record to TransactionDT
                                    //newTransaction.Mytransid = CommonMethods.CreateEmployeeId();
                                    newTransaction.MasterServiceId = maxSwitch;
                                    newTransaction.TotalAmount = transactionHdDto.TotalAmount;
                                    newTransaction.Totamt = transactionHdDto.TotalAmount;
                                    await _context.TransactionHds.AddAsync(newTransaction);
                                    await _context.SaveChangesAsync();

                                    // To be paid today
                                    payableAmount = ((((decimal)transactionHdDto.TotalAmount * totalMonths) / 100) * Convert.ToInt32(discountValues[i].Switch1));

                                    var data = new TransactionDtDto
                                    {
                                        TenentId = transactionHdDto.TenentId,
                                        LocationId = transactionHdDto.LocationId,
                                        Mytransid = newTransaction.Mytransid,
                                        Myid = myId,
                                        EmployeeId = transactionHdDto.EmployeeId,
                                        InstallmentNumber = myId,
                                        AttachId = attachId,
                                        PeriodCode = GetPeriodCode(),// comes from TBLPeriods table.
                                        InstallmentAmount = payableAmount,
                                        ReceivedAmount = 0,
                                        PendingAmount = payableAmount,
                                        DiscountAmount = 0,
                                        DiscountReference = string.Empty,
                                        UniversityBatchNo = string.Empty,
                                        ReceivedDate = null,
                                        EffectedAccount = null,
                                        OtherReference = null,
                                        Activityid = null,
                                        CrupId = 1,
                                        Glpost = "1",
                                        Glpost1 = null,
                                        Glpostref = "1",
                                        Glpostref1 = "1",
                                        Active = true,
                                        Switch1 = null,
                                        DelFlag = null,
                                        InstallmentsBegDate = transactionHdDto.InstallmentsBegDate,
                                        UntilMonth = transactionHdDto.UntilMonth,
                                        Userid = newTransaction.Userid,
                                        Entrydate = DateTime.Now
                                    };
                                    var transactionDt = _mapper.Map<TransactionDt>(data);
                                    await _context.TransactionDts.AddAsync(transactionDt);
                                    await _context.SaveChangesAsync();
                                    _context.ChangeTracker.Clear();

                                    payableAmountAfterOneYear = ((((decimal)transactionHdDto.TotalAmount * totalMonths) / 100) * Convert.ToInt32(discountValues[i].Switch2));
                                    //
                                      
                                    data = new TransactionDtDto
                                    {
                                        TenentId = transactionHdDto.TenentId,
                                        LocationId = transactionHdDto.LocationId,
                                        Mytransid = newTransaction.Mytransid,
                                        Myid = myId + 1,
                                        EmployeeId = transactionHdDto.EmployeeId,
                                        InstallmentNumber = myId,
                                        AttachId = attachId,
                                        PeriodCode = GenerateMonthForOneYearLater(),// comes from TBLPeriods table.
                                        InstallmentAmount = payableAmountAfterOneYear,
                                        ReceivedAmount = 0,
                                        PendingAmount = payableAmountAfterOneYear,
                                        DiscountAmount = 0,
                                        DiscountReference = string.Empty,
                                        UniversityBatchNo = string.Empty,
                                        ReceivedDate = null,
                                        EffectedAccount = null,
                                        OtherReference = null,
                                        Activityid = null,
                                        CrupId = 1,
                                        Glpost = "1",
                                        Glpost1 = null,
                                        Glpostref = "1",
                                        Glpostref1 = "1",
                                        Active = true,
                                        Switch1 = null,
                                        DelFlag = null,
                                        InstallmentsBegDate = transactionHdDto.InstallmentsBegDate,
                                        UntilMonth = transactionHdDto.UntilMonth,
                                        Userid = newTransaction.Userid,
                                        Entrydate = DateTime.Now
                                    };
                                    transactionDt = _mapper.Map<TransactionDt>(data);
                                    await _context.TransactionDts.AddAsync(transactionDt);
                                    await _context.SaveChangesAsync();
                                    _context.ChangeTracker.Clear();

                                     
                                    break;

                                }
                            }
                            #endregion
                        }
                        else
                        {
                            return new FinancialServiceResponse
                            {
                                IsSuccess = false,
                                Message = "Service Not Implemented"
                            };
                        }

                        #region Save Into TransactionHDDApprovalDetails
                        if (serviceApprovals != null)
                        {
                            List<string> myService = new List<string>
                            {
                                serviceApprovals.SerApproval1,
                                serviceApprovals.SerApproval2,
                                serviceApprovals.SerApproval3,
                                serviceApprovals.SerApproval4,
                                serviceApprovals.SerApproval5,
                                serviceApprovals.SerApproval6
                            };
                            if (serviceApprovals != null)
                            {
                                myService.RemoveAll(item => item == null);
                                int srId = 0;
                                for (int i = 0; i < myService.Count; i++) // myservice is one active  = true else false.
                                {
                                    var transactionHddApprovalsDto = new TransactionHddapprovalDetailDto()
                                    {
                                        TenentId = newTransaction.TenentId,
                                        Mytransid = newTransaction.Mytransid,
                                        LocationId = (int)newTransaction.LocationId,
                                        SerApprovalId = srId + 1,
                                        SerApproval = myService[i].ToString(),
                                        EmployeeId = newTransaction.EmployeeId,
                                        ServiceType = newTransaction.ServiceTypeId,
                                        ServiceSubType = newTransaction.ServiceSubTypeId,
                                        ServiceId = srId + 1,
                                        MasterServiceId = maxSwitch,
                                        ApprovalDate = null,
                                        RejectionType = null,
                                        RejectionRemarks = null,
                                        AttachId = attachId,
                                        Status = "ManagerApproval",
                                        Userid = newTransaction.Userid,
                                        Entrydate = DateTime.Now,
                                        Entrytime = DateTime.Now,
                                        Updttime = DateTime.Now,
                                        ApprovalRemarks = "BySystem",
                                        mySeq = srId + 1,
                                        DisplayPERIOD_CODE = transactionHdDto.PeriodCode

                                    };
                                    // We will set active first recored and other will by inactive by default.
                                    if (i == 0)
                                    {
                                        transactionHddApprovalsDto.Active = true;
                                    }
                                    else
                                    {
                                        transactionHddApprovalsDto.Active = false;
                                    }

                                    var transactionHddApprovals = _mapper.Map<TransactionHddapprovalDetail>(transactionHddApprovalsDto);
                                    transactionHddApprovals.MasterServiceId = maxSwitch;
                                    await _context.TransactionHddapprovalDetails.AddAsync(transactionHddApprovals);
                                    srId++;
                                }
                            }
                        }
                        #endregion

                        return new FinancialServiceResponse
                        {
                            Response = newTransaction.Mytransid.ToString(),
                            AttachId = attachId.ToString(),
                            TransactionId = newTransaction.Mytransid.ToString(),
                            IsSuccess = true,
                            PFId = pfid,
                            Message = "Saved Successfully..."
                        };
                    }
                }
                return new FinancialServiceResponse
                {
                    IsSuccess = true,
                    Message = "Saved Successfully..."
                };
            }
            catch (Exception ex)
            {
                return new FinancialServiceResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<int> DeleteFinancialServiceAsync(long id)
        {
            int result = 0;

            if (_context != null)
            {
                var transactionHd = await _context.TransactionHds.FirstOrDefaultAsync(x => x.Mytransid == id);
                var transactionDt = await _context.TransactionDts.Where(c => c.Mytransid == id).ToListAsync();
                if (transactionHd != null)
                {
                    _context.TransactionHds.Remove(transactionHd);
                    _context.TransactionDts.RemoveRange(transactionDt);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<FinancialServiceResponse> UpdateFinancialServiceAsync(TransactionHdDto transactionHdDto)
        {
            if (_context != null)
            {
                var existingtransactionHd = _context.TransactionHds
                    .Where(c => c.Mytransid == transactionHdDto.Mytransid).FirstOrDefault();

                var existingtransactionDT = _context.TransactionDts
                    .Where(c => c.Mytransid == transactionHdDto.Mytransid).ToList();

                if (existingtransactionHd != null)
                {
                    // Update TransactionHD
                    existingtransactionHd.Mytransid = transactionHdDto.Mytransid;
                    existingtransactionHd.Totamt = transactionHdDto.Totamt;
                    existingtransactionHd.DiscountedGiftAmount = transactionHdDto.AllowDiscountAmount;
                    existingtransactionHd.Discount = transactionHdDto.AllowDiscountAmount;
                    existingtransactionHd.EachInstallmentsAmt = transactionHdDto.EachInstallmentsAmt;
                    _context.TransactionHds.Update(existingtransactionHd);
                    await _context.SaveChangesAsync();
                    // Update TransactionDT
                    foreach (var item in existingtransactionDT)
                    {
                        item.InstallmentAmount = transactionHdDto.EachInstallmentsAmt;
                        _context.TransactionDts.Update(item);
                        await _context.SaveChangesAsync();
                        _context.ChangeTracker.Clear();
                    }

                }

            };
            return new FinancialServiceResponse
            {
                IsSuccess = true,
                Message = "Saved Successfully..."
            };
        }

        public async Task<PagedList<ReturnTransactionHdDto>> GetFinancialServiceAsync(PaginationModel paginationModel, int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal)
        {
            var data = (from e in _context.DetailedEmployees
                        join t in _context.TransactionHds
                        on Convert.ToInt32(e.EmployeeId) equals t.EmployeeId
                        where e.Subscription_status == (filterVal == 0 ? e.Subscription_status : filterVal)
                        && ((t.SerApproval2 == (ServiceStatusFilterVal == 1 ? "2" : t.SerApproval2)) && (t.Status == (ServiceStatusFilterVal == 2 ? "Rejected" : t.Status)))  //1 = Aprroved , 2= Rejected , 0= Show All //
                        && ((t.IsDraftCreated == (DraftStatusFilterVal == 1 ? true : t.IsDraftCreated)) && (t.Status == (DraftStatusFilterVal == 2 ? "CashierDelivery" : t.Status)) && (t.IsDraftCreated == (DraftStatusFilterVal == 3 ? true : t.IsDraftCreated) && t.Status != (DraftStatusFilterVal == 3 ? "CashierDelivery" : "")))  //  1 = Draft Prepared, 2= Draft Delivered , 3=Draft Not Delivered, 0=SHOW ALL
                        select new ReturnTransactionHdDto
                        {
                            MYTRANSID = t.Mytransid,
                            EmployeeId = Convert.ToInt32(e.EmployeeId),
                            PFId = e.Pfid,
                            CID = e.EmpCidNum,
                            EnglishName = e.EnglishName,
                            ArabicName = e.ArabicName,
                            ServiceType = t.ServiceType,
                            ServiceSubType = t.ServiceSubType,
                            Installment = t.InstallmentAmount,
                            Amount = t.AmtPaid,
                            Discounted = t.Discount,
                            PayDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        }).OrderByDescending(c => c.MYTRANSID).AsQueryable();

            if (!string.IsNullOrEmpty(paginationModel.Query))
            {
                data = data.Where(u =>
                u.PFId.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.CID.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.EmployeeId.ToString().Contains(paginationModel.Query.ToLower())
                    );
            }
            return await PagedList<ReturnTransactionHdDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);
        }

        public async Task<ReturnSingleFinancialServiceById> GetFinancialServiceByIdAsync(long id)
        {
            var result = (from e in _context.DetailedEmployees
                          join t in _context.TransactionHds
                          on Convert.ToInt32(e.EmployeeId) equals t.EmployeeId
                          //join hddms in _context.TransactionHddms
                          //on t.Mytransid equals hddms.Mytransid
                          where t.Mytransid == id
                          select new ReturnSingleFinancialServiceById
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
                              SubscriptionStatus = e.Subscription_status.ToString(),
                              EmployeeStatus = e.EmpStatus.ToString(),
                              EndDate = e.EndDate,
                              TerminationDate = e.TerminationDate,
                              SubscriptionAmount = t.Totamt,
                              SubscriptionDueAmount = t.SubscriptionDueAmount,
                              FinancialAmount = t.FinancialAmount,
                              PaidSubscriptionAmount = t.PaidSubscriptionAmount,
                              FinancialAmountRemarks = t.FinancialAmountRemarks,
                              FinancialAidPercentage = t.FinancialAidPercentage,
                              FinancialAid           = t.FinancialAid,
                              PFFundRevenue          = t.PFFundRevenue,
                              PFFundRevenuePercentage   = t.PFFundRevenuePercentage,
                              AdjustmentAmount = t.AdjustmentAmount,
                              AdjustmentAmountRemarks = t.AdjustmentAmountRemarks,
                              LoanAmountBalance = t.LoanAmountBalance,
                              CalculatedAmount = t.CalculatedAmount,
                              YearOfService = t.YearOfService,
                              DiscountedGiftAmount = t.DiscountedGiftAmount,
                              Discount = t.Discount,

                          }).FirstOrDefault();

            string empStatus = string.Empty;
            string subscriptionStauts = string.Empty;

            if (result.EmployeeStatus != null)
                empStatus = await _context.Reftables.Where(p => p.Refid == Convert.ToInt32(result.EmployeeStatus) && p.Reftype == "KUPF" && p.Refsubtype == "EmpStatus").Select(c => c.Shortname).FirstOrDefaultAsync();
            result.EmployeeStatus = empStatus;
            //
            if (result.SubscriptionStatus != null)
                subscriptionStauts = await _context.Reftables.Where(p => p.Refid == Convert.ToInt32(result.SubscriptionStatus) && p.Reftype == "KUPF" && p.Refsubtype == "SubscriptionStatus").Select(c => c.Shortname).FirstOrDefaultAsync();
            result.SubscriptionStatus = subscriptionStauts;
            //var hddms = _context.TransactionHddms.Where(c => c.Mytransid == id).ToList();
            //result.TransactionHDDMSDto = _mapper.Map<List<TransactionHDDMSDto>>(hddms);
            return result;
        }

        public async Task<ServiceSetupDto> GetServiceByServiceTypeAndSubType(int serviceType, int serviceSubType, int tenentId)
        {
            var result = await _context.ServiceSetups.Where(c => c.Active == "1" && c.ServiceType == serviceType && c.ServiceSubType == serviceSubType && c.TenentId == tenentId).FirstOrDefaultAsync();
            var data = _mapper.Map<ServiceSetupDto>(result);
            return data;
        }

        public async Task<PagedList<ManagerApprovalDto>> GetServiceApprovalsAsync([FromQuery] PaginationModel paginationModel, long periodCode, int tenentId, int locationId, bool isShowAll)
        {
            try
            {
                if (isShowAll)
                {
                    var data = (from e in _context.DetailedEmployees
                                join ap in _context.TransactionHddapprovalDetails
                                on e.EmployeeId equals ap.EmployeeId
                                join hd in _context.TransactionHds
                                on ap.Mytransid equals hd.Mytransid
                                where ap.TenentId == tenentId &&
                                e.TenentId == tenentId &&
                                e.LocationId == locationId &&
                                ap.LocationId == locationId &&
                                ap.SerApprovalId == 1 //&& // Manager Role Id
                                                      // ap.DisplayPERIOD_CODE <= periodCode &&
                                                      // ap.DisplayPERIOD_CODE >= periodCode
                                select new ManagerApprovalDto
                                {
                                    TransId = (int)ap.Mytransid,
                                    EmployeeId = Convert.ToString(e.EmployeeId),
                                    EnglishName = e.EnglishName,
                                    ArabicName = e.ArabicName,
                                    ServiceName = hd.ServiceSubType,
                                    Pfid = e.Pfid,
                                    EmpCidNum = e.EmpCidNum,
                                    MobileNumber = e.MobileNumber,
                                    PeriodCode = Convert.ToString(ap.DisplayPERIOD_CODE),
                                    TenentId = ap.TenentId,
                                    LocationId = ap.LocationId,
                                    DraftAmount1 = hd.DraftAmount1,
                                    DraftAmount2 = hd.DraftAmount2,
                                    DraftDate1 = hd.DraftDate1,
                                    DraftDate2 = hd.DraftDate2,
                                    TotalAmount = hd.Totamt,
                                    TotalInstallments = (int)hd.Totinstallments,
                                    Status = ap.Status,
                                    Active = ap.Active,
                                    CrupId = (long)e.CRUP_ID
                                }).OrderByDescending(c => c.TransId).AsQueryable();
                    if (!string.IsNullOrEmpty(paginationModel.Query))
                    {
                        data = data.Where(u =>
                        u.Pfid.ToLower().Contains(paginationModel.Query.ToLower()) ||
                         u.TransId.ToString().ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.ServiceName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.EmpCidNum.ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.EmployeeId.ToLower().Contains(paginationModel.Query.ToLower())
                            );
                    }
                    return await PagedList<ManagerApprovalDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);


                }
                else
                {
                    var data = (from e in _context.DetailedEmployees
                                join ap in _context.TransactionHddapprovalDetails
                                on e.EmployeeId equals ap.EmployeeId
                                join hd in _context.TransactionHds
                                on ap.Mytransid equals hd.Mytransid
                                where ap.TenentId == tenentId &&
                                e.TenentId == tenentId &&
                                e.LocationId == locationId &&
                                ap.LocationId == locationId &&
                                ap.Status == "ManagerApproval" &&
                                 ap.SerApprovalId == 1 && // Manager Role Id
                                // ap.DisplayPERIOD_CODE <= periodCode &&
                                // ap.DisplayPERIOD_CODE >= periodCode &&
                                ap.Active == true
                                select new ManagerApprovalDto
                                {
                                    TransId = (int)ap.Mytransid,
                                    EmployeeId = Convert.ToString(e.EmployeeId),
                                    EnglishName = e.EnglishName,
                                    ArabicName = e.ArabicName,
                                    ServiceName = hd.ServiceSubType,
                                    Pfid = e.Pfid,
                                    EmpCidNum = e.EmpCidNum,
                                    MobileNumber = e.MobileNumber,
                                    PeriodCode = Convert.ToString(ap.DisplayPERIOD_CODE),
                                    TenentId = ap.TenentId,
                                    LocationId = ap.LocationId,
                                    DraftAmount1 = hd.DraftAmount1,
                                    DraftAmount2 = hd.DraftAmount2,
                                    DraftDate1 = hd.DraftDate1,
                                    DraftDate2 = hd.DraftDate2,
                                    TotalAmount = hd.Totamt,
                                    TotalInstallments = (int)hd.Totinstallments,
                                    Status = ap.Status,
                                    Active = ap.Active,
                                    CrupId = (long)e.CRUP_ID
                                }).OrderByDescending(c => c.TransId).AsQueryable();
                    if (!string.IsNullOrEmpty(paginationModel.Query))
                    {
                        data = data.Where(u =>
                        u.Pfid.ToLower().Contains(paginationModel.Query.ToLower()) ||
                         u.TransId.ToString().ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.ServiceName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.EmpCidNum.ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                        u.EmployeeId.ToLower().Contains(paginationModel.Query.ToLower())
                            );
                    }
                    return await PagedList<ManagerApprovalDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);

                }


            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<string> ManagerApproveServiceAsync(ApproveRejectServiceDto approveRejectServiceDto)
        {
            int result = 0;
            try
            {
                if (_context != null)
                {
                    var existingtransactionHddApprovals = _context.TransactionHddapprovalDetails
                        .Where(c => c.Mytransid == approveRejectServiceDto.Mytransid && c.SerApprovalId == 1).FirstOrDefault();
                    //
                    var employeeDetails = _context.DetailedEmployees.Where(c => c.EmployeeId == existingtransactionHddApprovals.EmployeeId
                    && c.TenentId == approveRejectServiceDto.TenentId && c.LocationId == approveRejectServiceDto.LocationId).FirstOrDefault();
                    //
                    var transactionDt = _context.TransactionDts.Where(e => e.Mytransid == approveRejectServiceDto.Mytransid).ToList();
                    // 
                    var existingTransactionHd = _context.TransactionHds.Where(c => c.Mytransid == existingtransactionHddApprovals.Mytransid).FirstOrDefault();

                    var activateNextRow = _context.TransactionHddapprovalDetails.Where(p => p.Mytransid == existingtransactionHddApprovals.Mytransid && p.SerApprovalId == 2).FirstOrDefault();

                    var serviceApprovals = _context.ServiceSetups.Where(p => p.ServiceType == existingTransactionHd.ServiceTypeId && p.ServiceSubType == existingTransactionHd.ServiceSubTypeId).FirstOrDefault();

                    if (existingtransactionHddApprovals != null)
                    {
                        // Update TransactionHddapprovalDetails
                        existingtransactionHddApprovals.Mytransid = approveRejectServiceDto.Mytransid;
                        existingtransactionHddApprovals.Userid = approveRejectServiceDto.Userid;
                        existingtransactionHddApprovals.ApprovalDate = approveRejectServiceDto.ApprovalDate;
                        existingtransactionHddApprovals.Entrydate = (DateTime)approveRejectServiceDto.Entrydate;
                        existingtransactionHddApprovals.Entrytime = (DateTime)approveRejectServiceDto.Entrytime;
                        existingtransactionHddApprovals.Status = "ManagerApproved";
                        existingtransactionHddApprovals.ApprovalDate = DateTime.Now;
                        existingtransactionHddApprovals.ApprovalRemarks = approveRejectServiceDto.ApprovalRemarks;
                        existingtransactionHddApprovals.Active = false;
                        existingtransactionHddApprovals.Userid = approveRejectServiceDto.UserId;
                        // Update Service Approvals
                        if (serviceApprovals != null)
                        {
                            List<string> myService = new List<string>
                            {
                                serviceApprovals.SerApproval1,
                                serviceApprovals.SerApproval2,
                                serviceApprovals.SerApproval3,
                                serviceApprovals.SerApproval4,
                                serviceApprovals.SerApproval5,
                                serviceApprovals.SerApproval6
                            };
                            if (serviceApprovals != null)
                            {
                                myService.RemoveAll(item => item == null);
                                existingTransactionHd.SerApproval1 = myService[0];
                                existingTransactionHd.ApprovalBy1 = approveRejectServiceDto.UserId;
                                existingTransactionHd.ApprovedDate1 = DateTime.Now;
                            }
                        }
                        _context.TransactionHddapprovalDetails.Update(existingtransactionHddApprovals);
                        await _context.SaveChangesAsync();
                        _context.ChangeTracker.Clear();

                        // Update TransactionHD.
                        existingTransactionHd.Active = true;
                        existingTransactionHd.Status = "Approved";
                        _context.TransactionHds.Update(existingTransactionHd);
                        await _context.SaveChangesAsync();
                        _context.ChangeTracker.Clear();

                        // Update Employee Status

                        if (existingTransactionHd.ServiceTypeId == 1 && (existingTransactionHd.ServiceSubTypeId == 1 || existingTransactionHd.ServiceSubTypeId == 2)) // Membership Subscribe - اشتراك العضوية  
                        {
                            employeeDetails.EmpStatus = 1;
                            employeeDetails.Subscription_status = 1;
                        }
                        else if (existingTransactionHd.ServiceTypeId == 1 && (existingTransactionHd.ServiceSubTypeId == 3 || existingTransactionHd.ServiceSubTypeId == 4 || existingTransactionHd.ServiceSubTypeId == 5 || existingTransactionHd.ServiceSubTypeId == 6)) // Membership Cessation  -    Membership Withdrawal
                        {
                            employeeDetails.EmpStatus = 3;   //   3 for termination
                            employeeDetails.Subscription_status = 3;
                            employeeDetails.TerminationDate = DateTime.Now;
                        }
                        _context.DetailedEmployees.Update(employeeDetails);
                        result = await _context.SaveChangesAsync();
                        _context.ChangeTracker.Clear();

                        //
                        activateNextRow.Active = true;
                        _context.TransactionHddapprovalDetails.Update(activateNextRow);
                        _context.SaveChanges();
                        _context.ChangeTracker.Clear();
                        // Update TransactionDt
                        foreach (var item in transactionDt)
                        {
                            item.Active = true;
                            _context.TransactionDts.Update(item);
                            result = await _context.SaveChangesAsync();
                            _context.ChangeTracker.Clear();
                        }

                    }
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            return result.ToString();
        }

        public async Task<string> ManagerRejectServiceAsync(ApproveRejectServiceDto approveRejectServiceDto)
        {
            int result = 0;
            if (_context != null)
            {
                // To get record by transId and Active...
                var existingtransactionHdApprovalDetails = _context.TransactionHddapprovalDetails
                    .Where(c => c.Mytransid == approveRejectServiceDto.Mytransid && c.Active == true).FirstOrDefault();

                // TO CHECK IF CRUP_ID IS NULL DETAILEDEMPLOYEE.
                var detailedEmployee = _context.DetailedEmployees.Where(c => c.EmployeeId == existingtransactionHdApprovalDetails.EmployeeId
                    && c.TenentId == approveRejectServiceDto.TenentId
                    && c.LocationId == approveRejectServiceDto.LocationId).FirstOrDefault();

                // 
                var existingTransactionHd = _context.TransactionHds.Where(c => c.Mytransid == existingtransactionHdApprovalDetails.Mytransid).FirstOrDefault();

                //
                var serviceApprovals = _context.ServiceSetups.Where(p => p.ServiceType == existingTransactionHd.ServiceTypeId && p.ServiceSubType == existingTransactionHd.ServiceSubTypeId).FirstOrDefault();
                if (existingtransactionHdApprovalDetails != null)
                {
                    // Update TransactionHddapprovalDetails
                    existingtransactionHdApprovalDetails.RejectionType = approveRejectServiceDto.RejectionType;
                    existingtransactionHdApprovalDetails.RejectionRemarks = approveRejectServiceDto.RejectionRemarks;
                    existingtransactionHdApprovalDetails.Active = false;
                    existingtransactionHdApprovalDetails.Status = "ManagerRejected";
                    existingtransactionHdApprovalDetails.ApprovalDate = DateTime.Now;
                    // Update Service Approval
                    _context.TransactionHddapprovalDetails.Update(existingtransactionHdApprovalDetails);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();

                    if (serviceApprovals != null)
                    {
                        List<string> myService = new List<string>
                            {
                                serviceApprovals.SerApproval1,
                                serviceApprovals.SerApproval2,
                                serviceApprovals.SerApproval3,
                                serviceApprovals.SerApproval4,
                                serviceApprovals.SerApproval5,
                                serviceApprovals.SerApproval6
                            };
                        if (serviceApprovals != null)
                        {
                            myService.RemoveAll(item => item == null);
                            existingTransactionHd.Status = "Rejected";
                            existingTransactionHd.SerApproval1 = myService[0];
                            existingTransactionHd.ApprovalBy1 = approveRejectServiceDto.UserId;
                            existingTransactionHd.ApprovedDate1 = DateTime.Now;
                        }
                    }
                    // Update TransactionHD.                    
                    _context.TransactionHds.Update(existingTransactionHd);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();

                    // Update Employee Details.
                    if (existingTransactionHd.ServiceTypeId == 1 && existingTransactionHd.ServiceSubTypeId == 1)
                    {
                        detailedEmployee.Subscription_status = 2; // rejected
                        _context.DetailedEmployees.Update(detailedEmployee);

                    }
                    result = await _context.SaveChangesAsync();
                }

            }
            return result.ToString();
        }

        public async Task<IEnumerable<RefTableDto>> GetRejectionType()
        {
            var result = await _context.Reftables.Where(c => c.Reftype == "KUPF" && c.Refsubtype == "Rejection").ToListAsync();
            var data = _mapper.Map<IEnumerable<RefTableDto>>(result);
            return data;
        }



        public async Task<IEnumerable<ReturnServiceApprovals>> GetServiceApprovalsByEmployeeId(int employeeId)
        {
            var data = (from e in _context.DetailedEmployees
                        join hd in _context.TransactionHds
                        on Convert.ToInt32(e.EmployeeId) equals hd.EmployeeId
                        // join app in _context.TransactionHddapprovalDetails
                        ////on hd.Mytransid equals app.Mytransid
                        where e.EmployeeId == employeeId ///&& hd.Active == true
                        select new ReturnServiceApprovals
                        {
                            MyTransId = (int)hd.Mytransid,
                            EmployeeId = Convert.ToInt32(e.EmployeeId),
                            EnglishName = e.EnglishName,
                            ArabicName = e.ArabicName,
                            Services = hd.ServiceId.ToString(),
                            Source = "Online",
                            TotalInstallments = (int)hd.Totinstallments,
                            Amount = (decimal)hd.InstallmentAmount,
                            Discounted = hd.Discount.ToString(),
                            InstallmentBeginDate = hd.InstallmentsBegDate,
                            UntilMonth = hd.UntilMonth,
                            ServiceType = hd.ServiceType,
                            ServiceSubType = hd.ServiceSubType,
                            TotalAmount = hd.Totamt

                        }).ToList();
            return data;
        }

        public async Task<IEnumerable<ReturnServiceApprovalDetails>> GetServiceApprovalDetailByTransId(int transId)
        {
            var data = (from hd in _context.TransactionHds
                        join dt in _context.TransactionDts
                        on hd.Mytransid equals dt.Mytransid
                        where hd.Mytransid == transId
                        select new ReturnServiceApprovalDetails
                        {
                            MyTransId = (int)hd.Mytransid,
                            MyId = dt.Myid,
                            InstallmentAmount = dt.InstallmentAmount,
                            PendingAmount = dt.PendingAmount,
                            ReceivedAmount = dt.ReceivedAmount,
                            DiscountedAmount = dt.DiscountAmount
                        }).ToList();
            return data;
        }

        public IEnumerable<SelectServiceTypeDto> GetServiceType(int tenentId)
        {
            //var result = _context.ServiceSetups.Where(c => c.Active == "1" && c.TenentId == tenentId).ToList();

            var result = _context.ServiceSetups
                .ToList().Where(c => c.Active == "1" && c.TenentId == tenentId)
                .GroupBy(c => new { c.ServiceType, c.ServiceName1 }).Select(c => c.First()).ToList();
            var data = _mapper.Map<IEnumerable<SelectServiceTypeDto>>(result);
            return data;
        }
        //public async Task<IEnumerable<SelectSubServiceTypeDto>> GetSubServiceTypeByServiceType(int tenentId, int serviceId)
        //{
        //    var result = await _context.ServiceSetups.Where(c => c.Active == "1" && c.ServiceType == serviceId && c.TenentId == tenentId).ToListAsync();

        //    var data = _mapper.Map<IEnumerable<SelectSubServiceTypeDto>>(result);

        //    return data;
        //}

        public async Task<int> MakeFinancialTransactionAsync(CostCenterDto costCenterDto)
        {
            int result = 0;
            if (_context != null)
            {
                var newTransaction = _mapper.Map<CostCenter>(costCenterDto);
                await _context.CostCenters.AddAsync(newTransaction);
                result = await _context.SaveChangesAsync();

            }
            return result;
        }

        public async Task<ReturnApprovalDetailsDto> GetServiceApprovalsByTransIdAsync(int tenentId, int locationId, int transId)
        {

            var result = (from hd in _context.TransactionHds
                          join emp in _context.DetailedEmployees
                          on hd.EmployeeId equals emp.EmployeeId
                          where hd.Mytransid == transId
                          select new ReturnApprovalDetailsDto
                          {
                              ArabicName = emp.ArabicName,
                              EnglishName = emp.EnglishName,
                              ServiceSubType = hd.ServiceSubType,
                              ServiceType = hd.ServiceType,
                              Totamt = hd.Totamt
                          }).FirstOrDefault();

            return result;
        }

        public async Task<PagedList<CashierApprovalDto>> GetCashierApprovals([FromQuery] PaginationModel paginationModel, long periodCode, int tenentId, int locationId, bool isShowAll)
        {
            if (isShowAll)
            {
                var data = (from e in _context.DetailedEmployees
                            join ap in _context.TransactionHddapprovalDetails
                            on Convert.ToInt32(e.EmployeeId) equals ap.EmployeeId
                            join hd in _context.TransactionHds
                            on ap.Mytransid equals hd.Mytransid
                            where ap.TenentId == tenentId &&
                            ap.LocationId == locationId &&
                            ap.SerApprovalId == 3 && // Cashier Role Id
                            ap.DisplayPERIOD_CODE <= periodCode
                            select new CashierApprovalDto
                            {
                                TransId = (int)ap.Mytransid,
                                EmployeeId = Convert.ToString(e.EmployeeId),
                                EnglishName = e.EnglishName,
                                ArabicName = e.ArabicName,
                                ServiceName = hd.ServiceSubType,
                                Pfid = e.Pfid,
                                EmpCidNum = e.EmpCidNum,
                                MobileNumber = e.MobileNumber,
                                PeriodCode = Convert.ToString(ap.DisplayPERIOD_CODE),
                                TenentId = ap.TenentId,
                                LocationId = ap.LocationId,
                                DraftAmount1 = hd.DraftAmount1,
                                DraftAmount2 = hd.DraftAmount2,
                                DraftDate1 = hd.DraftDate1,
                                DraftDate2 = hd.DraftDate2,
                                IsDraftCreated = hd.IsDraftCreated
                            }).OrderByDescending(c => c.TransId).AsQueryable();
                if (!string.IsNullOrEmpty(paginationModel.Query))
                {
                    data = data.Where(u =>
                    u.Pfid.ToLower().Contains(paginationModel.Query.ToLower()) ||
                      u.TransId.ToString().ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.ServiceName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EmpCidNum.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.MobileNumber.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EmployeeId.ToLower().Contains(paginationModel.Query.ToLower())
                        );
                }
                return await PagedList<CashierApprovalDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);

            }
            else
            {
                var data = (from e in _context.DetailedEmployees
                            join ap in _context.TransactionHddapprovalDetails
                            on Convert.ToInt32(e.EmployeeId) equals ap.EmployeeId
                            join hd in _context.TransactionHds
                            on ap.Mytransid equals hd.Mytransid
                            where ap.TenentId == tenentId &&
                            ap.LocationId == locationId &&
                            ap.SerApprovalId == 3 && // Cashier Role Id
                            ap.Active == true &&
                            ap.DisplayPERIOD_CODE <= periodCode
                            select new CashierApprovalDto
                            {
                                TransId = (int)ap.Mytransid,
                                EmployeeId = Convert.ToString(e.EmployeeId),
                                EnglishName = e.EnglishName,
                                ArabicName = e.ArabicName,
                                ServiceName = hd.ServiceSubType,
                                Pfid = e.Pfid,
                                EmpCidNum = e.EmpCidNum,
                                MobileNumber = e.MobileNumber,
                                PeriodCode = Convert.ToString(ap.DisplayPERIOD_CODE),
                                TenentId = ap.TenentId,
                                LocationId = ap.LocationId,
                                DraftAmount1 = hd.DraftAmount1,
                                DraftAmount2 = hd.DraftAmount2,
                                DraftDate1 = hd.DraftDate1,
                                DraftDate2 = hd.DraftDate2,
                                IsDraftCreated = hd.IsDraftCreated
                            }).OrderByDescending(c => c.TransId).AsQueryable();
                if (!string.IsNullOrEmpty(paginationModel.Query))
                {
                    data = data.Where(u =>
                    u.Pfid.ToLower().Contains(paginationModel.Query.ToLower()) ||
                      u.TransId.ToString().ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.ServiceName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EmpCidNum.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.MobileNumber.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EmployeeId.ToLower().Contains(paginationModel.Query.ToLower())
                        );
                }
                return await PagedList<CashierApprovalDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);
            }
        }

        public async Task<int> CreateCahierDelivery(CashierApprovalDto cashierApprovalDto)
        {
            int result = 0;
            var existingtransactionHd = _context.TransactionHds
                    .Where(c => c.Mytransid == cashierApprovalDto.TransId &&
                    c.EmployeeId == Convert.ToInt32(cashierApprovalDto.EmployeeId)).FirstOrDefault();

            var existingTransactionApprovals = _context.TransactionHddapprovalDetails
                .Where(p => p.Mytransid == cashierApprovalDto.TransId
                && p.EmployeeId == Convert.ToInt32(cashierApprovalDto.EmployeeId) && p.SerApprovalId == 3).FirstOrDefault();
            //
            var serviceApprovals = _context.ServiceSetups.Where(p => p.ServiceType == existingtransactionHd.ServiceTypeId && p.ServiceSubType == existingtransactionHd.ServiceSubTypeId).FirstOrDefault();

            if (existingtransactionHd != null)
            {
                //
                existingTransactionApprovals.Status = "CashierDelivery";
                existingTransactionApprovals.ApprovalDate = DateTime.Now;
                _context.TransactionHddapprovalDetails.Update(existingTransactionApprovals);
                result = await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();
                //
                if (serviceApprovals != null)
                {
                    List<string> myService = new List<string>
                            {
                                serviceApprovals.SerApproval1,
                                serviceApprovals.SerApproval2,
                                serviceApprovals.SerApproval3,
                                serviceApprovals.SerApproval4,
                                serviceApprovals.SerApproval5,
                                serviceApprovals.SerApproval6
                            };
                    if (serviceApprovals != null)
                    {
                        myService.RemoveAll(item => item == null);
                        existingtransactionHd.SerApproval3 = myService[2];
                        existingtransactionHd.ApprovalBy3 = cashierApprovalDto.DeliveredBy1;
                        existingtransactionHd.ApprovedDate3 = DateTime.Now;
                    }
                }

                existingtransactionHd.DraftNumber1 = cashierApprovalDto.DraftNumber1;
                existingtransactionHd.DraftNumber2 = cashierApprovalDto.DraftNumber2;
                existingtransactionHd.DraftDate1 = cashierApprovalDto.DraftDate1;
                existingtransactionHd.DraftDate2 = cashierApprovalDto.DraftDate2;
                existingtransactionHd.TotalAmount = cashierApprovalDto.TotalAmount;
                existingtransactionHd.BankAccount1 = cashierApprovalDto.BankAccount1;
                existingtransactionHd.ReceivedBy1 = cashierApprovalDto.ReceivedBy1;
                existingtransactionHd.ReceivedDate1 = cashierApprovalDto.ReceivedDate1;
                existingtransactionHd.DeliveryDate1 = cashierApprovalDto.ReceivedDate;
                existingtransactionHd.DeliveredBy1 = cashierApprovalDto.DeliveredBy1;
                existingtransactionHd.Transdate = DateTime.Now;
                existingtransactionHd.Status = "CashierDelivery";
                existingtransactionHd.Mytransid = (long)cashierApprovalDto.TransId;
                existingtransactionHd.EmployeeId = Convert.ToInt32(cashierApprovalDto.EmployeeId);
                existingtransactionHd.Active = false;

                _context.TransactionHds.Update(existingtransactionHd);
                result = await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();
            }
            // Update approvals
            var approvals = _context.TransactionHddapprovalDetails.Where(c => c.Mytransid == cashierApprovalDto.TransId &&
            c.EmployeeId == Convert.ToInt32(cashierApprovalDto.EmployeeId) && c.SerApprovalId == 3 && c.Active == true).FirstOrDefault();
            if (approvals != null)
            {
                approvals.Active = false;
                _context.TransactionHddapprovalDetails.Update(approvals);
                result = await _context.SaveChangesAsync();

            }

            return result;
        }

        public async Task<int> CreateCahierDraft(CashierApprovalDto cashierApprovalDto)
        {
            int result = 0;
            try
            {

                var existingtransactionHd = _context.TransactionHds
                        .Where(c => c.Mytransid == cashierApprovalDto.TransId &&
                        c.EmployeeId == Convert.ToInt32(cashierApprovalDto.EmployeeId)).FirstOrDefault();

                var existingTransactionApprovals = _context.TransactionHddapprovalDetails
                    .Where(p => p.Mytransid == cashierApprovalDto.TransId
                    && p.EmployeeId == Convert.ToInt32(cashierApprovalDto.EmployeeId) && p.SerApprovalId == 3).FirstOrDefault();

                var data = _context.TransactionHddapprovalDetails
             .Where(c => c.Mytransid == existingtransactionHd.Mytransid
               && c.SerApprovalId == 1).FirstOrDefault();

                var crupid = data.CrupId == null ? 0 : data.CrupId;

                if (existingtransactionHd != null)
                {
                    //
                    existingtransactionHd.DraftNumber1 = cashierApprovalDto.DraftNumber1;
                    existingtransactionHd.DraftNumber2 = cashierApprovalDto.DraftNumber2;
                    existingtransactionHd.DraftDate1 = cashierApprovalDto.DraftDate1;
                    existingtransactionHd.DraftDate2 = cashierApprovalDto.DraftDate2;
                    existingtransactionHd.TotalAmount = cashierApprovalDto.TotalAmount;
                    existingtransactionHd.BankAccount1 = cashierApprovalDto.BankAccount1;
                    existingtransactionHd.ReceivedBy1 = cashierApprovalDto.ReceivedBy1;
                    existingtransactionHd.ReceivedDate1 = cashierApprovalDto.ReceivedDate1;
                    existingtransactionHd.DeliveryDate1 = cashierApprovalDto.ReceivedDate;
                    existingtransactionHd.DeliveredBy1 = cashierApprovalDto.DeliveredBy1;
                    existingtransactionHd.Transdate = DateTime.Now;
                    existingtransactionHd.Status = "DraftMade";
                    existingtransactionHd.IsDraftCreated = true;

                    existingtransactionHd.Mytransid = (long)cashierApprovalDto.TransId;
                    existingtransactionHd.EmployeeId = Convert.ToInt32(cashierApprovalDto.EmployeeId);
                    existingtransactionHd.AccountantID = cashierApprovalDto.AccountantID;
                    existingtransactionHd.BenefeciaryName = cashierApprovalDto.BenefeciaryName;
                    existingtransactionHd.ChequeNumber = cashierApprovalDto.ChequeNumber;
                    existingtransactionHd.ChequeDate = cashierApprovalDto.ChequeDate;
                    existingtransactionHd.ChequeAmount = cashierApprovalDto.ChequeAmount;
                    existingtransactionHd.CollectedBy = cashierApprovalDto.CollectedBy;
                    existingtransactionHd.Relationship = cashierApprovalDto.Relationship;
                    existingtransactionHd.CollectedPersonCID = cashierApprovalDto.CollectedPersonCID;

                    _context.TransactionHds.Update(existingtransactionHd);
                    result = await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();


                    existingTransactionApprovals.CrupId = crupid;
                    existingTransactionApprovals.Status = "CashierDraft";
                    existingTransactionApprovals.ApprovalDate = DateTime.Now;
                    _context.TransactionHddapprovalDetails.Update(existingTransactionApprovals);
                    result = await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();
                }


                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public int GenerateFinancialServiceSerialNo()
        {
            int maxSerialNo = (int)_context.TransactionHds.FromSqlRaw("select ISNULL(max(ServiceID),0)+1 as ServiceId from TransactionHD").Select(p => p.ServiceId).FirstOrDefault();
            return maxSerialNo;
        }
        #region
        public async Task<ReturnSearchResultDto> SearchEmployee(SearchEmployeeDto searchEmployeeDto)
        {
            if (searchEmployeeDto.EmployeeId == 0
                && string.IsNullOrWhiteSpace(searchEmployeeDto.PFId)
                && string.IsNullOrWhiteSpace(searchEmployeeDto.CID))
            {
                throw new Exception("Invalid Input");
            }

            var employee = new Models.DetailedEmployee();
            List<TransactionDt> transactions = new List<TransactionDt>();
            string empStatus = string.Empty;
            string subscriptionStatus = string.Empty;
            if (searchEmployeeDto.EmployeeId != 0)
            {
                employee = await _context.DetailedEmployees.Where(c => c.EmployeeId == searchEmployeeDto.EmployeeId).FirstOrDefaultAsync();
                if (employee != null)
                {
                    transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
                }
            }
            else if (searchEmployeeDto.PFId != string.Empty || !string.IsNullOrWhiteSpace(searchEmployeeDto.PFId))
            {

                employee = await _context.DetailedEmployees.Where(c => c.Pfid == searchEmployeeDto.PFId).FirstOrDefaultAsync();
                if (employee != null)
                {
                    transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
                }
            }
            else if (searchEmployeeDto.CID != string.Empty || !string.IsNullOrWhiteSpace(searchEmployeeDto.CID))
            {
                employee = await _context.DetailedEmployees.Where(c => c.EmpCidNum == searchEmployeeDto.CID).FirstOrDefaultAsync();
                if (employee != null)
                {
                    transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
                }
            }

            if (employee == null)
            {
                return new ReturnSearchResultDto
                {
                    IsSuccess = false,
                    Message = "Employee not found"
                };
            }
            else
            {
                var country = await _context.TblCountries.Where(c => c.TenentId == employee.TenentId && c.Countryid == employee.NationCode).FirstOrDefaultAsync();
                //
                var contractType = await _context.Reftables.Where(c => c.TenentId == employee.TenentId && c.Refid == Convert.ToInt32(employee.ContractType) && c.Refsubtype == "ContractType").FirstOrDefaultAsync();
                //
                if (employee.EmpStatus != null)
                    empStatus = await _context.Reftables.Where(p => p.Refid == (int)employee.EmpStatus && p.Reftype == "KUPF" && p.Refsubtype == "EmpStatus").Select(c => c.Shortname).FirstOrDefaultAsync();
                //
                if (employee.Subscription_status != null)
                    subscriptionStatus = await _context.Reftables.Where(p => p.Refid == (int)employee.Subscription_status && p.Reftype == "KUPF" && p.Refsubtype == "SubscriptionStatus").Select(c => c.Shortname).FirstOrDefaultAsync();
                var data = new ReturnSearchResultDto()
                {
                    TenentId = employee.TenentId,
                    LocationId = employee.LocationId,
                    EmployeeId = employee.EmployeeId.ToString(),
                    Pfid = employee.Pfid,
                    EmpCidNum = employee.EmpCidNum,
                    EnglishName = employee.EnglishName,
                    ArabicName = employee.ArabicName,
                    EmpGender = employee.EmpGender,
                    JoinedDate = employee.JoinedDate,
                    MobileNumber = employee.MobileNumber,
                    EmpMaritalStatus = employee.EmpMaritalStatus,
                    ContractType = contractType.Refid.ToString(),
                    Next2KinName = employee.Next2KinName,
                    Next2KinMobNumber = employee.Next2KinMobNumber,
                    EndDate = employee.EndDate,
                    EmployeeStatus = empStatus,
                    SubscriptionStatus = subscriptionStatus,
                    SubscriptionAmount = transactions.Sum(c => (decimal)c.InstallmentAmount),
                    SubscriptionPaid = transactions.Sum(c => (decimal)c.ReceivedAmount),
                    LastSubscriptionPaid = transactions.Sum(c => (decimal)c.PendingAmount),
                    SubscriptionDueAmount = transactions.Sum(c => (decimal)c.PendingAmount),
                    IsKUEmployee = employee.IsKUEmployee,
                    IsMemberOfFund = employee.IsMemberOfFund,
                    IsOnSickLeave = employee.IsOnSickLeave,
                    CountryId = country.Countryid,
                    CountryNameArabic = country.Couname2,
                    CountryNameEnglish = country.Couname1,
                    IsSuccess = true,
                    Salary = (decimal)employee.Salary,
                    TerminationDate = employee.TerminationDate
                };
                if (employee.Subscription_status == 2)
                {
                    data.IsSuccess = false;
                    data.Message = "Membership Subscription is  Rejected";
                }
                else if (employee.EmpStatus != 1 || employee.Subscription_status != 1)
                {
                    data.IsSuccess = false;
                    data.Message = "Employee is not Subscribed / Terminated/Rejected / Settlement Done";
                }
                else if (employee.TerminationId != null)
                {

                    data.IsSuccess = false;
                    data.Message = "" + employee.EnglishName + " is Terminated On " + ((DateTime)employee.TerminationDate).ToString("dd/MM/yyyy") + " Can not proceed";
                }
                else if (employee.Pfid == null)
                {

                    data.IsSuccess = false;
                    data.Message = "Membership Subscription Approval is pending";
                }
                return data;
            }
        }

        public async Task<ReturnSearchResultDto> SearchSponsor(SearchEmployeeDto searchEmployeeDto)
        {
            if (searchEmployeeDto.EmployeeId == 0
                && string.IsNullOrWhiteSpace(searchEmployeeDto.PFId)
                && string.IsNullOrWhiteSpace(searchEmployeeDto.CID))
            {
                throw new Exception("Invalid Input");
            }

            var employee = new Models.DetailedEmployee();
            List<TransactionDt> transactions = new List<TransactionDt>();
            string empStatus = string.Empty;
            string subscriptionStatus = string.Empty;
            if (searchEmployeeDto.EmployeeId != 0)
            {
                employee = await _context.DetailedEmployees.Where(c => c.EmployeeId == searchEmployeeDto.EmployeeId && c.TerminationDate == null && c.SubscribedDate != null && c.Pfid != null).FirstOrDefaultAsync();
                transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
            }
            else if (searchEmployeeDto.PFId != string.Empty || !string.IsNullOrWhiteSpace(searchEmployeeDto.PFId))
            {
                employee = await _context.DetailedEmployees.Where(c => c.Pfid == searchEmployeeDto.PFId && c.TerminationDate == null && c.SubscribedDate != null && c.Pfid != null).FirstOrDefaultAsync();
                transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
            }
            else if (searchEmployeeDto.CID != string.Empty || !string.IsNullOrWhiteSpace(searchEmployeeDto.CID))
            {
                employee = await _context.DetailedEmployees.Where(c => c.EmpCidNum == searchEmployeeDto.CID && c.TerminationDate == null && c.SubscribedDate != null && c.Pfid != null).FirstOrDefaultAsync();
                transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
            }
            if (employee == null)
            {
                return new ReturnSearchResultDto
                {
                    IsSuccess = false,
                    Message = "Sponsor not found..."
                };
            }
            else
            {
                if (employee.EmpStatus != 1 || employee.Subscription_status != 2)
                {
                    return new ReturnSearchResultDto
                    {
                        IsSuccess = false,
                        Message = "Employee is not Subscribed / Terminated / Settlement Done"
                    };
                }
                else if (employee.TerminationId != null)
                {
                    return new ReturnSearchResultDto
                    {
                        IsSuccess = false,
                        Message = "" + employee.EnglishName + " is Terminated On " + ((DateTime)employee.TerminationDate).ToString("dd/MM/yyyy") + " Cant proceed"
                    };
                }

                var country = await _context.TblCountries.Where(c => c.TenentId == employee.TenentId && c.Countryid == employee.NationCode).FirstOrDefaultAsync();
                //
                var contractType = await _context.Reftables.Where(c => c.TenentId == employee.TenentId && c.Refid == Convert.ToInt32(employee.ContractType) && c.Refsubtype == "ContractType").FirstOrDefaultAsync();
                //
                if (employee.EmpStatus != null)
                    empStatus = await _context.Reftables.Where(p => p.Refid == (int)employee.EmpStatus && p.Reftype == "KUPF" && p.Refsubtype == "EmpStatus").Select(c => c.Shortname).FirstOrDefaultAsync();
                //
                if (employee.Subscription_status != null)
                    subscriptionStatus = await _context.Reftables.Where(p => p.Refid == (int)employee.Subscription_status && p.Reftype == "KUPF" && p.Refsubtype == "SubscriptionStatus").Select(c => c.Shortname).FirstOrDefaultAsync();
                var data = new ReturnSearchResultDto()
                {
                    TenentId = employee.TenentId,
                    LocationId = employee.LocationId,
                    EmployeeId = employee.EmployeeId.ToString(),
                    Pfid = employee.Pfid,
                    EmpCidNum = employee.EmpCidNum,
                    EnglishName = employee.EnglishName,
                    ArabicName = employee.ArabicName,
                    EmpGender = employee.EmpGender,
                    JoinedDate = employee.JoinedDate,
                    MobileNumber = employee.MobileNumber,
                    EmpMaritalStatus = employee.EmpMaritalStatus,
                    ContractType = contractType.Refid.ToString(),
                    Next2KinName = employee.Next2KinName,
                    Next2KinMobNumber = employee.Next2KinMobNumber,
                    EndDate = employee.EndDate,
                    EmployeeStatus = empStatus,
                    SubscriptionStatus = subscriptionStatus,
                    SubscriptionAmount = transactions.Sum(c => (decimal)c.InstallmentAmount),
                    SubscriptionPaid = transactions.Sum(c => (decimal)c.ReceivedAmount),
                    LastSubscriptionPaid = transactions.Sum(c => (decimal)c.PendingAmount),
                    SubscriptionDueAmount = transactions.Sum(c => (decimal)c.PendingAmount),
                    IsKUEmployee = employee.IsKUEmployee,
                    IsMemberOfFund = employee.IsMemberOfFund,
                    IsOnSickLeave = employee.IsOnSickLeave,
                    CountryId = country.Countryid,
                    CountryNameArabic = country.Couname2,
                    CountryNameEnglish = country.Couname1,
                    IsSuccess = true,
                    Salary = (decimal)employee.Salary,
                    TerminationDate = employee.TerminationDate
                };
                return data;

            }
        }
        public async Task<ReturnSearchResultDto> SearchNewSubscriber(SearchEmployeeDto searchEmployeeDto)
        {
            if (searchEmployeeDto.EmployeeId == 0
               && string.IsNullOrWhiteSpace(searchEmployeeDto.PFId)
               && string.IsNullOrWhiteSpace(searchEmployeeDto.CID))
            {
                throw new Exception("Invalid Input");
            }

            var employee = new Models.DetailedEmployee();
            List<TransactionDt> transactions = new List<TransactionDt>();
            string empStatus = string.Empty;
            string subscriptionStatus = string.Empty;

            if (searchEmployeeDto.EmployeeId != 0)
            {
                employee = await _context.DetailedEmployees.Where(c => c.EmployeeId == searchEmployeeDto.EmployeeId).FirstOrDefaultAsync();
                transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
            }
            else if (searchEmployeeDto.PFId != string.Empty || !string.IsNullOrWhiteSpace(searchEmployeeDto.PFId))
            {
                employee = await _context.DetailedEmployees.Where(c => c.Pfid == searchEmployeeDto.PFId).FirstOrDefaultAsync();
                transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
            }
            else if (searchEmployeeDto.CID != string.Empty || !string.IsNullOrWhiteSpace(searchEmployeeDto.CID))
            {
                employee = await _context.DetailedEmployees.Where(c => c.EmpCidNum == searchEmployeeDto.CID).FirstOrDefaultAsync();
                transactions = _context.TransactionDts.Where(p => p.TenentId == employee.TenentId && p.LocationId == employee.LocationId && p.EmployeeId == Convert.ToInt32(employee.EmployeeId)).ToList();
            }
            if (employee == null)
            {
                return new ReturnSearchResultDto
                {
                    IsSuccess = false,
                    Message = "Employee not found..."
                };
            }
            else if (employee.TerminationDate != null)
            {
                return new ReturnSearchResultDto
                {
                    IsSuccess = false,
                    Message = "Employee is terminated on" + employee.TerminationDate + ""
                };
            }
            else
            {
                // 1 = Joined and null = Not Subscribered
                if (employee.EmpStatus == 1 && employee.Subscription_status != null)
                {
                    return new ReturnSearchResultDto
                    {
                        // employe empstatus 1=joined subscription stuats =2  i consider this person is subscribed 
                        // if termination date is null and terminationid is null than this persons is not terminated and true live subscriber
                        IsSuccess = false,
                        Message = "This is employee is already susbcribed. Please click on Search Employee"
                    };
                }
                else if (employee.TerminationId != null)
                {
                    return new ReturnSearchResultDto
                    {
                        IsSuccess = false,
                        Message = "" + employee.EnglishName + " is Terminated On " + ((DateTime)employee.TerminationDate).ToString("dd/MM/yyyy") + " Cant proceed"
                    };
                }

                var country = await _context.TblCountries.Where(c => c.TenentId == employee.TenentId && c.Countryid == employee.NationCode).FirstOrDefaultAsync();
                //
                var contractType = await _context.Reftables.Where(c => c.TenentId == employee.TenentId && c.Refid == Convert.ToInt32(employee.ContractType) && c.Refsubtype == "ContractType").FirstOrDefaultAsync();
                //
                if (employee.EmpStatus != null)
                    empStatus = await _context.Reftables.Where(p => p.Refid == (int)employee.EmpStatus && p.Reftype == "KUPF" && p.Refsubtype == "EmpStatus").Select(c => c.Shortname).FirstOrDefaultAsync();
                //
                if (employee.Subscription_status != null)
                    subscriptionStatus = await _context.Reftables.Where(p => p.Refid == (int)employee.Subscription_status && p.Reftype == "KUPF" && p.Refsubtype == "SubscriptionStatus").Select(c => c.Shortname).FirstOrDefaultAsync();
                var data = new ReturnSearchResultDto()
                {
                    TenentId = employee.TenentId,
                    LocationId = employee.LocationId,
                    EmployeeId = employee.EmployeeId.ToString(),
                    Pfid = employee.Pfid,
                    EmpCidNum = employee.EmpCidNum,
                    EnglishName = employee.EnglishName,
                    ArabicName = employee.ArabicName,
                    EmpGender = employee.EmpGender,
                    JoinedDate = employee.JoinedDate,
                    MobileNumber = employee.MobileNumber,
                    EmpMaritalStatus = employee.EmpMaritalStatus,
                    ContractType = contractType.Refid.ToString(),
                    Next2KinName = employee.Next2KinName,
                    Next2KinMobNumber = employee.Next2KinMobNumber,
                    EndDate = employee.EndDate,
                    EmployeeStatus = empStatus,
                    SubscriptionStatus = subscriptionStatus,
                    SubscriptionAmount = transactions.Sum(c => (decimal)c.InstallmentAmount),
                    SubscriptionPaid = transactions.Sum(c => (decimal)c.ReceivedAmount),
                    LastSubscriptionPaid = transactions.Sum(c => (decimal)c.PendingAmount),
                    SubscriptionDueAmount = transactions.Sum(c => (decimal)c.PendingAmount),
                    IsKUEmployee = employee.IsKUEmployee,
                    IsMemberOfFund = employee.IsMemberOfFund,
                    IsOnSickLeave = employee.IsOnSickLeave,
                    CountryId = country.Countryid,
                    CountryNameArabic = country.Couname2,
                    CountryNameEnglish = country.Couname1,
                    IsSuccess = true,
                    Salary = (decimal)employee.Salary,
                    TerminationDate = employee.TerminationDate
                };
                return data;

            }
        }

        #endregion

        public async Task<IEnumerable<ReturnApprovalsByEmployeeId>> GetServiceApprovalsByEmployeeIdForManager(int employeeId, int tenentId, int locationId)
        {
            var data = (from ap in _context.TransactionHddapprovalDetails
                        join hd in _context.TransactionHds
                        on ap.Mytransid equals hd.Mytransid
                        where ap.TenentId == tenentId &&
                        ap.TenentId == tenentId &&
                        ap.LocationId == locationId &&
                        ap.LocationId == locationId &&
                        ap.EmployeeId == employeeId
                        select new ReturnApprovalsByEmployeeId
                        {
                            TransId = (int)ap.Mytransid,
                            TenentId = (int)ap.TenentId,
                            LocationId = ap.LocationId,
                            ServiceType = hd.ServiceType,
                            ServiceSubType = hd.ServiceSubType,
                            Status = ap.Status,
                            ApprovalRemarks = ap.ApprovalRemarks,
                            Active = ap.Active
                        }).ToList();
            return data;
        }

        public async Task<PagedList<CashierApprovalDto>> GetFinacialApprovals([FromQuery] PaginationModel paginationModel, long periodCode, int tenentId, int locationId, bool isShowAll)
        {
            if (isShowAll)
            {
                var data = (from e in _context.DetailedEmployees
                            join ap in _context.TransactionHddapprovalDetails
                            on Convert.ToInt32(e.EmployeeId) equals ap.EmployeeId
                            join hd in _context.TransactionHds
                            on ap.Mytransid equals hd.Mytransid
                            where ap.TenentId == tenentId &&
                            ap.LocationId == locationId &&
                            ap.SerApprovalId == 2 && // Finance Role Id Ser (ap.SerApprovalId == RoleID or RoleID==1)                            
                            ap.DisplayPERIOD_CODE <= periodCode
                            select new CashierApprovalDto
                            {
                                TransId = (int)ap.Mytransid,
                                EmployeeId = Convert.ToString(e.EmployeeId),
                                EnglishName = e.EnglishName,
                                ArabicName = e.ArabicName,
                                ServiceName = hd.ServiceSubType,
                                Pfid = e.Pfid,
                                EmpCidNum = e.EmpCidNum,
                                MobileNumber = e.MobileNumber,
                                PeriodCode = Convert.ToString(ap.DisplayPERIOD_CODE),
                                TenentId = ap.TenentId,
                                LocationId = ap.LocationId,
                                DraftAmount1 = hd.DraftAmount1,
                                DraftAmount2 = hd.DraftAmount2,
                                DraftDate1 = hd.DraftDate1,
                                DraftDate2 = hd.DraftDate2,
                                CrupId = (long)e.CRUP_ID,
                                EntryDate = hd.Entrydate
                            }).OrderByDescending(c => c.TransId).AsQueryable();
                if (!string.IsNullOrEmpty(paginationModel.Query))
                {
                    data = data.Where(u =>
                    u.Pfid.ToLower().Contains(paginationModel.Query.ToLower()) ||
                      u.TransId.ToString().ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.ServiceName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EmpCidNum.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.MobileNumber.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    //u.PeriodCode.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EmployeeId.ToLower().Contains(paginationModel.Query.ToLower())
                        );
                }

                return await PagedList<CashierApprovalDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);

            }
            else
            {
                var data = (from e in _context.DetailedEmployees
                            join ap in _context.TransactionHddapprovalDetails
                            on Convert.ToInt32(e.EmployeeId) equals ap.EmployeeId
                            join hd in _context.TransactionHds
                            on ap.Mytransid equals hd.Mytransid
                            where ap.TenentId == tenentId &&
                            ap.LocationId == locationId &&
                            ap.SerApprovalId == 2 && // Finance Role Id Ser (ap.SerApprovalId == RoleID or RoleID==1)
                            ap.Active == true &&
                            ap.DisplayPERIOD_CODE <= periodCode
                            select new CashierApprovalDto
                            {
                                TransId = (int)ap.Mytransid,
                                EmployeeId = Convert.ToString(e.EmployeeId),
                                EnglishName = e.EnglishName,
                                ArabicName = e.ArabicName,
                                ServiceName = hd.ServiceSubType,
                                Pfid = e.Pfid,
                                EmpCidNum = e.EmpCidNum,
                                MobileNumber = e.MobileNumber,
                                PeriodCode = Convert.ToString(ap.DisplayPERIOD_CODE),
                                TenentId = ap.TenentId,
                                LocationId = ap.LocationId,
                                DraftAmount1 = hd.DraftAmount1,
                                DraftAmount2 = hd.DraftAmount2,
                                DraftDate1 = hd.DraftDate1,
                                DraftDate2 = hd.DraftDate2,
                                CrupId = (long)e.CRUP_ID,
                                EntryDate = hd.Entrydate
                            }).OrderByDescending(c => c.TransId).AsQueryable();
                if (!string.IsNullOrEmpty(paginationModel.Query))
                {
                    data = data.Where(u =>
                    u.Pfid.ToLower().Contains(paginationModel.Query.ToLower()) ||
                      u.TransId.ToString().ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.ServiceName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EmpCidNum.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.MobileNumber.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    //u.PeriodCode.ToLower().Contains(paginationModel.Query.ToLower()) ||
                    u.EmployeeId.ToLower().Contains(paginationModel.Query.ToLower())
                        );
                }
                return await PagedList<CashierApprovalDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);

            }
        }

        public async Task<string> FinanceApproveServiceAsync(ApproveRejectServiceDto approveRejectServiceDto)
        {
            try
            {
                int result = 0;
                if (_context != null)
                {
                    // Update status of existing record...
                    var existingtransactionHddApprovals = _context.TransactionHddapprovalDetails
                        .Where(c => c.Mytransid == approveRejectServiceDto.Mytransid
                        && c.TenentId == approveRejectServiceDto.TenentId
                        && c.LocationId == approveRejectServiceDto.LocationId && c.SerApprovalId == 2).FirstOrDefault();

                    var data = _context.TransactionHddapprovalDetails
               .Where(c => c.Mytransid == approveRejectServiceDto.Mytransid
               && c.TenentId == approveRejectServiceDto.TenentId
               && c.LocationId == approveRejectServiceDto.LocationId && c.SerApprovalId == 1).FirstOrDefault();

                    var crupid = data.CrupId == null ? 0 : data.CrupId;
                    // 
                    var existingTransactionHd = _context.TransactionHds.Where(c => c.Mytransid == existingtransactionHddApprovals.Mytransid).FirstOrDefault();
                    //
                    var serviceApprovals = _context.ServiceSetups.Where(p => p.ServiceType == existingTransactionHd.ServiceTypeId && p.ServiceSubType == existingTransactionHd.ServiceSubTypeId).FirstOrDefault();
                    if (existingtransactionHddApprovals != null)
                    {
                        // Update TransactionHddapprovalDetails
                        existingtransactionHddApprovals.SerApproval = Convert.ToString(approveRejectServiceDto.RoleId);
                        existingtransactionHddApprovals.Userid = approveRejectServiceDto.UserId;
                        existingtransactionHddApprovals.ApprovalDate = approveRejectServiceDto.ApprovalDate;
                        existingtransactionHddApprovals.Entrydate = (DateTime)approveRejectServiceDto.Entrydate;
                        existingtransactionHddApprovals.Entrytime = (DateTime)approveRejectServiceDto.Entrytime;
                        existingtransactionHddApprovals.Status = "FinanceApproved";
                        existingtransactionHddApprovals.CrupId = crupid;
                        existingtransactionHddApprovals.ApprovalDate = DateTime.Now;
                        existingtransactionHddApprovals.ApprovalRemarks = approveRejectServiceDto.ApprovalRemarks;
                        existingtransactionHddApprovals.Active = false;
                        _context.TransactionHddapprovalDetails.Update(existingtransactionHddApprovals);
                        await _context.SaveChangesAsync();
                        _context.ChangeTracker.Clear();
                        //
                        if (serviceApprovals != null)
                        {
                            List<string> myService = new List<string>
                            {
                                serviceApprovals.SerApproval1,
                                serviceApprovals.SerApproval2,
                                serviceApprovals.SerApproval3,
                                serviceApprovals.SerApproval4,
                                serviceApprovals.SerApproval5,
                                serviceApprovals.SerApproval6
                            };
                            if (serviceApprovals != null)
                            {
                                myService.RemoveAll(item => item == null);
                                existingTransactionHd.SerApproval2 = myService[1];
                                existingTransactionHd.ApprovalBy2 = approveRejectServiceDto.UserId;
                                existingTransactionHd.ApprovedDate2 = DateTime.Now;
                            }
                        }
                        // Update TransactionHD.                    
                        _context.TransactionHds.Update(existingTransactionHd);
                        await _context.SaveChangesAsync();
                        _context.ChangeTracker.Clear();

                    }
                    var activateNextRow = _context.TransactionHddapprovalDetails
                        .Where(c => c.Mytransid == approveRejectServiceDto.Mytransid
                        && c.TenentId == approveRejectServiceDto.TenentId
                        && c.LocationId == approveRejectServiceDto.LocationId && c.SerApprovalId == 3).FirstOrDefault();

                    if (activateNextRow != null)
                    {
                        activateNextRow.Active = true;
                        _context.TransactionHddapprovalDetails.Update(activateNextRow);
                        await _context.SaveChangesAsync();
                        _context.ChangeTracker.Clear();
                    }
                    return result.ToString();
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }

        }

        public async Task<string> FinanceRejectServiceAsync(ApproveRejectServiceDto approveRejectServiceDto)
        {
            int result = 0;
            if (_context != null)
            {
                // To get record by transId and Active...
                var existingtransactionHddApprovals = _context.TransactionHddapprovalDetails
                    .Where(c => c.Mytransid == approveRejectServiceDto.Mytransid && c.Active == true).FirstOrDefault();

                // TO CHECK IF CRUP_ID IS NULL DETAILEDEMPLOYEE.
                var detailedEmployee = _context.DetailedEmployees.Where(c => c.EmployeeId == existingtransactionHddApprovals.EmployeeId
                    && c.TenentId == approveRejectServiceDto.TenentId
                    && c.LocationId == approveRejectServiceDto.LocationId).FirstOrDefault();
                // 
                var existingTransactionHd = _context.TransactionHds.Where(c => c.Mytransid == existingtransactionHddApprovals.Mytransid).FirstOrDefault();

                //
                var serviceApprovals = _context.ServiceSetups.Where(p => p.ServiceType == existingTransactionHd.ServiceTypeId && p.ServiceSubType == existingTransactionHd.ServiceSubTypeId).FirstOrDefault();
                //
                if (existingtransactionHddApprovals != null)
                {
                    // Update TransactionHddapprovalDetails
                    existingtransactionHddApprovals.RejectionType = approveRejectServiceDto.RejectionType;
                    existingtransactionHddApprovals.RejectionRemarks = approveRejectServiceDto.RejectionRemarks;
                    existingtransactionHddApprovals.Active = false;
                    existingtransactionHddApprovals.Status = "FinanceRejected";
                    existingtransactionHddApprovals.ApprovalDate = DateTime.Now;
                    _context.TransactionHddapprovalDetails.Update(existingtransactionHddApprovals);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();
                    //
                    if (serviceApprovals != null)
                    {
                        List<string> myService = new List<string>
                            {
                                serviceApprovals.SerApproval1,
                                serviceApprovals.SerApproval2,
                                serviceApprovals.SerApproval3,
                                serviceApprovals.SerApproval4,
                                serviceApprovals.SerApproval5,
                                serviceApprovals.SerApproval6
                            };
                        if (serviceApprovals != null)
                        {
                            myService.RemoveAll(item => item == null);
                            existingTransactionHd.Status = "Rejected";
                            existingTransactionHd.SerApproval2 = myService[1];
                            existingTransactionHd.ApprovalBy2 = approveRejectServiceDto.UserId;
                            existingTransactionHd.ApprovedDate2 = DateTime.Now;
                        }
                    }
                    // Update TransactionHD.                    
                    _context.TransactionHds.Update(existingTransactionHd);
                    await _context.SaveChangesAsync();
                    _context.ChangeTracker.Clear();

                    if (existingTransactionHd.ServiceTypeId == 1 && existingTransactionHd.ServiceSubTypeId == 1)
                    {
                        // Update Employee Details.
                        detailedEmployee.Subscription_status = 2; // rejected
                        _context.DetailedEmployees.Update(detailedEmployee);
                    }
                    result = await _context.SaveChangesAsync();
                }

            }
            return result.ToString();
        }
        public long GetPeriodCode()
        {
            long periodCode = _context.Tblperiods.FromSqlRaw("select * from tblperiods where getdate() between PRD_START_DATE and PRD_END_DATE").Select(p => p.PeriodCode).FirstOrDefault();
            return periodCode;
        }

        public long GenerateMonthForOneYearLater()
        {
            long nextYearPeriodCode =Convert.ToInt64( _context.Tblperiods.FromSqlRaw("select * from tblperiods where getdate() between PRD_START_DATE and PRD_END_DATE").Select(p => p.PrdPeriod3).FirstOrDefault());
            return nextYearPeriodCode;

        }

        public async Task<IEnumerable<ReturnTransactionHdDto>> GetFinancialServiceData(int pageNo, int itemCount, string searchKeyword)
        {
            var filterdata = new List<ReturnTransactionHdDto>();
            try
            {
                var data = (from e in _context.DetailedEmployees
                            join t in _context.TransactionHds
                            on Convert.ToInt32(e.EmployeeId) equals t.EmployeeId
                            select new ReturnTransactionHdDto
                            {
                                MYTRANSID = t.Mytransid,
                                EmployeeId = Convert.ToInt32(e.EmployeeId),
                                PFId = e.Pfid,
                                CID = e.EmpCidNum,
                                EnglishName = e.EnglishName,
                                ArabicName = e.ArabicName,
                                ServiceType = t.ServiceType,
                                ServiceSubType = t.ServiceSubType,
                                Installment = t.InstallmentAmount,
                                Amount = t.AmtPaid,
                                Discounted = t.Discount,
                                PayDate = DateTime.Now.ToString("dd/MM/yyyy"),

                            }).OrderByDescending(c => c.MYTRANSID).Skip((pageNo - 1) * itemCount).Take(itemCount).ToList();

                if (searchKeyword != null)
                {
                    filterdata = data.Where(a => a.EnglishName.ToLower().Contains(searchKeyword.ToLower()) || a.ArabicName.ToLower().Contains(searchKeyword.ToLower()) || a.ServiceType.ToLower().Contains(searchKeyword.ToLower())).ToList();

                }
                else
                {
                    filterdata = data.ToList();
                }

                return filterdata;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }

        }

        public async Task<IEnumerable<ReturnTransactionHdDto>> GetFinancialServicesToExportExcel(int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal)
        {
            var data = (from e in _context.DetailedEmployees
                        join t in _context.TransactionHds
                        on Convert.ToInt32(e.EmployeeId) equals t.EmployeeId
                        where e.Subscription_status == (filterVal == 0 ? e.Subscription_status : filterVal)
                       && ((t.SerApproval2 == (ServiceStatusFilterVal == 1 ? "2" : t.SerApproval2)) && (t.Status == (ServiceStatusFilterVal == 2 ? "Rejected" : t.Status)))  //1 = Aprroved , 2= Rejected , 0= Show All //
                       && ((t.IsDraftCreated == (DraftStatusFilterVal == 1 ? true : t.IsDraftCreated)) && (t.Status == (DraftStatusFilterVal == 2 ? "CashierDelivery" : t.Status)) && (t.IsDraftCreated == (DraftStatusFilterVal == 3 ? true : t.IsDraftCreated) && t.Status != (DraftStatusFilterVal == 3 ? "CashierDelivery" : "")))  //  1 = Draft Prepared, 2= Draft Delivered , 3=Draft Not Delivered, 0=SHOW ALL
                        select new ReturnTransactionHdDto
                        {
                            MYTRANSID = t.Mytransid,
                            EmployeeId = Convert.ToInt32(e.EmployeeId),
                            PFId = e.Pfid,
                            CID = e.EmpCidNum,
                            EnglishName = e.EnglishName,
                            ArabicName = e.ArabicName,
                            ServiceType = t.ServiceType,
                            ServiceSubType = t.ServiceSubType,
                            Installment = t.InstallmentAmount,
                            Amount = t.AmtPaid,
                            Discounted = t.Discount,
                            PayDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        }).OrderByDescending(c => c.MYTRANSID).ToList();
            return data;
        }

        public async Task<PagedList<ReturnTransactionHdDto>> GetFinancialServicesByServiceTypeAndServiceSubType([FromQuery] PaginationModel paginationModel, int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal, int ServiceTypeId, int ServiceSubTypeId)
        {
            var data = (from e in _context.DetailedEmployees
                        join t in _context.TransactionHds
                        on Convert.ToInt32(e.EmployeeId) equals t.EmployeeId
                        where e.Subscription_status == (filterVal == 0 ? e.Subscription_status : filterVal)
                        && t.ServiceTypeId == ServiceTypeId && t.ServiceSubTypeId == ServiceSubTypeId
                        && ((t.SerApproval2 == (ServiceStatusFilterVal == 1 ? "2" : t.SerApproval2)) && (t.Status == (ServiceStatusFilterVal == 2 ? "Rejected" : t.Status)))  //1 = Aprroved , 2= Rejected , 0= Show All //
                        && ((t.IsDraftCreated == (DraftStatusFilterVal == 1 ? true : t.IsDraftCreated)) && (t.Status == (DraftStatusFilterVal == 2 ? "CashierDelivery" : t.Status)) && (t.IsDraftCreated == (DraftStatusFilterVal == 3 ? true : t.IsDraftCreated) && t.Status != (DraftStatusFilterVal == 3 ? "CashierDelivery" : "")))  //  1 = Draft Prepared, 2= Draft Delivered , 3=Draft Not Delivered, 0=SHOW ALL
                        select new ReturnTransactionHdDto
                        {
                            MYTRANSID = t.Mytransid,
                            EmployeeId = Convert.ToInt32(e.EmployeeId),
                            PFId = e.Pfid,
                            CID = e.EmpCidNum,
                            EnglishName = e.EnglishName,
                            ArabicName = e.ArabicName,
                            ServiceType = t.ServiceType,
                            ServiceSubType = t.ServiceSubType,
                            Installment = t.InstallmentAmount,
                            Amount = t.AmtPaid,
                            Discounted = t.Discount,
                            PayDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        }).OrderByDescending(c => c.MYTRANSID).AsQueryable();

            if (!string.IsNullOrEmpty(paginationModel.Query))
            {
                data = data.Where(u =>
                u.PFId.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.CID.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.EnglishName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.ArabicName.ToLower().Contains(paginationModel.Query.ToLower()) ||
                u.EmployeeId.ToString().Contains(paginationModel.Query.ToLower())
                    );
            }
            return await PagedList<ReturnTransactionHdDto>.CreateAsync(data, paginationModel.PageNumber, paginationModel.PageSize);
        }

        public async Task<IEnumerable<SelectSubServiceTypeDto>> GetSubServiceTypeByServiceType(int tenentId, int serviceId)
        {
            try
            {
                var data = new List<SelectSubServiceTypeDto>();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("tenentId", tenentId);
                hashTable.Add("serviceId", serviceId);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spGetServiceSubTypeByServiceId]", CommandType.StoredProcedure, hashTable);
                data = this.AutoMapToObject<SelectSubServiceTypeDto>(objDataset.Tables[0]);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<IEnumerable<SeriveTypeSubServiceTypeMDL>> GetServiceTypeSubServiceTypeByTenentId(int tenentId)
        {
            try
            {
                var data = new List<SeriveTypeSubServiceTypeMDL>();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("tenentId", tenentId);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spGetServiceTypeServiceSubType]", CommandType.StoredProcedure, hashTable);
                data = this.AutoMapToObject<SeriveTypeSubServiceTypeMDL>(objDataset.Tables[0]);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
