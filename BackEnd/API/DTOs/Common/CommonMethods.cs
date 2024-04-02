using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace API.Common
{
    public static class CommonMethods
    {
        public static List<string> CreateMemberShipPeriodCode()
        {
            List<string> list = new List<string>();
            int nextMonth = DateTime.Now.Month;
            int months = (nextMonth - 12);
            int remainingMonths = Math.Abs(months);
            string customPrd = string.Empty;
            for (int i = 1; i <= remainingMonths; i++)
            {
                var nextMonth1 = DateTime.Now.AddMonths(i).ToString("MM");
                var currentYear = DateTime.Now.Year;
                customPrd = currentYear + "" + nextMonth1;
                list.Add(customPrd);
            }
            int nextCounter = 24 - (remainingMonths - 1);
            for (int i = 1; i <= nextCounter; i++)
            {
                DateTime FirstDT;
                if (i <= 12)
                {
                    FirstDT = new DateTime(DateTime.Now.AddYears(1).Year, 1, 1);
                    customPrd = FirstDT.Year + "" + FirstDT.AddMonths(i - 1).ToString("MM");
                    list.Add(customPrd);
                }
                else if (i > 12)
                {
                    FirstDT = new DateTime(DateTime.Now.AddYears(2).Year, 1, 1);
                    customPrd = FirstDT.Year + "" + FirstDT.AddMonths(i - 1).ToString("MM");
                    list.Add(customPrd);
                }
            }
            return list;
        }

        public static List<string> GetSocialLoanPeriodCode()
        {
            List<string> list = new List<string>();
            int nextMonth = DateTime.Now.Month;
            int months = (nextMonth - 12);
            int remainingMonths = Math.Abs(months);
            string customPrd = string.Empty;
            for (int i = 1; i <= remainingMonths; i++)
            {
                var nextMonth1 = DateTime.Now.AddMonths(i).ToString("MM");
                var currentYear = DateTime.Now.Year;
                customPrd = currentYear + "" + nextMonth1;
                list.Add(customPrd);
            }
            int nextCounter = (10 - remainingMonths);
            for (int i = 1; i <= nextCounter; i++)
            {
                DateTime FirstDT;
                if (i <= 12)
                {
                    FirstDT = new DateTime(DateTime.Now.AddYears(1).Year, 1, 1);
                    customPrd = FirstDT.Year + "" + FirstDT.AddMonths(i - 1).ToString("MM");
                    list.Add(customPrd);
                }
            }
            return list;
        }

        public static Int64 CreateEmployeeId()
        {
            Random rnd = new Random();
            Int64 employeeId = rnd.Next(1, 1000000);
            return employeeId;
        }
        public static Int32 CreateUserId()
        {
            Random rnd = new Random();
            Int32 userId = rnd.Next(1, 10000);
            return userId;
        }
        public static string DecodePass(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string EncodePass(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static int CreateSubscriberInstallments(DateTime installmentBeginDate)
        {
            int currentMonth = installmentBeginDate.Month;
            int months = currentMonth - 12;
            int remainingMonths = Math.Abs(months);
            int installments = remainingMonths + 12;
            return installments;
        }
        /// <summary>
        /// To calculate subscription duration...
        /// </summary>
        /// <param name="subscribeDate">Get total months</param>
        /// <returns></returns>
        public static int CalculateMembershipDuration(DateTime subscribeDate)
        {
            DateTime CurrentDate = DateTime.Now;
            int totalMonths = 12 * (CurrentDate.Year - subscribeDate.Year) + CurrentDate.Month - subscribeDate.Month;
            return totalMonths;
        }

        public static int CreateMyTransId()
        {
            Random rnd = new Random();
            int transId = rnd.Next(1, 100000);
            return transId;
        }
        public static int GenerateFileName()
        {
            Random rnd = new Random();
            int fileName = rnd.Next(1, 100000);
            return fileName;
        }
        public static byte[] GetFileFromFolder(string filePath)
        {
            byte[] result = null;
            if (filePath != null)
            {
                var file = System.IO.File.ReadAllBytes(filePath);
                result = file;
            }
            return result;
        }
        /// <summary>
        /// To get db connection string.
        /// </summary>
        /// <returns></returns>
        public static string GetDbConnection()
        {
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            var dbconnectionStr = dbconfig["ConnectionStrings:MsSqlConnection"];
            return dbconnectionStr;
        }

        public static List<T> AutoMapToObject<T>(this object a, DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            var typ = pro.PropertyType;
                            if (typ.IsGenericType && typ.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                string data = $"{row[pro.Name]}";
                                if (String.IsNullOrEmpty(data)) pro.SetValue(objT, null);
                                else pro.SetValue(objT, Convert.ChangeType(data, typ.GetGenericArguments()[0]));
                            }
                            else pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                return objT;
            }).ToList();
        }

        public static DataSet GetDataSet(string ProcNameORQuery, CommandType commandType, Hashtable ht = null, List<SqlParameter> outputParams = null)
        {
            SqlParameter[] mySqlParam = null;

            if (ht != null) mySqlParam = GetSqlParametersfromHash(ht);
            SqlConnection mycon = new SqlConnection(GetDbConnection());
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandType = commandType;
            mycmd.Connection = mycon;
            mycmd.CommandText = ProcNameORQuery;
            mycmd.CommandTimeout = 0;

            if (mySqlParam != null) mycmd.Parameters.AddRange(mySqlParam);
            if (outputParams != null) mycmd.Parameters.AddRange(outputParams.ToArray());
            if (mycon.State == ConnectionState.Closed) mycon.Open();

            SqlDataAdapter myda = new SqlDataAdapter(mycmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            if (mycon.State == ConnectionState.Open) mycon.Close();
            return myds;
        }

        public static DataTable GetDataTable(string ProcNameORQuery, CommandType commandType, Hashtable ht = null)
        {
            SqlParameter[] mySqlParam = null;

            if (ht != null)
                mySqlParam = GetSqlParametersfromHash(ht);

            DataTable mydt = new DataTable();
            SqlConnection mycon = new SqlConnection(GetDbConnection());
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandType = commandType;
            mycmd.Connection = mycon;
            mycmd.CommandText = ProcNameORQuery;
            mycmd.CommandTimeout = 0;
            if (mySqlParam != null)
                mycmd.Parameters.AddRange(mySqlParam);
            if (mycon.State == ConnectionState.Closed)
                mycon.Open();
            SqlDataAdapter myda = new SqlDataAdapter(mycmd);
            myda.Fill(mydt);
            if (mycon.State == ConnectionState.Open)
                mycon.Close();
            return mydt;
        }

        public static SqlParameter[] GetSqlParametersfromHash(Hashtable HT)
        {
            SqlParameter[] param = new SqlParameter[HT.Keys.Count];
            int index = 0;
            foreach (DictionaryEntry item in HT)
            {
                param[index] = new SqlParameter("@" + item.Key.ToString(), item.Value);
                index++;
            }

            return param;

        }

        public static string OleDBString(string FileName, string ExtensionType, string Header = "YES")
        {
            string OleDBString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0;HDR=" + Header + ";IMEX=1'";

            if (ExtensionType == ".XLS")
                OleDBString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties='Excel 8.0;HDR=" + Header + ";IMEX=1'";

            return OleDBString;
        }
        public static string GetXmlString(string[] xmlFieldNames, object[,] values, int Records)
        {
            StringBuilder xmlString = new StringBuilder();
            xmlString.AppendFormat("<{0}>", "DATA");
            for (int i = 0; i < Records; i++)
            {
                xmlString.AppendFormat("<{0}>", "ID");
                for (int j = 0; j < xmlFieldNames.Length; j++)
                {
                    string KeyName = "<" + xmlFieldNames[j] + ">{0}</" + xmlFieldNames[j] + ">";
                    xmlString.AppendFormat(KeyName, values[i, j]);
                }
                xmlString.AppendFormat("</{0}>", "ID");
            }
            xmlString.AppendFormat("</{0}>", "DATA");
            return xmlString.ToString();
        }


        public static string ConvertObjToXML(object InputString)
        {
            if (InputString != null && !string.IsNullOrEmpty(InputString.ToString()))
            {
                XmlSerializer ser = new XmlSerializer(InputString.GetType(), "http://schemas.yournamespace.com");
                string result = string.Empty;
                using (MemoryStream memStm = new MemoryStream())
                {
                    ser.Serialize(memStm, InputString);
                    memStm.Position = 0; 
                    result = new StreamReader(memStm).ReadToEnd();
                }
                System.Xml.Linq.XElement xmlDocumentWithoutNs = RemoveAllNamespaces(System.Xml.Linq.XElement.Parse(result));
                return !string.IsNullOrEmpty(xmlDocumentWithoutNs.Value) ? xmlDocumentWithoutNs.ToString() : "";
            }
            else { return ""; }
        }
        public static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;
                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute); return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements()
                .Select(el => RemoveAllNamespaces(el)));
        }

        public static string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        public static Int32 NextMonth(Int32 SalMonth)
        {
            if (SalMonth.ToString().Substring(4, 2) == "12")
                return SalMonth + 89;
            else
                return SalMonth + 1;

        }
        public static Int32 PreviousMonth(Int32 SalMonth)
        {
            if (SalMonth.ToString().Substring(4, 2) == "01")
                return SalMonth - 89;
            else
                return SalMonth - 1;

        }
    }
}