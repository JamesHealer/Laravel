using API.Common;
using API.DTOs;
using API.DTOs.EmployeeDto;
using API.Helpers;
using API.Models;
using API.Servivces.Interfaces;
using API.Servivces.Interfaces.DetailedEmployee;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly string fileDownloadPath;
        private readonly string fileUploadPath;
        private readonly KUPFDbContext _context;
        private readonly IDetailedEmployeeService _detailedEmployeeService;
        public IMapper _mapper;
        public EmployeeController(KUPFDbContext context, IDetailedEmployeeService detailedEmployeeService, IMapper mapper, IConfiguration _config)
        {
            _context = context;
            _mapper = mapper;
            _detailedEmployeeService = detailedEmployeeService;
            fileDownloadPath = _config.GetSection("filePath").GetSection("filedownloadpath").Value;
            fileUploadPath = _config.GetSection("filePath").GetSection("fileuploadpath").Value;
        }
        /// <summary>
        /// Api to add new employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult<int>> AddEmployee(DetailedEmployeeDto detailedEmployeeDto)
        {
            var response = await _detailedEmployeeService.AddEmployeeAsync(detailedEmployeeDto);
            await _context.SaveChangesAsync();
            return response;
        }
        /// <summary>
        /// Api to update existing employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<ActionResult<int>> UpdateEmployee(DetailedEmployeeDto detailedEmployeeDto)
        {
            if (detailedEmployeeDto != null)
            {
                var result = await _detailedEmployeeService.UpdateEmployeeAsync(detailedEmployeeDto);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to Get existing employee By Id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<DetailedEmployeeDto> GetEmployeeById(int employeeId)
        {
            if (employeeId != null)
            {
                var result = await _detailedEmployeeService.GetEmployeeByIdAsync(employeeId);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to Get existing employees
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<PagedList<DetailedEmployeeDto>> GetEmployees([FromQuery] PaginationModel paginationModel)
        {
            var result = await _detailedEmployeeService.GetEmployeesAsync(paginationModel);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }
        /// <summary>
        /// Api to deleted employee By Id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("DeleteEmployee")]
        public async Task<TransData> DeleteEmployee(DetailedEmployeeDto detailedEmployeeDto)
        {
            TransData result = null;
            if (detailedEmployeeDto != null)
            {
                result = await _detailedEmployeeService.DeleteEmployeeAsync(detailedEmployeeDto);
            }

            return result;
        }
        /// <summary>
        /// Validate new employee data
        /// </summary>
        /// <returns></returns>

        [Authorize]
        [HttpPost]
        [Route("ValidateEmployeeData")]
        public async Task<ActionResult<string>> ValidateEmployeeData(DetailedEmployeeDto detailedEmployeeDto)
        {
            var response = await _detailedEmployeeService.ValidateEmployeeData(detailedEmployeeDto);
            //await _context.SaveChangesAsync();
            return response;
        }

        [HttpGet]
        [Route("ValidateEmployeeId")]
        public async Task<bool> ValidateEmployeeId(long tenantId, int locationId, long employeeId)
        {
            var response = await _detailedEmployeeService.ValidateEmployeeId(tenantId, locationId, employeeId);
            return response;
        }

        [Authorize]
        [HttpGet]
        [Route("FilterEmployee")]
        public async Task<PagedList<DetailedEmployeeDto>> FilterEmployeeListAsync([FromQuery] PaginationParams paginationParams, int filterVal)
        {
            var result = await _detailedEmployeeService.FilterEmployeeListAsync(paginationParams, filterVal);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }

        [HttpPost]
        [Route("ImportEmployeeData")]
        public async Task<ResultMDL> ImportEmployeeData([FromBody] ImportEmpDataModel data)
        {
            var result = await _detailedEmployeeService.ImportEmployeeData(data);
            return result;
        }

        [HttpPost]
        [Route("CheckMonthlyData")]
        public async Task<List<CheckMonthlyDataMDL>> CheckMonthlyData([FromBody] ImportMonthlyDataModel data)
        {
            var result = await _detailedEmployeeService.CheckMonthlyData(data);
            return result;
        }

        [HttpPost]
        [Route("ImportMonthlyData")]
        public async Task<ResultMDL> ImportMonthlyData([FromBody] ImportMonthlyDataModel data)
        {
            var result = new ResultMDL();
            var chkResult = await this.CheckMonthlyData(data);
            var index = 0;
            foreach(var cr in chkResult)
            {
                index++;
                if(cr.Exceptions.Count > 0)
                {
                    result.Message = string.Format("{0}th {1}", index, cr.Exceptions[0]);
                    result.Result = 1;
                    return result;
                }
            }

            result = await _detailedEmployeeService.ImportMonthlyData(data);
            return result;
        }

        /// <summary>
        /// //[Authorize]
        /// </summary>
        /// <param name="importEmpDataInputModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("PrintLabel")]
        public async Task<PagedList<DetailedEmployeeDto>> PrintLabel([FromQuery] PaginationParams paginationParams, int filterVal)
        {
            var result = await _detailedEmployeeService.SixMonthSubcriptionDateFilterEmployeeListAsync(paginationParams, filterVal);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }
        /// <summary>
        /// //[Authorize]
        /// </summary>
        /// <param name="importEmpDataInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UploadEmployeeExcelFile")]
        public async Task<ActionResult<ResultMDL>> UploadEmployeeExcelFile([FromForm] UploadEmpDataInputModel importEmpDataInputModel)
        {
            String Msg = "";
           // int response = 0;
            var result = new ResultMDL();
            try
            {
                var formAccumulator = new KeyValueAccumulator();
                string targetFilePath = null;


                var datafile = importEmpDataInputModel.file;
                if (Request.Form.Files.Count > 0)
                {
                    string[] ACCEPTED_IMAGE_FILE_TYPES = { ".xlsx", ".csv", ".xls" };

                    var files = Request.Form.Files;
                    foreach (var file in files)
                    {
                        IFormFile filesData = file;
                        if (filesData == null || filesData.Length == 0)
                            return BadRequest();


                        string fileExtension = Path.GetExtension(filesData.FileName).ToLower();

                        if (!ACCEPTED_IMAGE_FILE_TYPES.Any(s => s == fileExtension))
                        {
                            return BadRequest("Invalid File");
                        }
                        //var path =  Path.GetDirectoryName(filesData.FileName);
                        // var path = "C:/Users/LENOVO/source/repos/KUPF_UPDATED/API/Documents/UploadedDocument";

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filesData.FileName);
                        var filePath = Path.Combine(fileUploadPath, fileName);

                        using (FileStream output = System.IO.File.Create(filePath))
                        {
                            file.CopyTo(output);
                        }
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM[Sheet1$]", CommonMethods.OleDBString(filePath, fileExtension.ToUpper(), "NO"));
                        da.Fill(dt);

                        string[] Heads = {"EmployeeId", "CivilId", "EmployeeName", "Reference", "Amount" };

                        for (int i = 0; i < Heads.Length - 1; i++)
                        {
                            string x = dt.Rows[0][i].ToString();
                            if (dt.Rows[0][i].ToString() != Heads[i])
                                Msg = "Header of the Sample File has been modified, Please download sample file again " + x;
                        }
                        if (Msg != "")
                        {
                            result.Result = 2;
                            result.Message = Msg;
                            return result;
                        }

                        XDocument xmlData = new XDocument(
                            new XElement("ServicesTransactions", from datatable in dt.AsEnumerable().Skip(1)
                                                                 select new XElement("ID",  new XElement("EmployeeId", datatable[0]), new XElement("CivilId", datatable[1])
                                                 , new XElement("EmployeeName", datatable[2]), new XElement("Reference", datatable[3]), new XElement("Amount", datatable[4]))));
                        System.Xml.Linq.XElement xmlDocumentWithoutNs = CommonMethods.RemoveAllNamespaces(System.Xml.Linq.XElement.Parse(xmlData.ToString()));
                        //string _encodedXML = string.Format("<pre>{0}</pre>", HttpUtility.HtmlEncode(serviceTransXMLData));
                        //var xmlConvertedObj = CommonMethods.ConvertObjToXML(dt);
                        result = await _detailedEmployeeService.UploadEmployeeExcelFile(Convert.ToString(xmlDocumentWithoutNs), Convert.ToInt32(importEmpDataInputModel.tenantId), importEmpDataInputModel.username, importEmpDataInputModel.UploaderName, importEmpDataInputModel.PeriodCode);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("DownloadSampleFile")]
        public async Task<IActionResult> DownloadSampleFile([FromQuery] string fileName)
        {

            //  var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName + ".xlsx");
            var filePath = Path.Combine(fileDownloadPath, fileName + ".xlsx");
            if (!System.IO.File.Exists(filePath)) return NotFound();
            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, CommonMethods.GetContentType(filePath), filePath);
        }

        [Authorize]
        [HttpGet]
        [Route("GetEmployeeImportServiceData")]
        public async Task<List<ImportEmployeeServiceMDL>> GetEmployeeImportServiceData(int tenantId, int periodCode, int DataImportFilterValue, string UploaderType)
        {
            var response = await _detailedEmployeeService.GetEmployeeImportServiceData(tenantId, periodCode, DataImportFilterValue, UploaderType);
            return response;
        }


         [Authorize]
        [HttpPost]
        [Route("AddEmployeeServiceData")]
        public async Task<ResultMDL> AddEmployeeServiceDataFinalSubmit(EmployeeServiceTransList employeeServiceTransList)
        {
            var response = await _detailedEmployeeService.AddEmployeeServiceDataFinalSubmit(employeeServiceTransList);
            return response;
        }

         [Authorize]
        [HttpPost]
        [Route("EmployeeServiceDataDraftSubmit")]
        public async Task<ResultMDL> EmployeeServiceDataDraftSubmit(EmployeeServiceTransList employeeServiceTransList)
        {
            var response = await _detailedEmployeeService.EmployeeServiceDataDraftSubmit(employeeServiceTransList);
            return response;
        }

        [Authorize]
        [HttpPost]
        [Route("DeletEmployeeImportServiceData")]
        public async Task<ResultMDL> DeletEmployeeImportServiceData(EmployeeServiceTransList employeeServiceTransList)
        {
            var response = await _detailedEmployeeService.DeletEmployeeImportServiceData(employeeServiceTransList);
            return response;
        }

        /// <summary>
        /// Api to get existing record(s) in deatiledemployee
        /// </summary>
        /// <returns></returns>
        /// 
       [Authorize]
        [HttpGet]
        [Route("GetEmployeeDataByEmpId")]
        public async Task<IEnumerable<EmployeeDetailsWithAllServiceData>> GetEmployeeDataByEmpId(long employeeId)
        {
            if (employeeId != 0)
            {
                var result = await _detailedEmployeeService.GetEmployeeDataByEmpId(employeeId);
                return result;
            }
            return null;
        }
    }

}
