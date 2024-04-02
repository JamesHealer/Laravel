USE KUPFDb
EXEC [MyDashboardSave] 21,1,202302
delete from myDashboard 
select * from myDashboard  order by asofdate desc
select * from DetailedEmployee where employeeID=3
select * from DetailedEmployee where MemberOfFund is null
select * from REFTABLE where reftype='KUPF' order by 4
select ISNULL(max(serviceID),0)+1 from TransactionHD 
--update ServiceSetup set DiscountType=1 where DiscountType is null 
---select * from reftable where reftype='KUPF' AND REFSUBTYPE ='EMPSTATUS' --TO KNOW THE EMPSTATUS FROM REFTABLE
select count(*) from DetailedEmployee where empstatus=1  ---Subscribed Employee\
---select count(*) from DetailedEmployee where empstatus=2  ---NOT SUBSCRIBED Employee\
select count(*) from DetailedEmployee where subscription_date is null  ---Settlement In Progress Employee\
select count(*) from DetailedEmployee where empstatus=9  ---Subscribed Employee\
select count(*) from DetailedEmployee where empstatus=10  ---Final Settlement Done Employee\


---update [TransactionHDDApprovalDetails] set DisplayPeriod_Code= '202302' where DisplayPeriod_Code<= '20230214'
select * from TransactionHDDApprovalDetails A where A.DisplayPeriod_Code<= '202302'

select count(*) from TransactionHD where  PeriodBegin<= '202302' ---100 / 8 =12.5
		SELECT  DISTINCT 
		         A.TenentID
				,A.LocationID
				,count(*) as SerCount ---B.MyTransID
				,(count(*)  / 8) as SerPerc ---B.EmployeeId
				,RTRIM(CAST(A.ServiceType AS VARCHAR))+'-'+RTRIM(A.ServiceSubType)  MyEmpName
				,GETDATE() AsOfDate
				,A.ServiceType MainType
				,0 SubType1
				,A.PeriodBegin MyPeriodCode
				,41 as MySeq
				,'Trans= '+CAST(count(*) AS NVARCHAR) MyLabel1
				,0 MyValue1
				,'Perc='+CAST(count(*) * 12.5  AS NVARCHAR) MyLabel2
				,0 MyValue2
		   	FROM TransactionHD A 
		    WHERE A.TenentID = 21 and  A.LocationID =1
			  and A.PeriodBegin<= '202302'
			Group by A.TenentID,A.LocationID,A.ServiceType,A.ServiceSubType,A.PeriodBegin


--- #5 Employee Performance by Employee ID and Week of this Month , Last Month
---5.1 DetailedEmployee
		SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,A.LocationID
				,Count(*)
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,0 MyPeriodCode
				,5 as MySeq
				,'Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Trans='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
						-- ,A.ServiceShortName, A.ServiceName2,
		   	FROM DetailedEmployee  A , USER_MST B
		    WHERE A.TenentID = 21 and  A.LocationID =1
			  AND B.TenentID = 21 and  B.LOCATION_ID =1
			  AND B.LOGIN_ID = A.userID
			  and A.datetime <='01/01/2023'
			Group by A.TenentID,A.LocationID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
--- 5.2 TransactionHD
			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,A.LocationID
				,Count(*)
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,0 MyPeriodCode
				,5 as MySeq
				,'Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Trans='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM TransactionHD  A , USER_MST B
		    WHERE A.TenentID = 21 and  A.LocationID =1
			  AND B.TenentID = 21 and  B.LOCATION_ID =1
			  AND B.LOGIN_ID = A.USERID
			  and A.ENTRYDATE <='01/01/2023'
			Group by A.TenentID,A.LocationID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
--- 5.3 TransactionDT
--update TransactionDT set USERID='prog1' , ENTRYDATE=getdate()

			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,A.LocationID
				,Count(*) JobDone
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,0 MyPeriodCode
				,5 as MySeq
				,'Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Trans='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM TransactionDT  A , USER_MST B
		    WHERE A.TenentID = 21 and  A.LocationID =1
			  AND B.TenentID = 21 and  B.LOCATION_ID =1
			  AND B.LOGIN_ID = A.USERID
			  and A.ENTRYDATE <='01/01/2024'
			Group by A.TenentID,A.LocationID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
--- 5.4 TransactionHDDApprovalDetails
			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,A.LocationID
				,Count(*) TotalJobs
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,0 MyPeriodCode
				,5 as MySeq
				,'Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Trans='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM TransactionHDDApprovalDetails  A , USER_MST B
		    WHERE A.TenentID = 21 and  A.LocationID =1
			  AND B.TenentID = 21 and  B.LOCATION_ID =1
			  AND B.LOGIN_ID = A.USERID
			  and A.ENTRYDATE <='01/01/2024'
			Group by A.TenentID,A.LocationID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
