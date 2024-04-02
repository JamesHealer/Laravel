USE [KUPFDb]
GO
/****** Object:  StoredProcedure [dbo].[MyDashboardSave]    Script Date: 18-02-2023 01:46:06 ******/
--- Typical Call is EXEC [MyDashboardSave] 21,1,202302
--- select * from MyDashboard  WHERE TenentID=21 and LocationID=1   
--- Find this month new subscription =1
--- Find Subscribed Total ACTIVE Subscribed Employee #2
--- Find this month new Transactions as table =3 provide the Date & Time and job Completed by
--- #4 Find the Approval Status of this month by drop down of the Approval by
--- #5 Employee Performance by Employee ID and Week of this Month , Last Month
--- 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[MyDashboardSave]
(
	 @TenentID                                int = 21
	,@LocationId                              int = 1
	,@CurrentPeriod                           BIGINT = 202302
)
AS
BEGIN  -- Main Begin
	DECLARE
		 @CP_Period                               BIGINT 
		,@CP_Begin                                Date
		,@CP_End                                  date
		,@PrevPeriod                              int
		,@PR_Begin                                Date
		,@PR_End                                  date
		,@NextPeriod                              int
		,@NT_Begin                                Date
		,@NT_End                                  date
		,@MyDateHW                                date
		,@MyEmployeeIdT                           int=0
		,@MyEmpNameT                              nvarchar(150)
		,@MyPeriodCodeT                           int
		,@MyTransIdT                              Bigint=0
		,@MainTypeT								  nvarchar(100)
		,@SubType1T								  nvarchar(100)
		,@AsOfDateT								  date
		,@MyMaxNow                                int=0
		,@MyMainSessionSeq                        int=0
		,@MyCountFound                            int=0
		,@MyRunCount                              int=0
		,@ClickMeT								  nvarchar(50)
		,@Action                                  VARCHAR(50)
		,@Label1								  VARCHAR(50)
		,@Value1								  decimal(18,2)=1.00
		,@Label2								  VARCHAR(50)
		,@Value2								  decimal(18,2)=1.00
		--,@Remarks                               nvarchar(1000)
BEGIN  ---Begin after Declare
	SELECT @MyMainSessionSeq=MAX(ISNULL(MainSessionSeq,0))+1 FROM MyDashboard WHERE TenentID=@TenentID and LocationID=@LocationId 
    SET @CP_Period=@CurrentPeriod;
	SELECT  @CP_Begin=PRD_START_DATE, @CP_End=PRD_END_DATE,@PR_Begin=PRD_START_DATE-1, @NT_End=PRD_END_DATE+1
	 FROM TBLPERIODS WHERE TenentID= @TenentID and PERIOD_CODE=@CP_Period

	SELECT @PrevPeriod=PERIOD_CODE, @PR_Begin=PRD_START_DATE, @PR_End=PRD_END_DATE,@PR_Begin=PRD_START_DATE-1, @NT_End=PRD_END_DATE+1
	 FROM TBLPERIODS WHERE TenentID= @TenentID and @PR_Begin BETWEEN PRD_START_DATE AND PRD_END_DATE

	SELECT @NextPeriod=PERIOD_CODE, @NT_Begin=PRD_START_DATE, @NT_End=PRD_END_DATE,@PR_Begin=PRD_START_DATE-1, @NT_End=PRD_END_DATE+1
	 FROM TBLPERIODS WHERE TenentID= @TenentID and @NT_End BETWEEN PRD_START_DATE AND PRD_END_DATE

--- Find this month new subscription =1
    select @MyCountFound=COUNT(*) from TransactionHD 
	 where TenentID=@TenentID and LocationID=@LocationId 
	   and transdate between @CP_Begin and @CP_End AND ServiceTypeId=1 AND ServiceSubTypeId IN (1,2)
	SET @MyMaxNow=1;
    print 'NewSubThisMonth 1='+CAST(@MyCountFound AS VARCHAR)
    IF @MyCountFound>0
		INSERT INTO MyDashboard
			(
				 MainSessionSeq
				,TenentID
				,locationID
				,AsOfDate
				,MainType
				,SubType1
				,MySeq
				,MyLabel1
				,MyValue1
				,MyLabel2
				,MyValue2
				,MyPeriodCode
			)
			VALUES
			(    @MyMainSessionSeq
				,@TenentID
				,@locationID
				,GETDATE()
				,@MyCountFound
				,''
				,@MyMaxNow
				,'NewSubThisMonth'
				,@MyCountFound
				,@CP_Period
				,'NewSubThisMonth'
				,@CP_Period
			)
