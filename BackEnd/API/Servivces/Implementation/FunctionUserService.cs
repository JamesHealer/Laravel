using API.Common;
using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace API.Servivces.Implementation
{
    public class FunctionUserService : IFunctionUserService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;

        public FunctionUserService(KUPFDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddFunctionUserAsync(FunctionUserDto functionUserDto)
        {
            int result = 0;
            if (_context != null)
            {
                var newFunctionUser = _mapper.Map<FUNCTION_USER>(functionUserDto);
                await _context.FUNCTION_USER.AddAsync(newFunctionUser);
                result = await _context.SaveChangesAsync();
                return result;
            }
            return result;
        }
        public async Task<int> UpdatFunctionUserAsync(FunctionUserDto functionUserDto)
        {
            int result = 0;
            if (_context != null)
            {
                var existingFunctionUser = _mapper.Map<FUNCTION_USER>(functionUserDto);
                _context.FUNCTION_USER.Update(existingFunctionUser);

                result = await _context.SaveChangesAsync();
                return result;
            };
            return result;
        }
        public async Task<int> DeletFunctionUserAsync(int id)
        {
            int result = 0;

            if (_context != null)
            {
                var functionUser = await _context.FUNCTION_USER.FirstOrDefaultAsync(x => x.MENU_ID == id);

                if (functionUser != null)
                {
                    _context.FUNCTION_USER.Remove(functionUser);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<IEnumerable<FunctionUserDto>> GetFunctionUserAsync()
        {
            var result = await _context.FUNCTION_USER.ToListAsync();
            var data = _mapper.Map<IEnumerable<FunctionUserDto>>(result);
            return data;
        }

        public async Task<IEnumerable<FunctionUserDto>> GetFunctionUserByMasterIdAsync(int masterId)
        {
            var result = await _context.FUNCTION_USER.Where(c => c.MASTER_ID == masterId).ToListAsync();
            var data = _mapper.Map<IEnumerable<FunctionUserDto>>(result);
            return data;
        }

        public async Task<int> AddFunctionsForUserAsync(FunctionForUserDto functionForUserDto)
        {
            int result = 0;
            if (_context != null)
            {
                var newFunctionUser = _mapper.Map<FUNCTION_USER>(functionForUserDto);
                await _context.FUNCTION_USER.AddAsync(newFunctionUser);
                result = await _context.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<IEnumerable<FunctionUserDto>> GetFunctionUserByUserIdAsync(int id)
        {
            var result = await _context.FUNCTION_USER.Where(c => c.USER_ID == id).ToListAsync();
            var data = _mapper.Map<IEnumerable<FunctionUserDto>>(result);
            return data;
        }

        public async Task<IEnumerable<FunctionUserDto>> GetFunctionUserByUserIdAsyncForLogin(int id)
        {
            var result = await _context.FUNCTION_USER.Where(c => c.USER_ID == id && c.ACTIVE_FLAG ==1).OrderBy(x => x.MENU_ORDER).ToListAsync();
            var data = _mapper.Map<IEnumerable<FunctionUserDto>>(result);
            return data;
        }

        public async Task<int> DeleteFunctionUserByUserIdAsync(int userId, int moduleId)
        {
            int result = 0;
                        
            if (userId != 0 && moduleId != 0 )
            {
                var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
                using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                {
                    string sql = "spDeleteFunctionUserByUserId";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@moduleId", moduleId);
                        connection.Open();
                        result = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<FunctionUserDto>> GetModuleWiseMenuItems()
        {

            var dbconfig = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
            var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
            List<FunctionUserDto> listFunctionUserDto = new List<FunctionUserDto>();
            using (SqlConnection connection = new SqlConnection(dbconnectionStr))
            {
                string sql = "select Distinct MASTER_ID,MENU_ID,MODULE_ID,MENU_LEVEL,MENU_NAMEEnglish,MENU_NAMEArabic,ACTIVETILLDATE from FUNCTION_MST Where MASTER_ID = 1 OR MASTER_ID = 0 ORder by MENU_ID ASC";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        
                        while (dataReader.Read())
                        {
                            FunctionUserDto functionUserDto = new FunctionUserDto();
                            functionUserDto.MASTER_ID = Convert.ToInt32(dataReader["MASTER_ID"]);
                            functionUserDto.MENU_ID = Convert.ToInt32(dataReader["MENU_ID"]);
                            functionUserDto.MODULE_ID = Convert.ToInt32(dataReader["MODULE_ID"]);
                            functionUserDto.Menu_Level = Convert.ToInt32(dataReader["Menu_Level"]);
                            functionUserDto.MENU_NAMEEnglish = dataReader["MENU_NAMEEnglish"].ToString();
                            functionUserDto.MENU_NAMEArabic = dataReader["MENU_NAMEArabic"].ToString();
                            listFunctionUserDto.Add(functionUserDto);
                        }
                        connection.Close();
                    }
                }
            }
            return listFunctionUserDto;
        }

        public async Task<ResultMDL> CalculateYearlyProcessForMembership(int periodCode, string loginUserName)
        {
            var result = new ResultMDL();
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("periodCode", periodCode);
                hashTable.Add("loginUserId", loginUserName);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spYearlyProcessForMembership]", CommandType.StoredProcedure, hashTable);
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

    }
}
