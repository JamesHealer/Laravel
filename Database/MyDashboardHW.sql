Use KUPFDb
select * from MyDashboard
exec [MyDashboardSave] '21','1','202302'
--- Find this month new subscription =1

select cOUNT(*) from TransactionHD 
 where TenentID=21 and LocationID=1 and transdate between CAST('02/01/2023' as date) and CAST('02/28/2023' as date)
   AND ServiceTypeId=1 AND ServiceSubTypeId IN (1,2)
--- Find this month new Transactions as table =2
select count(*) as TotEmployee
  FROM DetailedEmployee A
 where A.TenentID=21 and A.LocationID=1 
   and (A.PFID is not null or A.PFID != '')
   and (A.termination_id IS NULL or  A.TerminationDate IS NULL)
UPDATE DetailedEmployee SET termination_id = NULL WHERE TerminationDate IS NULL
select TenentID,PFID,termination_id,TerminationDate FROM DetailedEmployee A
--- Find this month new Transactions as table =3
   select MyCountFound=count(*)
	  FROM TransactionHD B, DetailedEmployee C,ServiceSetup A
	 where A.TenentID=21 and A.ServiceType = B.ServiceTypeId and A.ServiceSubType = B.ServiceSubTypeId
	   AND B.TenentID=21 and B.LocationID=1 
	   and C.TenentID=21 and C.LocationID=1 and C.employeeID = B.employeeID
	   and B.PeriodBegin= 202302


select B.MyTransID,A.ServiceShortName,A.ServiceName2, 
       RTRIM(CAST(B.EmployeeId AS VARCHAR))+'-'+RTRIM(C.EnglishName) +'-'+ RTRIM(C.ArabicName,1) AS NAME, 
	   B.PeriodBegin,B.EachInstallmentsAmt
  FROM TransactionHD B, DetailedEmployee C,ServiceSetup A
 where B.TenentID=21 and B.LocationID=1 
   and A.TenentID=21 
   and A.ServiceType = B.ServiceTypeId 
   and A.ServiceSubType = B.ServiceSubTypeId
   and C.TenentID=21 and C.LocationID=1 and C.employeeID  = B.employeeID
   and B.PeriodBegin= 202302




select * from TransactionHD
SELECT DISTINCT EMPLOYEEID FROM DetailedEmployee