--- Find Subscribed Total ACTIVE Subscribed Employee #2
	SET @MyMaxNow=2;
	select @MyCountFound = count(*) 
	  FROM DetailedEmployee A
	 where A.TenentID=21 and A.LocationID=1 
	   and (A.PFID is not null or A.PFID != '')	
       and (A.termination_id IS NULL or A.TerminationDate IS NULL)
       print 'SubscribedEmpl 2='+CAST(@MyCountFound AS VARCHAR)
     IF @MyCountFound>0
        INSERT INTO MyDashboard
		(	 MainSessionSeq,TenentID
			,locationID
			,AsOfDate
			,MainType
			,SubType1
			,MySeq
			,MyLabel1
			,MyValue1
			,MyPeriodCode
		)
		VALUES
		(	 @MyMainSessionSeq,@TenentID
			,@locationID
			,GETDATE()
			,@MyCountFound
			,''
			,@MyMaxNow
			,'SubscribedEmpl'
			,@MyCountFound
			,@CurrentPeriod
		)
---	   raiserror('this is a raised error', 18, 1)
--- Find this month new Transactions as table =3
    SET @MyCountFound=1;
	SET @MyMaxNow=3;
    select @MyCountFound=count(*)
	  FROM TransactionHD B
	 where B.TenentID=@TenentID and B.LocationID=@LocationId and B.PeriodBegin<= @CurrentPeriod
     print 'ThisMonthTotTrans 3='+CAST(@MyCountFound AS VARCHAR)
    IF @MyCountFound>0
		Begin ---ThisMonthTotTrans 3 Begin
			print 'ThisMonthTotTrans 3='++CAST(@MyCountFound AS VARCHAR)+' Trans='++CAST(@MyTransIdT AS VARCHAR)
  			insert into MyDashboard 
			   ( MainSessionSeq
				,TenentID
				,locationID  
				,TransId 
				,MyEmployeeId 
				,MyEmpName  
				,AsOfDate  
				,MainType  
				,SubType1  
				,MyPeriodCode 
				,MySeq  
				,MyLabel1  
				,MyValue1 
				,MyLabel2 
				,MyValue2 )	 
		SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  B.MyTransID) MainSessionSeq
		        ,B.TenentID
				,B.LocationID
				,B.MyTransID
				,B.EmployeeId
				,RTRIM(CAST(B.EmployeeId AS VARCHAR))+'-'+RTRIM(C.EnglishName) +'-'+ RTRIM(C.ArabicName) MyEmpName
				,GETDATE() AsOfDate
				,A.ServiceShortName MainType
				,B.PeriodBegin SubType1
				,B.PeriodBegin MyPeriodCode
				,3 as MySeq
				,'TransMonth' MyLabel1
				,B.EachInstallmentsAmt MyValue1
				,'TransMonth' MyLabel2
				,B.EachInstallmentsAmt MyValue2
						-- ,A.ServiceShortName, A.ServiceName2,
		   	FROM TransactionHD B
			inner join DetailedEmployee C  on C.TenentID=B.TenentID and c.employeeID=B.employeeID
			inner join ServiceSetup A  on A.TenentID=B.TenentID and a.ServiceType=b.ServiceTypeId and a.ServiceSubType=b.ServiceSubTypeId
		    WHERE A.ServiceType = B.ServiceTypeId and A.ServiceSubType = B.ServiceSubTypeId
			  and C.LocationID=B.LocationID and C.employeeID = B.employeeID
			  and B.PeriodBegin<= @CurrentPeriod
		--END  -- End of Do While This Month Transactions
       END---ThisMonthTotTrans 3 Begin
