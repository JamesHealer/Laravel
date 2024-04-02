using API.Common;
using API.DTOs;
using API.DTOs.DropDown;
using API.DTOs.EmployeeDto;
using API.DTOs.RefTable;
using API.Helpers;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace API.Servivces.Implementation
{
    public class RefTableService : IRefTableService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;

        public RefTableService(KUPFDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddRefTableAsync(RefTableDto refTableDto)
        {
            int result = 0;

            if (_context != null)
            {
                var refId = (from d in _context.Reftables
                             where d.TenentId == refTableDto.TenentId
                             && d.Reftype == refTableDto.Reftype
                             && d.Refsubtype == refTableDto.Refsubtype
                             select new
                             {
                                 Refid = d.Refid + 1
                             })
                         .Distinct()
                         .OrderBy(x => 1).Max(c => c.Refid);

                var newRefTable = _mapper.Map<Reftable>(refTableDto);
                newRefTable.Refid = refId;
                if (refTableDto.Active == "true")
                {
                    newRefTable.Active = "Y";
                }
                else
                {
                    newRefTable.Active = "N";
                }
                if (refTableDto.Infrastructure == "true")
                {
                    newRefTable.Infrastructure = "Y";
                }
                else
                {
                    newRefTable.Infrastructure = "N";
                }
                newRefTable.Refname1 = refTableDto.Refname3;
                newRefTable.TenentId = refTableDto.TenentId;
                await _context.Reftables.AddAsync(newRefTable);

                result = await _context.SaveChangesAsync();

                return result;
            }

            return result;
        }
        public async Task<int> UpdatRefTableAsync(RefTableDto refTableDto)
        {
            int result = 0;
            if (_context != null)
            {
                // Get existing data based on refId,refType and refSubtype...
                var exitingRecord = _context.Reftables.Where(c => c.Refid == refTableDto.Refid
                && c.Reftype == refTableDto.Reftype && c.Refsubtype == refTableDto.Refsubtype && c.TenentId == 21).FirstOrDefault();
                if (exitingRecord != null)
                {
                    exitingRecord.Refname1 = refTableDto.Refname1;
                    exitingRecord.Refname2 = refTableDto.Refname2;
                    exitingRecord.Refname3 = refTableDto.Refname3;
                    exitingRecord.Remarks = refTableDto.Remarks;
                }
                var existingRefTable = _mapper.Map<Reftable>(exitingRecord);

                _context.Reftables.Update(existingRefTable);
                result = await _context.SaveChangesAsync();

                return result;
            };
            return result;
        }
        public async Task<int> DeleteRefTableAsync(int id)
        {
            int result = 0;

            if (_context != null)
            {
                var refTable = await _context.Reftables.FirstOrDefaultAsync(x => x.Refid == id);

                if (refTable != null)
                {
                    _context.Reftables.Remove(refTable);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<IEnumerable<RefTableDto>> GetRefTableAsync()
        {
            var result = await _context.Reftables.ToListAsync();
            var data = _mapper.Map<IEnumerable<RefTableDto>>(result);
            return data;
        }

        public async Task<RefTableDto> GetRefTableByIdAsync(int refId, string refType, string refSubType)
        {
            var result = await _context.Reftables
                            .Where(c => c.Refid == refId && c.Reftype == refType && c.Refsubtype == refSubType).FirstOrDefaultAsync();

            var data = _mapper.Map<RefTableDto>(result);
            return data;
        }
        public async Task<RefTableDtoListObj> GetRefTableByRefTypeAndSubTypeAsync(PaginationParams paginationParams, string refType, string refSubType)
        {
            var data = new RefTableDtoListObj();
            var result = await _context.Reftables.Where(c => c.Reftype.ToLower() == refType.ToLower()
            && c.Refsubtype.ToLower() == refSubType.ToLower()).ToListAsync();

            var dataList = _mapper.Map<IEnumerable<RefTableDto>>(result);
            if (!string.IsNullOrEmpty(paginationParams.Query))
            {
                dataList = dataList.Where(a => a.Refname1.ToUpper().Contains(paginationParams.Query.ToUpper()) ||
                a.Refname2.ToUpper().Contains(paginationParams.Query.ToUpper()) ||
                a.Refname3.ToUpper().Contains(paginationParams.Query.ToUpper()) ||
                a.Refsubtype.ToUpper().Contains(paginationParams.Query.ToUpper()) ||
                a.Reftype.ToUpper().Contains(paginationParams.Query.ToUpper())).ToList();

            }
            data.TotalRecords = dataList.Count();
            data.RefTableDto = dataList.Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize).Take(paginationParams.PageSize).ToList();

            return data;
        }

        public async Task<EmployeeDetailsWithHistoryDtoObj> GetRefTableByFilterAsync(PaginationParams paginationParams, int tenentId, int university, int contractType, int departmentFrom, int departmentTo, int position, int serviceType, int periodFrom, int periodTo)
        {
            try
            {
                var result = new EmployeeDetailsWithHistoryDtoObj();
                List<EmployeeDetailsWithHistoryDto> empDetailHistoryList = new List<EmployeeDetailsWithHistoryDto>();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("TenentID", tenentId);
                hashTable.Add("University", university);
                hashTable.Add("ContractType", contractType);
                hashTable.Add("DepartmentIDFrom", departmentFrom);
                hashTable.Add("DepartmentIDTo", departmentTo);
                hashTable.Add("Occupation", position);
                hashTable.Add("Services", 0);
                hashTable.Add("PeriodFrom", periodFrom);
                hashTable.Add("PeriodTo", periodTo);
                hashTable.Add("ServicesType", "0");
                hashTable.Add("STypeList", "0");
                hashTable.Add("ServicesSubType", "0");
                hashTable.Add("MyOffset", paginationParams.PageSize * (paginationParams.PageNumber - 1));
                hashTable.Add("MyNextRows", paginationParams.PageSize);

                List<SqlParameter> outputParams = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        ParameterName = "@TotalCount",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    }
                };

                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[Get_DetailEmployee_History]", CommandType.StoredProcedure, hashTable, outputParams);
                empDetailHistoryList = this.AutoMapToObject<EmployeeDetailsWithHistoryDto>(objDataset.Tables[0]);
                result.TotalRecords = (int)outputParams[0].Value;
                result.EmpDetailsWithHistoryList = empDetailHistoryList;
                
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<EmployeeDetailsWithHistoryDtoObj> GetRefTableByFilterForCertificateAsync(int tenentId, int university, int contractType, int departmentFrom, int departmentTo, int position, int serviceType, int periodFrom, int periodTo)
        {
            try
            {
                var result = new EmployeeDetailsWithHistoryDtoObj();
                List<EmployeeDetailsWithHistoryDto> empDetailHistoryList = new List<EmployeeDetailsWithHistoryDto>();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("TenentID", tenentId);
                hashTable.Add("University", university);
                hashTable.Add("ContractType", contractType);
                hashTable.Add("DepartmentIDFrom", departmentFrom);
                hashTable.Add("DepartmentIDTo", departmentTo);
                hashTable.Add("Occupation", position);
                hashTable.Add("Services", 0);
                hashTable.Add("PeriodFrom", periodFrom);
                hashTable.Add("PeriodTo", periodTo);
                hashTable.Add("ServicesType", "0");
                hashTable.Add("STypeList", "0");
                hashTable.Add("ServicesSubType", "0");
                hashTable.Add("MyOffset", 0);
                hashTable.Add("MyNextRows", 10);

                List<SqlParameter> outputParams = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        ParameterName = "@TotalCount",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    }
                };

                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[Get_DetailEmployee_History]", CommandType.StoredProcedure, hashTable, outputParams);
                empDetailHistoryList = this.AutoMapToObject<EmployeeDetailsWithHistoryDto>(objDataset.Tables[0]);
                result.TotalRecords = (int)outputParams[0].Value;
                result.EmpDetailsWithHistoryList = empDetailHistoryList;

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<EmployeeDetailsWithHistoryDtoObj> GetRefTableByFilterForReportAsync(PaginationParams paginationParams, int tenentId, int university, int contractType, int departmentFrom, int departmentTo, int position, int serviceType, int periodFrom, int periodTo)
        {   
            try
            {
                var result = new EmployeeDetailsWithHistoryDtoObj();
                List<EmployeeDetailsWithHistoryDto> empDetailHistoryList = new List<EmployeeDetailsWithHistoryDto>();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("TenentID", tenentId);
                hashTable.Add("University", university);
                hashTable.Add("ContractType", contractType);
                hashTable.Add("DepartmentIDFrom", departmentFrom);
                hashTable.Add("DepartmentIDTo", departmentTo);
                hashTable.Add("Occupation", position);
                hashTable.Add("Services", 0);
                hashTable.Add("PeriodFrom", periodFrom);
                hashTable.Add("PeriodTo", periodTo);
                hashTable.Add("ServicesType", "0");
                hashTable.Add("STypeList", "0");
                hashTable.Add("ServicesSubType", "0");
                hashTable.Add("MyOffset", paginationParams.PageSize * (paginationParams.PageNumber - 1));
                hashTable.Add("MyNextRows", paginationParams.PageSize);

                List<SqlParameter> outputParams = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        ParameterName = "@TotalCount",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    }
                };

                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[Get_DetailEmployee_History]", CommandType.StoredProcedure, hashTable, outputParams);
                empDetailHistoryList = this.AutoMapToObject<EmployeeDetailsWithHistoryDto>(objDataset.Tables[0]);
                result.TotalRecords = (int)outputParams[0].Value;
                result.EmpDetailsWithHistoryList = empDetailHistoryList;

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
