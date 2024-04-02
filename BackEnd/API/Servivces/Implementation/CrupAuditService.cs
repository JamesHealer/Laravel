using API.DTOs;
using API.Servivces.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class CrupAuditService : ICrupAuditService
    {
        public int InsertCrupAudit(CrupAuditDto crupAuditDto)
        {
            int result = 0;
            if (crupAuditDto != null)
            {
                var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUPAuditInsert";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", crupAuditDto.TenantId);
                        cmd.Parameters.AddWithValue("@LocationID", crupAuditDto.LocationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupAuditDto.CrupId);
                        cmd.Parameters.AddWithValue("@MySerial", crupAuditDto.MySerial);
                        cmd.Parameters.AddWithValue("@AuditType", crupAuditDto.AuditType);
                        cmd.Parameters.AddWithValue("@TableName", crupAuditDto.TableName);
                        cmd.Parameters.AddWithValue("@FieldName", crupAuditDto.FieldName);
                        cmd.Parameters.AddWithValue("@OldValue", crupAuditDto.OldValue);
                        cmd.Parameters.AddWithValue("@NewValue", crupAuditDto.NewValue);
                        cmd.Parameters.AddWithValue("@UpdateDate", crupAuditDto.UpdateDate);
                        cmd.Parameters.AddWithValue("@UpdateUserName", crupAuditDto.UpdateUserName);
                        cmd.Parameters.AddWithValue("@CreatedDate", crupAuditDto.CreatedDate);
                        cmd.Parameters.AddWithValue("@CreatedUserName", crupAuditDto.CreatedUserName);
                        connection.Open();
                        result = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                return result;
            }
            return result;
        }

        public int UpdatCrupAudit(CrupAuditDto crupAuditDto)
        {
            int result = 0;
            if (crupAuditDto != null)
            {
                var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUPAuditUpdate";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", crupAuditDto.TenantId);
                        cmd.Parameters.AddWithValue("@LocationID", crupAuditDto.LocationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupAuditDto.CrupId);
                        cmd.Parameters.AddWithValue("@MySerial", crupAuditDto.MySerial);
                        cmd.Parameters.AddWithValue("@AuditNo", crupAuditDto.AuditNo);
                        cmd.Parameters.AddWithValue("@AuditType", crupAuditDto.AuditType);
                        cmd.Parameters.AddWithValue("@TableName", crupAuditDto.TableName);
                        cmd.Parameters.AddWithValue("@FieldName", crupAuditDto.FieldName);
                        cmd.Parameters.AddWithValue("@OldValue", crupAuditDto.OldValue);
                        cmd.Parameters.AddWithValue("@NewValue", crupAuditDto.NewValue);
                        cmd.Parameters.AddWithValue("@UpdateDate", crupAuditDto.UpdateDate);
                        cmd.Parameters.AddWithValue("@UpdateUserName", crupAuditDto.UpdateUserName);
                        cmd.Parameters.AddWithValue("@CreatedDate", crupAuditDto.CreatedDate);
                        cmd.Parameters.AddWithValue("@CreatedUserName", crupAuditDto.CreatedUserName);
                        connection.Open();
                        result = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                return result;
            }
            return result;
        }
        public int DeleteCrupMst(int tenantId, int locationId, long crupId, int mySerial, int auditNo)
        {
            int result = 0;
            if (!(tenantId == 0 && locationId == 0 && crupId == 0 && mySerial == 0 && auditNo == 0))
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUPAuditDelete";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", tenantId);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupId);
                        cmd.Parameters.AddWithValue("@MySerial", mySerial);
                        cmd.Parameters.AddWithValue("@AuditNo", auditNo);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            return result;
        }

        public CrupAuditDto GetCrupAudit(int tenantId, int locationId, long crupId, int mySerial, int auditNo)
        {
            CrupAuditDto curpAudit = new CrupAuditDto();
            if (tenantId != 0 && locationId != 0 && crupId != 0)
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUPAuditSelect";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", tenantId);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupId);
                        cmd.Parameters.AddWithValue("@MySerial", mySerial);
                        cmd.Parameters.AddWithValue("@AuditNo",auditNo);
                        connection.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                curpAudit.TenantId = Convert.ToInt32(dataReader["TENANT_ID"]);
                                curpAudit.LocationId = Convert.ToInt32(dataReader["LocationID"]);
                                curpAudit.CrupId = Convert.ToInt32(dataReader["CRUP_ID"]);
                                curpAudit.MySerial = Convert.ToInt32(dataReader["MySerial"]);                                
                                curpAudit.AuditNo = Convert.ToInt32(dataReader["AuditNo"]);
                                curpAudit.AuditType = Convert.ToString(dataReader["AuditType"]);
                                curpAudit.TableName = Convert.ToString(dataReader["TableName"]);
                                curpAudit.FieldName = Convert.ToString(dataReader["FieldName"]);
                                curpAudit.OldValue = Convert.ToString(dataReader["OldValue"]);
                                curpAudit.NewValue = Convert.ToString(dataReader["NewValue"]);
                                curpAudit.UpdateDate = Convert.ToDateTime(dataReader["UpdateDate"]);
                                curpAudit.UpdateUserName = Convert.ToString(dataReader["UpdateUserName"]);
                                curpAudit.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
                                curpAudit.CreatedUserName = Convert.ToString(dataReader["CreatedUserName"]);
                            }
                            connection.Close();
                        }
                    }
                }
            }
            return curpAudit;
        }

        public int CrupSetCellMaxAudit(Int64 tenantId, int locationId, Int64 crupId, int mySerial)
        {
            int result = 0;

            if (tenantId != 0 && locationId != 0 && crupId != 0 && mySerial != 0)
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];

                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUPAuditSelMAXAudit";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", tenantId);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupId);
                        cmd.Parameters.AddWithValue("@MySerial", mySerial);
                        connection.Open();

                        // Return Value From Sp...
                        var returnParameter = cmd.Parameters.Add("@MyAuditNo", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(returnParameter.Value);
                        connection.Close();
                    }
                }
            }
            return result;
        }

        public ReturnCrupCellMaxSerial CrupSetCellMaxSerial(Int64 tenantId, int locationId, Int64 crupId)
        {

            ReturnCrupCellMaxSerial maxSerial = new ReturnCrupCellMaxSerial();
            if (tenantId != 0 && locationId != 0 && crupId != 0)
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];

                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUPAuditSelMAXSerial";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", tenantId);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupId);
                        connection.Open();

                        // Return Value From Sp...
                        var serialNo = new SqlParameter("@SerialNo", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(serialNo);

                        var auditNo = new SqlParameter("@AuditNo", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(auditNo);
                        
                        cmd.ExecuteNonQuery();
                        
                        maxSerial.MySerial = Convert.ToInt32(serialNo.Value);
                        maxSerial.MyAuditNo = Convert.ToInt32(auditNo.Value);
                        connection.Close();
                    }
                }
            }
            return maxSerial;
        }
    }
}