--- #5.5 IN REFTABLE JOB DONE
select * from reftable
update reftable set uploadby='prog1', uploaddate=getdate()
         SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,B.Location_ID
				,Count(*) JobDone
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,0 MyPeriodCode
				,5 as MySeq
				,'Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Trans='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM REFTABLE  A , USER_MST B
		    WHERE A.TenentID = 21 
			  AND B.TenentID = 21 and  B.LOCATION_ID =1
			  AND B.LOGIN_ID = A.Uploadby                       --- are missing in the table
			  AND A.UploadDate  <='01/01/2024'  --- are missing in the table
			Group by A.TenentID,B.Location_ID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
--- #5.6 IN REFTABLE JOB DONE
select * from reftable
update reftable set uploadby='prog1', uploaddate=getdate()
         SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,B.Location_ID
				,Count(*) JobDone
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,0 MyPeriodCode
				,5 as MySeq
				,'Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Trans='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM LettersHD  A , USER_MST B
		    WHERE A.TenentID = 21 
			  AND B.TenentID = 21 and  B.LOCATION_ID =1
			  AND B.LOGIN_ID = A.USERID                       --- are missing in the table
			  AND A.ENTRYDATE  <='01/01/2024'  --- are missing in the table
			Group by A.TenentID,B.Location_ID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME


update TransactionHD set userID='prog1'
select count(*)  from TransactionHD where userID='prog1' and ENTRYDATE <='01/01/2025'
			  
			  
			  --AND D.ServiceType = B.ServiceTypeId and D.ServiceSubType = B.ServiceSubTypeId
			  --and C.LocationID=B.LocationID and C.employeeID = B.employeeID
			  --AND C.LocationID = A.LocationID
			  --AND E.REFID = A.SerApproval
			  --and B.PeriodBegin<= '202302'
SELECT      c.name  AS 'ColumnName'
            ,t.name AS 'TableName'
FROM        sys.columns c
JOIN        sys.tables  t   ON c.object_id = t.object_id
WHERE       c.name LIKE '%user%'
ORDER BY    TableName
            ,ColumnName;
update DetailedEmployee set userID='prog1' where userID is NULL
update TransactionHDDApprovalDetails set DisplayPERIOD_CODE=202302 where DisplayPERIOD_CODE=20230214
select count(*) from  CRUPAudit Where UserId='prog1' 
select count(*) from  DetailedEmployee Where userID='prog1' 
select count(*)  from DetailedEmployee where userID='prog1' and datetime <='01/01/2023'
---select count(*) from  DetailedEmployee_Import Where userID='prog1' 
select count(*) from  FUNCTION_USER Where USER_ID='prog1' 
select count(*) from  FUNCTION_USER Where USER_TYPE='prog1' 
select count(*) from  LettersHD Where USERID='prog1' 
select count(*) from  Location Where UserID='prog1' 
select count(*) from  MYCOMPANYSETUP Where USERID='prog1' 
select count(*) from  RefTableAdmin Where NormalUser='prog1' 
select count(*) from  ServiceSetup Where SerIDByUser='prog1' 
select count(*) from  ServiceSetup Where USERID='prog1' 
select count(*) from  tblAudit Where CreatedUserName='prog1' 
select count(*) from  tblAudit Where UpdateUserName='prog1' 
select count(*) from  TBLCOMPANYSETUP Where CUSERID='prog1' 
select count(*) from  TBLCOMPANYSETUP Where USERID='prog1' 
select count(*) from  TBLCONTACT_DEL_ADRES Where CUSERID='prog1' 
select count(*) from  tblImportCOA Where UserID='prog1' 
select count(*) from  tblImportCOAV2 Where UserID='prog1' 
select count(*) from  tblImportVoucher Where UserID='prog1' 
select count(*) from  TransactionHD Where USERBATCHNO='prog1' 
select count(*) from  TransactionHD Where UserDefinedNumber='prog1' 
select count(*) from  TransactionHD Where USERID='prog1' 
select count(*) from  TransactionHDDApprovalDetails Where USERID='prog1' 
select count(*) from  University Where UnivIDByUser='prog1' 
select count(*) from  University Where USERID='prog1' 
select count(*) from  USER_DTL Where USER_DETAIL_ID='prog1' 
select count(*) from  USER_MST Where ACTIVEUSER='prog1' 
select count(*) from  USER_MST Where USER_DETAIL_ID='prog1' 
select count(*) from  USER_MST Where USER_ID='prog1' 
select count(*) from  USER_MST Where USER_TYPE='prog1' 
select count(*) from  USER_MST Where USERDATE='prog1' 
select count(*) from  UserPages Where User_ID='prog1' 
select count(*) from  UserPages Where UserWebPageID='prog1' 
select count(*) from  Users Where UserID='prog1' 
select count(*) from  Users Where UserName='prog1' 
select count(*) from  VoucherDetail_History Where User_ID='prog1' 

