using API.Common;
using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.TeamFoundation.Build.WebApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;


namespace API.Servivces.Implementation
{
    public class ReportsService : IReportsService
    {
        private readonly KUPFDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConverter _converter;

        public ReportsService(KUPFDbContext context, IMapper mapper, IConverter converter)
        {
            _context = context;
            _mapper = mapper;
            _converter = converter;
        }
        public async Task<VoucherDetailReport> GetVoucherDetailsReport(ReportInputModel reportInputModel)
        {
            string reportTemplate = "";
            var reportData = new VoucherDetailReport();
            var data = new VoucherDetailReportModel();
            Hashtable hashTable = new Hashtable();
            hashTable.Add("TransId", reportInputModel.TransId);
            hashTable.Add("VoucherId", reportInputModel.VoucherId);
            DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spGetVourcherDetailsReport]", CommandType.StoredProcedure, hashTable);
            data = this.AutoMapToObject<VoucherDetailReportModel>(objDataset.Tables[0]).FirstOrDefault();
            data.voucherDetailTrans = this.AutoMapToObject<VoucherDetailTrans>(objDataset.Tables[1]).ToList();

            DataTable DataTable = CommonMethods.GetDataTable("select Remarks  from REFTABLE where REFSUBTYPE = 'VoucherReport'", CommandType.Text, null);
            reportTemplate = Convert.ToString(DataTable.Rows[0]["Remarks"]);
            reportTemplate = reportTemplate.Replace("@EmployeeId", data.EmployeeId).Replace("@EmployeeName", data.EmployeeName)
                .Replace("@VoucherType", data.VoucherType).Replace("@Voucher", data.VoucherNumber).Replace("@VouchDate", data.VoucherDate)
                .Replace("@VoucDescription", data.VoucherDescription).Replace("@Draft", data.DraftNumber).Replace("@DrDate", data.DraftDate).Replace("\r", "").Replace("\n", "").Replace("\t", "");
            int srNo = 0;
            double totalDebit = 0;
            double totalCredit = 0;
            foreach (VoucherDetailTrans val in data.voucherDetailTrans)
            {
                srNo++;
                reportTemplate += "<tr>";
                reportTemplate += "<td style='width: 60px;'>" + srNo + "</td>";
                reportTemplate += "<td style='width: 140px;'>" + val.AccountNumber + "</td>";
                reportTemplate += "<td style='width: 200px;'>" + val.AccountName + "</td>";
                reportTemplate += "<td style='width: 150px;'>" + val.Debit + "</td>";
                reportTemplate += "<td style='width: 150px;'>" + val.Credit + "</td>";
                reportTemplate += "</tr>";
                totalDebit += Convert.ToDouble(val.Debit);
                totalCredit += Convert.ToDouble(val.Credit);

            }
            reportTemplate += "</table  style='border-collapse: collapse; width:80%; margin-left: auto;     margin-right: auto;'><br><div style='float: right;'><table  style=' border-collapse: collapse; width:75%; margin-left: auto;     margin-right: 30%;'><tr><td style=' width: 200px;'>Balance - رصيد حساب</td>";
            reportTemplate += "<td style='width: 145px; background-color: #ff5b5b;'>" + totalDebit + "</td><td style='width: 145px; background-color: #40f786;'>" + totalCredit + "</td></tr></table></div> <style> tr:nth-child(even) {  background: #dddddd;  } td, th{ border-bottom: 1px solid #d3d1d1; color: #505050;  }" +
                " table{     border-top: 1px solid #d3d1d1; border-collapse: collapse; textgit checkout -align: center; } div " +
                "{ color: #505050!important; } </style></div></div></div></div>";
            reportData.ReportContent = reportTemplate;
            return reportData;
        }
        public async Task<byte[]> GenerateLoansDeducationReport(EmployeeDetailsWithHistoryDtoObj obj)
        {
            StringBuilder htmlBuilder1 = new StringBuilder();



            htmlBuilder1.Append("<!DOCTYPE html>");
            htmlBuilder1.Append("<html lang=\"en\">");
            htmlBuilder1.Append("<head>");
            htmlBuilder1.Append("    <meta charset=\"utf-8\" />");
            htmlBuilder1.Append("    <title>Report 1</title>");
            htmlBuilder1.Append("    <style>");
            htmlBuilder1.Append("        body {");
            htmlBuilder1.Append("            color: black;");
            htmlBuilder1.Append("            background-color: white;");
            htmlBuilder1.Append("            font-family: Arial, sans-serif;");
            htmlBuilder1.Append("            margin: 0;");
            htmlBuilder1.Append("            padding: 0;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .container {");
            htmlBuilder1.Append("            width: 21cm;");
            htmlBuilder1.Append("            height: 29.7cm;");
            htmlBuilder1.Append("            margin: 2cm auto;");
            htmlBuilder1.Append("            text-align: center;");
            htmlBuilder1.Append("            padding: 1cm;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .header {");
            htmlBuilder1.Append("            display: flex;");
            htmlBuilder1.Append("            justify-content: space-between;");
            htmlBuilder1.Append("            margin-bottom: 100px;");
            htmlBuilder1.Append("            text-align: right;");
            htmlBuilder1.Append("            font-size: 20px;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .header .left {");
            htmlBuilder1.Append("            text-align: left;");
            htmlBuilder1.Append("            flex: 1;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .header .right {");
            htmlBuilder1.Append("            text-align: right;");
            htmlBuilder1.Append("            flex: 1;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .title {");
            htmlBuilder1.Append("            font-size: 24px;");
            htmlBuilder1.Append("            margin-bottom: 20px;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .body-text {");
            htmlBuilder1.Append("            text-align: right;");
            htmlBuilder1.Append("            font-size: 20px;");
            htmlBuilder1.Append("            margin-bottom: 20px;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .footer {");
            htmlBuilder1.Append("            display: flex;");
            htmlBuilder1.Append("            justify-content: space-between;");
            htmlBuilder1.Append("            margin-top: 20px;");
            htmlBuilder1.Append("            text-align: right;");
            htmlBuilder1.Append("            font-size: 20px;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .footer .left {");
            htmlBuilder1.Append("            text-align: left;");
            htmlBuilder1.Append("            flex: 1;");
            htmlBuilder1.Append("            margin: 60px;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .footer .right {");
            htmlBuilder1.Append("            text-align: right;");
            htmlBuilder1.Append("            flex: 1;");
            htmlBuilder1.Append("            margin-top: 200px;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("    </style>");
            htmlBuilder1.Append("</head>");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("<body>");
            htmlBuilder1.Append("    <div class=\"container\">");
            htmlBuilder1.Append("        <div class=\"header\">");
            htmlBuilder1.Append("            <div class=\"left\">");
            htmlBuilder1.Append("                <br/>");
            htmlBuilder1.Append("                <p style=\"text-align: left;\">المحترم</p>");
            htmlBuilder1.Append("            </div>");
            htmlBuilder1.Append("            <div class=\"right\">");
            htmlBuilder1.Append("                <p>1-1</p>");
            htmlBuilder1.Append("                <p>: رقم الاخطار الالى</p>");
            htmlBuilder1.Append("                <p>السيد / مدير ادارة</p>");
            htmlBuilder1.Append("                <p>,,,, تحية طيبة و بعد</p>");
            htmlBuilder1.Append("            </div>");
            htmlBuilder1.Append("        </div>");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        <div class=\"title\">");
            htmlBuilder1.Append("            <p style=\"font-size: 30px\">\" الموضوع : خصم قروض\"</p>");
            htmlBuilder1.Append("        </div>");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        <div class=\"body-text\">");
            htmlBuilder1.Append("            <p style=\"text-align: right; font-size: 20px\">يرجى الايعاز لما يلزم نحو خصم قيمة القروض الممنوحة  لاعضاء المذكورين بالكشف /الكشوف المرفقة  اعتبارا  من شهر  12/2023  و حسب  المدة المشاؤر اليها قريبن كل اسم </p>");
            htmlBuilder1.Append("        </div>");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        <div class=\"footer\">");
            htmlBuilder1.Append("            <div class=\"left\">");
            htmlBuilder1.Append("                <p>مع خالص التحية </p>");
            htmlBuilder1.Append("                <p>رئيس مجلس  الادارة</p>");
            htmlBuilder1.Append("            </div>");
            htmlBuilder1.Append("            <div class=\"right\">");
            htmlBuilder1.Append("                <p> : المرفقات</p>");
            htmlBuilder1.Append("                <p>	عدد (  99 ) كشف •</p>");
            htmlBuilder1.Append("            </div>");
            htmlBuilder1.Append("        </div>");
            htmlBuilder1.Append("    </div>");
            htmlBuilder1.Append("</body>");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("</html>");

            htmlBuilder1.Append("<!DOCTYPE html>");
            htmlBuilder1.Append("<html lang=\"en\">");
            htmlBuilder1.Append("<head>");
            htmlBuilder1.Append("    <meta charset=\"utf-8\" />");
            htmlBuilder1.Append("    <title>Report 2</title>");
            htmlBuilder1.Append("    <style>");
            htmlBuilder1.Append("        body {");
            htmlBuilder1.Append("            color: black;");
            htmlBuilder1.Append("            background-color: white;");
            htmlBuilder1.Append("            font-family: Arial, sans-serif;");
            htmlBuilder1.Append("            margin: 0;");
            htmlBuilder1.Append("            padding: 0;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .container {");
            htmlBuilder1.Append("            width: 21cm;");
            htmlBuilder1.Append("            height: 29.7cm;");
            htmlBuilder1.Append("            margin: 2cm auto;");
            htmlBuilder1.Append("            text-align: center;");
            htmlBuilder1.Append("            padding: 1cm;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .header {");
            htmlBuilder1.Append("            margin-bottom: 20px;");
            htmlBuilder1.Append("            font-size: 20px;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .header-text {");
            htmlBuilder1.Append("            text-align: right;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        .section {");
            htmlBuilder1.Append("            margin-bottom: 30px;");
            htmlBuilder1.Append("            display: flex;");
            htmlBuilder1.Append("            justify-content: space-between;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        table {");
            htmlBuilder1.Append("            border-collapse: collapse;");
            htmlBuilder1.Append("            width: 100%;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("        table, th, td {");
            htmlBuilder1.Append("            border: 1px solid black;");
            htmlBuilder1.Append("        }");
            htmlBuilder1.Append("    </style>");
            htmlBuilder1.Append("</head>");
            htmlBuilder1.Append("");
            htmlBuilder1.Append("<body>");
            htmlBuilder1.Append("    <div class=\"container\">");
            htmlBuilder1.Append("        <div class=\"header\">");
            htmlBuilder1.Append("            <p class=\"header-text\">2-1</p>");
            htmlBuilder1.Append("            <p class=\"header-text\">: رقم الاخطار الالى </p>");
            htmlBuilder1.Append("            <p class=\"header-text\">: تاريخ </p>");
            htmlBuilder1.Append("        </div>");
            htmlBuilder1.Append("        <br/>");
            htmlBuilder1.Append("        <p style=\"text-align: right; font-size: 20px\">الادارة :   ادارة الامن و السلامة </p>");
            htmlBuilder1.Append("        <div class=\"section\">");
            htmlBuilder1.Append("            <table>");
            htmlBuilder1.Append("                <tr>");
            htmlBuilder1.Append("                    <th>نهاية الخصم</th>");
            htmlBuilder1.Append("                    <th>بداية الخصم</th>");
            htmlBuilder1.Append("                    <th>نوع القرض</th>");
            htmlBuilder1.Append("                    <th>رقم القرض</th>");
            htmlBuilder1.Append("                    <th>القسط</th>");
            htmlBuilder1.Append("                    <th>عدد الاقساط</th>");
            htmlBuilder1.Append("                    <th>قيمة القرض</th>");
            htmlBuilder1.Append("                    <th>الاسم</th>");
            htmlBuilder1.Append("                    <th>الرقم الوظيفى</th>");
            htmlBuilder1.Append("                    <th>م</th>");

            htmlBuilder1.Append("                </tr>");
            int index = 1;
            foreach (var e in obj.EmpDetailsWithHistoryList)
            {
                htmlBuilder1.Append("                <tr>");
                htmlBuilder1.Append($"                    <td>{e.SubscribedDate?.AddMonths(e.InstallmentNumber).ToString("M/d/yyyy") ?? ""}</td>");
                htmlBuilder1.Append($"                    <td>{e.SubscribedDate?.ToString("M/d/yyyy") ?? ""}</td>");
                htmlBuilder1.Append($"                    <td>{e.TOTAMT}</td>");
                htmlBuilder1.Append($"                    <td>{e.DEPFID}</td>");
                htmlBuilder1.Append($"                    <td>{e.EachInstallmentsAmt}</td>");
                htmlBuilder1.Append($"                    <td>{e.InstallmentNumber}</td>");
                htmlBuilder1.Append($"                    <td>{e.TOTAMT}</td>");
                htmlBuilder1.Append($"                    <td>{e.ArabicName}</td>");
                htmlBuilder1.Append($"                    <td>{e.KUEmployee}</td>");
                htmlBuilder1.Append($"                    <td>{index}</td>");

                htmlBuilder1.Append("                </tr>");
                index++;
            }
            htmlBuilder1.Append("            </table>");
            htmlBuilder1.Append("        </div>");
            htmlBuilder1.Append("        <p style=\"text-align: right; font-size: 20px\">الادارة :  ادارة شئون العاملين</p>");
            htmlBuilder1.Append("        <div class=\"section\">");
            htmlBuilder1.Append("            <table>");
            htmlBuilder1.Append("                <tr>");
            htmlBuilder1.Append("                    <th>نهاية الخصم</th>");
            htmlBuilder1.Append("                    <th>بداية الخصم</th>");
            htmlBuilder1.Append("                    <th>نوع القرض</th>");
            htmlBuilder1.Append("                    <th>رقم القرض</th>");
            htmlBuilder1.Append("                    <th>القسط</th>");
            htmlBuilder1.Append("                    <th>عدد الاقساط</th>");
            htmlBuilder1.Append("                    <th>قيمة القرض</th>");
            htmlBuilder1.Append("                    <th>الاسم</th>");
            htmlBuilder1.Append("                    <th>الرقم الوظيفى</th>");
            htmlBuilder1.Append("                    <th>م</th>");

            htmlBuilder1.Append("                </tr>");
            int index1 = 1;
            foreach (var e in obj.EmpDetailsWithHistoryList)
            {
                htmlBuilder1.Append("                <tr>");
                htmlBuilder1.Append($"                    <td>{e.SubscribedDate?.AddMonths(e.InstallmentNumber).ToString("M/d/yyyy") ?? ""}</td>");
                htmlBuilder1.Append($"                    <td>{e.SubscribedDate?.ToString("M/d/yyyy") ?? ""}</td>");
                htmlBuilder1.Append($"                    <td>{e.TOTAMT}</td>");
                htmlBuilder1.Append($"                    <td>{e.DEPFID}</td>");
                htmlBuilder1.Append($"                    <td>{e.EachInstallmentsAmt}</td>");
                htmlBuilder1.Append($"                    <td>{e.InstallmentNumber}</td>");
                htmlBuilder1.Append($"                    <td>{e.TOTAMT}</td>");
                htmlBuilder1.Append($"                    <td>{e.ArabicName}</td>");
                htmlBuilder1.Append($"                    <td>{e.KUEmployee}</td>");
                htmlBuilder1.Append($"                    <td>{index}</td>");


                htmlBuilder1.Append("                </tr>");
                index1++;
            }
            htmlBuilder1.Append("            </table>");
            htmlBuilder1.Append("        </div>");
            htmlBuilder1.Append("    </div>");
            htmlBuilder1.Append("</body>");
            htmlBuilder1.Append("</html>");



            string htmlContent1 = htmlBuilder1.ToString();
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent1
                    }
                }
            };

            byte[] pdfBytes = _converter.Convert(doc);

            return pdfBytes;
        }

        public async Task<byte[]> GenerateSubscribersMembersReport(EmployeeDetailsWithHistoryDtoObj obj)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            

        
            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html lang=\"en\">");
            htmlBuilder.AppendLine("<head>");
            htmlBuilder.AppendLine("  <meta charset=\"utf-8\" />");
            htmlBuilder.AppendLine("  <title>Medical</title>");
            htmlBuilder.AppendLine("  <link rel=\"stylesheet\" href=\"master.css\" />");
            htmlBuilder.AppendLine("</head>");
            htmlBuilder.AppendLine("<body style=\"padding: 10px; margin: 0; font-family: Arial, sans-serif;\">");
            htmlBuilder.AppendLine("  <div style=\"width: 100vw; margin: 0 auto;\">");
            htmlBuilder.AppendLine("    <div style=\"color: grey; padding: 10px; margin-bottom: 40px; display: flex; justify-content: space-between; align-items: center; border-bottom: 1px solid grey;\">");
            htmlBuilder.AppendLine("      <div>");
            htmlBuilder.AppendLine("      <div style=\"flex: 1;\">صندوق الضمان الاجتماعي</div>");
            htmlBuilder.AppendLine("      <div style=\"flex: 1; text-align: right;\">Social Security Fund</div>");
            htmlBuilder.AppendLine("    </div>");
            htmlBuilder.AppendLine("      <div style=\"flex: 1; text-align: center; font-size: 24px;\">PF Logo</div>"); 
            htmlBuilder.AppendLine("    </div>");
            htmlBuilder.AppendLine("    <div style=\"font-weight: 700; text-align: center\">\" كشف اعضاء الصندوق\"</div>");
            htmlBuilder.AppendLine("    <div style=\"font-weight: 700; margin: 10px 0; text-align: center\">\" PF Members report\"</div>");
            htmlBuilder.AppendLine("    <div style=\"padding: 10px 10px 10px; width: 100%; text-align: left;\">");
            htmlBuilder.AppendLine($"    <p style=\"text-align: end; margin: 10px 0px\">{DateTime.Now.ToString("M/d/yyyy")} : تاريخ الكشف  </p>");
            htmlBuilder.AppendLine("      <table style=\"border-collapse: collapse; padding: 15px 15px 15px; width: 100%\">");
            htmlBuilder.AppendLine("      <tr>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          ملاحظات <br />Notes");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          تاريخ الاشتراك <br />Subscription date");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          رقم العضوية <br />PF Number");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          الوظيفة <br />Job Desc.");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          مركز العمل <br />Job Department");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          الاسم <br />Name");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          الرقم الوظيفى <br />Employee#");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; text-align: center\">م</td>");
            htmlBuilder.AppendLine("      </tr>");
            int index = 1;
            foreach (var e in obj.EmpDetailsWithHistoryList)
            {
                htmlBuilder.AppendLine("      <tr>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.ContractTypeEnglish}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.SubscribedDate?.ToString("M/d/yyyy") ?? ""}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.DEPFID}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.DepartmentDesc}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.Department_Name}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.ArabicName}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.DEemployeeID}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: center\">{index}</td>");
                htmlBuilder.AppendLine("      </tr>");

                index++;
            }
            htmlBuilder.AppendLine("      </table>");
            htmlBuilder.AppendLine("    </div>");
            htmlBuilder.AppendLine("    <footer style=\"width: 100%; margin-top: 20px; display: flex; justify-content: space-between;\">");
            htmlBuilder.AppendLine("      <div style=\"text-align: left; flex: 1;\">");
            htmlBuilder.AppendLine("        SAID : المستخد ");
            htmlBuilder.AppendLine("      </div>");
            htmlBuilder.AppendLine("      <div style=\"text-align: right; flex: 1;\">");
            htmlBuilder.AppendLine("       1 صفحة رقم");
            htmlBuilder.AppendLine("      </div>");
            htmlBuilder.AppendLine("      <div style=\"text-align: left; flex: 1;\">");
            htmlBuilder.AppendLine($"     {DateTime.Now.ToString("M/d/yyyy")}  :   تاریخ ");
            htmlBuilder.AppendLine("      </div>");
            htmlBuilder.AppendLine("    </footer>");
            htmlBuilder.AppendLine("  </div>");
            htmlBuilder.AppendLine("</div>");
            htmlBuilder.AppendLine("  </body>");
            htmlBuilder.AppendLine("</html>");

            string htmlContent = htmlBuilder.ToString();
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent
                    }
                }
            };

            byte[] pdfBytes = _converter.Convert(doc);

            return pdfBytes;
        }


        public async Task<byte[]> GenerateAssemblyReport(EmployeeDetailsWithHistoryDtoObj obj)
        {
            StringBuilder htmlBuilder = new StringBuilder();



            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html lang=\"en\">");
            htmlBuilder.AppendLine("<head>");
            htmlBuilder.AppendLine("  <meta charset=\"utf-8\" />");
            htmlBuilder.AppendLine("  <title>Medical</title>");
            htmlBuilder.AppendLine("  <link rel=\"stylesheet\" href=\"master.css\" />");
            htmlBuilder.AppendLine("</head>");
            htmlBuilder.AppendLine("<body style=\"padding: 10px; margin: 0; font-family: Arial, sans-serif;\">");
            htmlBuilder.AppendLine("  <div style=\"width: 100vw; margin: 0 auto;\">");
            htmlBuilder.AppendLine("    <div style=\"color: grey; padding: 10px; margin-bottom: 40px; display: flex; justify-content: space-between; align-items: center; border-bottom: 1px solid grey;\">");
            htmlBuilder.AppendLine("      <div>");
            htmlBuilder.AppendLine("      <div style=\"flex: 1;\">صندوق الضمان الاجتماعي</div>");
            htmlBuilder.AppendLine("      <div style=\"flex: 1; text-align: right;\">Social Security Fund</div>");
            htmlBuilder.AppendLine("    </div>");
            htmlBuilder.AppendLine("      <div style=\"flex: 1; text-align: center; font-size: 24px;\">PF Logo</div>");
            htmlBuilder.AppendLine("    </div>");
            htmlBuilder.AppendLine("    <div style=\"font-weight: 700; text-align: center\">\" كشف الجمعية العمومية  و الانتخابات للصندوق\"</div>");
            htmlBuilder.AppendLine("    <div style=\"font-weight: 700; margin: 10px 0; text-align: center\">\" General Assumedly report-for PF election –\"</div>");
            htmlBuilder.AppendLine("    <p style=\"font-weight: 700; margin: 10px 0; text-align: center\">\" member subscribed before 6 months of report date\"</p>");
            htmlBuilder.AppendLine("    <div style=\"padding: 10px 10px 10px; width: 100%; text-align: left;\">");
            htmlBuilder.AppendLine($"    <p style=\"text-align: end; margin: 10px 0px\"> {DateTime.Now.ToString("M/d/yyyy")} : تاريخ الكشف</p>");
            htmlBuilder.AppendLine("      <table style=\"border-collapse: collapse; padding: 15px 15px 15px; width: 100%\">");
            htmlBuilder.AppendLine("      <tr>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          ملاحظات <br />Notes");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          تاريخ الاشتراك <br />Subscription date");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          رقم العضوية <br />PF Number");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          الوظيفة <br />Job Desc.");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          مركز العمل <br />Job Department");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          الاسم <br />Name");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; padding: 5px; text-align: right; font-size: 14px; padding: 0px 10px; text-align: right;\">");
            htmlBuilder.AppendLine("          الرقم الوظيفى <br />Employee#");
            htmlBuilder.AppendLine("        </td>");
            htmlBuilder.AppendLine("        <td style=\"border: 1px solid grey; text-align: center\">م</td>");
            htmlBuilder.AppendLine("      </tr>");
            int index = 1;   
            foreach (var e in obj.EmpDetailsWithHistoryList)
            {
                htmlBuilder.AppendLine("      <tr>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.DepartmentDesc}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.SubscribedDate?.ToString("M/d/yyyy") ?? ""}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.DEPFID}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.DepartmentDesc}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.Department_Name}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.ArabicName}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: right\">{e.DEemployeeID}</td>");
                htmlBuilder.AppendLine($"        <td style=\"border: 1px solid grey; padding: 5px; text-align: center\">{index}</td>");
                htmlBuilder.AppendLine("      </tr>");

                index++;
            }
            htmlBuilder.AppendLine("      </table>");
            htmlBuilder.AppendLine("    </div>");
            htmlBuilder.AppendLine("    <footer style=\"width: 100%; margin-top: 20px; display: flex; justify-content: space-between;\">");
            htmlBuilder.AppendLine("      <div style=\"text-align: left; flex: 1;\">");
            htmlBuilder.AppendLine("        SAID : المستخد ");
            htmlBuilder.AppendLine("      </div>");
            htmlBuilder.AppendLine("      <div style=\"text-align: right; flex: 1;\">");
            htmlBuilder.AppendLine("      1  صفحة رقم");
            htmlBuilder.AppendLine("      </div>");
            htmlBuilder.AppendLine("      <div style=\"text-align: left; flex: 1;\">");
            htmlBuilder.AppendLine($"      {DateTime.Now.ToString("M/d/yyyy")}    : تاریخ ");
            htmlBuilder.AppendLine("      </div>");
            htmlBuilder.AppendLine("    </footer>");
            htmlBuilder.AppendLine("  </div>");
            htmlBuilder.AppendLine("</div>");
            htmlBuilder.AppendLine("  </body>");
            htmlBuilder.AppendLine("</html>");

            string htmlContent = htmlBuilder.ToString();
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent
                    }
                }
            };

            byte[] pdfBytes = _converter.Convert(doc);

            return pdfBytes;
        }

        public async Task<byte[]> GenerateEmployeeLoansStatementsReport(EmployeeDetailsWithHistoryDto obj)
        {
            StringBuilder htmlBuilder = new StringBuilder();


            htmlBuilder.Append("<!DOCTYPE html>");
            htmlBuilder.Append("<html lang=\"en\">");

            htmlBuilder.Append("<head>");
            htmlBuilder.Append("    <meta charset=\"utf-8\" />");
            htmlBuilder.Append("    <title>Black and White Report</title>");
            htmlBuilder.Append("    <style>");
            htmlBuilder.Append("        body {");
            htmlBuilder.Append("            color: black;");
            htmlBuilder.Append("            background-color: white;");
            htmlBuilder.Append("            font-family: Arial, sans-serif;");
            htmlBuilder.Append("            margin: 0;");
            htmlBuilder.Append("            padding: 0;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        .container {");
            htmlBuilder.Append("            width: 21cm;");
            htmlBuilder.Append("            height: 29.7cm;");
            htmlBuilder.Append("            margin: 2cm auto;");
            htmlBuilder.Append("            text-align: center;");
            htmlBuilder.Append("            padding: 1cm;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        .header {");
            htmlBuilder.Append("            font-size: 24px;");
            htmlBuilder.Append("            font-weight: bold;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        .section {");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("            display: flex;");
            htmlBuilder.Append("            justify-content: space-between;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        .section div {");
            htmlBuilder.Append("            width: 48%; /* Adjust width as needed */");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        .section div p {");
            htmlBuilder.Append("            margin: 12px 0; /* Increased space between lines */");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        table {");
            htmlBuilder.Append("            border-collapse: collapse;");
            htmlBuilder.Append("            width: 100%;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        table, th, td {");
            htmlBuilder.Append("            border: 1px solid black;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        th, td {");
            htmlBuilder.Append("            padding: 8px;");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        .footer {");
            htmlBuilder.Append("            margin-top: 20px;");
            htmlBuilder.Append("            display: flex;");
            htmlBuilder.Append("            justify-content: space-between;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        .black-text {");
            htmlBuilder.Append("            color: black;");
            htmlBuilder.Append("            font-size: 20px; /* Increase font size */");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("        p {");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("            font-size: 20px;");
            htmlBuilder.Append("        }");

            htmlBuilder.Append("    </style>");
            htmlBuilder.Append("</head>");

            htmlBuilder.Append("<body>");
            htmlBuilder.Append("    <div class=\"container\">");

            htmlBuilder.Append("        <div class=\"header\">");
            htmlBuilder.Append("            كشف حساب القروض");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append("<br>");
            htmlBuilder.Append("<br>");
            htmlBuilder.Append("        <div class=\"section\">");
            htmlBuilder.Append("            <div>");
            htmlBuilder.Append("                <p>: مركز العمل </p>");
            htmlBuilder.Append("                <p>: رقم العضوية </p>");
            htmlBuilder.Append("                <p>: تاريخ العضوية </p>");
            htmlBuilder.Append("                <p>: الى تاريخ </p>");
            htmlBuilder.Append("            </div>");

            htmlBuilder.Append("            <div>");
            htmlBuilder.Append("                <p>: التاريخ </p>");
            htmlBuilder.Append("                <p>: الاسم </p>");
            htmlBuilder.Append("                <p>: رقم الحساب </p>");
            htmlBuilder.Append("                <p>: من تاريخ </p>");
            htmlBuilder.Append("            </div>");
            htmlBuilder.Append("        </div>");

            htmlBuilder.Append("<br>");
            htmlBuilder.Append("        <div class=\"section\">");
            htmlBuilder.Append("            <table>");
            htmlBuilder.Append("                <tr>");
            htmlBuilder.Append("                    <th>الرصيد</th>");
            htmlBuilder.Append("                    <th>دائن </th>");
            htmlBuilder.Append("                    <th>مدين </th>");
            htmlBuilder.Append("                    <th>البيان</th>");
            htmlBuilder.Append("                    <th>رقم القيد </th>");
            htmlBuilder.Append("                    <th>التاريخ </th>");
            htmlBuilder.Append("                </tr>");
            
                htmlBuilder.Append("                <tr>");
                htmlBuilder.Append($"                    <td>{obj.DEemployeeID}</td>");
                htmlBuilder.Append($"                    <td>Data 2</td>");
                htmlBuilder.Append($"                    <td>Data 3</td>");
                htmlBuilder.Append($"                    <td>Data 4</td>");
                htmlBuilder.Append($"                    <td>Data 5</td>");
                htmlBuilder.Append($"                    <td>Data 6</td>");
                htmlBuilder.Append("                </tr>");
            
            htmlBuilder.Append("                <!-- Add more rows as needed -->");
            htmlBuilder.Append("                <tr>");
            htmlBuilder.Append("                    <td>{}</td>");
            htmlBuilder.Append("                    <td>Data 8</td>");
            htmlBuilder.Append("                    <td>Data 9</td>");
            htmlBuilder.Append("                    <td colspan=\"3\">الاجمالى</td>");
            htmlBuilder.Append("                </tr>");
            htmlBuilder.Append("            </table>");
            htmlBuilder.Append("        </div>");

            htmlBuilder.Append("<br>");
            htmlBuilder.Append("            <p>يعتبر هذ  الكشف صحيحا ما لم يرد عليه اعتراض خلال خممسة عشر يوما من تاريخ الاستلام </p>");
            htmlBuilder.Append("<br>");
            htmlBuilder.Append("        <div class=\"footer\">");
            htmlBuilder.Append("            <div style=\"      font-size: 30px;\">امين الصندوق  </div>");
            htmlBuilder.Append("            <div style=\"      font-size: 30px;\">المحاسب </div>");
            htmlBuilder.Append("        </div>");

            htmlBuilder.Append("    </div>");
            htmlBuilder.Append("</body>");

            htmlBuilder.Append("</html>");



            string htmlContent = htmlBuilder.ToString();
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent
                    }
                }
            };

            byte[] pdfBytes = _converter.Convert(doc);

            return pdfBytes;
        }





        public async Task<byte[]> GenerateSubscribeDeducationReport(EmployeeDetailsWithHistoryDtoObj obj)
        {
            StringBuilder htmlBuilder = new StringBuilder();



            htmlBuilder.Append("<!DOCTYPE html>");
            htmlBuilder.Append("<html lang=\"en\">");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append("    <meta charset=\"utf-8\" />");
            htmlBuilder.Append("    <title>Report 1</title>");
            htmlBuilder.Append("    <style>");
            htmlBuilder.Append("        body {");
            htmlBuilder.Append("            color: black;");
            htmlBuilder.Append("            background-color: white;");
            htmlBuilder.Append("            font-family: Arial, sans-serif;");
            htmlBuilder.Append("            margin: 0;");
            htmlBuilder.Append("            padding: 0;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        table {");
            htmlBuilder.Append("            border-collapse: collapse;");
            htmlBuilder.Append("            width: 100%;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        table, th, td {");
            htmlBuilder.Append("            border: 1px solid black;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        th, td {");
            htmlBuilder.Append("            padding: 8px;");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .container {");
            htmlBuilder.Append("            width: 21cm;");
            htmlBuilder.Append("            height: 29.7cm;");
            htmlBuilder.Append("            margin: 2cm auto;");
            htmlBuilder.Append("            text-align: center;");
            htmlBuilder.Append("            padding: 1cm;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header {");
            htmlBuilder.Append("            display: flex;");
            htmlBuilder.Append("            justify-content: space-between;");
            htmlBuilder.Append("            margin-bottom: 100px;");
            htmlBuilder.Append("            font-size: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header .left {");
            htmlBuilder.Append("            text-align: left;");
            htmlBuilder.Append("            flex: 1;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header .right {");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("            flex: 1;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .title {");
            htmlBuilder.Append("            font-size: 24px;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .body-text {");
            htmlBuilder.Append("            text-align: center;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("            font-size: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .section {");
            htmlBuilder.Append("            margin-bottom: 30px;");
            htmlBuilder.Append("            display: flex;");
            htmlBuilder.Append("            justify-content: space-between;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("    </style>");
            htmlBuilder.Append("</head>");
            htmlBuilder.Append("");
            htmlBuilder.Append("<body>");
            htmlBuilder.Append("    <div class=\"container\">");
            htmlBuilder.Append("        <div class=\"header\" style=\"text-align: right;\">");
            htmlBuilder.Append("            <div class=\"left\">");
            htmlBuilder.Append("                <p style=\"text-align: left;\">المحترم</p>");
            htmlBuilder.Append("            </div>");
            htmlBuilder.Append("            <div class=\"right\">");
            htmlBuilder.Append("                <p>رقم الاخطار الالى : </p>");
            htmlBuilder.Append("                <p>الى السيد / مدير ادارة    الموارد البشرية</p>");
            htmlBuilder.Append("                <p>من السيد / رئيس مجلس  الادارة – صندوق الضمان الاجتماعى</p>");
            htmlBuilder.Append("                <p>,,,, تحية طيبة و بعد</p>");
            htmlBuilder.Append("            </div>");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append("");
            htmlBuilder.Append("        <div class=\"title\">");
            htmlBuilder.Append("            <p style=\"font-size: 30px\">\" (%الموضوع : اشعار خصم اشتراك شهرى (1\"</p>");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append("<br/>");
            htmlBuilder.Append("        <div class=\"body-text\">");
            htmlBuilder.Append("            <p style=\"text-align: right;\">يرجى الايعاز لما يلزم نحو خصم قيمة الاشترا (1%)  من الراتب الشهرى  لاعضاء المذكورين ادناه  اعتبارا من راتب شهر  ديسمبر 2023  و ذلك لاشتراكهم بعضوية  صندوق الضمان الاجتماعى</p>");
            htmlBuilder.Append("            <p style=\"text-align: left;\">Please advise what should be obtained from the reduction in the value of contributions (1%) of the monthly salary of its members because the credit score is not lower than the salary for the month of December 2023(PERIOD_CODE), due to their participation in some of the Social Security Fund.</p>");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append("<br/>");
            htmlBuilder.Append("        <div class=\"section\">");
            htmlBuilder.Append("            <table>");
            htmlBuilder.Append("                <tr>");
            htmlBuilder.Append("                    <th>نوع العقد<br/>Contract Type</th>");
            htmlBuilder.Append("                    <th>تاريخ العضوية<br/>Subscription Date</th>");
            htmlBuilder.Append("                    <th>مركز العمل<br/>Department</th>");
            htmlBuilder.Append("                    <th>الاسم <br/>Employee Name</th>");
            htmlBuilder.Append("                    <th>الرقم الوظيفى <br/>Employe ID</th>");
            htmlBuilder.Append("                    <th>م</th>");
            htmlBuilder.Append("                </tr>");
            int index = 1;
            foreach (var e in obj.EmpDetailsWithHistoryList)
            {
                htmlBuilder.Append("                <tr>");
                htmlBuilder.Append($"                    <td>{e.ContractType}</td>");
                htmlBuilder.Append($"                    <td>{e.SubscribedDate?.ToString("M/d/yyyy") ?? ""}</td>");
                htmlBuilder.Append($"                    <td>{e.Department}</td>");
                htmlBuilder.Append($"                    <td>{e.ArabicName}</td>");
                htmlBuilder.Append($"                    <td>{e.DEemployeeID}</td>");
                htmlBuilder.Append($"                    <td>{index}</td>");
                htmlBuilder.Append("                </tr>");
                index++;
            }
            htmlBuilder.Append("            </table>");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append("<p style=\"text-align: right; font-size: 30px\"> و تفضلوا بقبول فائق التحية و التقدير ,,,,, </p>");
            htmlBuilder.Append("    </div>");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");


            string htmlContent = htmlBuilder.ToString();
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent
                    }
                }
            };

            byte[] pdfBytes = _converter.Convert(doc);

            return pdfBytes;
        }


        public async Task<byte[]> GenerateCertificatesReport(EmployeeDetailsWithHistoryDto obj)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<!DOCTYPE html>");
            htmlBuilder.Append("<html lang=\"en\">");

            htmlBuilder.Append("<head>");
            htmlBuilder.Append("    <meta charset=\"utf-8\" />");
            htmlBuilder.Append("    <title>Report 1</title>");
            htmlBuilder.Append("    <style>");
            htmlBuilder.Append("        body {");
            htmlBuilder.Append("            color: black;");
            htmlBuilder.Append("            background-color: white;");
            htmlBuilder.Append("            font-family: Arial, sans-serif;");
            htmlBuilder.Append("            margin: 0;");
            htmlBuilder.Append("            padding: 0;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("  table {");
            htmlBuilder.Append("            border-collapse: collapse;");
            htmlBuilder.Append("            width: 100%;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        table, th, td {");
            htmlBuilder.Append("            border: 1px solid black;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        th, td {");
            htmlBuilder.Append("      		");
            htmlBuilder.Append("            padding: 8px;");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("        .container {");
            htmlBuilder.Append("            width: 21cm;");
            htmlBuilder.Append("            height: 29.7cm;");
            htmlBuilder.Append("            margin: 2cm auto;");
            htmlBuilder.Append("            text-align: center;");
            htmlBuilder.Append("            padding: 1cm;");
            htmlBuilder.Append("           ");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header {");
            htmlBuilder.Append("            display: flex;");
            htmlBuilder.Append("            justify-content: space-between;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header .left {");
            htmlBuilder.Append("            text-align: left;");
            htmlBuilder.Append("            flex: 1;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header .right {");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("            flex: 1;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .title {");
            htmlBuilder.Append("            font-size: 24px;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .body-text {");
            htmlBuilder.Append("            text-align: center;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .footer {");
            htmlBuilder.Append("            display: flex;");
            htmlBuilder.Append("            justify-content: space-between;");
            htmlBuilder.Append("            margin-top: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append(" ");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .footer .right {");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("            flex: 1;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("    </style>");
            htmlBuilder.Append("</head>");

            htmlBuilder.Append("<body>");
            htmlBuilder.Append("    <div class=\"container\">");
            htmlBuilder.Append("     ");
            htmlBuilder.Append("");
            htmlBuilder.Append("        <div class=\"title\">");
            htmlBuilder.Append("            <p style=\"font-size: 30px\">\" (%الموضوع : اشعار خصم اشتراك شهرى (1\"</p>");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append("<br/>    ");
            htmlBuilder.Append("        <div class=\"body-text\">"); 
            htmlBuilder.Append("            <p style=\"text-align: right; font-size: 20px\">: تشهد ادارة صندوق الضمان الجتماعى للعاملين بجامعة الكويت بان</p>");
            htmlBuilder.Append("          <p></p>");
            htmlBuilder.Append($"   <p style=\"text-align: right; font-size: 20px\"> {obj.Department_Name} السيد :  احمد درويس  - رقم  مدنى 123456789012 – رقم وظيفى    123456789012 – مركز العمل   </p>");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append("       <p style=\"text-align: right; font-size: 20px\">لديه استقطاع شهرى شهرى (شتراك بصندوق الضمان الاجتماعى) بمبلغ 5.750 دينار تستقع من راتبه شهريا و لازال </p>");
            htmlBuilder.Append("       <p style=\"text-align: right; font-size: 20px\">الاستقطاع قائم حتى تاريخه </p>");
            htmlBuilder.Append("       <p style=\"text-align: right; font-size: 20px\">منحت الشهادة بناع على طلبه دون  تحمل ادارة الصندوق لادنى مسئولية تجاه او تجاه الغير</p>");
            htmlBuilder.Append("");
            htmlBuilder.Append("      <p style=\"text-align: right; font-size: 20px\"> رئيس مجلس  الادارة </p>");
            htmlBuilder.Append("            ");
            htmlBuilder.Append("       <br/>");
            htmlBuilder.Append("       <br/>");
            htmlBuilder.Append("        <div class=\"footer\" style=\"text-align: right; font-size: 20px\">");
            htmlBuilder.Append(" \t\t<div class=\"right\" style=\"margin-top: 200px\" >");
            htmlBuilder.Append("                <p > : ملحوظة</p>");
            htmlBuilder.Append("                <p> \t\tصلاحية الشهادة شهر واحد فقط  •</p>");
            htmlBuilder.Append("              ");
            htmlBuilder.Append("              <p>لا يعتد الا باصل الشهادة •</p>");
            htmlBuilder.Append("            </div>");
            htmlBuilder.Append("        </div> \t");
            htmlBuilder.Append("         ");
            htmlBuilder.Append("    </div>");
            htmlBuilder.Append("    ");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("");
            htmlBuilder.Append("</html>");
            htmlBuilder.Append("<!DOCTYPE html>");
            htmlBuilder.Append("<html lang=\"en\">");

            htmlBuilder.Append("<head>");
            htmlBuilder.Append("    <meta charset=\"utf-8\" />");
            htmlBuilder.Append("    <title>Report 1</title>");
            htmlBuilder.Append("    <style>");
            htmlBuilder.Append("        body {");
            htmlBuilder.Append("            color: black;");
            htmlBuilder.Append("            background-color: white;");
            htmlBuilder.Append("            font-family: Arial, sans-serif;");
            htmlBuilder.Append("            margin: 0;");
            htmlBuilder.Append("            padding: 0;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("  table {");
            htmlBuilder.Append("            border-collapse: collapse;");
            htmlBuilder.Append("            width: 100%;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        table, th, td {");
            htmlBuilder.Append("            border: 1px solid black;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        th, td {");
            htmlBuilder.Append("      		");
            htmlBuilder.Append("            padding: 8px;");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("        .container {");
            htmlBuilder.Append("            width: 21cm;");
            htmlBuilder.Append("            height: 29.7cm;");
            htmlBuilder.Append("            margin: 2cm auto;");
            htmlBuilder.Append("            text-align: center;");
            htmlBuilder.Append("            padding: 1cm;");
            htmlBuilder.Append("           ");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header {");
            htmlBuilder.Append("            display: flex;");
            htmlBuilder.Append("            justify-content: space-between;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header .left {");
            htmlBuilder.Append("            text-align: left;");
            htmlBuilder.Append("            flex: 1;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .header .right {");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("            flex: 1;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .title {");
            htmlBuilder.Append("            font-size: 24px;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .body-text {");
            htmlBuilder.Append("            text-align: center;");
            htmlBuilder.Append("            margin-bottom: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .footer {");
            htmlBuilder.Append("            display: flex;");
            htmlBuilder.Append("            justify-content: space-between;");
            htmlBuilder.Append("            margin-top: 20px;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("");
            htmlBuilder.Append(" ");
            htmlBuilder.Append("");
            htmlBuilder.Append("        .footer .right {");
            htmlBuilder.Append("            text-align: right;");
            htmlBuilder.Append("            flex: 1;");
            htmlBuilder.Append("        }");
            htmlBuilder.Append("    </style>");
            htmlBuilder.Append("</head>");

            htmlBuilder.Append("<body>");
            htmlBuilder.Append("    <div class=\"container\">");    
            htmlBuilder.Append("     ");
            htmlBuilder.Append("");
            htmlBuilder.Append("        <div class=\"title\">");
            htmlBuilder.Append("            <p style=\"font-size: 30px\">  شهادة مديونية</p>");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append("<br/>    ");
            htmlBuilder.Append("        <div class=\"body-text\">");
            htmlBuilder.Append("            <p style=\"text-align: right; font-size: 20px\">يشهد صندوق الضمان الجتماعى للعاملين بجامعة الكويت بان:</p>");
            htmlBuilder.Append("          <p></p>");
            htmlBuilder.Append("          <p style=\"text-align: right; font-size: 20px\">   السيد :  احمد درويس) </p>");
            htmlBuilder.Append("        </div>");
            htmlBuilder.Append(" \t<p style=\"text-align: right; font-size: 20px\"> 123456789012 رقم  مدنى </p>");
            htmlBuilder.Append("       <p style=\"text-align: right; font-size: 20px\">1234567890 رقم وظيفى</p>");
            htmlBuilder.Append("       <p style=\"text-align: right; font-size: 20px\">مركز العمل ادارة شؤون العاملين </p>");
            htmlBuilder.Append("       <p style=\"text-align: right; font-size: 20px\">   عضو مدين للصندوق و لا تزال ذمته المالية مشغولة تجاه الصندوق  بمبلغ و قدره (2000) د. ك </p>");
            htmlBuilder.Append("       <p style=\"text-align: right; font-size: 20px\"> ققط الفين دينار كويتى حتى تاريخ 30/10/2023 , علما بان هذا المبلغ يقسط شهريا بواقع 200 د.ك    </p>");

            htmlBuilder.Append("      <p style=\"text-align: right; font-size: 20px ; margin-right: 100px;\">	قرض اجتماع بمبلغ 1000 د,ك تاريخه - </p>");
            htmlBuilder.Append("      <p style=\"text-align: right; font-size: 20px; margin-right: 100px;\">	قرض اجتماع بمبلغ 1000 د,ك تاريخه - </p>");
            htmlBuilder.Append("      <br/>");
            htmlBuilder.Append("      ");
            htmlBuilder.Append("      <p style=\"text-align: right; font-size: 20px;\">و قد اعطيت هذه الشهادة بناء على طلبه مع الاقرار منه بان هذه الشهادة مؤكدة للدين الذى لا يزال قائما و لم يسدد, مع الحفظ الكامل </p>");
            htmlBuilder.Append("      <p style=\"text-align: right; font-size: 20px;\">لحقوق الصندوق تجاهه و تجاه الغير, دون ادنى مسئولية على الصندوق تجاه اى منهم  </p>");
            htmlBuilder.Append("      <p style=\"text-align: right; font-size: 20px;\">رئيس مجلس  الادارة </p>");
            htmlBuilder.Append("      <br/>");
            htmlBuilder.Append("        <div class=\"footer\">");
            htmlBuilder.Append(" \t\t<div class=\"right\" style=\"margin-top: 200px\" >");
            htmlBuilder.Append("                <p  style=\"text-align: right; font-size: 20px\"> : ملحوظة</p>");
            htmlBuilder.Append("                <p style=\"text-align: right; font-size: 18px\">	من المفهوم ان فترة السداد قد تتغير فى حال اخلال المقترض بسداد اى مبلغ ف تاريخ استحقاقهصلاحية الشهادة شهر واحد فقط  • </p>");
            htmlBuilder.Append("                <p  style=\"text-align: right; font-size: 20px\">صلاحية الشهادة شهر واحد فقط  •</p>");
            htmlBuilder.Append("                <p  style=\"text-align: right; font-size: 20px\">لا يعتد الا باصل الشهادة •</p>");
            htmlBuilder.Append("            </div>");
            htmlBuilder.Append("        </div> \t");
            htmlBuilder.Append("         ");
            htmlBuilder.Append("    </div>");
            htmlBuilder.Append("    ");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("");
            htmlBuilder.Append("</html>");




            string htmlContent = htmlBuilder.ToString();
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent
                    }
                }
            };

            byte[] pdfBytes = _converter.Convert(doc);

            return pdfBytes;
        }

    }
}
