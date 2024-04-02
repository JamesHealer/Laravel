using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
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
    public class CrupMstService : ICrupMstServivce
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;

        public CrupMstService(KUPFDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int InsertCrupMst(CrupMstDto crupMstDto)
        {
            int result = 0;
            if (crupMstDto != null)
            {
                var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUP_MSTInsert";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", crupMstDto.TenantId);
                        cmd.Parameters.AddWithValue("@LocationID", crupMstDto.LocationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupMstDto.CrupId);
                        cmd.Parameters.AddWithValue("@MySerial", crupMstDto.MySerial);
                        cmd.Parameters.AddWithValue("@MENU_ID", crupMstDto.MenuId);
                        cmd.Parameters.AddWithValue("@PHYSICALLOCID", crupMstDto.Physicallocid);
                        cmd.Parameters.AddWithValue("@ActivityNote", crupMstDto.ActivityNote);
                        cmd.Parameters.AddWithValue("@CREATED_BY", crupMstDto.CreatedBy);
                        cmd.Parameters.AddWithValue("@CREATED_DT", crupMstDto.CreatedDt);
                        cmd.Parameters.AddWithValue("@UPDATED_BY", crupMstDto.UpdatedBy);
                        cmd.Parameters.AddWithValue("@UPDATED_DT", crupMstDto.UpdatedDt);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            
                return result;
            }
            return result;
        }
        public int UpdatCrupMst(CrupMstDto crupMstDto)
        {
            int result = 0;
            if (crupMstDto != null)
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUP_MSTUpdate";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", crupMstDto.TenantId);
                        cmd.Parameters.AddWithValue("@LocationID", crupMstDto.LocationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupMstDto.CrupId);
                        cmd.Parameters.AddWithValue("@MySerial", crupMstDto.MySerial);
                        cmd.Parameters.AddWithValue("@MENU_ID", crupMstDto.MenuId);
                        cmd.Parameters.AddWithValue("@PHYSICALLOCID", crupMstDto.Physicallocid);
                        cmd.Parameters.AddWithValue("@ActivityNote", crupMstDto.ActivityNote);
                        cmd.Parameters.AddWithValue("@CREATED_BY", crupMstDto.CreatedBy);
                        cmd.Parameters.AddWithValue("@CREATED_DT", crupMstDto.CreatedDt);
                        cmd.Parameters.AddWithValue("@UPDATED_BY", crupMstDto.UpdatedBy);
                        cmd.Parameters.AddWithValue("@UPDATED_DT", crupMstDto.UpdatedDt);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            };
            return result;
        }
        public int DeleteCrupMst(int tenantId, int locationId, Int64 crupId)
        {
            int result = 0;

            if (tenantId != 0 && locationId != 0 && crupId != 0)
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUP_MSTDelete";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", tenantId);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupId);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            return result;
        }
        public CrupMstDto GetCrupMst(int tenantId, int locationId, Int64 crupId)
        {           
            CrupMstDto crupMst = new CrupMstDto();
            if (tenantId != 0 && locationId != 0 && crupId != 0)
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUP_MSTSelect";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", tenantId);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);
                        cmd.Parameters.AddWithValue("@CRUP_ID", crupId);
                        connection.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {                                
                                crupMst.TenantId = Convert.ToInt32(dataReader["TENANT_ID"]);
                                crupMst.LocationId = Convert.ToInt32(dataReader["LocationID"]);
                                crupMst.CrupId = Convert.ToInt32(dataReader["CRUP_ID"]);
                                crupMst.MySerial = Convert.ToInt32(dataReader["MySerial"]);
                                crupMst.MenuId = Convert.ToInt32(dataReader["MENU_ID"]);
                                crupMst.Physicallocid = Convert.ToString(dataReader["PHYSICALLOCID"]);
                                crupMst.ActivityNote = Convert.ToString(dataReader["ActivityNote"]);
                                crupMst.CreatedBy = Convert.ToString(dataReader["CREATED_BY"]);
                                crupMst.CreatedDt = Convert.ToDateTime(dataReader["CREATED_DT"]);
                                crupMst.UpdatedBy = Convert.ToString(dataReader["UPDATED_BY"]);
                                crupMst.UpdatedDt = Convert.ToDateTime(dataReader["UPDATED_DT"]);                                
                            }
                            connection.Close();
                        }
                    }
                }
            }
            return crupMst;
        }
        public Int64 MstSetCellMax(int tenantId, int locationId)
        {
            Int64 result = 0;

            if (tenantId != 0 && locationId != 0)
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
               
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "KU_CRUP_MSTSelMAX";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENANT_ID", tenantId);
                        cmd.Parameters.AddWithValue("@LocationID", locationId);
                        connection.Open();

                        // Return Value From Sp...
                        var returnParameter = cmd.Parameters.Add("@MyCRUP_ID", SqlDbType.BigInt);
                        returnParameter.Direction = ParameterDirection.ReturnValue;                        
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt64(returnParameter.Value);
                        connection.Close();
                    }
                }
            }
            return result;
        }
    }
}
