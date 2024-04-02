using API.DTOs;
using API.DTOs.EmployeeDto;
using API.DTOs.FinancialTransaction;
using API.Models;
using API.Servivces.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class FinancialTransactionService : IFinancialTransactionService
    {

        public Response SaveCOA(List<AccountRequest> accounts)
        {
            Response obj = new Response();

            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];

            SqlConnection connection = new SqlConnection(dbconnectionStr);
            SqlCommand cmd = new SqlCommand("[Accounts].[API_SaveCOA]", connection);
            try
            {
                connection.Open();
                foreach (var item in accounts)
                {
                    int result = IfAccountExists(item.TenantID, item.LocationID, 5,item.AccountID);
                    //if (result != 1)
                    //{
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountID", item.AccountID);
                        cmd.Parameters.AddWithValue("@AccountName", item.AccountName);
                        cmd.Parameters.AddWithValue("@ArabicAccountName", item.ArabicAccountName);
                        cmd.Parameters.AddWithValue("@AccountTypeID", item.AccountTypeID);
                        cmd.Parameters.AddWithValue("@UserID", item.UserID);
                        cmd.Parameters.AddWithValue("@ActivityDateTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TenantID", item.TenantID);
                        cmd.Parameters.AddWithValue("@LocationID", item.LocationID);
                        //cmd.Parameters.Add("@InsertedID", SqlDbType.Int).Direction = ParameterDirection.Output;

                        obj.Status = cmd.ExecuteNonQuery();
                   // }
                    
                }

                //obj.ID = (int)cmd.Parameters["@InsertedID"].Value;
                connection.Close();

                if (obj.Status != 0)
                {
                    obj.Message = "Account added / updated successfully";
                }
                else
                {
                    obj.Message = "Fail to add / update Account";
                }
            }
            catch (Exception ex)
            {
                obj.Message = ex.Message;
                //obj.ID = (int)cmd.Parameters["@InsertedID"].Value;
                obj.Status = 0;
            }
            finally
            {
                connection.Dispose();
            }
            return obj;
        }

        public Response SaveVoucher(VoucherRequest Req)
        {
            Response obj = new Response();

            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
            SqlConnection connection = new SqlConnection(dbconnectionStr);

            SqlCommand cmd = new SqlCommand("[Accounts].[API_SaveVoucher]", connection);
            DataTable dt = new DataTable();
            dt.Columns.Add("RowNo", typeof(int));
            dt.Columns.Add("Account_ID", typeof(int));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("Particular", typeof(string));
            dt.Columns.Add("Dr", typeof(decimal));
            dt.Columns.Add("Cr", typeof(decimal));
            try
            {
                decimal Dr, Cr;
                int RowNo = 0;
                foreach (var item in Req.VoucherDetail)
                {
                    if (item.Amount > 0)
                    {
                        Dr = item.Amount;
                        Cr = 0;
                    }
                    else
                    {
                        Dr = 0;
                        Cr = Math.Abs(item.Amount);
                    }
                    RowNo += 1;
                    dt.Rows.Add(RowNo, item.Account_ID, item.Amount, item.Particulars, Dr, Cr);
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InvoiceNo", Req.InvoiceNo);
                cmd.Parameters.AddWithValue("@VoucherDate", Req.VoucherDate);
                cmd.Parameters.AddWithValue("@VoucherType_ID", Req.VoucherType_ID);
                cmd.Parameters.AddWithValue("@CostCenter_ID", Req.CostCenter_ID);
                cmd.Parameters.AddWithValue("@UserID", Req.UserID);
                cmd.Parameters.AddWithValue("@TenantID", Req.TenantID);
                cmd.Parameters.AddWithValue("@LocationID", Req.LocationID);
                cmd.Parameters.Add("@dt", SqlDbType.Structured).Value = dt;
                connection.Open();
                obj.Status = (int)cmd.ExecuteNonQuery();
                obj.ID = 0;
                connection.Close();
                if (obj.Status != 0)
                {
                    obj.Message = "Voucher added successfully";
                }
                else
                {
                    obj.Message = "Fail to add voucher";
                }
            }
            catch (Exception ex)
            {
                obj.Message = ex.Message;
                obj.ID = 0;
                obj.Status = 0;
            }
            finally
            {
                connection.Dispose();
            }
            return obj;
        }

        public Response GetAccountByType(COARequest Req)
        {
            Response ob = new Response();
            ob.Result = new DataTable();

            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
            SqlConnection connection = new SqlConnection(dbconnectionStr);

            SqlCommand cmd = new SqlCommand("[Accounts].[GetCOAByTypeID]", connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenantID", Req.TenantID);
                cmd.Parameters.AddWithValue("@LocationID", Req.LocationID);
                cmd.Parameters.AddWithValue("@AccountTypeID", Req.AccountTypeID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                connection.Open();
                da.Fill(ob.Result);
                connection.Close();
                ob.Status = 0;
                if (ob.Result.Rows.Count == 0)
                {
                    ob.Message = "No Record Found";
                }
                else
                {
                    ob.Message = ob.Result.Rows.Count.ToString() + " Account(s) Found";
                }
            }
            catch (Exception ex)
            {
                ob.Status = 0;
                ob.Message = ex.Message;
            }
            finally
            {
                connection.Dispose();
            }
            return ob;
        }

        public Response GetCostCenters(RequestParamters Req)
        {
            Response ob = new Response();
            ob.Result = new DataTable();
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
            SqlConnection connection = new SqlConnection(dbconnectionStr);

            SqlCommand cmd = new SqlCommand("[Accounts].[GetActiveCostCenters]", connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenantID", Req.TenantID);
                cmd.Parameters.AddWithValue("@LocationID", Req.LocationID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                connection.Open();
                da.Fill(ob.Result);
                connection.Close();
                ob.Status = 0;
                if (ob.Result.Rows.Count == 0)
                {
                    ob.Message = "No Record Found";
                }
                else
                {
                    ob.Message = ob.Result.Rows.Count.ToString() + " Cost Center(s) Found";
                }
            }
            catch (Exception ex)
            {
                ob.Status = 0;
                ob.Message = ex.Message;
            }
            finally
            {
                connection.Dispose();
            }
            return ob;
        }

        public Response CashVoucher(CashRequest Req)
        {
            Response obj = new Response();

            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
            SqlConnection connection = new SqlConnection(dbconnectionStr);

            SqlCommand cmd = new SqlCommand("[Accounts].[API_SaveCashVoucher]", connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InvoiceNo", Req.InvoiceNo);
                cmd.Parameters.AddWithValue("@VoucherDate", Req.VoucherDate);
                cmd.Parameters.AddWithValue("@VoucherType_ID", Req.VoucherType_ID);
                cmd.Parameters.AddWithValue("@CostCenter_ID", Req.CostCenter_ID);
                cmd.Parameters.AddWithValue("@UserID", Req.UserID);
                cmd.Parameters.AddWithValue("@TenantID", Req.TenantID);
                cmd.Parameters.AddWithValue("@LocationID", Req.LocationID);
                cmd.Parameters.AddWithValue("@Account_ID", Req.Account_ID);
                cmd.Parameters.AddWithValue("@Amount", Req.Amount);
                connection.Open();
                obj.Status = (int)cmd.ExecuteNonQuery();
                obj.ID = 0;
                connection.Close();
                if (obj.Status != 0)
                {
                    obj.Message = "Voucher added successfully";
                }
                else
                {
                    obj.Message = "Fail to add voucher";
                }
            }
            catch (Exception ex)
            {
                obj.Message = ex.Message;
                obj.ID = 0;
                obj.Status = 0;
            }
            finally
            {
                connection.Dispose();
            }
            return obj;
        }

        public int IfAccountExists(int tenantId, int locationId, int headId, int accountNo)
        {
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];

            int result = 0;
            SqlConnection connection = new SqlConnection(dbconnectionStr);
            SqlCommand cmd = new SqlCommand("Accounts.IfAccountExists", connection);

            connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenantId", tenantId);
            cmd.Parameters.AddWithValue("@LocationId", locationId);
            cmd.Parameters.AddWithValue("@HeadId", headId);
            cmd.Parameters.AddWithValue("@AccountNo", accountNo);
            result = (int)cmd.ExecuteScalar();
            connection.Close();

            return result;
        }
    }
}
