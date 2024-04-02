using API.Common;
using API.DTOs;
using API.DTOs.FinancialTransaction;
using API.Helpers;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class AccountService : IAccountService
    {

        public async Task<VoucherDtoListObj> GetVoucher(PaginationParams paginationParams)
        {
            try
            {
               var data = new VoucherDtoListObj();
                List<VoucherDto> voucherList = new List<VoucherDto>();
                using (SqlConnection connection = new SqlConnection(CommonMethods.GetDbConnection()))
                {
                    string sql = "spGetVourcher";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {

                                VoucherDto voucher = new VoucherDto();
                                voucher.JvId = Convert.ToInt32(dataReader["VoucherID"]);
                                voucher.JvDate = Convert.ToDateTime(dataReader["VoucherDate"]);
                                voucher.JvCode = Convert.ToString(dataReader["VoucherCode"]);
                                voucher.Narrations = dataReader["Narrations"].ToString();
                                voucher.IsPosted = (bool)dataReader["IsPosted"];
                                voucher.TotalAmount = Convert.ToDouble(dataReader["TotalAmount"]);
                                voucher.MYTRANSID = Convert.ToInt64(dataReader["MYTRANSID"]);
                                voucher.ArabicName = Convert.ToString(dataReader["ArabicName"]);
                                voucher.EnglishName = Convert.ToString(dataReader["EnglishName"]);
                                voucher.employeeID = Convert.ToString(dataReader["employeeID"]);
                                voucher.LoanAccountNumber = Convert.ToString(dataReader["LoanAct"]);
                                voucher.ServiceType = Convert.ToString(dataReader["ServiceType"]);
                                voucher.ServiceSubType = Convert.ToString(dataReader["ServiceSubType"]);
                                voucher.CivilId = Convert.ToString(dataReader["emp_cid_num"]);
                                voucher.PFID = Convert.ToString(dataReader["PFID"]);
                                voucher.Status = Convert.ToString(dataReader["Status"]);
                                voucherList.Add(voucher);
                            }
                            connection.Close();
                        }
                    }
                  
                    if (!string.IsNullOrEmpty(paginationParams.Query))
                    {
                        voucherList = voucherList.Where(a => a.EnglishName.ToUpper().Contains(paginationParams.Query.ToUpper()) || a.ArabicName.ToUpper().Contains(paginationParams.Query.ToUpper()) ||
                        a.ServiceType.ToUpper().Contains(paginationParams.Query.ToUpper()) || a.Status.ToUpper().Contains(paginationParams.Query.ToUpper())
                        || a.JvCode.ToUpper().Contains(paginationParams.Query.ToUpper()) || a.CivilId.ToUpper().Contains(paginationParams.Query.ToUpper())
                           || a.PFID.ToUpper().Contains(paginationParams.Query.ToUpper()) ||  a.employeeID.ToUpper().Contains(paginationParams.Query.ToUpper())).ToList();

                    }
                    data.TotalRecords = voucherList.Count();
                    data.VoucherDto = voucherList.Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize).Take(paginationParams.PageSize).ToList();

                }
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<VoucherDetailsDto> GetVoucherDetails(int voucherId)
        {
            try
            {
                List<VoucherDetailsDto> voucherDetailsList = new List<VoucherDetailsDto>();
                using (SqlConnection connection = new SqlConnection(CommonMethods.GetDbConnection()))
                {
                    string sql = "spGetVourcherDetails";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VoucherId", voucherId);
                        connection.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                VoucherDetailsDto voucherDetails = new VoucherDetailsDto();
                                voucherDetails.VoucherDetailID = Convert.ToInt64(dataReader["VoucherDetailID"]);
                                voucherDetails.AccountName = dataReader["AccountName"].ToString();
                                voucherDetails.AccountId = Convert.ToString(dataReader["Account_ID"]);
                                voucherDetails.Amount = Convert.ToDouble(dataReader["Amount"]);
                                voucherDetails.Particular = dataReader["Particular"].ToString();
                                if (dataReader["ChequeNo"] == DBNull.Value)
                                {
                                    voucherDetails.ChequeNo = "";
                                }
                                else
                                {
                                    voucherDetails.ChequeNo = dataReader["ChequeNo"].ToString();
                                }
                                if (dataReader["ChequeDate"] == DBNull.Value)
                                {
                                    voucherDetails.ChequeDate = null;
                                }
                                else
                                {
                                    voucherDetails.ChequeDate = Convert.ToDateTime(dataReader["ChequeDate"]);
                                }
                                voucherDetails.Dr = Convert.ToDouble(dataReader["Dr"]);
                                voucherDetails.Cr = Convert.ToDouble(dataReader["Cr"]);
                                voucherDetails.CostCenterID = Convert.ToInt32(dataReader["CostCenter_ID"]);
                                voucherDetails.CostCenterName = dataReader["CostCenterName"].ToString();
                                voucherDetailsList.Add(voucherDetails);
                            }
                            connection.Close();
                        }
                    }
                }
                return voucherDetailsList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IEnumerable<VoucherDetailsDto> GetVoucherDetailsByTransId(int TransId)
        {
            try
            {
                List<VoucherDetailsDto> voucherDetailsList = new List<VoucherDetailsDto>();
                using (SqlConnection connection = new SqlConnection(CommonMethods.GetDbConnection()))
                {
                    string sql = "spGetVourcherDetailsByTransId";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TransId", TransId);
                        connection.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                VoucherDetailsDto voucherDetails = new VoucherDetailsDto();
                                voucherDetails.VoucherDetailID = Convert.ToInt64(dataReader["VoucherDetailID"]);
                                voucherDetails.AccountName = dataReader["AccountName"].ToString();
                                voucherDetails.AccountId = Convert.ToString(dataReader["Account_ID"]);
                                voucherDetails.Amount = Convert.ToDouble(dataReader["Amount"]);
                                voucherDetails.Particular = dataReader["Particular"].ToString();
                                if (dataReader["ChequeNo"] == DBNull.Value)
                                {
                                    voucherDetails.ChequeNo = "";
                                }
                                else
                                {
                                    voucherDetails.ChequeNo = dataReader["ChequeNo"].ToString();
                                }
                                if (dataReader["ChequeDate"] == DBNull.Value)
                                {
                                    voucherDetails.ChequeDate = null;
                                }
                                else
                                {
                                    voucherDetails.ChequeDate = Convert.ToDateTime(dataReader["ChequeDate"]);
                                }
                                voucherDetails.Dr = Convert.ToDouble(dataReader["Dr"]);
                                voucherDetails.Cr = Convert.ToDouble(dataReader["Cr"]);
                                voucherDetails.CostCenterID = Convert.ToInt32(dataReader["CostCenter_ID"]);
                                voucherDetails.CostCenterName = dataReader["CostCenterName"].ToString();
                                voucherDetailsList.Add(voucherDetails);
                            }
                            connection.Close();
                        }
                    }
                }
                return voucherDetailsList;
            }
            catch (Exception ex)
             {
                return null;
            }
        }
    }
}