--- #4 Find the Approval Status of this month by drop down of the Approval by
    SET @MyCountFound=0;
	SET @MyMaxNow=4;
    select @MyCountFound=count(*)
	  FROM TransactionHDDApprovalDetails B
	 where B.TenentID=@TenentID and B.LocationID=@LocationId and B.DisplayPERIOD_CODE<= @CurrentPeriod
     print 'ThisMonthTotApproval 4='+CAST(@MyCountFound AS VARCHAR)
    IF @MyCountFound>0
		Begin ---ThisMonthTotApproval 4 Begin
			print 'ThisMonthTotAproval 4='++CAST(@MyCountFound AS VARCHAR)+' Trans='++CAST(@MyTransIdT AS VARCHAR)
  			insert into MyDashboard 
			   ( MainSessionSeq
				,TenentID
				,locationID  
				,TransId 
				,MyEmployeeId 
				,MyEmpName  
				,AsOfDate  
				,MainType  
				,SubType1  
				,MyPeriodCode 
				,MySeq  
				,MyLabel1  
				,MyValue1 
				,MyLabel2 
				,MyValue2 )	 
		SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  B.MyTransID) MainSessionSeq
		        ,B.TenentID
				,B.LocationID
				,B.MyTransID
				,B.EmployeeId
				,RTRIM(CAST(B.EmployeeId AS VARCHAR))+'-'+RTRIM(C.EnglishName) +'-'+ RTRIM(C.ArabicName) MyEmpName
				,GETDATE() AsOfDate
				,D.ServiceShortName MainType
				,B.PeriodBegin SubType1
				,B.PeriodBegin MyPeriodCode
				,4 as MySeq
				,'Role= '+E.SHORTNAME MyLabel1
				,E.REFID MyValue1
				,'Status / Remarks='+A.Status+' - '+A.ApprovalRemarks MyLabel2
				,B.EachInstallmentsAmt MyValue2
		   	FROM TransactionHDDApprovalDetails A 
			inner join TransactionHD    B on B.TenentID=B.TenentID 
			inner join DetailedEmployee C on C.TenentID=B.TenentID and c.employeeID=B.employeeID
			inner join ServiceSetup     D on D.TenentID=B.TenentID and D.ServiceType=b.ServiceTypeId and D.ServiceSubType=b.ServiceSubTypeId
			inner join REFTABLE         E on E.TenentID=B.TenentID and E.REFTYPE='KUPF' and E.REFSUBTYPE='ROLE'
		    WHERE A.TenentID = @TenentID and  A.LocationID =@LocationId
			  AND D.ServiceType = B.ServiceTypeId and D.ServiceSubType = B.ServiceSubTypeId
			  and C.LocationID=B.LocationID and C.employeeID = B.employeeID
			  AND C.LocationID = A.LocationID
			  AND E.REFID = A.SerApproval
			  and B.PeriodBegin<= @CurrentPeriod
       END---ThisMonthTotTrans 4 Begin
--- #5 Find the Employee Done Job in the System
--- #5.1 IN DetailedEmployee JOB DONE
       SET @MyCountFound=0;
       SET @MyMaxNow=51;
       insert into MyDashboard 
			   ( MainSessionSeq
				,TenentID
				,locationID  
				,TransId 
				,MyEmployeeId 
				,MyEmpName  
				,AsOfDate  
				,MainType  
				,SubType1  
				,MyPeriodCode 
				,MySeq  
				,MyLabel1  
				,MyValue1 
				,MyLabel2 
				,MyValue2 )	 
			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,A.LocationID
				,Count(*)
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,@CurrentPeriod
				,51 as MySeq
				,' Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,' Employees='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM DetailedEmployee  A , USER_MST B
		    WHERE A.TenentID = @TenentID and  A.LocationID =@LocationId
			  AND B.TenentID = @TenentID and  B.LOCATION_ID =@LocationId
			  AND B.LOGIN_ID = A.userID
			  AND A.datetime BETWEEN @CP_Begin AND  @CP_End
			Group by A.TenentID,A.LocationID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
 --- #5.2 IN TransactionHD JOB DONE
      SET @MyCountFound=0;
       SET @MyMaxNow=52;
       insert into MyDashboard 
			   ( MainSessionSeq
				,TenentID
				,locationID  
				,TransId 
				,MyEmployeeId 
				,MyEmpName  
				,AsOfDate  
				,MainType  
				,SubType1  
				,MyPeriodCode 
				,MySeq  
				,MyLabel1  
				,MyValue1 
				,MyLabel2 
				,MyValue2 )	 
			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,A.LocationID
				,Count(*)
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,@CurrentPeriod
				,52 as MySeq
				,' Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of HD Trans='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM TransactionHD  A , USER_MST B
		    WHERE A.TenentID = @TenentID and  A.LocationID =@LocationId
			  AND B.TenentID = @TenentID and  B.LOCATION_ID =@LocationId
			  AND B.LOGIN_ID = A.USERID
			  and A.ENTRYDATE BETWEEN @CP_Begin AND  @CP_End
			Group by A.TenentID,A.LocationID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
  --- #5.3 IN TransactionDT JOB DONE
      SET @MyCountFound=0;
       SET @MyMaxNow=53;
       insert into MyDashboard 
			   ( MainSessionSeq
				,TenentID
				,locationID  
				,TransId 
				,MyEmployeeId 
				,MyEmpName  
				,AsOfDate  
				,MainType  
				,SubType1  
				,MyPeriodCode 
				,MySeq  
				,MyLabel1  
				,MyValue1 
				,MyLabel2 
				,MyValue2 )	 
			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,A.LocationID
				,Count(*) JobDone
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,@CurrentPeriod
				,53 as MySeq
				,' Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Detail Trans='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM TransactionDT  A , USER_MST B
		    WHERE A.TenentID = @TenentID and  A.LocationID =@LocationId
			  AND B.TenentID = @TenentID and  B.LOCATION_ID =@LocationId
			  AND B.LOGIN_ID = A.USERID                       --- are missing in the table
			  AND A.ENTRYDATE BETWEEN @CP_Begin AND  @CP_End  --- are missing in the table
			Group by A.TenentID,A.LocationID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
