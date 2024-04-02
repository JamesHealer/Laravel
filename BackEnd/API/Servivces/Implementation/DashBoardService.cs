using API.Common;
using API.DTOs;
using API.Helpers;
using API.Models;
using API.Servivces.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace API.Servivces.Implementation
{
    public class DashBoardService : IDashBoardService
    {
        public async Task<DashBoardModel>  GetDashBoardData(int tenentId)
        {
            try
            {
                var data = new DashBoardModel();
                Hashtable hashTable = new Hashtable();
                hashTable.Add("tenentId", tenentId);
                DataSet objDataset = CommonMethods.GetDataSet("[dbo].[spGetDashBoardDetails]", CommandType.StoredProcedure, hashTable);
                data.newMembersDashBoardModel = this.AutoMapToObject<NewMembersDashBoardModel>(objDataset.Tables[0]);
                data.membersStatisticsDashBoardModel = this.AutoMapToObject<NewMembersDashBoardModel>(objDataset.Tables[1]);
                data.latestSubscriberDashBoardModel = this.AutoMapToObject<NewMembersDashBoardModel>(objDataset.Tables[2]);
                data.newSubscriberDashBoardModel = this.AutoMapToObject<NewSubscriberDashBoardModel>(objDataset.Tables[3]);
                data.toDoDashBoardModels = this.AutoMapToObject<ToDoDashBoardModel>(objDataset.Tables[4]);
                data.employeePerformanceDashBoardModel = this.AutoMapToObject<EmployeePerformanceDashBoardModel>(objDataset.Tables[5]);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