--- #5.4 IN TransactionHDDApprovalDetails JOB DONE
      SET @MyCountFound=0;
       SET @MyMaxNow=54;
       insert into MyDashboard 
			   ( MainSessionSeq
				,TenentID
				,locationID  
				,TransId 
				,MyEmployeeId 
				,MyEmpName  
				,AsOfDate  
				,MainType  
				,SubType1  
				,MyPeriodCode 
				,MySeq  
				,MyLabel1  
				,MyValue1 
				,MyLabel2 
				,MyValue2 )	 
			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,A.LocationID
				,Count(*)
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,@CurrentPeriod
				,54 as MySeq
				,' Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Approval='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM TransactionHDDApprovalDetails  A , USER_MST B
		    WHERE A.TenentID = @TenentID and  A.LocationID =@LocationId
			  AND B.TenentID = @TenentID and  B.LOCATION_ID =@LocationId
			  AND B.LOGIN_ID = A.USERID                       --- are missing in the table
			  AND A.ENTRYDATE BETWEEN @CP_Begin AND  @CP_End  --- are missing in the table
			Group by A.TenentID,A.LocationID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
--- #5.5 IN REFTABLE JOB DONE
      SET @MyCountFound=0;
       SET @MyMaxNow=55;
       insert into MyDashboard 
			   ( MainSessionSeq
				,TenentID
				,locationID  
				,TransId 
				,MyEmployeeId 
				,MyEmpName  
				,AsOfDate  
				,MainType  
				,SubType1  
				,MyPeriodCode 
				,MySeq  
				,MyLabel1  
				,MyValue1 
				,MyLabel2 
				,MyValue2 )	 
			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,B.Location_ID
				,Count(*) JobDone
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,@CurrentPeriod
				,55 as MySeq
				,' Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Trans Reference='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM REFTABLE  A , USER_MST B
		    WHERE A.TenentID = @TenentID
			  AND B.TenentID = @TenentID and  B.LOCATION_ID =@LocationId
			  AND B.LOGIN_ID = A.Uploadby
			  AND A.UploadDate BETWEEN @CP_Begin AND  @CP_End
			Group by A.TenentID,B.Location_ID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME
--- #5.6 IN LettersHD JOB DONE
      SET @MyCountFound=0;
       SET @MyMaxNow=56;
       insert into MyDashboard 
			   ( MainSessionSeq
				,TenentID
				,locationID  
				,TransId 
				,MyEmployeeId 
				,MyEmpName  
				,AsOfDate  
				,MainType  
				,SubType1  
				,MyPeriodCode 
				,MySeq  
				,MyLabel1  
				,MyValue1 
				,MyLabel2 
				,MyValue2 )	 
			SELECT  (select max(myid) from MyDashboard)+row_number() over(order by  A.TenentID) MainSessionSeq
		        ,A.TenentID
				,B.Location_ID
				,Count(*) JobDone
				,B.LOGIN_ID
				,RTRIM(CAST(B.LOGIN_ID AS VARCHAR))+'-'+RTRIM(B.FIRST_NAME) +'-'+ RTRIM(B.LAST_NAME) MyEmpName
				,GETDATE() AsOfDate
				,0 MainType
				,0 SubType1
				,@CurrentPeriod
				,56 as MySeq
				,' Employee ID= '+B.LOGIN_ID MyLabel1
				,B.LOGIN_ID MyValue1
				,'Number of Trans in Letters ='+CAST(count(*) AS char(8)) MyLabel2
				,0 MyValue2
		   	FROM LettersHD  A , USER_MST B
		    WHERE A.TenentID = @TenentID
			  AND B.TenentID = @TenentID and  B.LOCATION_ID =@LocationId
			  AND B.LOGIN_ID = A.USERID
			  AND A.ENTRYDATE BETWEEN @CP_Begin AND  @CP_End
			Group by A.TenentID,B.Location_ID,b.LOGIN_ID,B.FIRST_NAME,B.LAST_NAME

  END ---Begin after Declare
END ---Main Begin
RETURN
--BEGIN CATCH

--	THROW;

--END CATCH
